using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;

namespace 通过列表页抓取详情页url
{
    class ToolsFirst
    {
        //抓取页面并加入listview
        public static String addHtmlToList(String url, StreamWriter sw, bool ifnext)
        {

            //新建doc对象
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //通过网页内容导入
            doc.Load(Get_Http(url));
            //为null退出
            if (doc == null)
            {
                MessageBox.Show("url error!");
                return null;
            }
            //转化为一个根node
            HtmlAgilityPack.HtmlNode allnode = doc.DocumentNode;
            //遍历node，取出东西
            sw.WriteLine("======Page Begin=======");

            //处理第一种普通情况
            while (true)
            {
                HtmlAgilityPack.HtmlNode anode = allnode.SelectSingleNode("//a[@class='a-link-normal s-access-detail-page  a-text-normal']");
                if (null == anode)
                    break;
                String a_url = anode.GetAttributeValue("href", "");

                //如果这个url以http开头，则ok，否则不搞
                if (a_url.StartsWith("http") == true)
                {
                    sw.WriteLine(a_url);
                }

                anode.Remove();
            }

            //处理第二种情况，常见于第一页中
            while (true)
            {
                HtmlAgilityPack.HtmlNode anode = allnode.SelectSingleNode("//h3[@class='newaps']");
                if (null == anode)
                    break;

                HtmlAgilityPack.HtmlNode bnode = anode.SelectSingleNode("a[@href]");
                if (null == bnode)
                    continue;

                String a_url = bnode.GetAttributeValue("href", "");

                //如果这个url以http开头，则ok，否则不搞
                if (a_url.StartsWith("http") == true)
                {
                    sw.WriteLine(a_url);
                }

                anode.Remove();
            }








            //第一类url，不继续了
            if (ifnext == false)
                return null;

            //看看是否有下一页的url，不是则返回null
            HtmlNode next_node = allnode.SelectSingleNode("//a[@id='pagnNextLink']");
            if (next_node == null)
                return null;


            //第二类url，返回下一页的url
            string[] url_spli = url.Split(new string[2] { "_pg_", "?" }, StringSplitOptions.RemoveEmptyEntries);
            string page = "";
            if (url_spli.Length >= 2)
                page = url_spli[1];
            else
                return null;
            int page_next = Convert.ToInt32(page, 10) + 1;
            string next = url.Replace("_pg_" + page, "_pg_" + page_next);
            next = next.Replace("&page=" + page, "&page=" + page_next);
            return next;
        }

        public static StreamReader Get_Http(string tUrl)
        {
            HttpWebRequest hwr;
            try
            {
                hwr = (HttpWebRequest)HttpWebRequest.Create(tUrl);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
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
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
