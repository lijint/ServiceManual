using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class ManageUserForm : Form
    {

        private int OptionType;   //1---add 2---modify
        public CommonData.UserMsgData userdata;

        List<CommonData.FilePermission> filePermissionList;
        public ManageUserForm()
        {
            InitializeComponent();

        }

        public ManageUserForm(int inOptionType)
        {
            InitializeComponent();
            OptionType = inOptionType;
            cbUserPermission.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUserStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUserTime.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIsOnline.DropDownStyle = ComboBoxStyle.DropDownList;
            filePermissionList = new List<CommonData.FilePermission>();
            if (GetFilePermissionList() == 0 && filePermissionList != null)
            {
                foreach (CommonData.FilePermission f in filePermissionList)
                {
                    comCheckBoxList1.AddItems(f.FileName);
                }
            }
            if (userdata == null)
            {
                userdata = new CommonData.UserMsgData();
            }
        }

        public ManageUserForm(int optionType, CommonData.UserMsgData inUserMsgData)
        {
            InitializeComponent();
            OptionType = optionType;
            userdata = inUserMsgData;
        }

        private void ManageUserForm_Load(object sender, EventArgs e)
        {
            try
            {
                cbUserTime.SelectedItem = "不修改";
                tbPsd.Show();
                lbPsd.Show();
                if (OptionType == 2)
                {
                    tbAccount.ReadOnly = true;
                    tbAccount.Text = userdata.Account;
                    tbUserName.Text = userdata.UserName;
                    tbUserTel.Text = userdata.UserTel;
                    tbPsd.Hide();
                    lbPsd.Hide();
                    lbps.Hide();
                    switch (userdata.UserPermission)
                    {
                        case 0:
                            cbUserPermission.SelectedItem = "无权限用户";
                            break;
                        case 1:
                            cbUserPermission.SelectedItem = "普通用户";
                            break;
                        case 2:
                            cbUserPermission.SelectedItem = "管理员";
                            break;
                    }
                    cbUserStatus.SelectedItem = userdata.StateCode ? "启用" : "禁用";
                    cbIsOnline.SelectedItem = userdata.IsOnline ? "在线" : "下线";
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(tbAccount.Text) || string.IsNullOrEmpty(cbUserPermission.Text) || string.IsNullOrEmpty(cbUserTime.Text))
                {
                    throw new Exception("所填值不允许为空");
                }
                if (OptionType == 1 && string.IsNullOrEmpty(tbPsd.Text))
                {
                    throw new Exception("密码不允许为空");
                }

                if (string.IsNullOrEmpty(tbUserName.Text))
                {
                    tbUserName.Text = "";
                }
                if (string.IsNullOrEmpty(tbUserTel.Text))
                {
                    tbUserTel.Text = "";
                }
                userdata.Account = tbAccount.Text;
                userdata.PassWord = " ";
                userdata.UserName = tbUserName.Text;
                userdata.UserTel = tbUserTel.Text;
                if (string.IsNullOrEmpty(cbUserStatus.Text))
                {
                    userdata.StateCode = true;
                }
                else
                {
                    switch (cbUserStatus.SelectedItem.ToString())
                    {
                        case "启用":
                            userdata.StateCode = true;
                            break;
                        case "禁用":
                            userdata.StateCode = false;
                            break;
                    }
                }
                switch (cbUserPermission.SelectedItem.ToString())
                {
                    case "无权限用户":
                        userdata.UserPermission = 0;
                        break;
                    case "普通用户":
                        userdata.UserPermission = 1;
                        break;
                    case "管理员":
                        userdata.UserPermission = 2;
                        break;
                }

                if(OptionType==1)
                {
                    userdata.CreateDateTime = DateTime.Now;
                    userdata.FailureDateTime = DateTime.Now;
                    userdata.PassWord = tbPsd.Text;
                }
                userdata.UpdateDateTime = DateTime.Now;
                //一个月
                //三个月
                //六个月
                //一年
                //两年
                //三年
                switch (cbUserTime.SelectedItem.ToString())
                {
                    case "不修改":
                        userdata.FailureDateTime = userdata.FailureDateTime;
                        break;
                    case "一个月":
                        userdata.FailureDateTime = userdata.FailureDateTime.AddMonths(1);
                        break;
                    case "三个月":
                        userdata.FailureDateTime = userdata.FailureDateTime.AddMonths(3);
                        break;
                    case "六个月":
                        userdata.FailureDateTime = userdata.FailureDateTime.AddMonths(6);
                        break;
                    case "一年":
                        userdata.FailureDateTime = userdata.FailureDateTime.AddYears(1);
                        break;
                    case "两年":
                        userdata.FailureDateTime = userdata.FailureDateTime.AddYears(2);
                        break;
                    case "三年":
                        userdata.FailureDateTime = userdata.FailureDateTime.AddYears(3);
                        break;
                }
                if (string.IsNullOrEmpty(cbIsOnline.Text))
                {
                    userdata.IsOnline = false;
                }
                else
                {
                    switch (cbIsOnline.SelectedItem.ToString())
                    {
                        case "在线":
                            userdata.IsOnline = true;
                            break;
                        case "下线":
                            userdata.IsOnline = false;
                            break;
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private int GetFilePermissionList()
        {
            int ret = -1;
            string retmsg;
            try
            {
                ret = ReturnData.DoGetFilePermissionList(out filePermissionList, out retmsg);
                if (ret != 0)
                {
                    MessageBox.Show(retmsg);
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
            return ret;
        }


    }
}
