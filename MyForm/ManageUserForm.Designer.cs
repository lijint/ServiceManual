namespace ServiceManual
{
    partial class ManageUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUserForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.tbUserTel = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbUserTime = new System.Windows.Forms.ComboBox();
            this.cbUserPermission = new System.Windows.Forms.ComboBox();
            this.cbUserStatus = new System.Windows.Forms.ComboBox();
            this.cbIsOnline = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPsd = new System.Windows.Forms.Label();
            this.tbPsd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbps = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户使用期限";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 3;
            this.label4.Tag = "用户权限";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "用户电话";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "姓名";
            // 
            // tbAccount
            // 
            this.tbAccount.Location = new System.Drawing.Point(92, 41);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(100, 21);
            this.tbAccount.TabIndex = 1;
            // 
            // tbUserTel
            // 
            this.tbUserTel.Location = new System.Drawing.Point(292, 75);
            this.tbUserTel.Name = "tbUserTel";
            this.tbUserTel.Size = new System.Drawing.Size(100, 21);
            this.tbUserTel.TabIndex = 4;
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(292, 41);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 21);
            this.tbUserName.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(104, 217);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "用户权限";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(225, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 12);
            this.label10.TabIndex = 3;
            this.label10.Tag = "用户权限";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(225, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "用户状态";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(246, 217);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbUserTime
            // 
            this.cbUserTime.FormattingEnabled = true;
            this.cbUserTime.Items.AddRange(new object[] {
            "不修改",
            "一个月",
            "三个月",
            "六个月",
            "一年",
            "两年",
            "三年"});
            this.cbUserTime.Location = new System.Drawing.Point(92, 81);
            this.cbUserTime.Name = "cbUserTime";
            this.cbUserTime.Size = new System.Drawing.Size(100, 20);
            this.cbUserTime.TabIndex = 3;
            // 
            // cbUserPermission
            // 
            this.cbUserPermission.FormattingEnabled = true;
            this.cbUserPermission.Items.AddRange(new object[] {
            "管理员",
            "普通用户",
            "无权限用户"});
            this.cbUserPermission.Location = new System.Drawing.Point(92, 124);
            this.cbUserPermission.Name = "cbUserPermission";
            this.cbUserPermission.Size = new System.Drawing.Size(100, 20);
            this.cbUserPermission.TabIndex = 5;
            // 
            // cbUserStatus
            // 
            this.cbUserStatus.FormattingEnabled = true;
            this.cbUserStatus.Items.AddRange(new object[] {
            "启用",
            "禁用"});
            this.cbUserStatus.Location = new System.Drawing.Point(292, 124);
            this.cbUserStatus.Name = "cbUserStatus";
            this.cbUserStatus.Size = new System.Drawing.Size(100, 20);
            this.cbUserStatus.TabIndex = 6;
            // 
            // cbIsOnline
            // 
            this.cbIsOnline.FormattingEnabled = true;
            this.cbIsOnline.Items.AddRange(new object[] {
            "在线",
            "下线"});
            this.cbIsOnline.Location = new System.Drawing.Point(92, 169);
            this.cbIsOnline.Name = "cbIsOnline";
            this.cbIsOnline.Size = new System.Drawing.Size(100, 20);
            this.cbIsOnline.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "用户是否在线";
            // 
            // lbPsd
            // 
            this.lbPsd.AutoSize = true;
            this.lbPsd.Location = new System.Drawing.Point(230, 169);
            this.lbPsd.Name = "lbPsd";
            this.lbPsd.Size = new System.Drawing.Size(29, 12);
            this.lbPsd.TabIndex = 6;
            this.lbPsd.Text = "密码";
            // 
            // tbPsd
            // 
            this.tbPsd.Location = new System.Drawing.Point(292, 169);
            this.tbPsd.Name = "tbPsd";
            this.tbPsd.Size = new System.Drawing.Size(100, 21);
            this.tbPsd.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(195, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(195, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "*";
            // 
            // lbps
            // 
            this.lbps.AutoSize = true;
            this.lbps.ForeColor = System.Drawing.Color.Red;
            this.lbps.Location = new System.Drawing.Point(395, 172);
            this.lbps.Name = "lbps";
            this.lbps.Size = new System.Drawing.Size(11, 12);
            this.lbps.TabIndex = 13;
            this.lbps.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(195, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "*";
            // 
            // ManageUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 268);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbps);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbIsOnline);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbUserStatus);
            this.Controls.Add(this.cbUserPermission);
            this.Controls.Add(this.cbUserTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbPsd);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.tbUserTel);
            this.Controls.Add(this.lbPsd);
            this.Controls.Add(this.tbAccount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑个人";
            this.Load += new System.EventHandler(this.ManageUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.TextBox tbUserTel;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbUserTime;
        private System.Windows.Forms.ComboBox cbUserPermission;
        private System.Windows.Forms.ComboBox cbUserStatus;
        private System.Windows.Forms.ComboBox cbIsOnline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbPsd;
        private System.Windows.Forms.TextBox tbPsd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbps;
        private System.Windows.Forms.Label label13;
    }
}