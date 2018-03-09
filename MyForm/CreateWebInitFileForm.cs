using System;
using System.IO;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class CreateWebInitFileForm : Form
    {
        public CreateWebInitFileForm()
        {
            InitializeComponent();
        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            try
            {
                string strWebFileName = tbVideoName.Text;
                string strPathValue = tbPathValue.Text;
                if (string.IsNullOrEmpty(strWebFileName) || string.IsNullOrEmpty(strPathValue))
                {
                    throw new Exception("请正确输入网页文件名或网页网址");
                }
                if (!Directory.Exists(Application.StartupPath + @"\manageWebIni\"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\manageWebIni\");
                }
                string iniPath = Application.StartupPath + @"\manageWebIni\" + strWebFileName + ".webini";
                INIClass ini = new INIClass(iniPath);
                if(ini.ExistINIFile())
                {
                    throw new Exception("该文件已存在，请更换网页配置文件名称");
                }
                ini.IniWriteValue("MyWebMsg", "WebName", strWebFileName);
                ini.IniWriteValue("MyWebMsg", "URL", strPathValue);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateWebInitFileForm_Load(object sender, EventArgs e)
        {

        }
    }
}
