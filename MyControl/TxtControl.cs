using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ServiceManual
{
    public partial class TxtControl : UserControl
    {
        public TxtControl()
        {
            InitializeComponent();
        }

        private void TxtControl_Load(object sender, EventArgs e)
        {

        }

        public void DisplayTxt(string filepath)
        {
            try
            {
                if (!string.IsNullOrEmpty(filepath))
                {
                    string[] lines = File.ReadAllLines(filepath);
                    // 先清空textBox1
                    textBox1.Clear();
                    textBox1.ReadOnly = true;
                    // 在textBox1中显示
                    foreach (string line in lines)
                        textBox1.AppendText(line + Environment.NewLine);
                }
                else
                {
                    throw new Exception("txt文件路径问空");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
    }
}
