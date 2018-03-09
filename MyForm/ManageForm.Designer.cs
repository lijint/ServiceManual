namespace ServiceManual
{
    partial class ManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ManageSet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetPrarms = new System.Windows.Forms.ToolStripMenuItem();
            this.我的ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangePsd = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateVideoInitFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateWebInitFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUserManage = new System.Windows.Forms.Label();
            this.btnFileManage = new System.Windows.Forms.Label();
            this.MyPanel = new System.Windows.Forms.Panel();
            this.btnPayPrarms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManageSet,
            this.我的ToolStripMenuItem,
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1252, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ManageSet
            // 
            this.ManageSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetPrarms,
            this.btnPayPrarms});
            this.ManageSet.Name = "ManageSet";
            this.ManageSet.Size = new System.Drawing.Size(44, 21);
            this.ManageSet.Text = "设置";
            this.ManageSet.Click += new System.EventHandler(this.ManageSet_Click);
            // 
            // btnSetPrarms
            // 
            this.btnSetPrarms.Name = "btnSetPrarms";
            this.btnSetPrarms.Size = new System.Drawing.Size(152, 22);
            this.btnSetPrarms.Text = "参数配置";
            this.btnSetPrarms.Click += new System.EventHandler(this.BtnSetPrarms_Click);
            // 
            // 我的ToolStripMenuItem
            // 
            this.我的ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLogout,
            this.btnChangePsd});
            this.我的ToolStripMenuItem.Name = "我的ToolStripMenuItem";
            this.我的ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.我的ToolStripMenuItem.Text = "我的";
            // 
            // btnLogout
            // 
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(152, 22);
            this.btnLogout.Text = "注销登录";
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnChangePsd
            // 
            this.btnChangePsd.Name = "btnChangePsd";
            this.btnChangePsd.Size = new System.Drawing.Size(152, 22);
            this.btnChangePsd.Text = "修改密码";
            this.btnChangePsd.Click += new System.EventHandler(this.BtnChangePsd_Click);
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateVideoInitFile,
            this.btnCreateWebInitFile});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // btnCreateVideoInitFile
            // 
            this.btnCreateVideoInitFile.Name = "btnCreateVideoInitFile";
            this.btnCreateVideoInitFile.Size = new System.Drawing.Size(172, 22);
            this.btnCreateVideoInitFile.Text = "创建视频配置文件";
            this.btnCreateVideoInitFile.Click += new System.EventHandler(this.BtnCreateVideoInitFile_Click);
            // 
            // btnCreateWebInitFile
            // 
            this.btnCreateWebInitFile.Name = "btnCreateWebInitFile";
            this.btnCreateWebInitFile.Size = new System.Drawing.Size(172, 22);
            this.btnCreateWebInitFile.Text = "创建网页配置文件";
            this.btnCreateWebInitFile.Click += new System.EventHandler(this.btnCreateWebInitFile_Click);
            // 
            // btnUserManage
            // 
            this.btnUserManage.AutoSize = true;
            this.btnUserManage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserManage.Location = new System.Drawing.Point(12, 113);
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Size = new System.Drawing.Size(63, 14);
            this.btnUserManage.TabIndex = 3;
            this.btnUserManage.Text = "用户管理";
            this.btnUserManage.Click += new System.EventHandler(this.BtnUserManage_Click);
            // 
            // btnFileManage
            // 
            this.btnFileManage.AutoSize = true;
            this.btnFileManage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFileManage.Location = new System.Drawing.Point(0, 163);
            this.btnFileManage.Name = "btnFileManage";
            this.btnFileManage.Size = new System.Drawing.Size(91, 14);
            this.btnFileManage.TabIndex = 3;
            this.btnFileManage.Text = "远程文件管理";
            this.btnFileManage.Click += new System.EventHandler(this.BtnFileManage_Click);
            // 
            // MyPanel
            // 
            this.MyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyPanel.Location = new System.Drawing.Point(93, 29);
            this.MyPanel.Name = "MyPanel";
            this.MyPanel.Size = new System.Drawing.Size(1159, 598);
            this.MyPanel.TabIndex = 4;
            // 
            // btnPayPrarms
            // 
            this.btnPayPrarms.Name = "btnPayPrarms";
            this.btnPayPrarms.Size = new System.Drawing.Size(152, 22);
            this.btnPayPrarms.Text = "支付参数配置";
            this.btnPayPrarms.Click += new System.EventHandler(this.btnPayPrarms_Click);
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 629);
            this.Controls.Add(this.MyPanel);
            this.Controls.Add(this.btnFileManage);
            this.Controls.Add(this.btnUserManage);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1245, 667);
            this.Name = "ManageForm";
            this.Text = "管理平台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageForm_FormClosing);
            this.Load += new System.EventHandler(this.ManageForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ManageSet;
        private System.Windows.Forms.Label btnUserManage;
        private System.Windows.Forms.Label btnFileManage;
        private System.Windows.Forms.ToolStripMenuItem btnSetPrarms;
        private System.Windows.Forms.ToolStripMenuItem 我的ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnLogout;
        private System.Windows.Forms.ToolStripMenuItem btnChangePsd;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnCreateVideoInitFile;
        private System.Windows.Forms.Panel MyPanel;
        private System.Windows.Forms.ToolStripMenuItem btnCreateWebInitFile;
        private System.Windows.Forms.ToolStripMenuItem btnPayPrarms;
    }
}