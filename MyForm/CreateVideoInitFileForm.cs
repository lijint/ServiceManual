using System;
using System.IO;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class CreateVideoInitFileForm : Form
    {
        public CreateVideoInitFileForm()
        {
            InitializeComponent();
        }

        private void CreateVideoInitFileForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnYes_Click(object sender, EventArgs e)
        {
            try
            {
                string strVideoName = tbVideoName.Text;
                string strPathValue = tbPathValue.Text;
                if(string.IsNullOrEmpty(strVideoName)||string.IsNullOrEmpty(strPathValue))
                {
                    throw new Exception("请正确输入视频名称或视频网址");
                }
                if (!Directory.Exists(Application.StartupPath + @"\manageVideoIni\"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\manageVideoIni\");
                }
                string iniPath = Application.StartupPath + @"\manageVideoIni\"+ strVideoName + ".ini";
                INIClass ini = new INIClass(iniPath);
                if(ini.ExistINIFile())
                {
                    throw new Exception("该文件已存在，请更换视频名称");
                }
                ini.IniWriteValue("MyVideoMsg", "VideoName", strVideoName);
                ini.IniWriteValue("MyVideoMsg", "VideoPath", strPathValue);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
