using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace GoodSpider
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
            //清理listview
            listView_main.Items.Clear();
            //开搞

            if (checkBox_infile.Checked == true)
            {
                tick.Start();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "TSV文件|*.tsv";
                sfd.RestoreDirectory = true;
                String filename="";
                if(sfd.ShowDialog()==DialogResult.OK)
                {
                    filename=sfd.FileName;
                    FileStream fs=new FileStream(filename,FileMode.CreateNew);
                    StreamWriter sw=new StreamWriter(fs);
                    String next = Tools.addHtmlToList(textBox_url.Text, listView_main,sw);
                    while (next != null)
                    {
                        next = Tools.addHtmlToList(next, listView_main,sw);
                    }
                    sw.Close();
                    fs.Close();

                }
                tick.Stop();
                toolStripStatusLabel_state.Text = "文件保存在 " + filename + "中 （用时 " + tick.ElapsedMilliseconds + " ms）";
            }
            else{
                tick.Start();
                String next = Tools.addHtmlToList(textBox_url.Text, listView_main,null);
                while (next != null)
                {
                    next = Tools.addHtmlToList(next, listView_main,null);
                }
                tick.Stop();
                toolStripStatusLabel_state.Text = "找到 " + listView_main.Items.Count + " 条结果 （用时 " + tick.ElapsedMilliseconds + " ms）";
            }


            
            



            //更新状态
            
        }




    }
}
