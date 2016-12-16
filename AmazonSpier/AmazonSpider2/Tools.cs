using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;
using System.Net;

namespace 通过详情页抓取数据
{
    class Tools
    {

        //获取网页文本
        public static StreamReader Get_Http(string tUrl)
        {
            HttpWebRequest hwr;
            try
            {
                hwr = (HttpWebRequest)HttpWebRequest.Create(tUrl);
            }
            catch (System.Exception ex)
            {
                return null;
            }
            
            hwr.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.15 Safari/537.36";
            hwr.Accept = "*/*";
 
            hwr.Timeout = 10000;
            try
            {
                HttpWebResponse hwrs = (HttpWebResponse)hwr.GetResponse();
                Stream myStream = hwrs.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                return sr;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        //从详情页里拿出数据******************************************
        public static int getSinglePage(String url, StreamWriter sw)
        {
            HtmlAgilityPack.HtmlWeb htmlweb = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            StreamReader sr=Get_Http(url);
            //网页没抓到东西，则返回0;
            if (sr == null)
                return 0;

            doc.Load(sr);
            //doc没有load成功，则返回0;
            if (doc == null)
                return 0;

            HtmlAgilityPack.HtmlNode allnode = doc.DocumentNode;

            string data_name = getInner(allnode, "span", "id", "productTitle");
            string data_seller = getInner(allnode, "a", "id", "brand");
            string data_price = getPrice(allnode);
            string data_stars = getStar(allnode);
            string data_reviews = getInner(allnode, "span", "id", "acrCustomerReviewText");
            string data_old = getInner(allnode, "span", "class", "olp-padding-right");
            string data_asin = getAsin(url);
            string data_sellerrank = getSellerRank(allnode);
            string data_date = getDate(allnode);
            string data_utime = getUtime();


            sw.WriteLine(
                data_name + "\t" +
                data_seller + "\t" +
                data_price + "\t" +
                data_stars + "\t" +
                data_reviews + "\t" +
                data_old + "\t" +
                data_asin + "\t" +
                data_sellerrank + "\t" +
                data_date + "\t" +
                data_utime);
            sw.Flush();
            return 1;
        }
        //封装之后的通过xpath找到innerhtml方法 OK
        private static string getInner(HtmlNode node, string type, string key, string value)
        {
            HtmlNode anode = node.SelectSingleNode("//" + type + "[@" + key + "='" + value + "']");
            if (anode == null)
                return "null";
            else
                return anode.InnerText.Trim();

        }
        //获取价格
        public static string getPrice(HtmlNode node)
        {
            string ret=getInner(node, "span", "id", "priceblock_ourprice");
            if(ret=="null")
                ret = getInner(node, "span", "id", "priceblock_saleprice");
            return ret;
        }
        //拿到星星数 OK
        public static string getStar(HtmlNode node)
        {
            //first class page:
            string ret = "null";
            try
            {
                ret = node.SelectSingleNode("//div[@id='avgRating']").InnerText.Trim();
                return ret;
            }
            catch (System.Exception ex)
            {
                ret = "null";
            }
            //second:

            try
            {
                ret = node.SelectSingleNode("//div[@id='averageCustomerReviewRating']").InnerText.Trim();
                return ret;
            }
            catch (System.Exception ex)
            {
                ret = "null";
            }
            return ret;


        }
        //拿到ASIN not 不用了 直接从url里拿
        public static string getAsin(HtmlNode node)
        {
            string ret = "null";
            //first try
        FIRST:
            HtmlNode big_node = node.SelectSingleNode("//div[@id='detail-bullets']");
            if (big_node == null)
                goto SECOND;
            else
            {
                string inner = big_node.InnerHtml;
                string[] inner_spi = inner.Split(new string[1]{"<b>ASIN: </b>"},StringSplitOptions.RemoveEmptyEntries);
                if (inner_spi.Length < 2)
                    goto SECOND;
                else
                {
                    string[] inner_spi_spi = inner_spi[1].Split(new string[1] { "</li>" }, StringSplitOptions.RemoveEmptyEntries);
                    if (inner_spi_spi.Length < 1)
                        goto SECOND;
                    else
                        return inner_spi_spi[0];
                }
            }

        SECOND:
            HtmlNode father_node = node.SelectSingleNode("//tr[@class='average_customer_reviews']").ParentNode;
           // return father_node.InnerText;
            HtmlNode that_node = father_node.SelectSingleNode("td[@class='value']");
            return that_node.InnerText;///TODO
        }
        //拿到ASIN from url OK
        public static string getAsin(string url)
        {
            string ret = "null";
            try
            {
                ret = url.Split(new string[2] { "/dp/", "/ref=" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }
            catch (System.Exception ex)
            {
                ret = null;
            }
            return ret;
        }
        //拿到sellerrank
        public static string getSellerRank(HtmlNode node)
        {
            string ret = "null";
        //first try
        FIRST:
            try
            {
                ret = node.SelectSingleNode("//li[@id='SalesRank']").InnerText;
                return ret.Replace("\n","").Trim();
            }
            catch (System.Exception ex)
            {
                ret = "null";
            }



        SECOND_RANK:
            try
            {
                ret = node.SelectSingleNode("//tr[@id='SalesRank']").SelectSingleNode("td[@class='value']").InnerText;
                return ret.Replace("\n", "").Trim() ;
            }
            catch (System.Exception ex)
            {
                ret = "null";
            }
            return ret;
        }
        //拿到时间 OK
        public static string getDate(HtmlNode node)
        {
            string ret = "null";
        //first try
        FIRST:
            HtmlNode big_node = node.SelectSingleNode("//div[@id='detail-bullets']");
            if (big_node == null)
                goto SECOND_DATE;
            else
            {
                string inner = big_node.InnerHtml;
                string[] inner_spi = inner.Split(new string[1] { "<li><b> Date first available at Amazon.com:</b> " }, StringSplitOptions.RemoveEmptyEntries);
                if (inner_spi.Length < 2)
                    goto SECOND_DATE;
                else
                {
                    string[] inner_spi_spi = inner_spi[1].Split(new string[1] { "</li>" }, StringSplitOptions.RemoveEmptyEntries);
                    if (inner_spi_spi.Length < 1)
                        goto SECOND_DATE;
                    else
                        return inner_spi_spi[0].Trim();
                }
            }

        SECOND_DATE:
            try
            {
                ret = node.SelectSingleNode("//tr[@class='date-first-available']").SelectSingleNode("td[@class='value']").InnerText;
                return ret.Trim();
            }
            catch (System.Exception ex)
            {
                return "null";
            }
        }
        //获取当前时间 OK
        public static string getUtime()
        {
            DateTime dt = DateTime.Now;
            return dt.ToLocalTime().ToString();
        }
   
    }
}
