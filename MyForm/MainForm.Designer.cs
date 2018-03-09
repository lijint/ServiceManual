namespace ServiceManual
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("文件目录");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnUpdateFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMine = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMyInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPay = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangePsd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.tv = new System.Windows.Forms.TreeView();
            this.MyPanel = new System.Windows.Forms.Panel();
            this.lbBeingPro = new System.Windows.Forms.Label();
            this.directoryIcons = new System.Windows.Forms.ImageList(this.components);
            this.filesIcons = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSreach = new System.Windows.Forms.Button();
            this.BtnCut = new System.Windows.Forms.Button();
            this.BtnPlus = new System.Windows.Forms.Button();
            this.lbAD = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.MyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile,
            this.btnMine});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnFile
            // 
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnUpdateFile});
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(44, 21);
            this.btnFile.Text = "文件";
            // 
            // BtnUpdateFile
            // 
            this.BtnUpdateFile.Name = "BtnUpdateFile";
            this.BtnUpdateFile.Size = new System.Drawing.Size(124, 22);
            this.BtnUpdateFile.Text = "文件更新";
            this.BtnUpdateFile.Click += new System.EventHandler(this.BtnUpdateFile_Click);
            // 
            // btnMine
            // 
            this.btnMine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMyInfo,
            this.btnPay,
            this.btnLogout,
            this.btnChangePsd,
            this.btnChangeSkin});
            this.btnMine.Name = "btnMine";
            this.btnMine.Size = new System.Drawing.Size(44, 21);
            this.btnMine.Text = "我的";
            // 
            // btnMyInfo
            // 
            this.btnMyInfo.Name = "btnMyInfo";
            this.btnMyInfo.Size = new System.Drawing.Size(152, 22);
            this.btnMyInfo.Text = "我的信息";
            this.btnMyInfo.Click += new System.EventHandler(this.btnMyInfo_Click);
            // 
            // btnPay
            // 
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(152, 22);
            this.btnPay.Text = "充值缴费";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(152, 22);
            this.btnLogout.Text = "注销登录";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePsd
            // 
            this.btnChangePsd.Name = "btnChangePsd";
            this.btnChangePsd.Size = new System.Drawing.Size(152, 22);
            this.btnChangePsd.Text = "修改密码";
            this.btnChangePsd.Click += new System.EventHandler(this.btnChangePsd_Click);
            // 
            // btnChangeSkin
            // 
            this.btnChangeSkin.Name = "btnChangeSkin";
            this.btnChangeSkin.Size = new System.Drawing.Size(152, 22);
            this.btnChangeSkin.Text = "换肤";
            this.btnChangeSkin.Click += new System.EventHandler(this.btnChangeSkin_Click);
            // 
            // tv
            // 
            this.tv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tv.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv.Location = new System.Drawing.Point(9, 66);
            this.tv.Name = "tv";
            treeNode7.Name = "gen";
            treeNode7.Text = "文件目录";
            this.tv.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.tv.ShowPlusMinus = false;
            this.tv.ShowRootLines = false;
            this.tv.Size = new System.Drawing.Size(223, 393);
            this.tv.TabIndex = 4;
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tv_AfterSelect);
            // 
            // MyPanel
            // 
            this.MyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyPanel.Controls.Add(this.lbBeingPro);
            this.MyPanel.Location = new System.Drawing.Point(241, 44);
            this.MyPanel.Name = "MyPanel";
            this.MyPanel.Size = new System.Drawing.Size(584, 415);
            this.MyPanel.TabIndex = 6;
            // 
            // lbBeingPro
            // 
            this.lbBeingPro.AutoSize = true;
            this.lbBeingPro.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBeingPro.Location = new System.Drawing.Point(306, 335);
            this.lbBeingPro.Name = "lbBeingPro";
            this.lbBeingPro.Size = new System.Drawing.Size(176, 24);
            this.lbBeingPro.TabIndex = 0;
            this.lbBeingPro.Text = "载入中... ...";
            // 
            // directoryIcons
            // 
            this.directoryIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("directoryIcons.ImageStream")));
            this.directoryIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.directoryIcons.Images.SetKeyName(0, "folder closed.ico");
            this.directoryIcons.Images.SetKeyName(1, "folder open.ico");
            this.directoryIcons.Images.SetKeyName(2, "script.ico");
            this.directoryIcons.Images.SetKeyName(3, "data (play).ico");
            this.directoryIcons.Images.SetKeyName(4, "report1.ico");
            this.directoryIcons.Images.SetKeyName(5, "image.ico");
            // 
            // filesIcons
            // 
            this.filesIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("filesIcons.ImageStream")));
            this.filesIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.filesIcons.Images.SetKeyName(0, "www.ico.la_4f20ae4264a30114b58bdf11a9a3ff3a_16X16.ico");
            this.filesIcons.Images.SetKeyName(1, "www.ico.la_9e8a75a94ac81dbd79167523b065070f_16X16.ico");
            this.filesIcons.Images.SetKeyName(2, "www.ico.la_465a275b4b0045dfeff3e93e0e084565_16X16.ico");
            this.filesIcons.Images.SetKeyName(3, "www.ico.la_9136be9dd513a4e6516784525b8f20c3_16X16.ico");
            this.filesIcons.Images.SetKeyName(4, "www.ico.la_dfb66af74a39e81adb2e5a2b6226cec1_16X16.ico");
            this.filesIcons.Images.SetKeyName(5, "www.ico.la_d9a40d110477f4275ed6f5c064f30b39_128X128.ico");
            this.filesIcons.Images.SetKeyName(6, "Google Profile.ico");
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSreach
            // 
            this.btnSreach.Location = new System.Drawing.Point(157, 37);
            this.btnSreach.Name = "btnSreach";
            this.btnSreach.Size = new System.Drawing.Size(75, 23);
            this.btnSreach.TabIndex = 9;
            this.btnSreach.Text = "查找";
            this.btnSreach.UseVisualStyleBackColor = true;
            this.btnSreach.Click += new System.EventHandler(this.btnSreach_Click);
            // 
            // BtnCut
            // 
            this.BtnCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCut.FlatAppearance.BorderSize = 0;
            this.BtnCut.Image = global::ServiceManual.Properties.Resources.zoom_out;
            this.BtnCut.Location = new System.Drawing.Point(304, 5);
            this.BtnCut.Name = "BtnCut";
            this.BtnCut.Size = new System.Drawing.Size(33, 33);
            this.BtnCut.TabIndex = 7;
            this.BtnCut.UseVisualStyleBackColor = true;
            this.BtnCut.Click += new System.EventHandler(this.BtnCut_Click);
            // 
            // BtnPlus
            // 
            this.BtnPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnPlus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnPlus.FlatAppearance.BorderSize = 0;
            this.BtnPlus.Image = global::ServiceManual.Properties.Resources.zoom_in;
            this.BtnPlus.Location = new System.Drawing.Point(255, 5);
            this.BtnPlus.Name = "BtnPlus";
            this.BtnPlus.Size = new System.Drawing.Size(33, 33);
            this.BtnPlus.TabIndex = 7;
            this.BtnPlus.UseVisualStyleBackColor = true;
            this.BtnPlus.Click += new System.EventHandler(this.BtnPlus_Click);
            // 
            // lbAD
            // 
            this.lbAD.AutoSize = true;
            this.lbAD.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAD.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbAD.Location = new System.Drawing.Point(435, 0);
            this.lbAD.Name = "lbAD";
            this.lbAD.Size = new System.Drawing.Size(0, 24);
            this.lbAD.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 471);
            this.Controls.Add(this.lbAD);
            this.Controls.Add(this.btnSreach);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnCut);
            this.Controls.Add(this.BtnPlus);
            this.Controls.Add(this.MyPanel);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(508, 320);
            this.Name = "MainForm";
            this.Text = "维修秘籍 V1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MyPanel.ResumeLayout(false);
            this.MyPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnFile;
        private System.Windows.Forms.ToolStripMenuItem btnMine;
        private System.Windows.Forms.ToolStripMenuItem BtnUpdateFile;
        private System.Windows.Forms.ToolStripMenuItem btnMyInfo;
        private System.Windows.Forms.ToolStripMenuItem btnPay;
        private System.Windows.Forms.ToolStripMenuItem btnLogout;
        private System.Windows.Forms.ToolStripMenuItem btnChangePsd;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Panel MyPanel;
        private System.Windows.Forms.ImageList directoryIcons;
        private System.Windows.Forms.ImageList filesIcons;
        private System.Windows.Forms.Button BtnPlus;
        private System.Windows.Forms.Button BtnCut;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSreach;
        private System.Windows.Forms.ToolStripMenuItem btnChangeSkin;
        private System.Windows.Forms.Label lbAD;
        private System.Windows.Forms.Label lbBeingPro;
    }
}