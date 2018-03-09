using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class SetPayPrarmForm : Form
    {
        private List<CommonData.PayPrarmsData> payinfolist;
        public SetPayPrarmForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                string retmsg="";
                if (string.IsNullOrEmpty(tbPrice1.Text) || string.IsNullOrEmpty(tbTime1.Text) || string.IsNullOrEmpty(tbPrice2.Text) || string.IsNullOrEmpty(tbTime2.Text))
                {
                    throw new Exception("支付参数输入错误");
                }
                else
                {
                    if (ReturnData.DoSetPayPrarms(tbPrice1.Text, tbTime1.Text, tbPrice2.Text, tbTime2.Text, out retmsg) == 0)
                    {
                        DialogResult = DialogResult.OK;
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void SetPayPrarmForm_Load(object sender, EventArgs e)
        {
            try
            {
                string retmsg = "";
                payinfolist = new List<CommonData.PayPrarmsData>();
                int ret = ReturnData.DoGetPayPrarms(out payinfolist, out retmsg);
                if (ret == 0)
                {
                    tbPrice1.Text = payinfolist[0].Price;
                    tbTime1.Text = payinfolist[0].RenewalTime;
                    tbPrice2.Text = payinfolist[1].Price;
                    tbTime2.Text = payinfolist[1].RenewalTime;
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
