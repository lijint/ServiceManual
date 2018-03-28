using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class UserInfoContrl : UserControl
    {
        List<CommonData.UserMsgData> userMsgList;
        public UserInfoContrl()
        {
            InitializeComponent();
        }
        private void UserInfoContrl_Load(object sender, EventArgs e)
        {
            userMsgList = new List<CommonData.UserMsgData>();
            GetAlUser();
            InitForm();
            DisplayUserMsg();
        }

        #region TestAddUserList
        private void TestAddUserList()
        {
            for (int i = 0; i < 10; i++)
            {
                CommonData.UserMsgData user = new CommonData.UserMsgData
                {
                    Account = "123456" + i,
                    UserName = "chenc",
                    CreateDateTime = DateTime.Now,
                    FailureDateTime = DateTime.Now.AddYears(1),
                    UpdateDateTime = DateTime.Now,
                    UserTel = "05916811111",
                    UserPermission = 1,
                    IsOnline = true,
                    StateCode = true
                };
                userMsgList.Add(user);
            }
        }
        #endregion

        private void InitForm()
        {
            lvUserList.FullRowSelect = true;
        }
        private int GetAlUser()
        {
            int ret = -1;
            string retmsg;
            try
            {
                ret = ReturnData.DoGetInfoByAccount("", out retmsg, out userMsgList);
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


        #region 刷新显示用户列表
        /// <summary>
        /// 刷新显示用户列表
        /// </summary>
        private void DisplayUserMsg()
        {
            try
            {
                lvUserList.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度  
                lvUserList.Items.Clear();
                foreach (CommonData.UserMsgData user in userMsgList)
                {
                    ListViewItem lvi = new ListViewItem
                    {
                        //lvUserList.Items.Add(user.Account);
                        Text = user.Account
                    };
                    //lvi.SubItems.Add(user.Account);
                    lvi.SubItems.Add(user.UserName);
                    lvi.SubItems.Add(user.CreateDateTime.ToString());
                    lvi.SubItems.Add(user.FailureDateTime.ToString());
                    lvi.SubItems.Add(user.UpdateDateTime.ToString());
                    lvi.SubItems.Add(user.UserTel);
                    //0表示没权限，1表示使用者，2表示管理员
                    switch (user.UserPermission)
                    {
                        case 0:
                            lvi.SubItems.Add("没权限");
                            break;
                        case 1:
                            lvi.SubItems.Add("普通用户");
                            break;
                        case 2:
                            lvi.SubItems.Add("管理员");
                            break;
                    }
                    lvi.SubItems.Add(user.IsOnline ? "在线" : "不在线");
                    lvi.SubItems.Add(user.StateCode ? "启用" : "禁用");
                    lvUserList.Items.Add(lvi);
                }
                lvUserList.EndUpdate();  //结束数据处理，UI界面一次性绘制。  
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                string resmsg;
                ManageUserForm manageUserForm = new ManageUserForm(1);
                DialogResult res = manageUserForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    userMsgList.Add(manageUserForm.userdata);
                    if (ReturnData.DoCreateUserInfo(manageUserForm.userdata, out  resmsg) != 0)
                    {
                        throw new Exception(resmsg);
                    }
                    DisplayUserMsg();
                    MessageBox.Show("添加成功");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModifyUser_Click(object sender, EventArgs e)
        {
            try
            {
                string resmsg;
                if (lvUserList.SelectedItems.Count == 0l)
                {
                    throw new Exception("请选择要修改的用户");
                }
                string SelectUserDataAccount = lvUserList.FocusedItem.SubItems[0].Text;

                CommonData.UserMsgData data = userMsgList.Find(
                    delegate (CommonData.UserMsgData outdata)
                    {
                        return outdata.Account == SelectUserDataAccount;
                    }
                );
                //CommonData.UserMsgData userdata = new CommonData.UserMsgData
                //{
                //    Account = lvUserList.FocusedItem.SubItems[0].Text,
                //    UserName = lvUserList.FocusedItem.SubItems[1].Text,
                //    CreateDateTime = DateTime.Parse(lvUserList.FocusedItem.SubItems[2].Text),
                //    FailureDateTime = DateTime.Parse(lvUserList.FocusedItem.SubItems[3].Text),
                //    UpdateDateTime = DateTime.Parse(lvUserList.FocusedItem.SubItems[4].Text),
                //    UserTel = lvUserList.FocusedItem.SubItems[5].Text,
                //    UserPermission = int.Parse(lvUserList.FocusedItem.SubItems[6].Text),
                //    IsOnline = bool.Parse(lvUserList.FocusedItem.SubItems[7].Text),
                //    StateCode = bool.Parse(lvUserList.FocusedItem.SubItems[8].Text)
                //};
                ManageUserForm manageUserForm = new ManageUserForm(2)
                {
                    userdata = data
                };
                DialogResult res = manageUserForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    data = manageUserForm.userdata;
                    int ret = ReturnData.DoSetUserInfo(data, out  resmsg);
                    if (ret != 0)
                    {
                        throw new Exception(resmsg);
                    }
                    DisplayUserMsg();
                    MessageBox.Show("修改成功");
                }
                //manageUserForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            try
            {
                string resmsg;
                if (lvUserList.SelectedItems.Count == 0)
                {
                    throw new Exception("请选择要删除的用户");
                }
                string SelectUserDataAccount = lvUserList.FocusedItem.SubItems[0].Text;
                string SelectUserDataName = lvUserList.FocusedItem.SubItems[1].Text;

                DialogResult res = MessageBox.Show("确定要删除 " + SelectUserDataName + " 用户吗？", "删除确认", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    if (ReturnData.DoDelUserInfo(SelectUserDataAccount, out  resmsg) != 0)
                    {
                        throw new Exception(resmsg);
                    }
                    CommonData.UserMsgData data = userMsgList.Find(delegate(CommonData.UserMsgData outdata)
                        {
                            return outdata.Account == SelectUserDataAccount;
                        }
                    );
                    userMsgList.Remove(data);
                    DisplayUserMsg();
                    MessageBox.Show("删除成功");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void LvUserList_DoubleClick(object sender, EventArgs e)
        {
            BtnModifyUser_Click(sender, e);
        }
    }
}
