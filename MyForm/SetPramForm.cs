using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class SetPramForm : Form
    {
        public SetPramForm()
        {
            InitializeComponent();
        }

        private void SetPramForm_Load(object sender, EventArgs e)
        {
            try
            {
                tbFTPPath.Text = Global.ConfigInfoList[Global.ConfigInfo.FtpPath];
                tbWebAddAddr.Text = Global.ConfigInfoList[Global.ConfigInfo.WebAddAddr];
                tbYeMei.Text = Global.ConfigInfoList[Global.ConfigInfo.YeMeiMsg];
                tbDefaultWebPath.Text = Global.ConfigInfoList[Global.ConfigInfo.InitAddr];
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            try
            {
                string strFtpPath = tbFTPPath.Text;
                string strWebAddAddr = tbWebAddAddr.Text;
                string strYeMeiMsg = tbYeMei.Text;
                string strInitWebAddr = tbDefaultWebPath.Text;
                if (!string.IsNullOrEmpty(strFtpPath))
                {
                    Global.ConfigInfoList[Global.ConfigInfo.FtpPath] = strFtpPath;
                    DialogResult = DialogResult.OK;
                }
                if (!string.IsNullOrEmpty(strWebAddAddr))
                {
                    Global.ConfigInfoList[Global.ConfigInfo.WebAddAddr] = strWebAddAddr;
                    DialogResult = DialogResult.OK;
                }
                if (!string.IsNullOrEmpty(strYeMeiMsg))
                {
                    Global.ConfigInfoList[Global.ConfigInfo.YeMeiMsg] = strYeMeiMsg;
                    DialogResult = DialogResult.OK;
                }
                if (!string.IsNullOrEmpty(strInitWebAddr))
                {
                    Global.ConfigInfoList[Global.ConfigInfo.InitAddr] = strInitWebAddr;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new Exception("请正确输入");
                }
                if (DialogResult == DialogResult.OK)
                {
                    string resmsg;
                    ReturnData.DoSetConfigInfo(Global.ConfigInfoList, out resmsg);
                }
            }
            catch(Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetpath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath+"\\File";

            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                tbDefaultWebPath.Text = file;
            }
        }


    }
}
