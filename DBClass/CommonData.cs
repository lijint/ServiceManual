using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ServiceManual
{
    public class CommonData
    {
        //[{"Account":"111",
        //"UserName":"草草草",
        //"CreateDateTime":"2017-11-30T18:30:29.997",
        //"FailureDateTime":"2027-11-30T09:52:10.32",
        //"UpdateDateTime":"2017-12-21T15:57:02.407",
        //"UserTel":"111111111",
        //"UserPermission":1,
        //"IsOnline":false,
        //"StateCode":true},
        //{"Account":"11",
        //"UserName":"草草草",
        //"CreateDateTime":"2017-11-30T18:29:15.913",
        //"FailureDateTime":"2027-11-30T09:52:10.32",
        //"UpdateDateTime":"2017-12-21T10:29:05.593",
        //"UserTel":"111111111",
        //"UserPermission":1,
        //"IsOnline":true,
        //"StateCode":true}]

        public enum FileType
        {
            None,
            Folder,
            TXT,
            Image,
            Video,
            Pdf,
            PCB,
            Web
        }

        public class UserMsgData
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Account { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string PassWord { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string UserName { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DateTime CreateDateTime { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DateTime FailureDateTime { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DateTime UpdateDateTime { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string UserTel { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public int UserPermission { get; set; }  //0表示没权限，1表示使用者，2表示管理员
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool IsOnline { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool StateCode { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string FilePermission { get; set; }
        }

        public class PayData
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Account { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string RenewalWay { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string QRStr { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string OrderNo { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool IsPreCreate { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public bool IsPay { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DateTime PayDateTime { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public DateTime PreCreateDateTime { get; set; }
        }

        public class FileData
        {
            public List<Data> DataList = new List<Data>();
        }

        public class Data
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string FilePath { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string FileMD5 { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string FileURL { get; set; }
        }

        public class MainFormFile : Data
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string FileLocalPath { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string FileName { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public FileType FileType { get; set; }
        }

        public class PayPrarmsData
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string ConfigCode { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string RenewalTime { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Price { get; set; }
        }

        public class FilePermission
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string FileName { get; set; }
        }
    }
}
