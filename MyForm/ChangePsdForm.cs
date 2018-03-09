using System;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class ChangePsdForm : Form
    {
        public ChangePsdForm()
        {
            InitializeComponent();
        }

        private void ChangePsdForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitForm();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void InitForm()
        {
            tbOldPsd.Clear();
            tbNewPsd.Clear();
            tbNewPsd2.Clear();
            tbOldPsd.PasswordChar = '*';
            tbNewPsd.PasswordChar = '*';
            tbNewPsd2.PasswordChar = '*';
            checkBox1.Checked = true;
            tbOldPsd.Focus();

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string tempNewpsd1 = tbNewPsd.Text;
                string tempNewpsd2 = tbNewPsd2.Text;
                string tempOldpsd = tbOldPsd.Text;
                string resmsg;
                if (string.IsNullOrEmpty(tempOldpsd) || string.IsNullOrEmpty(tempOldpsd) || string.IsNullOrEmpty(tempOldpsd))
                {
                    throw new Exception("请正确填写密码");
                }
                if (string.Compare(tempNewpsd1, tempNewpsd2) != 0)
                {
                    throw new Exception("两次新密码输入不一致，请重新输入");
                }
                int ret = ReturnData.DoChangePsd(Global.userMsgData.Account, tempOldpsd, tempNewpsd1, out resmsg);
                if (ret != 0)
                {
                    throw new Exception(resmsg);
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //复选框被勾选，明文显示  
                tbOldPsd.PasswordChar = new char();
                tbNewPsd.PasswordChar = new char();
                tbNewPsd2.PasswordChar = new char();
            }
            else
            {
                //复选框被取消勾选，密文显示  
                tbOldPsd.PasswordChar = '*';
                tbNewPsd.PasswordChar = '*';
                tbNewPsd2.PasswordChar = '*';
            }

        }
    }
}
