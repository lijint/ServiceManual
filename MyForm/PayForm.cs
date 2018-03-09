using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class PayForm : Form
    {
        private CommonData.PayData payData;
        private int TimeTick;
        private List<CommonData.PayPrarmsData> payInfoList;

        public PayForm()
        {
            InitializeComponent();
        }

        private void PayForm_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = 1000;
                timerQuery.Interval = 5000;
                string outmsg="";
                payInfoList = new List<CommonData.PayPrarmsData>();
                ReturnData.DoGetPayPrarms(out payInfoList, out outmsg);
                if (payInfoList.Count == 2)
                {
                    for (int i = 0; i < payInfoList.Count; i++)
                    {
                        if (string.Compare(payInfoList[i].ConfigCode, "RenewalWay1") == 0)
                        {
                            rbRenewal1.Text = payInfoList[i].RenewalTime + "个月";
                            rbRenewal1.Checked = true;
                        }
                        if (string.Compare(payInfoList[i].ConfigCode, "RenewalWay2") == 0)
                        {
                            rbRenewal2.Text = payInfoList[i].RenewalTime + "个月";
                        }
                    }
                }
                payData = new CommonData.PayData
                {
                    Account = Global.userMsgData.Account,
                    IsPreCreate = false,
                    IsPay = false
                };
                TimeTick = 120;
                timer1.Enabled = false;
                timerQuery.Enabled = false;
                lbTimeTick.Text = "0";
                btnCreatQRCode.Enabled = true;
                btnCancelOrder.Enabled = false;
                lbAccount.Text = Global.userMsgData.Account;
                lbFailrueDateTime.Text = Global.userMsgData.FailureDateTime.ToLongDateString();
                //FormClosing += PayForm_FormClosing;
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCreatQRCode_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                btnCreatQRCode.Enabled = false;
                btnCancelOrder.Enabled = true;
                if(rbRenewal1.Checked)
                {
                    payData.RenewalWay = "renewalWay1";
                }
                else if(rbRenewal2.Checked)
                {
                    payData.RenewalWay = "renewalWay2";
                }
                MethodInvoker MethInvo = new MethodInvoker(DoCreatePerOrder);
                BeginInvoke(MethInvo);

            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                btnCreatQRCode.Enabled = true;
                btnCancelOrder.Enabled = false;
                TimeTick = 120;
                lbTimeTick.Text = "0";
                picQRCode.Image = null;
                MethodInvoker MethInvo = new MethodInvoker(DoCancelOrder);
                BeginInvoke(MethInvo);
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        #region 根据传入参数生成二维码
        /// <summary>
        /// 根据传入参数生成二维码
        /// </summary>
        /// <param name="qrstr"></param>
        /// <returns></returns>
        public int CreateQRCodeImg(string qrstr)
        {
            int ret = -1;
            try
            {
                QRCodeHandler qr = new QRCodeHandler();
                string qrString = qrstr;                                                                                 //二维码字符串
                Image image = qr.CreateQRCode(qrString, "Byte", 4, 0, "H");      //生成
                picQRCode.Image = image;

                ret = 0;
            }
            catch
            {
                ret = -1;
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err");
                throw;
            }
            return ret;
        }
        #endregion

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (TimeTick != 0)
                {
                    lbTimeTick.Text = TimeTick.ToString();
                    TimeTick--;
                }
                else if (TimeTick == 0)
                {
                    Thread.Sleep(10000);
                    BtnCancelOrder_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void TimerQuery_Tick(object sender, EventArgs e)
        {
            try
            {
                while (!IsHandleCreated) ;
                MethodInvoker MethInvo = new MethodInvoker(DoQueryOrder);
                BeginInvoke(MethInvo);
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void GetUserInfo()
        {
            List<CommonData.UserMsgData> userlist = new List<CommonData.UserMsgData>();
            string retmsg;
            if (ReturnData.DoGetInfoByAccount(payData.Account, out retmsg, out userlist) == 0)
            {
                //Log.Debug("failure date time before : " + Global.userMsgData.FailureDateTime.ToLongDateString());
                if (userlist.Count > 0)
                    Global.userMsgData = userlist[0];
                //Log.Debug("failure date time after : " + Global.userMsgData.FailureDateTime.ToLongDateString());
            }
            else
            {
                throw new Exception("重新获取用户信息失败，请检查网络设置"+ retmsg);
            }
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        private void DoCancelOrder()
        {
            try
            {
                string retmsg;
                if (ReturnData.DoCancelPreOrder(payData.Account, payData.OrderNo, out retmsg) == 0)
                {
                    payData.IsPreCreate = false;
                }
                else
                {
                    throw new Exception(retmsg);
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 创建预下单
        /// </summary>
        private void DoCreatePerOrder()
        {
            try
            {
                string retmsg;
                string qrStr;
                string orderNo;
                if (ReturnData.DoPreCreate(Global.userMsgData.Account, payData.RenewalWay, out  retmsg, out  qrStr, out  orderNo) != 0)
                {
                    throw new Exception("预下单失败" + retmsg);
                }
                if (CreateQRCodeImg(qrStr) == 0)
                {
                    payData.QRStr = qrStr;
                    payData.OrderNo = orderNo;
                    payData.IsPreCreate = true;
                    payData.PreCreateDateTime = DateTime.Now;
                    timerQuery.Enabled = true;
                    //DoQueryOrder();
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        private void DoQueryOrder()
        {
            try
            {
                bool IsPay;
                string retmsg;
                if (ReturnData.DoQueryByOrder(payData.Account, payData.OrderNo, out retmsg, out IsPay) != 0)
                {
                    throw new Exception("查询订单失败" + retmsg);
                }
                else
                {
                    if (IsPay)
                    {
                        //支付完成
                        timerQuery.Enabled = false;
                        timer1.Enabled = false;
                        btnCreatQRCode.Enabled = true;
                        btnCancelOrder.Enabled = false;
                        TimeTick = 120;
                        lbTimeTick.Text = "0";
                        picQRCode.Image = null;
                        GetUserInfo();
                        lbFailrueDateTime.Text = Global.userMsgData.FailureDateTime.ToLongDateString();
                        MessageBox.Show("支付成功");
                        payData.IsPay = true;
                        payData.PayDateTime = DateTime.Now;
                    }
                    else
                    {
                        //支付未完成
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void PayForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void PayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //发送取消订单请求
            try
            {
                timerQuery.Enabled = false;
                timer1.Enabled = false;
                if (payData.IsPreCreate)
                {
                    DoCancelOrder();
                    //MethodInvoker MethInvo = new MethodInvoker(DoCancelOrder);
                    //BeginInvoke(MethInvo);
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void rbRenewal1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRenewal1.Checked)
            {
                lbPrice.Text = payInfoList[0].Price;
            }
        }

        private void rbRenewal2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRenewal2.Checked)
            {
                lbPrice.Text = payInfoList[1].Price;
            }
        }
    }
}
