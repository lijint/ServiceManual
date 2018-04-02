using System.Collections.Generic;
namespace ServiceManual
{
    public class Global
    {
        public enum FileType
        {
            TXT = 0,
            PDF = 1,
            VEDIO = 2,
        }

        public static CommonData.UserMsgData userMsgData = new CommonData.UserMsgData();

        public static FileType fileType;
        private static TransAccessFactory accessFactory = new TransAccessFactory();
        public static string SysFilePath
        {
            get { return accessFactory.GetPramFromDB("SysFilePath"); }
            set { accessFactory.SetPramToDB("SysFilePath", value); }
        }

        public static string AccessFile = "db.mdb";
        public static string AccessPin = "123456";
        public static string AccessProviderName = "System.Data.OleDb";
        public static string FileEnKey
        {
            get { return accessFactory.GetPramFromDB("FileEnKey"); }
            set { accessFactory.SetPramToDB("FileEnKey", value); }
        }
        public static string FtpPath
        {
            get { return accessFactory.GetPramFromDB("FtpPath"); }
            set { accessFactory.SetPramToDB("FtpPath", value); }
        }
        public static string SkinName
        {
            get { return accessFactory.GetPramFromDB("SkinName"); }
            set { accessFactory.SetPramToDB("SkinName", value); }
        }
        public static string WebAddAddr
        {
            get { return accessFactory.GetPramFromDB("WebAddAddr"); }
            set { accessFactory.SetPramToDB("WebAddAddr", value); }
        }
        public static string LoginUserID
        {
            get { return accessFactory.GetPramFromDB("LoginUserID"); }
            set { accessFactory.SetPramToDB("LoginUserID", value); }
        }
        public static string LoginUserPsw
        {
            get { return accessFactory.GetPramFromDB("LoginUserPsw"); }
            set { accessFactory.SetPramToDB("LoginUserPsw", value); }
        }

        public static string MainFormTitle = "维修秘籍 " + Vesion;
        public const string Vesion = "V1.2";

        public static Dictionary<ConfigInfo, string> ConfigInfoList = new Dictionary<ConfigInfo, string>();

        public enum ConfigInfo
        {
            FtpPath=1,
            WebAddAddr,
            YeMeiMsg,
            InitAddr
        }

        //public static string SysFilePath;
        //public static string FileEnKey;
        //public static string FtpPath;

    }
}
