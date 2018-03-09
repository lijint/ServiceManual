using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class WebForm : Form
    {
        public WebForm()
        {
            InitializeComponent();
        }

        private void WebForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Width = System.Windows.Forms.SystemInformation.WorkingArea.Width / 2;
                this.Height = System.Windows.Forms.SystemInformation.WorkingArea.Height;
                int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width);
                int y = 30; 
                this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
                this.Location = (Point)new Size(x, y);         //窗体的起始位置为(x,y)
                webBrowser1.Navigate(Global.ConfigInfoList[Global.ConfigInfo.WebAddAddr]);
                TopMost = true;
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex.Message);

            }
        }
    }
}
