using System;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class MyInfoForm : Form
    {
        public MyInfoForm()
        {
            InitializeComponent();
        }

        private void MyInfoForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Global.userMsgData==null)
                {
                    throw new Exception("该用户无数据");
                }
                lbAccount.Text = Global.userMsgData.Account;
                lbName.Text = Global.userMsgData.UserName;
                lbTel.Text = Global.userMsgData.UserTel;
                lbStartDate.Text = Global.userMsgData.CreateDateTime.ToLongDateString();
                lbEndDate.Text = Global.userMsgData.FailureDateTime.ToLongDateString();
                switch (Global.userMsgData.StateCode)
                {
                    case true:
                        lbStatus.Text = "已启用";
                        break;
                    case false:
                        lbStatus.Text = "已禁用";
                        break;
                }
                //lbStatus.Text = Global.userMsgData.StateCode.ToString();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
