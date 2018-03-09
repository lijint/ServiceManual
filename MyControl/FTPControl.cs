using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class FTPControl : UserControl
    {
        public FTPControl()
        {
            InitializeComponent();
            tbFTPPath.Text = Global.ConfigInfoList[Global.ConfigInfo.FtpPath];
            tbUserAccount.Text = Global.userMsgData.Account;
            tbUserPsd.Text = Global.userMsgData.PassWord;
            tbUserPsd.PasswordChar = '*';
            tbFTPPort.Text = "";
        }

        private void FTPControl_Load(object sender, EventArgs e)
        {
            tbFTPPath.Text = Global.FtpPath;
            tbUserAccount.Text = Global.userMsgData.Account;
            tbUserPsd.Text = Global.userMsgData.PassWord;
            tbUserPsd.PasswordChar = '*';
            tbFTPPort.Text = "";
        }

        private void btnConnectFTP_Click(object sender, EventArgs e)
        {
            try
            {
                string strFTPPath = "";
                if (tbFTPPath.Text == null)
                {
                    throw new Exception("请输入ftp地址");
                }
                string path = tbFTPPath.Text;
                //string path = Global.FtpPath;
                string account = tbUserAccount.Text;
                string password = tbUserPsd.Text;
                string port = tbFTPPort.Text;
                if (!string.IsNullOrEmpty(account) && !string.IsNullOrEmpty(password))
                {
                    strFTPPath = "ftp://" + account + ":" + password + "@" + path;
                }
                else
                {
                    strFTPPath = "ftp://" + path;
                }
                if (!string.IsNullOrEmpty(port))
                {
                    strFTPPath += ":" + port;
                }
                ShowFTP(strFTPPath);
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);

                MessageBox.Show(ex.Message);
            }
        }
        private void ShowFTP(string strFTPPath)
        {
            wbFTP.Navigate(strFTPPath);
        }

    }
}
