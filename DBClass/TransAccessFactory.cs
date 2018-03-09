using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ServiceManual
{
    public class TransAccessFactory : DataAccess
    {

        /// <summary>
        /// 删除表LocalFileList中所有数据
        /// </summary>
        public void DeleteFileDataList()
        {
            string strSql = @"DELETE FROM LocalFileList";
            int iRet = ExecuteCommand(strSql);
        }

        /// <summary>
        /// 将本地文件信息写进数据库
        /// </summary>
        /// <param name="fileData"></param>
        public void SetFileDataToDB(CommonData.FileData fileData)
        {
            DeleteFileDataList();
            for (int i = 0; i < fileData.DataList.Count; i++)
            {
                string strSql = string.Format(@"Insert into LocalFileList ([FilePath],[FileMD5],[FileURL]) VALUES ('{0}','{1}','{2}')", EncryptString(fileData.DataList[i].FilePath, Skey), EncryptString(fileData.DataList[i].FileMD5, Skey), EncryptString(fileData.DataList[i].FileURL, Skey));
                ExecuteCommand(strSql);
            }
        }

        /// <summary>
        /// 读取数据库中本地文件信息
        /// </summary>
        /// <returns></returns>
        public CommonData.FileData GetFileDataFromDB()
        {
            CommonData.FileData filedata = new CommonData.FileData();

            string strSql = string.Format(@"SELECT FilePath,FileMD5,FileURL FROM LocalFileList");
            DataTable table = GetDataTable(strSql);
            if (table == null || table.Rows.Count == 0)
                return null;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                CommonData.Data data = new CommonData.Data();
                data.FilePath = DecryptString(GetString(dr["FilePath"]), Skey);
                data.FileMD5 = DecryptString(GetString(dr["FileMD5"]), Skey);
                data.FileURL = DecryptString(GetString(dr["FileURL"]), Skey);
                filedata.DataList.Add(data);
            }
            return filedata;
        }

        /// <summary>
        /// 设置参数进数据库
        /// </summary>
        /// <param name="keyname"></param>
        /// <param name="value"></param>
        public void SetPramToDB(string keyname, string value)
        {
            //UPDATE 表名称 SET 列名称 = 新值 WHERE 列名称 = 某值
            string strSql = string.Format(@"update SystemPrams Set {0} = '{1}' Where ID = 10", keyname, EncryptString(value, Skey));
            ExecuteCommand(strSql);
        }

        /// <summary>
        /// 根据key从数据库获取参数
        /// </summary>
        /// <param name="keyname"></param>
        /// <returns></returns>
        public string GetPramFromDB(string keyname)
        {
            string value = "";

            string strSql = string.Format(@"SELECT {0} FROM SystemPrams", keyname);
            DataTable table = GetDataTable(strSql);
            if (table == null || table.Rows.Count == 0)
                return null;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                value = DecryptString(GetString(dr[keyname]), Skey);
            }
            return value;
        }



        /// <summary>
        /// 删除所有参数
        /// </summary>
        /// <param name="key"></param>
        public void DeleteAllPram()
        {
            string strSql = string.Format(@"Delete * From SystemPrams");
            int iRet = ExecuteCommand(strSql);
        }




        private string GetString(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        private string Skey
        {
            get
            {
                string skey = Global.AccessPin;
                if (skey.Length > 8)
                    skey = skey.Substring(0, 8);
                else
                    skey = skey.PadRight(8, 'L');
                return skey;
            }
        }

        /// <summary>
        /// 创建数据库连接
        /// </summary>
        /// <param name="ConfigString"></param>
        /// <returns></returns>
        public override string GetConnectionString(string ConfigString)
        {
            string dbPath = Path.Combine(Application.StartupPath, Global.AccessFile);
            string dbPsd = Global.AccessPin;
            string strConn = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1}", dbPath, dbPsd);
            return strConn;
        }
        /// <summary>
        /// 获取数据库驱动
        /// </summary>
        /// <param name="ConfigString"></param>
        /// <returns></returns>
        public override string GetProviderName(string ConfigString)
        {
            string ProviderName = Global.AccessProviderName;
            return ProviderName;
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string EncryptString(string input, string sKey)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            byte[] data = Encoding.UTF8.GetBytes(input);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = des.CreateEncryptor();
                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return BitConverter.ToString(result);
            }
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string DecryptString(string input, string sKey)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            string[] sInput = input.Split("-".ToCharArray());
            byte[] data = new byte[sInput.Length];
            for (int i = 0; i < sInput.Length; i++)
            {
                data[i] = byte.Parse(sInput[i], NumberStyles.HexNumber);
            }
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                ICryptoTransform desencrypt = des.CreateDecryptor();
                byte[] result = desencrypt.TransformFinalBlock(data, 0, data.Length);
                return Encoding.UTF8.GetString(result);
            }
        }
    }
}
