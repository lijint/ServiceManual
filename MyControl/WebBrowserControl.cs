using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class WebBrowserControl : UserControl
    {

        private string VideoValue = string.Empty;
        public WebBrowserControl()
        {
            InitializeComponent();
            string mywebpath = AppDomain.CurrentDomain.BaseDirectory + "a.html";
            webBrowser1.Navigate(mywebpath);
            //webBrowser1.Document.GetElementsByTagName("");
            //webBrowser1.Navigate(@"http://v.youku.com/v_show/id_XMzY4NTcwMTMy==.html?spm=a2hww.20027244.m_250036.5~5!2~5~5!3~5~5~A&f=51529255");
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
        }

        private void WebBrowserControl_Load(object sender, EventArgs e)
        {
        }

        private string GetEmValue(string invalue)
        {
            string EmValue1 = "<embed id='myvideo' src='http://player.youku.com/player.php/Type/Folder/Fid//Ob//sid/";
            string EmValue2 = "==/v.swf' quality='high' width='480' height='400' align='middle' allowScriptAccess='always' allowFullScreen='true' mode='transparent' type='application/x-shockwave-flash'  style='position: absolute;top: -200px;left: -240px;'  wmode='opaque' onmousedown='flashRightClick(event)'></embed>";
            string VideoId = "";
            try
            {
                //invalue = "http://v.youku.com/v_show/id_XMzI4MDA3MzQ2MA==.html?spm=a2hww.20027244.m_250379.5~1~3~A&f=51426480";
                int begin = invalue.LastIndexOf("id_");
                int end = invalue.LastIndexOf("==");
                if (end < 0)
                {
                    end = invalue.LastIndexOf(".html");
                }
                VideoId = invalue.Substring(begin + 3, end - begin - 3);
            }
            catch
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err");
<<<<<<< HEAD
                MessageBox.Show("视频地址解析错误");
=======
                throw;
>>>>>>> e1735ae7a1e8474c7cb918a2774c0d0b53683982
            }
            return EmValue1 + VideoId + EmValue2;
            //return @"<embed src='http://player.youku.com/player.php/sid/XMzM3MzUyNDU2NA==/v.swf' allowFullScreen='true' quality='high' width='480' height='400' align='middle' allowScriptAccess='always' type='application/x-shockwave-flash'></embed>";

        }

        private void WebBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                foreach (HtmlElement links in this.webBrowser1.Document.Links)
                {
                    links.SetAttribute("target", "_self");
                }
                foreach (HtmlElement form in this.webBrowser1.Document.Forms)
                {
                    form.SetAttribute("target", "_self");
                }
                //webBrowser1.Document.GetElementById("myiframe").InnerHtml = VideoValue;
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        public void SetVideoValue(string videoaddr)
        {
            try
            {
                if (!string.IsNullOrEmpty(videoaddr))
                {
                    VideoValue = GetEmValue(videoaddr);
                    webBrowser1.Document.GetElementById("myiframe").InnerHtml = VideoValue;
                }
                else
                {
                    throw new Exception("视频地址为空");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        public void DisplayVideo(string videoaddr)
        {
            try
            {
                if (!string.IsNullOrEmpty(videoaddr))
                {
                    string videoValue = GetEmValue(videoaddr);
                    webBrowser1.Document.GetElementById("myiframe").InnerHtml = videoValue;
                }
                else
                {
                    throw new Exception("视频地址为空");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearVideo()
        {
            if(webBrowser1.Document!=null)  
                webBrowser1.Document.GetElementById("myiframe").InnerHtml = "";
        }

    }
}
