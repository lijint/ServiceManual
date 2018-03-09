using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class ManageForm : Form
    {
        LoginForm myFather;
        public delegate void DoLogout_d();

        private FTPControl ftpContrl;
        private UserInfoContrl userInfoContrl;


        public ManageForm(LoginForm father)
        {
            InitializeComponent();
            myFather = father;
            WindowState = FormWindowState.Maximized;
        }

        private void ManageForm_Load(object sender, EventArgs e)
        {
            //FormClosing += ManageForm_FormClosing;
            try
            {
                GetConfigInfo();
                InitContrl();
                MyPanel.Controls.Add(userInfoContrl);
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
            //MyPanel.Controls.Add(ftpContrl);
        }

        private void InitContrl()
        {
            try
            {
                userInfoContrl = new UserInfoContrl
                {
                    Width = MyPanel.Width,
                    Height = MyPanel.Height,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right
                };
                ftpContrl = new FTPControl
                {
                    Width = MyPanel.Width,
                    Height = MyPanel.Height,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right
                };
            }
            catch(Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }
        private void ManageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DoLogout_d d = new DoLogout_d(DoLogout);
                d.BeginInvoke(new AsyncCallback(Closeingcall), null);
                Hide();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        public static void DoLogout()
        {
            string retMsg;
            int res = ReturnData.DoLogout(Global.userMsgData.Account, out retMsg);
            if (res != 0)
                MessageBox.Show(retMsg);
        }

        private void Closeingcall(IAsyncResult ar)
        {
            Environment.Exit(0);
        }
        
        private void ManageSet_Click(object sender, EventArgs e)
        {
        }

        private void BtnUserManage_Click(object sender, EventArgs e)
        {
            try
            {
                MyPanel.Controls.Clear();
                MyPanel.Controls.Add(userInfoContrl);
                MyPanel.Focus();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnFileManage_Click(object sender, EventArgs e)
        {
            try
            {
                MyPanel.Controls.Clear();
                MyPanel.Controls.Add(ftpContrl);
                MyPanel.Focus();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelUser_Click(object sender, EventArgs e)
        {

        }

        private void BtnSetPrarms_Click(object sender, EventArgs e)
        {
            try
            {
                SetPramForm setPramForm = new SetPramForm();
                DialogResult ret = setPramForm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    MessageBox.Show("设置成功");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                DoLogout_d d = new DoLogout_d(DoLogout);
                d.BeginInvoke(new AsyncCallback(Logoutcall), null);
                Hide();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void Logoutcall(IAsyncResult ar)
        {
            myFather.Show();
            myFather.InitForm();
        }

        private void BtnChangePsd_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePsdForm changePsdForm = new ChangePsdForm();
                DialogResult ret = changePsdForm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    MessageBox.Show("修改成功");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }

        }

        private string GetVideoAddrByInitfilepath(string initFilePath)
        {
                string strRes = "";
                INIClass gasCardReaderIni = new INIClass(initFilePath);
                strRes = gasCardReaderIni.IniReadValue("MyService", "VideoAddr");
                return strRes;
        }

        private void BtnCreateVideoInitFile_Click(object sender, EventArgs e)
        {
            try
            {
                CreateVideoInitFileForm createVideoInitFileForm = new CreateVideoInitFileForm();
                DialogResult ret = createVideoInitFileForm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    MessageBox.Show("创建成功，请将配置文件移至服务器上");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void GetConfigInfo()
        {
            string resmsg;
            Dictionary<Global.ConfigInfo, string> config = new Dictionary<Global.ConfigInfo, string>();
            int ret = ReturnData.DoGetConfiginfo(out config, out resmsg);
            if (ret != 0)
            {
                throw new Exception(resmsg);
            }
            else
            {
                Global.ConfigInfoList.Clear();
                Global.ConfigInfoList = config;
            }
        }

        private void btnCreateWebInitFile_Click(object sender, EventArgs e)
        {
            try
            {
                CreateWebInitFileForm createWebInitFileForm = new CreateWebInitFileForm();
                DialogResult ret = createWebInitFileForm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    MessageBox.Show("创建成功，请将配置文件移至服务器上");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPayPrarms_Click(object sender, EventArgs e)
        {
            try
            {
                SetPayPrarmForm setPayPrarmForm = new SetPayPrarmForm();
                DialogResult ret = setPayPrarmForm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    MessageBox.Show("设置成功");
                }

            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

    }
}
