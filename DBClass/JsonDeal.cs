using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServiceManual
{
    class JsonDeal
    {
        public static CommonData.FileData JsonData2FileData(string jsondata)
        {
            CommonData.FileData filedata = new CommonData.FileData();
            //filedata = JsonConvert.DeserializeObject<CommonData.FileData>(jsondata);
            List<CommonData.Data> datalist = JsonConvert.DeserializeObject<List<CommonData.Data>>(jsondata);
            filedata.DataList = datalist;
            return filedata;
        }

        public static string FileData2JsonData(CommonData.FileData filedata)
        {
            string jsondata = "";
            jsondata = JsonConvert.SerializeObject(filedata);

            return jsondata;
        }
        public static List<CommonData.UserMsgData> JsonData2UserMsgListData(string jsondata)
        {
            //filedata = JsonConvert.DeserializeObject<CommonData.FileData>(jsondata);
            List<CommonData.UserMsgData> datalist = JsonConvert.DeserializeObject<List<CommonData.UserMsgData>>(jsondata);
            return datalist;
        }

        public static string UserMsgListData2JsonData(List<CommonData.UserMsgData> userlistdata)
        {
            string jsondata = "";
            jsondata = JsonConvert.SerializeObject(userlistdata);

            return jsondata;
        }

        public static Dictionary<Global.ConfigInfo, string> JsonData2ConfigInfolist(string jsondata)
        {
            //filedata = JsonConvert.DeserializeObject<CommonData.FileData>(jsondata);
            Dictionary<Global.ConfigInfo, string> datalist = JsonConvert.DeserializeObject<Dictionary<Global.ConfigInfo, string>>(jsondata);
            return datalist;
        }

        public static string ConfigInfolist2JsonData(Dictionary<Global.ConfigInfo, string> Configlist)
        {
            string jsondata = "";
            jsondata = JsonConvert.SerializeObject(Configlist);

            return jsondata;
        }

        public static List<CommonData.PayPrarmsData> JsonData2PayInfolist(string jsondata)
        {
            //filedata = JsonConvert.DeserializeObject<CommonData.FileData>(jsondata);
            List<CommonData.PayPrarmsData> datalist = JsonConvert.DeserializeObject<List<CommonData.PayPrarmsData>>(jsondata);
            return datalist;
        }

    
    }
}
