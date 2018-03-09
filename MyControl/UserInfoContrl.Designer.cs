namespace ServiceManual
{
    partial class UserInfoContrl
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnModifyUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.lvUserList = new System.Windows.Forms.ListView();
            this.account = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreateDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FailureDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UpdateDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserTel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserPermission = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsOnline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StateCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnModifyUser
            // 
            this.btnModifyUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifyUser.Location = new System.Drawing.Point(897, 4);
            this.btnModifyUser.Name = "btnModifyUser";
            this.btnModifyUser.Size = new System.Drawing.Size(75, 23);
            this.btnModifyUser.TabIndex = 8;
            this.btnModifyUser.Text = "修改用户";
            this.btnModifyUser.UseVisualStyleBackColor = true;
            this.btnModifyUser.Click += new System.EventHandler(this.BtnModifyUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.Location = new System.Drawing.Point(793, 4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 7;
            this.btnAddUser.Text = "添加用户";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.BtnAddUser_Click);
            // 
            // lvUserList
            // 
            this.lvUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUserList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.account,
            this.userName,
            this.CreateDateTime,
            this.FailureDateTime,
            this.UpdateDateTime,
            this.UserTel,
            this.UserPermission,
            this.IsOnline,
            this.StateCode});
            this.lvUserList.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvUserList.Location = new System.Drawing.Point(6, 33);
            this.lvUserList.Name = "lvUserList";
            this.lvUserList.Size = new System.Drawing.Size(1146, 639);
            this.lvUserList.TabIndex = 6;
            this.lvUserList.UseCompatibleStateImageBehavior = false;
            this.lvUserList.View = System.Windows.Forms.View.Details;
            this.lvUserList.DoubleClick += new System.EventHandler(this.LvUserList_DoubleClick);
            // 
            // account
            // 
            this.account.Text = "账号";
            this.account.Width = 85;
            // 
            // userName
            // 
            this.userName.Text = "用户姓名";
            this.userName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.userName.Width = 104;
            // 
            // CreateDateTime
            // 
            this.CreateDateTime.Text = "用户创建日期";
            this.CreateDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CreateDateTime.Width = 180;
            // 
            // FailureDateTime
            // 
            this.FailureDateTime.Text = "用户失效日期";
            this.FailureDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FailureDateTime.Width = 180;
            // 
            // UpdateDateTime
            // 
            this.UpdateDateTime.Text = "用户更新日期";
            this.UpdateDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpdateDateTime.Width = 180;
            // 
            // UserTel
            // 
            this.UserTel.Text = "用户电话";
            this.UserTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserTel.Width = 124;
            // 
            // UserPermission
            // 
            this.UserPermission.Text = "用户权限";
            this.UserPermission.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserPermission.Width = 104;
            // 
            // IsOnline
            // 
            this.IsOnline.Text = "是否在线";
            this.IsOnline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IsOnline.Width = 88;
            // 
            // StateCode
            // 
            this.StateCode.Text = "用户状态";
            this.StateCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StateCode.Width = 96;
            // 
            // btnDelUser
            // 
            this.btnDelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelUser.Location = new System.Drawing.Point(1004, 4);
            this.btnDelUser.Name = "btnDelUser";
            this.btnDelUser.Size = new System.Drawing.Size(75, 23);
            this.btnDelUser.TabIndex = 9;
            this.btnDelUser.Text = "删除用户";
            this.btnDelUser.UseVisualStyleBackColor = true;
            this.btnDelUser.Click += new System.EventHandler(this.btnDelUser_Click);
            // 
            // UserInfoContrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelUser);
            this.Controls.Add(this.btnModifyUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lvUserList);
            this.Name = "UserInfoContrl";
            this.Size = new System.Drawing.Size(1158, 676);
            this.Load += new System.EventHandler(this.UserInfoContrl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModifyUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ListView lvUserList;
        private System.Windows.Forms.ColumnHeader account;
        private System.Windows.Forms.ColumnHeader userName;
        private System.Windows.Forms.ColumnHeader CreateDateTime;
        private System.Windows.Forms.ColumnHeader FailureDateTime;
        private System.Windows.Forms.ColumnHeader UpdateDateTime;
        private System.Windows.Forms.ColumnHeader UserTel;
        private System.Windows.Forms.ColumnHeader UserPermission;
        private System.Windows.Forms.ColumnHeader IsOnline;
        private System.Windows.Forms.ColumnHeader StateCode;
        private System.Windows.Forms.Button btnDelUser;
    }
}
