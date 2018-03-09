namespace ServiceManual
{
    partial class FTPControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.wbFTP = new System.Windows.Forms.WebBrowser();
            this.btnConnectFTP = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFTPPort = new System.Windows.Forms.TextBox();
            this.tbUserPsd = new System.Windows.Forms.TextBox();
            this.tbUserAccount = new System.Windows.Forms.TextBox();
            this.tbFTPPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // wbFTP
            // 
            this.wbFTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbFTP.Location = new System.Drawing.Point(8, 34);
            this.wbFTP.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbFTP.Name = "wbFTP";
            this.wbFTP.Size = new System.Drawing.Size(823, 495);
            this.wbFTP.TabIndex = 40;
            // 
            // btnConnectFTP
            // 
            this.btnConnectFTP.Location = new System.Drawing.Point(735, 3);
            this.btnConnectFTP.Name = "btnConnectFTP";
            this.btnConnectFTP.Size = new System.Drawing.Size(75, 20);
            this.btnConnectFTP.TabIndex = 35;
            this.btnConnectFTP.Text = "连接";
            this.btnConnectFTP.UseVisualStyleBackColor = true;
            this.btnConnectFTP.Click += new System.EventHandler(this.btnConnectFTP_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(579, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 39;
            this.label4.Text = "端口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "FTP地址：";
            // 
            // tbFTPPort
            // 
            this.tbFTPPort.Location = new System.Drawing.Point(626, 4);
            this.tbFTPPort.Name = "tbFTPPort";
            this.tbFTPPort.Size = new System.Drawing.Size(72, 21);
            this.tbFTPPort.TabIndex = 34;
            // 
            // tbUserPsd
            // 
            this.tbUserPsd.Location = new System.Drawing.Point(456, 4);
            this.tbUserPsd.Name = "tbUserPsd";
            this.tbUserPsd.Size = new System.Drawing.Size(102, 21);
            this.tbUserPsd.TabIndex = 33;
            // 
            // tbUserAccount
            // 
            this.tbUserAccount.Location = new System.Drawing.Point(293, 4);
            this.tbUserAccount.Name = "tbUserAccount";
            this.tbUserAccount.Size = new System.Drawing.Size(102, 21);
            this.tbUserAccount.TabIndex = 32;
            // 
            // tbFTPPath
            // 
            this.tbFTPPath.Location = new System.Drawing.Point(71, 4);
            this.tbFTPPath.Name = "tbFTPPath";
            this.tbFTPPath.Size = new System.Drawing.Size(150, 21);
            this.tbFTPPath.TabIndex = 31;
            // 
            // FTPControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wbFTP);
            this.Controls.Add(this.btnConnectFTP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFTPPort);
            this.Controls.Add(this.tbUserPsd);
            this.Controls.Add(this.tbUserAccount);
            this.Controls.Add(this.tbFTPPath);
            this.Name = "FTPControl";
            this.Size = new System.Drawing.Size(834, 532);
            this.Load += new System.EventHandler(this.FTPControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbFTP;
        private System.Windows.Forms.Button btnConnectFTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFTPPort;
        private System.Windows.Forms.TextBox tbUserPsd;
        private System.Windows.Forms.TextBox tbUserAccount;
        private System.Windows.Forms.TextBox tbFTPPath;
    }
}
