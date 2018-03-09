using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class WebControl : UserControl
    {


        public WebControl()
        {
            InitializeComponent();
        }

        private void WebControl_Load(object sender, EventArgs e)
        {
            webBrowser1.IsWebBrowserContextMenuEnabled = false;

        }

        public void DisplayWeb(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    this.webBrowser1.Navigate(url);
                }
                else
                {
                    throw new Exception("网页地址无效");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        public void GetUrl()
        {

        }
    }
}
