namespace ServiceManual
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.BtnLogin = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRemind = new System.Windows.Forms.Label();
            this.btnCreatAccount = new System.Windows.Forms.Button();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(142, 194);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(102, 37);
            this.BtnLogin.TabIndex = 2;
            this.BtnLogin.Text = "登录";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            this.BtnLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(297, 172);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "显示密码";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.checkBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(156, 64);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(156, 125);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(100, 21);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // lbRemind
            // 
            this.lbRemind.AutoSize = true;
            this.lbRemind.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRemind.Location = new System.Drawing.Point(95, 262);
            this.lbRemind.Name = "lbRemind";
            this.lbRemind.Size = new System.Drawing.Size(192, 16);
            this.lbRemind.TabIndex = 4;
            this.lbRemind.Text = "正在登陆，请稍等... ...";
            // 
            // btnCreatAccount
            // 
            this.btnCreatAccount.Location = new System.Drawing.Point(297, 62);
            this.btnCreatAccount.Name = "btnCreatAccount";
            this.btnCreatAccount.Size = new System.Drawing.Size(75, 23);
            this.btnCreatAccount.TabIndex = 5;
            this.btnCreatAccount.Text = "button1";
            this.btnCreatAccount.UseVisualStyleBackColor = true;
            this.btnCreatAccount.Click += new System.EventHandler(this.btnCreatAccount_Click);
            this.btnCreatAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(297, 130);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "记住密码";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 327);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.btnCreatAccount);
            this.Controls.Add(this.lbRemind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.BtnLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRemind;
        private System.Windows.Forms.Button btnCreatAccount;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

