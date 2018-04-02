using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class MainForm : Form
    {
        LoginForm myFather;
        //private PDFControl pdfControl;
        private WebBrowserControl webBrowserControl;
        private TxtControl txtControl;
        private PictureControl picControl;
        private PDFFoxControl pdfFoxControl;
        private PCBControl pcbControl;
        private WebControl webControl;

        public delegate void DoLogout_d();
        public delegate void ShowFile(TreeViewEventArgs e);
        public FileSystem fileSys;
        private bool IsNeedUpdateFile = false;   //true need   false noneed
        private List<CommonData.MainFormFile> LocalFileList;
        private List<CommonData.MainFormFile> SreachResFileList;

        public MainForm(LoginForm father)
        {
            InitializeComponent();
            this.Text = Global.MainFormTitle != null ? Global.MainFormTitle : "维修秘籍";
            myFather = father;
            InitContrl();
            this.WindowState = FormWindowState.Maximized;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                lbBeingPro.Location = new Point(this.Width / 2 - 300, this.Height / 2 - 100);
                BeingProcess(true);
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += initMainForm;
                bw.RunWorkerAsync();
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //MyInfoForm myinfo = new MyInfoForm();
                //myinfo.ShowDialog();
                BeingProcess(false);
                ShowAdd();
                LocalFileList.Clear();
                GetNodeValue(Global.SysFilePath, tv.Nodes);
                initFrom();

            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void initMainForm(object sender, DoWorkEventArgs e)
        {
            try
            {
                WriteWebBrowserRegKey("FEATURE_BROWSER_EMULATION", 10001, true);
                GetConfigInfo();
                lbAD.Location = new Point(this.Width / 2, 10);

                fileSys = new FileSystem();
                LocalFileList = new List<CommonData.MainFormFile>();
                SreachResFileList = new List<CommonData.MainFormFile>();
                InitFileSys();

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

        //方法需传入绝对路径，以及Treeview的Name的Nodes属性
        private void GetNodeValue(string path, TreeNodeCollection tc, bool IsFirst = true)
        {
            try
            {
                //加载选定文件夹下的文件的名字
                string[] FilePath = Directory.GetDirectories(path);
                tv.ImageList = filesIcons;
                //获得文件的名字
                string filename = string.Empty;
                //获得文件夹的名字
                for (int i = 0; i < FilePath.Length; i++)
                {
                    filename = Path.GetFileNameWithoutExtension(FilePath[i]);
                    if (filename == "temp")
                        continue;
                    if (IsFirst)
                    {
                        if (!Global.userMsgData.FilePermission.Contains(filename))
                        {
                            continue;
                        }
                    }
                    TreeNode tn = new TreeNode
                    {
                        Text = filename,
                        ImageIndex = IconIndexes.ClosedFolder,
                        SelectedImageIndex = IconIndexes.ClosedFolder,
                        Tag = CommonData.FileType.Folder
                    };
                    //在treeview节点下存下每个节点的路径
                    tc.Add(tn);
                    //if()
                    //这里遇到了递归，遇到文件夹，先进入文件夹里面去遍历，将大的tr，替换为小的tr
                    GetNodeValue(FilePath[i], tn.Nodes, false);
                }
                //因为目录名不能被点击，获得目录下的文件
                //获得文件夹下文件的名字，
                string[] Newfilepath = Directory.GetFiles(path);
                for (int i = 0; i < Newfilepath.Length; i++)
                {
                    //filename = Path.GetFileName(Newfilepath[i]);
                    CommonData.MainFormFile myfile = new CommonData.MainFormFile();
                    filename = Path.GetFileNameWithoutExtension(Newfilepath[i]);
                    if (Path.GetExtension(Newfilepath[i]) != ".temp")
                        continue;
                    TreeNode tn = new TreeNode
                    {
                        ImageIndex = -1
                    };

                    //取出文件拓展名
                    string filenameExtension = filename.Substring(filename.IndexOf('.') + 1);
                    CommonData.FileType fileType = GetFileType(filenameExtension);
                    switch (fileType)
                    {
                        case CommonData.FileType.Pdf:
                            {
                                tn.ImageIndex = IconIndexes.PDFFile;
                                tn.SelectedImageIndex = IconIndexes.PDFFile;
                            }
                            break;
                        case CommonData.FileType.Video:
                            {
                                tn.ImageIndex = IconIndexes.VideoFile;
                                tn.SelectedImageIndex = IconIndexes.VideoFile;
                            }
                            break;
                        case CommonData.FileType.TXT:
                            {
                                tn.ImageIndex = IconIndexes.TXTFile;
                                tn.SelectedImageIndex = IconIndexes.TXTFile;
                            }
                            break;
                        case CommonData.FileType.Image:
                            {
                                tn.ImageIndex = IconIndexes.PicFile;
                                tn.SelectedImageIndex = IconIndexes.PicFile;
                            }
                            break;
                        case CommonData.FileType.PCB:
                            {
                                tn.ImageIndex = IconIndexes.PCBFile;
                                tn.SelectedImageIndex = IconIndexes.PCBFile;
                            }
                            break;
                        case CommonData.FileType.Web:
                            {
                                tn.ImageIndex = IconIndexes.WebFile;
                                tn.SelectedImageIndex = IconIndexes.WebFile;
                            }
                            break;
                    }
                    tn.Text = Path.GetFileNameWithoutExtension(filename);
                    tn.Name = Newfilepath[i];
                    //在treeview节点下存下每个节点的路径
                    tn.Tag = fileType;
                    myfile.FileLocalPath = Newfilepath[i];
                    myfile.FileName = Path.GetFileNameWithoutExtension(filename);
                    myfile.FileType = fileType;
                    tc.Add(tn);
                    LocalFileList.Add(myfile);
                    //fileInfo.Add(tn.Text)
                    //}
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void Tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                //HideBox();
                TreeNode tn = e.Node;
                CommonData.FileType filetype = new CommonData.FileType();
                if (tn.Tag == null)
                    return;
                filetype = (CommonData.FileType)tn.Tag;
                string filepath = tn.Name;
                if (filetype != CommonData.FileType.Folder && filetype != CommonData.FileType.None)
                {
                    string name = tn.Text;
                    string fullPath = Global.SysFilePath + "\\" + tn.FullPath;
                    webBrowserControl.ClearVideo();
                    switch (filetype)
                    {
                        case CommonData.FileType.Pdf:
                            {

                                //pdfControl.DisplayPDFFile(filepath);
                                pdfFoxControl.DisplayPDFFile(filepath);
                                MyPanel.Controls.Clear();
                                MyPanel.Controls.Add(pdfFoxControl);
                                IsPicOrTxt(false);
                            }
                            break;
                        case CommonData.FileType.Video:
                            {
                                //INIClass ini = new INIClass(fullPath + ".temp");
                                INIClass ini = new INIClass(filepath);
                                string videoValue = ini.IniReadValue("MyVideoMsg", "VideoPath");
                                if (!string.IsNullOrEmpty(videoValue))
                                {
                                    webBrowserControl.SetVideoValue(videoValue);
                                    MyPanel.Controls.Clear();
                                    MyPanel.Controls.Add(webBrowserControl);
                                    IsPicOrTxt(false);
                                }
                                else
                                {
                                    throw new Exception("视频地址为空");
                                }
                            }
                            break;
                        case CommonData.FileType.TXT:
                            {
                                //txtControl.DisplayTxt(fullPath + ".temp");
                                txtControl.DisplayTxt(filepath);
                                MyPanel.Controls.Clear();
                                MyPanel.Controls.Add(txtControl);
                                IsPicOrTxt(false);
                            }
                            break;
                        case CommonData.FileType.Image:
                            {
                                picControl.SetPicPath(filepath);
                                MyPanel.Controls.Clear();
                                MyPanel.Controls.Add(picControl);
                                IsPicOrTxt(true);
                            }
                            break;
                        case CommonData.FileType.PCB:
                            {

                                pcbControl.ShowPcb(filepath);
                                MyPanel.Controls.Clear();
                                MyPanel.Controls.Add(pcbControl);
                                IsPicOrTxt(false);
                            }
                            break;
                        case CommonData.FileType.Web:
                            {
                                INIClass ini = new INIClass(filepath);
                                string url = ini.IniReadValue("MyWebMsg", "URL");
                                webControl.DisplayWeb(url);
                                MyPanel.Controls.Clear();
                                MyPanel.Controls.Add(webControl);
                                IsPicOrTxt(false);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }


        private void InitFileSys()
        {
            try
            {
                fileSys.InitFileList();
                fileSys.fileListLocal.DataList.Clear();
                fileSys.fileListAccept.DataList.Clear();
                fileSys.SetLocalFileList(Global.SysFilePath);
                fileSys.GetServerFileList(Global.userMsgData.Account);

                if (fileSys.fileListAccept.DataList.Count != 0)
                    IsNeedUpdateFile = fileSys.MatchFilePath();

                if (IsNeedUpdateFile)
                {
                    if (MessageBox.Show("文件需要更新！点击确定更新文件。") == DialogResult.OK)
                    {
                        //更新文件
                        //Thread t_UpdateFile = new Thread(new ThreadStart(DoUpdateFile));
                        BeingUpdateFile updateForm = new BeingUpdateFile(fileSys);
                        DialogResult dr = updateForm.ShowDialog();
                        fileSys.DelAllTempFile(Global.SysFilePath);
                        fileSys.fileListLocal.DataList.Clear();
                        fileSys.SetLocalFileList(Global.SysFilePath);
                        if (dr != DialogResult.Yes)
                            MessageBox.Show("文件未更新完成，请再次操作");
                        else
                            MessageBox.Show("文件更新完成，欢迎使用！");
                    }
                }
                //else
                //    MessageBox.Show("文件初始化完毕，欢迎使用！");
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        public static void WriteWebBrowserRegKey(string regkeyname, int regkeyvalue, bool bIsUse)
        {
            RegistryKey reg = null;
            try
            {
                reg = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\" + regkeyname, true);
                if (reg == null)
                    reg = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\" + regkeyname);
                string applicationname = Application.ProductName + @".exe";
                if (bIsUse)
                {
                    reg.SetValue(applicationname, regkeyvalue, RegistryValueKind.DWord);
                }
                else
                {
                    reg.DeleteValue(applicationname, false);
                }

            }
            catch (System.Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);

            }
            finally
            {
                if (reg != null)
                    reg.Close();
            }
        }

        public void DoLogout()
        {
            string retMsg;
            try
            {
                int res = ReturnData.DoLogout(Global.userMsgData.Account, out retMsg);
                FileSystem fs = new FileSystem();
                ClearAllControl();
                fs.DelAllTempFile(Global.SysFilePath);
                if (res != 0)
                    throw new Exception(retMsg);
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void Closeingcall(IAsyncResult ar)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 检测是否文件需要更新
        /// </summary>
        private void CheckFileUpdate()
        {
            //if (fileSys.fileListLocal.DataList.Count == 0)
            fileSys.fileListLocal.DataList.Clear();
            fileSys.fileListAccept.DataList.Clear();
            //if (fileSys.fileListAccept.DataList.Count == 0)
            fileSys.SetLocalFileList(Global.SysFilePath);
            fileSys.GetServerFileList(Global.userMsgData.Account);

            if (fileSys.fileListLocal.DataList.Count != 0 && fileSys.fileListAccept.DataList.Count != 0)
                IsNeedUpdateFile = fileSys.MatchFilePath();
            else
                throw new Exception("localList or acceptList is null");
        }
        private void InitContrl()
        {
            try
            {
                webBrowserControl = new WebBrowserControl();
                txtControl = new TxtControl();
                picControl = new PictureControl();
                pdfFoxControl = new PDFFoxControl();
                pcbControl = new PCBControl();
                webControl = new WebControl();

                NewControl<WebBrowserControl>(ref webBrowserControl);
                NewControl<TxtControl>(ref txtControl);
                NewControl<PictureControl>(ref picControl);
                NewControl<PDFFoxControl>(ref pdfFoxControl);
                NewControl<PCBControl>(ref pcbControl);
                NewControl<WebControl>(ref webControl);

                IsPicOrTxt(false);
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void NewControl<T>(ref T t) where T : Control
        {
            t.Width = MyPanel.Width;
            t.Height = MyPanel.Height;
            t.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private CommonData.FileType GetFileType(string FileExName)
        {
            CommonData.FileType fileType = new CommonData.FileType();
            try
            {
                switch (FileExName)
                {
                    case "pdf":
                        fileType = CommonData.FileType.Pdf;
                        break;
                    case "txt":
                        fileType = CommonData.FileType.TXT;
                        break;
                    case "ini":
                        fileType = CommonData.FileType.Video;
                        break;
                    case "jpg":
                    case "bmp":
                    case "png":
                        fileType = CommonData.FileType.Image;
                        break;
                    case "pcb":
                        fileType = CommonData.FileType.PCB;
                        break;
                    case "webini":
                        fileType = CommonData.FileType.Web;
                        break;
                    default:
                        fileType = CommonData.FileType.None;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                MessageBox.Show(ex.Message);
            }
            return fileType;
        }

        private void ClearAllControl()
        {
            try
            {
                picControl.ClearPic();
                pdfFoxControl.ClearPdf();
            }
            catch
            {
                throw;
            }
        }

        private void IsPicOrTxt(bool ispicortxt)
        {
            if (ispicortxt)
            {
                //BtnPlus.Image = Image.FromFile(@"zoom in.png");
                //BtnPlus.FlatAppearance.BorderSize = 0;
                //BtnCut.Image = Image.FromFile(@"Resources\zoom in.png");
                BtnPlus.Show();
                BtnCut.Show();
            }
            else
            {
                BtnPlus.Hide();
                BtnCut.Hide();
            }
        }
        private void DisplaySreachResFileList(List<CommonData.MainFormFile> filelist)
        {
            try
            {
                Log.Info("display sreach result");
                if (filelist.Count > 0)
                {
                    while (tv.Nodes.Count > 1)
                        tv.Nodes[tv.Nodes.Count - 1].Remove();
                    foreach (CommonData.MainFormFile mf in filelist)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = mf.FileName;
                        tn.Name = mf.FileLocalPath;
                        tn.Tag = mf.FileType;
                        switch (mf.FileType)
                        {
                            case CommonData.FileType.Pdf:
                                {
                                    tn.ImageIndex = IconIndexes.PDFFile;
                                    tn.SelectedImageIndex = IconIndexes.PDFFile;
                                }
                                break;
                            case CommonData.FileType.Video:
                                {
                                    tn.ImageIndex = IconIndexes.VideoFile;
                                    tn.SelectedImageIndex = IconIndexes.VideoFile;
                                }
                                break;
                            case CommonData.FileType.TXT:
                                {
                                    tn.ImageIndex = IconIndexes.TXTFile;
                                    tn.SelectedImageIndex = IconIndexes.TXTFile;
                                }
                                break;
                            case CommonData.FileType.Image:
                                {
                                    tn.ImageIndex = IconIndexes.PicFile;
                                    tn.SelectedImageIndex = IconIndexes.PicFile;
                                }
                                break;
                            case CommonData.FileType.PCB:
                                {
                                    tn.ImageIndex = IconIndexes.PCBFile;
                                    tn.SelectedImageIndex = IconIndexes.PCBFile;
                                }
                                break;
                        }
                        tv.Nodes.Add(tn);
                    }
                }
                else
                {
                    throw new Exception("文件列表为空");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }

        private int SreachFile(List<CommonData.MainFormFile> infilelist, out List<CommonData.MainFormFile> outfilelist, string sreachInfo)
        {
            int res = -1;
            outfilelist = new List<CommonData.MainFormFile>();
            try
            {
                if (infilelist.Count > 0)
                {
                    foreach (CommonData.MainFormFile mf in infilelist)
                    {
                        if (mf.FileName.Contains(sreachInfo))
                        {
                            outfilelist.Add(mf);
                        }
                    }
                    res = 0;
                }
                else
                {
                    throw new Exception("输入文件列表为空");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                res = -1;
            }
            return res;
        }
        private void ShowAdd()
        {
            try
            {
                if (string.IsNullOrEmpty(Global.ConfigInfoList[Global.ConfigInfo.WebAddAddr]))
                {
                    MessageBox.Show("广告地址未配置");
                }
                else
                {
                    WebForm wf = new WebForm();
                    wf.Show();
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
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
                Global.ConfigInfoList.Clear();
                throw new Exception(resmsg);
            }
            else
            {
                Global.ConfigInfoList.Clear();
                Global.ConfigInfoList = config;
            }
        }

        private void initFrom()
        {
            try
            {
                lbAD.Text = Global.ConfigInfoList[Global.ConfigInfo.YeMeiMsg];
                string initFilePath = Global.ConfigInfoList[Global.ConfigInfo.InitAddr];

                if (string.IsNullOrEmpty(initFilePath))
                    return;
                string fullpath = Application.StartupPath + "\\" + initFilePath.Substring(initFilePath.IndexOf("File"));
                string tempstr = Path.GetFileNameWithoutExtension(initFilePath);
                string filenameExtension = tempstr.Substring(tempstr.IndexOf('.') + 1);
                initFilePath = fullpath.Substring(0, fullpath.LastIndexOf("."))+".temp";
                TreeNode tn = new TreeNode();
                //取出文件拓展名
                //string filenameExtension = Path.GetFileNameWithoutExtension(initFilePath).Substring(initFilePath.IndexOf('.') + 1);
                CommonData.FileType fileType = GetFileType(filenameExtension);
                switch (fileType)
                {
                    case CommonData.FileType.Pdf:
                        {

                            //pdfControl.DisplayPDFFile(filepath);
                            pdfFoxControl.DisplayPDFFile(initFilePath);
                            MyPanel.Controls.Clear();
                            MyPanel.Controls.Add(pdfFoxControl);
                            IsPicOrTxt(false);
                        }
                        break;
                    case CommonData.FileType.Video:
                        {
                            //INIClass ini = new INIClass(fullPath + ".temp");
                            INIClass ini = new INIClass(initFilePath);
                            string videoValue = ini.IniReadValue("MyVideoMsg", "VideoPath");
                            if (!string.IsNullOrEmpty(videoValue))
                            {
                                //webBrowserControl.SetVideoValue(videoValue);
                                MyPanel.Controls.Clear();
                                MyPanel.Controls.Add(webBrowserControl);
                                IsPicOrTxt(false);
                            }
                            else
                            {
                                throw new Exception("视频地址为空");
                            }
                        }
                        break;
                    case CommonData.FileType.TXT:
                        {
                            //txtControl.DisplayTxt(fullPath + ".temp");
                            txtControl.DisplayTxt(initFilePath);
                            MyPanel.Controls.Clear();
                            MyPanel.Controls.Add(txtControl);
                            IsPicOrTxt(false);
                        }
                        break;
                    case CommonData.FileType.Image:
                        {
                            picControl.SetPicPath(initFilePath);
                            MyPanel.Controls.Clear();
                            MyPanel.Controls.Add(picControl);
                            IsPicOrTxt(true);
                        }
                        break;
                    case CommonData.FileType.PCB:
                        {
                            pcbControl.ShowPcb(initFilePath);
                            MyPanel.Controls.Clear();
                            MyPanel.Controls.Add(pcbControl);
                            IsPicOrTxt(false);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void BeingProcess(bool flag)
        {
            if (flag)
            {
                lbBeingPro.Show();
            }
            else
            {
                lbBeingPro.Hide();
            }
            btnFile.Enabled = !flag;
            btnMine.Enabled = !flag;
            btnSreach.Enabled = !flag;
        }
        #region Event
        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                PayForm payform = new PayForm();
                payform.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //MyPanel.Controls.Clear();
                DoLogout_d d = new DoLogout_d(DoLogout);
                d.BeginInvoke(new AsyncCallback(Closeingcall), null);
                this.Hide();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdateFile_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAllControl();
                CheckFileUpdate();
                if (IsNeedUpdateFile)
                {
                    BeingUpdateFile updateForm = new BeingUpdateFile(fileSys);
                    DialogResult dr = updateForm.ShowDialog();
                    //int res = fileSys.DoUpdateFileList();
                    if (dr != DialogResult.Yes)
                        throw new Exception("文件未更新完成，请再次操作");
                    while (tv.Nodes.Count > 1)
                        tv.Nodes[tv.Nodes.Count - 1].Remove();
                    LocalFileList.Clear();
                    GetNodeValue(Global.SysFilePath, tv.Nodes);
                    MessageBox.Show("更新完成");
                }
                else
                    MessageBox.Show("当前文件无需更新！");
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMyInfo_Click(object sender, EventArgs e)
        {
            try
            {
                MyInfoForm myInfoForm = new MyInfoForm();
                DialogResult ret = myInfoForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChangePsd_Click(object sender, EventArgs e)
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

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            if (this.MyPanel.Controls[0] == picControl)
            {
                picControl.btnPicAdd_Click();
            }
        }

        private void BtnCut_Click(object sender, EventArgs e)
        {
            if (this.MyPanel.Controls[0] == picControl)
            {
                picControl.btnPicCut_Click();
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                //pdfControl.Width = MyPanel.Width;
                //pdfControl.Height = MyPanel.Height;
                //pdfControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                pdfFoxControl.Width = MyPanel.Width;
                pdfFoxControl.Height = MyPanel.Height;
                pdfFoxControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                webBrowserControl.Width = MyPanel.Width;
                webBrowserControl.Height = MyPanel.Height;
                webBrowserControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                txtControl.Width = MyPanel.Width;
                txtControl.Height = MyPanel.Height;
                txtControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                picControl.Width = MyPanel.Width;
                picControl.Height = MyPanel.Height;
                picControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                pcbControl.Width = MyPanel.Width;
                pcbControl.Height = MyPanel.Height;
                pcbControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                webControl.Width = MyPanel.Width;
                webControl.Height = MyPanel.Height;
                webControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            }
            catch (Exception ex)
            {
                Log.Error("[" + MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSreach_Click(object sender, EventArgs e)
        {
            try
            {
                string txtStr = textBox1.Text;
                if (!string.IsNullOrEmpty(txtStr))
                {
                    SreachResFileList.Clear();
                    int res = SreachFile(LocalFileList, out SreachResFileList, textBox1.Text);
                    if (res == 0)
                    {
                        DisplaySreachResFileList(SreachResFileList);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                while (tv.Nodes.Count > 1)
                    tv.Nodes[tv.Nodes.Count - 1].Remove();
                LocalFileList.Clear();
                GetNodeValue(Global.SysFilePath, tv.Nodes);
                return;
            }
        }

        private void btnChangeSkin_Click(object sender, EventArgs e)
        {
            //ChangeSkin changeSkin = new ChangeSkin();
            //changeSkin.ShowDialog();
        }

        #endregion

    }
}
