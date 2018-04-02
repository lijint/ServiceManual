using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class LoginForm : Form
    {
        private MainForm mainMenu;
        private ManageForm manageForm;
        private delegate void dDoLogin(string account, string psd, out string res);
        private Thread t_login;
        private string StrAccount;
        private string StrPsd;
        private string RetMsg;
        private int RetCode;

        public LoginForm()
        {
            Log.Info("---------------------------------------------程序开始运行---------------------------------------------");
            InitializeComponent();
            if (OCXClass.RegsvrStarTrans())
            {
                Log.Info("注册成功");
            }
            else
            {
                Log.Error("注册未成功");
                if (MessageBox.Show("组件注册未成功，首次运行请使用管理员权限登录！")==DialogResult.OK)
                {
                    System.Environment.Exit(0);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            InitForm();
            //if (!string.IsNullOrEmpty(Global.LoginUserID))
            //{
            //    txtUserName.Text = Global.LoginUserID;
            //    txtPassWord.Text = Global.LoginUserPsw;
            //    BtnLogin.Focus();
            //}
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                t_login = new Thread(new ThreadStart(DoLogin))
                {
                    ApartmentState = ApartmentState.STA
                };

                IsBeingLogin(true);
                string account = txtUserName.Text;
                string psd = txtPassWord.Text;
                if (string.IsNullOrEmpty(account))
                {
                    MessageBox.Show("请输入账号");
                    IsBeingLogin(false);
                    return;
                }
                if (string.IsNullOrEmpty(psd))
                {
                    MessageBox.Show("请输入密码");
                    IsBeingLogin(false);
                    return;
                }
                StrAccount = account;
                StrPsd = psd;
                t_login.Start();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //复选框被勾选，明文显示  
                txtPassWord.PasswordChar = new char();
            }
            else
            {
                //复选框被取消勾选，密文显示  
                txtPassWord.PasswordChar = '*';
            }
        }

        public void InitForm()
        {
            HttpWebRequest.DefaultWebProxy = null;
            IsBeingLogin(false);
            txtPassWord.Clear();
            txtUserName.Text = Global.LoginUserID;
            txtPassWord.Text = Global.LoginUserPsw;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                txtUserName.Focus();
            }
            else
            {
                txtPassWord.Focus();
            }
            checkBox1.Hide();
            checkBox2.Checked = !string.IsNullOrEmpty(Global.LoginUserPsw);
            txtPassWord.PasswordChar = '*';
#if !DEBUG
            btnCreatAccount.Hide();
#endif
            //Global.SkinName = "SportsCyan";     
            Global.SkinName = "OneBlue";
            this.skinEngine1.SkinFile = "Skins\\" + Global.SkinName + ".ssk";
        }

        private void IsBeingLogin(bool beingPro)
        {
            if (beingPro)
            {
                lbRemind.Show();
                txtUserName.Enabled = false;
                txtPassWord.Enabled = false;
                BtnLogin.Enabled = false;
                btnCreatAccount.Enabled = false;
            }
            else
            {
                lbRemind.Hide();
                txtUserName.Enabled = true;
                txtPassWord.Enabled = true;
                BtnLogin.Enabled = true;
                btnCreatAccount.Enabled = true;
            }
        }

        private void DoLogin()
        {
            //Thread.Sleep(5000);
            Setprams();
            //initSetConfig();
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                int res = ReturnData.DoCheckPsw(StrAccount, StrPsd, out RetMsg, out RetCode);
                if (res == 0)
                {
                    Global.LoginUserID = StrAccount;
                    Global.userMsgData.Account = StrAccount;
                    if (checkBox2.Checked)
                    {
                        Global.LoginUserPsw = StrPsd;
                    }
                    else
                    {
                        Global.LoginUserPsw = "";
                    }
                    if (Global.userMsgData.UserPermission == 1)
                    {
                        while (!IsHandleCreated) ;
                        MethodInvoker MethInvo = new MethodInvoker(ShowMainForm);
                        BeginInvoke(MethInvo);
                    }
                    else if (Global.userMsgData.UserPermission == 2)
                    {
                        while (!IsHandleCreated) ;
                        MethodInvoker MethInvo = new MethodInvoker(ShowManageForm);
                        BeginInvoke(MethInvo);
                    }
                    List<CommonData.UserMsgData> userlist = new List<CommonData.UserMsgData>();
                    res = ReturnData.DoGetInfoByAccount(StrAccount, out RetMsg, out userlist);
                    if (res == 0)
                    {
                        Global.userMsgData = userlist[0];
                    }
                }
                else
                {
                    if (RetCode == 99)
                    {
                        //续期
                        List<CommonData.UserMsgData> userlist = new List<CommonData.UserMsgData>();
                        res = ReturnData.DoGetInfoByAccount(StrAccount, out RetMsg, out userlist);
                        if (res == 0)
                        {
                            Global.userMsgData = userlist[0];
                        }
                        PayForm payForm = new PayForm();
                        payForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(RetMsg);
                    }
                }
                IsBeingLogin(false);
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
            return;
        }

        #region setPrams
        private void Setprams()
        {
            try
            {
                Global.SysFilePath = Application.StartupPath + "\\File";
                if (!Directory.Exists(Global.SysFilePath))
                {
                    Directory.CreateDirectory(Global.SysFilePath);
                }
                Global.FileEnKey = "123456";
                Global.FtpPath = "39.108.188.162";
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                throw;
            }
        }
        private void initSetConfig()
        {
            string msg;
            Global.ConfigInfoList.Clear();
            Global.ConfigInfoList.Add(Global.ConfigInfo.FtpPath, "39.108.188.162");
            Global.ConfigInfoList.Add(Global.ConfigInfo.WebAddAddr, "www.baidu.com");
            Global.ConfigInfoList.Add(Global.ConfigInfo.YeMeiMsg, "维修秘籍");
            Global.ConfigInfoList.Add(Global.ConfigInfo.InitAddr, "");
            int ret = ReturnData.DoSetConfigInfo(Global.ConfigInfoList, out msg);
        }



        #endregion

        private void ShowMainForm()
        {
            mainMenu = new MainForm(this);
            mainMenu.Show();
            Hide();
        }

        private void ShowManageForm()
        {
            manageForm = new ManageForm(this);
            manageForm.Show();
            Hide();
        }

        private void btnCreatAccount_Click(object sender, EventArgs e)
        {
            string returnMsg;
            ReturnData.DoLogout("szw", out returnMsg);
            ReturnData.DoLogout("admin", out returnMsg);

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    BtnLogin_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (string.Compare(txtUserName.Text, Global.LoginUserID) == 0)
            {
                txtPassWord.Text = Global.LoginUserPsw;
            }
            else
            {
                txtPassWord.Text = "";
            }
        }
    }
}
