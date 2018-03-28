using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ServiceManual
{
    public class FileSystem
    {
        public CommonData.FileData fileListLocal;
        public CommonData.FileData fileListAccept;
        public CommonData.FileData fileListAdd;
        public CommonData.FileData fileListUpdate;
        public CommonData.FileData fileListDelete;

        public void InitFileList()
        {
            fileListLocal = new CommonData.FileData();
            fileListAccept = new CommonData.FileData();
            fileListAdd = new CommonData.FileData();
            fileListUpdate = new CommonData.FileData();
            fileListDelete = new CommonData.FileData();
        }

        /// <summary>
        /// 从本地文件中读取文件信息，放进locallist列表
        /// </summary>
        /// <param name="path"></param>
        public void SetLocalFileList(string path)
        {
            try
            {
                string[] FilePath = Directory.GetDirectories(path);
                string filename = string.Empty;
                for (int i = 0; i < FilePath.Length; i++)
                {
                    SetLocalFileList(FilePath[i]);
                }
                string[] Newfilepath = Directory.GetFiles(path);
                for (int i = 0; i < Newfilepath.Length; i++)
                {
                    filename = Path.GetFullPath(Newfilepath[i]);
                    string fileRealName = Path.GetDirectoryName(Newfilepath[i]) + "\\" + Path.GetFileNameWithoutExtension(Newfilepath[i]);
                    string fileExName = Path.GetExtension(Newfilepath[i]);
                    if (string.Compare(fileExName, ".xxx") == 0)
                    {
                        string fileTempName = fileRealName + ".temp";

                        DESFileClass.DecryptFile(filename, fileTempName, Global.FileEnKey);
                        CommonData.Data data = new CommonData.Data
                        {
                            FilePath = fileRealName,
                            FileMD5 = GetMD5Content(fileTempName),
                            FileURL = ""
                        };
                        fileListLocal.DataList.Add(data);
                    }
                }
                string sysPath = System.Windows.Forms.Application.StartupPath;
            }
            catch(Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                throw;
            }
        }

        /// <summary>
        /// 获取服务器上filelist
        /// </summary>
        public void GetServerFileList()
        {
            //fileListAccpect = new CommonData.FileData();
            try
            {
                string resmsg;
                int res = ReturnData.DoUpdateFileList(out resmsg, out fileListAccept);

                if (res != 0)
                {
                    throw new Exception("更新文件出错");
                }
            }
            catch(Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                throw;
            }
        }

        /// <summary>
        /// 对比本地文件列表和服务器上文件列表，找出需要更新、删除、添加的文件
        /// </summary>
        /// <returns>返回是否需要更新文件true--需要更新</returns>
        public bool MatchFilePath()
        {
            bool res = false;

            try
            {
                foreach (CommonData.Data d in fileListLocal.DataList)
                {
                    fileListDelete.DataList.Add(d);
                }
                foreach (CommonData.Data d in fileListAccept.DataList)
                {
                    fileListAdd.DataList.Add(d);
                }
                //fileListAdd.DataList = fileListAccept.DataList;
                //fileListDelete.DataList = fileListLocal.DataList;

                foreach (CommonData.Data d in fileListAccept.DataList)
                {
                    foreach (CommonData.Data t in fileListLocal.DataList)
                    {
                        if (string.Compare(Application.StartupPath + "\\" + d.FilePath, t.FilePath) == 0)
                        {
                            if (string.Compare(d.FileMD5, t.FileMD5) != 0)
                            {
                                //修改，更新
                                fileListUpdate.DataList.Add(d);
                            }

                            fileListDelete.DataList.Remove(t);
                            fileListAdd.DataList.Remove(d);
                            break;
                        }
                    }
                }

                if (fileListDelete.DataList.Count != 0 || fileListAdd.DataList.Count != 0 || fileListUpdate.DataList.Count != 0)
                    res = true;
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                throw;
            }
            return res;
        }

        public int DoUpdateFileList(BeingUpdateFile beingupdateform)
        {
            int res = -1;
            bool stepIsOk = true;
            try
            {
                //fileListLocal.DataList=fileListUpdate.DataList+fileListAdd.DataList;
                if (fileListUpdate.DataList.Count != 0 && fileListDelete.DataList.Count != 0 && fileListAdd.DataList.Count != 0)
                    return res;
                int totalCount = fileListUpdate.DataList.Count * 2 + fileListDelete.DataList.Count + fileListAdd.DataList.Count;
                beingupdateform.SetMaxValue(10000 * (totalCount - 1)/totalCount);
                int index = 0;
                if (fileListUpdate.DataList.Count != 0)
                {
                    foreach (CommonData.Data d in fileListUpdate.DataList)
                    {
                        CommonData.Data delData = FindDataByPath(fileListLocal, d.FilePath);
                        if (delData != null)
                        {
                            //int index = fileListLocal.DataList.IndexOf();
                            if (File.Exists(delData.FilePath + ".xxx"))
                            {
                                File.Delete(delData.FilePath + ".xxx");
                                fileListLocal.DataList.Remove(delData);
                                fileListAdd.DataList.Add(d);
                                if(File.Exists(delData.FilePath + ".temp"))
                                {
                                    File.Delete(delData.FilePath + ".temp");
                                }
                                beingupdateform.SetTextMessage(10000 * index++ / totalCount);
                            }
                            else
                            {
                                stepIsOk = false;
                                break;
                            }
                        }
                    }
                    if(stepIsOk)
                        fileListUpdate.DataList.Clear();
                }

                if (fileListDelete.DataList.Count != 0)
                {
                    foreach (CommonData.Data d in fileListDelete.DataList)
                    {
                        CommonData.Data data = FindDataByPath(fileListLocal, d.FilePath);
                        if (data != null)
                        {
                            //int index = fileListLocal.DataList.IndexOf();
                            if (File.Exists(data.FilePath + ".xxx"))
                            {
                                File.Delete(data.FilePath + ".xxx");
                                fileListLocal.DataList.Remove(data);
                                if (File.Exists(data.FilePath + ".temp"))
                                {
                                    File.Delete(data.FilePath + ".temp");
                                }
                                beingupdateform.SetTextMessage(10000 * index++ / totalCount);

                            }
                            else
                            {
                                stepIsOk = false;
                                break;
                            }
                        }
                    }
                    if (stepIsOk)
                        fileListDelete.DataList.Clear();
                }

                if (fileListAdd.DataList.Count != 0)
                {
                    foreach (CommonData.Data d in fileListAdd.DataList)
                    {
                        //Log.Info("Application.StartupPath + \"//\" + d.FilePath + \".temp\" = " + Application.StartupPath + "//" + d.FilePath + ".temp");
                        if (HttpDownload(d.FileURL, Application.StartupPath + "//" + d.FilePath + ".temp"))
                        {
                            DESFileClass.EncryptFile(Application.StartupPath + "//" + d.FilePath + ".temp", Application.StartupPath + "//" + d.FilePath + ".xxx", Global.FileEnKey);
                            fileListLocal.DataList.Add(d);
                            beingupdateform.SetTextMessage(10000 * index++ / totalCount);
                        }
                        else
                        {
                            stepIsOk = false;
                            break;
                        }
                    }
                    if (stepIsOk)
                        fileListAdd.DataList.Clear();
                }
                if (fileListUpdate.DataList.Count == 0 && fileListDelete.DataList.Count == 0 && fileListAdd.DataList.Count == 0)
                {
                    res = 0;
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                res = -1;
                throw;
            }
            return res;
        }

        #region 删除所有缓存文件
        /// <summary>
        /// 删除所有缓存文件
        /// </summary>
        /// <param name="path"></param>
        public void DelAllTempFile(string path)
        {
            string[] FilePath = Directory.GetDirectories(path);
            string filename = string.Empty;
            for (int i = 0; i < FilePath.Length; i++)
            {
                DelAllTempFile(FilePath[i]);
            }
            string[] Newfilepath = Directory.GetFiles(path);
            if (Newfilepath.Length == 0 && FilePath.Length == 0 && string.Compare(path, Global.SysFilePath) != 0)
            {
                Directory.Delete(path);
            }
            for (int i = 0; i < Newfilepath.Length; i++)
            {
                string fileExtension = Path.GetExtension(Newfilepath[i]);
                string fileEnName = Path.GetDirectoryName(Newfilepath[i]) + "\\" + Path.GetFileNameWithoutExtension(Newfilepath[i]);
                if (string.Compare(fileExtension, ".temp") == 0)
                {
                    string filerealpath = Path.GetFullPath(Newfilepath[i]);
                    if (File.Exists(filerealpath))
                    {
                        //DESFileClass.EncryptFile(filerealpath, fileEnName+".xxx", Global.FileEnKey);
                        File.Delete(filerealpath);
                    }
                }
            }
        }
        #endregion

        #region 将所有文件加密成xxx文件
        /// <summary>
        /// 将所有文件加密成xxx文件
        /// </summary>
        /// <param name="path"></param>
        public void AllFile2xxx(string path)
        {
            string[] FilePath = Directory.GetDirectories(path);
            string filename = string.Empty;
            for (int i = 0; i < FilePath.Length; i++)
            {
                AllFile2xxx(FilePath[i]);
            }
            string[] Newfilepath = Directory.GetFiles(path);
            for (int i = 0; i < Newfilepath.Length; i++)
            {
                string filepath = Path.GetFullPath(Newfilepath[i]);
                string filerealpath = Path.GetDirectoryName(Newfilepath[i]) + "\\" + Path.GetFileNameWithoutExtension(Newfilepath[i]);
                DESFileClass.EncryptFile(filepath, filerealpath + ".xxx", Global.FileEnKey);
            }
        }
        #endregion

        #region http下载文件
        /// <summary>
        /// http下载文件
        /// </summary>
        /// <param name="url">下载文件地址</param>
        /// <param name="path">文件存放地址，包含文件名</param>
        /// <returns></returns>
        public bool HttpDownload(string url, string path)
        {
            string tempPath = System.IO.Path.GetDirectoryName(path) + @"\temp";
            System.IO.Directory.CreateDirectory(tempPath);  //创建临时文件目录
            string tempFile = tempPath + @"\" + System.IO.Path.GetFileName(path) + ".temp"; //临时文件

            if (System.IO.File.Exists(tempFile))
            {
                System.IO.File.Delete(tempFile);    //存在则删除
            }

            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                //Stream stream = new FileStream(tempFile, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);

                while (size > 0)
                {
                    //stream.Write(bArr, 0, size);
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }

                //stream.Close();
                fs.Close();
                responseStream.Close();
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);    //存在则删除
                }
                System.IO.File.Move(tempFile, path);
                return true;

            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                return false;
            }
        }
        #endregion

        #region 根据路径在list中找到CommonData数据
        /// <summary>
        /// 根据路径在list中找到CommonData数据
        /// </summary>
        /// <param name="infileList"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private CommonData.Data FindDataByPath(CommonData.FileData infileList, string path)
        {
            if (infileList.DataList.Count == 0)
                return null;
            foreach (CommonData.Data d in infileList.DataList)
            {
                if (string.Compare(path, d.FilePath) == 0)
                    return d;
            }
            return null;
        }
        #endregion

        #region 获取文件的MD5方法
        /// <summary>
        /// 获取文件的MD5方法
        /// </summary>
        /// <param name="url">文件路径</param>
        /// <returns></returns>
        public static string GetMD5Content(string url)
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                FileStream file = new FileStream(url, System.IO.FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                return sb.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);

                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
