using System;
using System.Collections.Generic;

namespace ServiceManual
{
    public class ReturnData
    {
        #region Login
        /// <summary>
        /// 登录验证密码
        /// </summary>
        /// <param name="account"></param>
        /// <param name="passWord"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoCheckPsw(string account, string passWord, out string retmsg,out int StateCodeID)
        {
            int res = -1;
//#if DEBUG
//            if (account == "1")
//            {
//                res = 0;
//                StateCodeID = 0;
//                Global.userMsgData.UserPermission = int.Parse(account);
//                retmsg = "调试状态，普通用户账号！";
//            }
//            else if (account == "2")
//            {
//                res = 0;
//                StateCodeID = 0;
//                Global.userMsgData.UserPermission = int.Parse(account);
//                retmsg = "调试状态，管理员账号！";
//            }
//            else
//            {
//                retmsg = "调试状态，无此账号！";
//                StateCodeID = -1;
//            }
//            return res;

//#endif
            try
            {
                StateCodeID = -1;
                WRLogin.LoginWebService ws = new WRLogin.LoginWebService();
                RecvRes retres = TransRes(ws.Login(account, passWord));
                retmsg = retres.Description;
                StateCodeID = retres.StateCodeID;
                if (retres.IsOK)
                {
                    try
                    {
                        Global.userMsgData.UserPermission = int.Parse(retres.ExtData);
                    }
                    catch
                    {
                        throw new Exception("用户权限解析错误");
                    }
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                StateCodeID = -1;
                throw;
            }
            return res;
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoLogout(string account, out string retmsg)
        {
            int res = -1;
            try
            {
                WRLogin.LoginWebService ws = new WRLogin.LoginWebService();
                RecvRes retres = TransRes(ws.UpdateOnLineStatus(account));
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="account"></param>
        /// <param name="oldpsd"></param>
        /// <param name="newpsd"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoChangePsd(string account, string oldpsd, string newpsd, out string retmsg)
        {
            int res = -1;
            try
            {
                WRLogin.LoginWebService ws = new WRLogin.LoginWebService();
                RecvRes retres = TransRes(ws.ChangePassword(account, oldpsd, newpsd));
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }

        #endregion

        #region file
        /// <summary>
        /// 更新文件列表
        /// </summary>
        /// <param name="retmsg"></param>
        /// <param name="filedata"></param>
        /// <returns></returns>
        public static int DoUpdateFileList(string account, out string retmsg, out CommonData.FileData filedata)
        {
            int res = -1;
            try
            {
                WRFileUpdate.UpdateFileWebService ws = new WRFileUpdate.UpdateFileWebService();
                RecvRes retres = TransRes(ws.GetUpdateFileList(account));
                retmsg = retres.Description;
                filedata = null;

                if (retres.IsOK)
                {
                    if (!string.IsNullOrEmpty(retres.ExtData))
                    {
                        string jsondata = retres.ExtData;
                        filedata = JsonDeal.JsonData2FileData(jsondata);
                        res = 0;
                    }
                    else
                    {
                        throw new Exception("accpect extData is null");
                    }
                }
            }
            catch (Exception ex)
            {
                filedata = null;

                retmsg = ex.Message;
                throw;
            }
            return res;
        }

        /// <summary>
        /// 获取所有权限文件夹名称
        /// </summary>
        /// <param name="data"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoGetFilePermissionList(out List<CommonData.FilePermission> FilePermission, out string retmsg)
        {
            int res = -1;
            try
            {
                FilePermission = null;
                WRFileUpdate.UpdateFileWebService ws = new WRFileUpdate.UpdateFileWebService();
                RecvRes retres = TransRes(ws.GetFilePermissionList());
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    FilePermission = JsonDeal.JsonData2FilePermissionlist(retres.ExtData);
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                FilePermission = null;
                retmsg = ex.Message;
                throw;
            }
            return res;
        }

        #endregion
        
        #region UserInfo
        /// <summary>
        /// 根据账号获取用户信息（若账号为空，获取全部用户信息）
        /// </summary>
        /// <param name="account"></param>
        /// <param name="retmsg"></param>
        /// <param name="userList">返回的用户信息列表</param>
        /// <returns></returns>
        public static int DoGetInfoByAccount(string account, out string retmsg, out List<CommonData.UserMsgData> userList)
        {
            int res = -1;
            try
            {
                WRLogin.LoginWebService ws = new WRLogin.LoginWebService();
                RecvRes retres = TransRes(ws.GetInfoByAccount(account));
                retmsg = retres.Description;
                //userList = null;
                if (retres.IsOK)
                {
                    if (!string.IsNullOrEmpty(retres.ExtData))
                    {
                        string jsondata = retres.ExtData;
                        userList = JsonDeal.JsonData2UserMsgListData(jsondata);
                        res = 0;
                    }
                    else
                    {
                        throw new Exception("accpect extData is null");
                    }
                    res = 0;
                }
                else
                {
                    userList = null;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                userList = null;
                throw;
            }
            return res;
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoSetUserInfo(CommonData.UserMsgData data, out string retmsg)
        {
            int res = -1;
            try
            {
                WRLogin.LoginWebService ws = new WRLogin.LoginWebService();
                RecvRes retres = TransRes(ws.EditeAccountInfo(data.Account, data.PassWord, data.UserName, data.FailureDateTime.ToString(), data.UserTel, data.UserPermission.ToString(), data.StateCode.ToString(), data.FilePermission));
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }

        /// <summary>
        /// 创建用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoCreateUserInfo(CommonData.UserMsgData data, out string retmsg)
        {
            int res = -1;
            try
            {
                WRLogin.LoginWebService ws = new WRLogin.LoginWebService();
                RecvRes retres = TransRes(ws.CreateAccount(data.Account, data.PassWord, data.UserName, data.FailureDateTime.ToString(), data.UserTel, data.UserPermission.ToString(), data.StateCode.ToString(), data.FilePermission));
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }
        /// <summary>
        /// 创建用户信息
        /// </summary>
        /// <param name="data"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoDelUserInfo(string data, out string retmsg)
        {
            int res = -1;
            try
            {
                WRLogin.LoginWebService ws = new WRLogin.LoginWebService();
                RecvRes retres = TransRes(ws.DeleteAccount(data));
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }

        #endregion

        #region AliPay

        /// <summary>
        /// 预下单获取支付地址与订单号
        /// </summary>
        /// <param name="account"></param>
        /// <param name="renewalWay"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoPreCreate(string account, string renewalWay, out string retmsg,out string QRStr,out string orderNo)
        {
            int res = -1;
            try
            {
                WRAliPay.AliPayWebService ws = new WRAliPay.AliPayWebService();
                RecvRes retres = TransRes(ws.PreCreate(account, renewalWay));
                retmsg = retres.Description;
                QRStr = "";
                orderNo = "";
                if (retres.IsOK)
                {
                    if (!string.IsNullOrEmpty(retres.ExtData))
                    {
                        QRStr = retres.ExtData;
                        if(!string.IsNullOrEmpty(retres.SucceedDescription))
                        {
                            orderNo = retres.SucceedDescription;
                            res = 0;
                        }
                    }
                    else
                    {
                        throw new Exception("accpect extData is null");
                    }
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }

        /// <summary>
        /// 查询订单是否已付款
        /// </summary>
        /// <param name="account"></param>
        /// <param name="orderNum"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoQueryByOrder(string account, string orderNum, out string retmsg, out bool IsPay)
        {
            int res = -1;
            try
            {
                IsPay = false;
                WRAliPay.AliPayWebService ws = new WRAliPay.AliPayWebService();
                RecvRes retres = TransRes(ws.QueryByOrderNo(account, orderNum));
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    if (retres.StateCodeID == 1)
                    {
                        IsPay = true;
                    }
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }


        /// <summary>
        /// 取消预下单
        /// </summary>
        /// <param name="account"></param>
        /// <param name="orderNum"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoCancelPreOrder(string account, string orderNum, out string retmsg)
        {
            int res = -1;
            try
            {
                WRAliPay.AliPayWebService ws = new WRAliPay.AliPayWebService();
                RecvRes retres = TransRes(ws.CancelPreOrder(account, orderNum));
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }


        /// <summary>
        /// 设置客户端参数
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoSetConfigInfo(Dictionary<Global.ConfigInfo, string> configlist, out string retmsg)
        {
            int res = -1;
            try
            {
                string jsonStr = JsonDeal.ConfigInfolist2JsonData(configlist);
                WRAliPay.AliPayWebService ws = new WRAliPay.AliPayWebService();
                RecvRes retres = TransRes(ws.SetNetConfigInfo(jsonStr));
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    //配置成功
                    res = 0;
                }
                else
                {
                    throw new Exception("配置参数失败");
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }

        /// <summary>
        /// 获取客户端参数配置
        /// </summary>
        /// <param name="configlist"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoGetConfiginfo(out Dictionary<Global.ConfigInfo, string> configlist, out string retmsg)
        {
            int res = -1;
//#if DEBUG
//            configlist = new Dictionary<Global.ConfigInfo, string>();
//            configlist.Add(Global.ConfigInfo.FtpPath, "39.108.188.162");
//            configlist.Add(Global.ConfigInfo.InitAddr, "");
//            configlist.Add(Global.ConfigInfo.WebAddAddr, "www.baidu.com");
//            configlist.Add(Global.ConfigInfo.YeMeiMsg, "维修秘籍");
//            retmsg = "调试状态，获取客户端参数配置返回成功！";
//            res = 0;
//            return res;
//#endif
            try
            {
                WRAliPay.AliPayWebService ws = new WRAliPay.AliPayWebService();
                RecvRes retres = TransRes(ws.GetNetConfigInfo());
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    //string jsonStr = JsonDeal.JsonData2ConfigInfolist(Global.ConfigInfoList);
                    if (!string.IsNullOrEmpty(retres.ExtData))
                    {
                        string jsondata = retres.ExtData;
                        configlist = JsonDeal.JsonData2ConfigInfolist(jsondata);
                        res = 0;
                    }
                    else
                    {
                        throw new Exception("accpect ConfigData is null");
                    }
                    res = 0;
                }
                else
                {
                    configlist = null;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                configlist = null;
                throw;
            }
            return res;
        }

        /// <summary>
        /// 设置支付参数
        /// </summary>
        /// <param name="priceF"></param>
        /// <param name="renewalTimeF"></param>
        /// <param name="priceS"></param>
        /// <param name="renewalTimeS"></param>
        /// <param name="retmsg"></param>
        /// <returns></returns>
        public static int DoSetPayPrarms(string priceF, string renewalTimeF, string priceS, string renewalTimeS, out string retmsg)
        {
            int res = -1;
            try
            {
                WRAliPay.AliPayWebService ws = new WRAliPay.AliPayWebService();
                RecvRes retres = TransRes(ws.SetRenewalInfo(priceF, renewalTimeF, priceS, renewalTimeS));
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                throw;
            }
            return res;
        }

        public static int DoGetPayPrarms(out List<CommonData.PayPrarmsData> paylist, out string retmsg)
        {
            int res = -1;
            try
            {
                WRAliPay.AliPayWebService ws = new WRAliPay.AliPayWebService();
                RecvRes retres = TransRes(ws.GetRenewalPriceInfo());
                retmsg = retres.Description;
                if (retres.IsOK)
                {
                    if (!string.IsNullOrEmpty(retres.ExtData))
                    {
                        string jsondata = retres.ExtData;
                        paylist = JsonDeal.JsonData2PayInfolist(jsondata);
                        res = 0;
                    }
                    else
                    {
                        throw new Exception("accpect PayPrarmData is null");
                    }
                }
                else
                {
                    paylist = null;
                }
            }
            catch (Exception ex)
            {
                retmsg = ex.Message;
                paylist = null;
                throw;
            }
            return res;
        }



        #endregion

        private static RecvRes TransRes(WRLogin.Result res)
        {
            RecvRes loginRes = new RecvRes
            {
                Description = res.Description,
                ExtData = res.ExtData,
                FailDescription = res.FailDescription,
                FailNum = res.FailNum,
                IsOK = res.IsOK,
                Num = res.Num,
                StateCodeID = res.StateCodeID,
                SucceedDescription = res.SucceedDescription,
                SucceedNum = res.SucceedNum
            };
            return loginRes;
        }
        private static RecvRes TransRes(WRFileUpdate.Result res)
        {
            RecvRes loginRes = new RecvRes
            {
                Description = res.Description,
                ExtData = res.ExtData,
                FailDescription = res.FailDescription,
                FailNum = res.FailNum,
                IsOK = res.IsOK,
                Num = res.Num,
                StateCodeID = res.StateCodeID,
                SucceedDescription = res.SucceedDescription,
                SucceedNum = res.SucceedNum
            };
            return loginRes;
        }
        private static RecvRes TransRes(WRAliPay.Result res)
        {
            RecvRes loginRes = new RecvRes
            {
                Description = res.Description,
                ExtData = res.ExtData,
                FailDescription = res.FailDescription,
                FailNum = res.FailNum,
                IsOK = res.IsOK,
                Num = res.Num,
                StateCodeID = res.StateCodeID,
                SucceedDescription = res.SucceedDescription,
                SucceedNum = res.SucceedNum
            };
            return loginRes;
        }


        private class RecvRes
        {
            // 摘要:
            //     结果描述属性
            public string Description { get; set; }
            //
            // 摘要:
            //     扩展数据属性
            public string ExtData { get; set; }
            //
            // 摘要:
            //     失败结果描述属性
            public string FailDescription { get; set; }
            //
            // 摘要:
            //     执行失败次数属性
            public int FailNum { get; set; }
            //
            // 摘要:
            //     是否执行成功属性
            public bool IsOK { get; set; }
            //
            // 摘要:
            //     执行次数属性
            public int Num { get; set; }
            //
            // 摘要:
            //     状态参数标识属性
            public int StateCodeID { get; set; }
            //
            // 摘要:
            //     成功结果描述属性
            public string SucceedDescription { get; set; }
            //
            // 摘要:
            //     执行成功次数属性
            public int SucceedNum { get; set; }
        }
    }
}
