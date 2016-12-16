using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace AmazonSpier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Stopwatch tick = new Stopwatch();
            tick.Start();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TSV文件|*.tsv";
            sfd.RestoreDirectory = true;
            String filename = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName;
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("name\tseller\tprice\tstars\treviews\told\tasin\trank\tdate");
                //抓第一个url，之后不继续
                Tools.addHtmlToList(textBox_url.Text, sw, false);
                //抓第二个url，循环抓
                String next = Tools.addHtmlToList(textBox_url2.Text, sw, true);
                while (next != null)
                {
                    next = Tools.addHtmlToList(next, sw , true);
                }
                sw.Close();
                fs.Close();
            }
            tick.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox_debug.Text;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(Tools.Get_Http(url));
            HtmlAgilityPack.HtmlNode allnode = doc.DocumentNode;
            MessageBox.Show(Tools.getSellerRank(allnode));

        }
    }
}
