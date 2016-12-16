using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace 通过详情页抓取数据
{
    public partial class Form1 : Form
    {
        //全局的变量
        FileStream fs;
        StreamWriter sw;
        bool main_running;

        public string[] urls;



        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            button_stop.Enabled = false;
        }
        //退出时通知thread
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.main_running = false;
        }

        //开始按钮
        private void button1_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TSV文件|*.tsv";
            sfd.RestoreDirectory = true;
            String filename = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //获取到所有的url
                filename = sfd.FileName;
                fs = new FileStream(filename, FileMode.Create);
                sw = new StreamWriter(fs,Encoding.Default);
                urls = textBox_whole.Text.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
  
                //调整进度条
                toolStripProgressBar1.Minimum = 0;
                toolStripProgressBar1.Maximum = urls.Length;

                //新建一个thread ，跑起来
                ThreadStart threadStart = new ThreadStart(run);
                button_start.Enabled = false;

                Thread thread = new Thread(threadStart);
                this.main_running = true;
                button_stop.Enabled = true;
                button_load.Enabled = false;
                textBox_whole.Enabled = false;
                button_clear.Enabled = false;
                toolStripProgressBar1.Value = 0;
                thread.Start(); 

            }

        }
        //线程方法
        public void run()
        {
            //读取每一个url并执行
            sw.WriteLine("产品名称\t品牌商名称\t价格\t评分\t评价数\t跟卖数\tASIN码\tAMAZON BEST SELLERS RANK\t开始上线日期\t抓取时间");

            foreach (string aurl in urls)
            {

                Tools.getSinglePage(aurl, sw);
                if (this.main_running == false || toolStripProgressBar1==null)
                    break;
                toolStripProgressBar1.Value = toolStripProgressBar1.Value + 1;
                toolStripStatusLabel2.Text = toolStripProgressBar1.Value + "已抓取";
            }
            //打开按钮
            button_start.Enabled = true;

            //关闭流
            sw.Close();
            fs.Close();

            //恢复状态
            this.main_running = false;
            button_stop.Text = "终止";
            button_stop.Enabled = false;
            button_load.Enabled = true ;
            textBox_whole.Enabled = true;
            button_clear.Enabled = true;
        }

        //导入详情页url们
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt文本文件|*.txt|所有文件|*.*";
            string filename = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                try
                {
                    StreamReader sr = new StreamReader(filename,Encoding.Default);
                    textBox_whole.Text = "";
                    string line;
                    int line_num = 0;
                    while (true)
                    {
                        line=sr.ReadLine();
                        if(line==null)
                            break;
                        textBox_whole.AppendText(line + "\r\n");
                        line_num++;
                    }
                    sr.Close();
                    toolStripStatusLabel1.Text = line_num + "个URL已导入";
                }
                catch (System.Exception ex)
                {
                    
                }
                
            }
        }
        //终止thread
        private void button_stop_Click(object sender, EventArgs e)
        {
            this.main_running = false;
            button_stop.Text = "终止中...";
        }
        //清空
        private void button3_Click(object sender, EventArgs e)
        {
            textBox_whole.Clear();
        }




    }
}
