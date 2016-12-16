using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;

namespace GoodSpider
{
    class Tools
    {
        //抓取页面并加入listview
        public static String addHtmlToList(String html,ListView lv,StreamWriter sw){
	        //MessageBox.Show(html);
	        HtmlAgilityPack.HtmlWeb  htmlweb=new HtmlAgilityPack.HtmlWeb();
	        HtmlAgilityPack.HtmlDocument  doc=new HtmlAgilityPack.HtmlDocument();


	        doc=htmlweb.Load(html);
	        if(doc==null){
		        MessageBox.Show("url error!");
		        return "";
	        }
	        HtmlAgilityPack.HtmlNode  allnode=doc.DocumentNode;
           
	        while(true){
                HtmlAgilityPack.HtmlNode anode = allnode.SelectSingleNode("//li[@qrdata]");
		        if(null==anode)
			        break;
		        String data_order=anode.SelectSingleNode("//em[@title='Total Orders']").InnerText;
                HtmlNode node_name = anode.SelectSingleNode("//a[@class='product ']");
                if(node_name==null)
                    node_name = anode.SelectSingleNode("//a[@class=' product ']");
                String data_name = node_name.InnerText;
		        String data_price=anode.SelectSingleNode("//span[@itemprop='price']").InnerText;
		        String data_seller=anode.SelectSingleNode("//a[@class='store']").GetAttributeValue("title","");
                String data_url = node_name.GetAttributeValue("href", "");

                //如果传进来的sw不是null说明需要保存到文件
                if (sw == null)
                {
                    ListViewItem lvi = new ListViewItem(data_name);
                    lvi.SubItems.Add(data_price);
                    lvi.SubItems.Add(data_order);
                    lvi.SubItems.Add(data_seller);
                    lvi.SubItems.Add(data_url);
                    lv.Items.Add(lvi);
                }
                else
                {
                    sw.Write(data_name + "\t" + data_price + "\t" + data_order + "\t" + data_seller + "\t" + data_url + "\n");   
                }
		        anode.Remove();

	        }
            HtmlNode nextnode = allnode.SelectSingleNode("//a[@class='page-next ui-pagination-next']");
            if(nextnode==null)
                return null;
	        else
                return nextnode.GetAttributeValue("href", "");
        }
    }
}
