using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace 通过列表页抓取详情页url
{
    public partial class Form1 : Form
    {
        //全局的变量
        FileStream fs;
        StreamWriter sw;


        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        //开始按钮按下去
        private void button1_Click(object sender, EventArgs e)
        {
            //1.判断第二个url是否合理
            String url2 = textBox_url2.Text;
            if (url2.IndexOf("_pg_") < 0 || url2.IndexOf("page=") < 0)
            {
                MessageBox.Show("第二个url不对！URL里需要包含'_pg_'和'page='。");
                return;
            }



            //2.打开保存文件对话框
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "文本文件|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //3.取出文件名，打开写流
                String filename = sfd.FileName;
                fs = new FileStream(filename, FileMode.Create);
                sw = new StreamWriter(fs);

                //4.初始化进度条
                toolStripProgressBar1.Minimum = 0;
                toolStripProgressBar1.Maximum = 30;
                
                //5.新建一个线程并启动
                ThreadStart threadStart = new ThreadStart(run);
                button_start.Enabled = false;
                Thread thread = new Thread(threadStart);
                thread.Start();
            }


        }

        //线程事件
        public void run()
        {
            //页数默认10页,除非配置了
            toolStripProgressBar1.Value = 0;
            int pgs = 10;
            try
            {
                pgs=Convert.ToInt32(textBox_pgs.Text, 10);
            }
            catch (System.Exception ex)
            {
                pgs = 10;
                textBox_pgs.Text = "10";
            }
            

            //抓第一个url，之后不继续
            ToolsFirst.addHtmlToList(textBox_url1.Text, sw, false);
            //抓第二个url，循环抓
            String next = ToolsFirst.addHtmlToList(textBox_url2.Text, sw, true);
            while (next != null && (--pgs) > 0)
            {
                toolStripProgressBar1.Value = (toolStripProgressBar1.Value + 1) % 31;
                next = ToolsFirst.addHtmlToList(next, sw, true);
            }



            sw.Close();
            fs.Close();
            button_start.Enabled = true;
            toolStripProgressBar1.Value = 30;
        }




    }
}
