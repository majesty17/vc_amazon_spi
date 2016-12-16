namespace AmazonSpier
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_url = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.saveFileDialog_main = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_state = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBox_show = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_url2 = new System.Windows.Forms.TextBox();
            this.textBox_debug = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_url
            // 
            this.textBox_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_url.Location = new System.Drawing.Point(13, 13);
            this.textBox_url.Name = "textBox_url";
            this.textBox_url.Size = new System.Drawing.Size(622, 21);
            this.textBox_url.TabIndex = 0;
            this.textBox_url.Text = "http://www.amazon.com/s/ref=nb_sb_noss?url=search-alias%3Daps&field-keywords=WINC" +
                "H";
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start.Location = new System.Drawing.Point(641, 11);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 50);
            this.button_start.TabIndex = 1;
            this.button_start.Text = "开始";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_state});
            this.statusStrip1.Location = new System.Drawing.Point(0, 290);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(728, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_state
            // 
            this.toolStripStatusLabel_state.Name = "toolStripStatusLabel_state";
            this.toolStripStatusLabel_state.Size = new System.Drawing.Size(0, 17);
            // 
            // textBox_show
            // 
            this.textBox_show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_show.Location = new System.Drawing.Point(13, 67);
            this.textBox_show.Multiline = true;
            this.textBox_show.Name = "textBox_show";
            this.textBox_show.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_show.Size = new System.Drawing.Size(703, 208);
            this.textBox_show.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "debug";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_url2
            // 
            this.textBox_url2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_url2.Location = new System.Drawing.Point(13, 40);
            this.textBox_url2.Name = "textBox_url2";
            this.textBox_url2.Size = new System.Drawing.Size(622, 21);
            this.textBox_url2.TabIndex = 5;
            this.textBox_url2.Text = "http://www.amazon.com/s/ref=sr_pg_2?rh=i%3Aaps%2Ck%3AWINCH&page=2&keywords=WINCH&" +
                "ie=UTF8&qid=1425914946";
            // 
            // textBox_debug
            // 
            this.textBox_debug.Location = new System.Drawing.Point(0, 180);
            this.textBox_debug.Name = "textBox_debug";
            this.textBox_debug.Size = new System.Drawing.Size(622, 21);
            this.textBox_debug.TabIndex = 6;
            this.textBox_debug.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 312);
            this.Controls.Add(this.textBox_debug);
            this.Controls.Add(this.textBox_url2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_show);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.textBox_url);
            this.Name = "Form1";
            this.Text = "亚马逊";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_url;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_main;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_state;
        private System.Windows.Forms.TextBox textBox_show;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_url2;
        private System.Windows.Forms.TextBox textBox_debug;
    }
}

