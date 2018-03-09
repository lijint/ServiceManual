namespace ServiceManual
{
    partial class SetPramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetPramForm));
            this.btnYes = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFTPPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbWebAddAddr = new System.Windows.Forms.TextBox();
            this.tbDefaultWebPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbYeMei = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetpath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnYes.Location = new System.Drawing.Point(88, 247);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "保存";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.BtnYes_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(250, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "FTP地址";
            // 
            // tbFTPPath
            // 
            this.tbFTPPath.Location = new System.Drawing.Point(118, 31);
            this.tbFTPPath.Name = "tbFTPPath";
            this.tbFTPPath.Size = new System.Drawing.Size(251, 21);
            this.tbFTPPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "广告页面地址";
            // 
            // tbWebAddAddr
            // 
            this.tbWebAddAddr.Location = new System.Drawing.Point(118, 76);
            this.tbWebAddAddr.Name = "tbWebAddAddr";
            this.tbWebAddAddr.Size = new System.Drawing.Size(251, 21);
            this.tbWebAddAddr.TabIndex = 2;
            // 
            // tbDefaultWebPath
            // 
            this.tbDefaultWebPath.Location = new System.Drawing.Point(118, 174);
            this.tbDefaultWebPath.Name = "tbDefaultWebPath";
            this.tbDefaultWebPath.Size = new System.Drawing.Size(185, 21);
            this.tbDefaultWebPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "启动默认页面";
            // 
            // tbYeMei
            // 
            this.tbYeMei.Location = new System.Drawing.Point(118, 129);
            this.tbYeMei.Name = "tbYeMei";
            this.tbYeMei.Size = new System.Drawing.Size(251, 21);
            this.tbYeMei.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "页眉显示信息";
            // 
            // btnGetpath
            // 
            this.btnGetpath.Location = new System.Drawing.Point(309, 174);
            this.btnGetpath.Name = "btnGetpath";
            this.btnGetpath.Size = new System.Drawing.Size(60, 23);
            this.btnGetpath.TabIndex = 7;
            this.btnGetpath.Text = "浏览";
            this.btnGetpath.UseVisualStyleBackColor = true;
            this.btnGetpath.Click += new System.EventHandler(this.btnGetpath_Click);
            // 
            // SetPramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 309);
            this.Controls.Add(this.btnGetpath);
            this.Controls.Add(this.tbDefaultWebPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbYeMei);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbWebAddAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFTPPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnYes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetPramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置参数";
            this.Load += new System.EventHandler(this.SetPramForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFTPPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWebAddAddr;
        private System.Windows.Forms.TextBox tbDefaultWebPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbYeMei;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetpath;
    }
}