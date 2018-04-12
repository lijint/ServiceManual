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
    public partial class PDFFoxControl : UserControl
    {
        public PDFFoxControl()
        {
            InitializeComponent();
        }

        private void PDFFoxControl_Load(object sender, EventArgs e)
        {
            //axFoxitReaderSDK1.OpenFile("", "");
        }

        public void DisplayPDFFile(string pdfpath)
        {
            try
            {
                if (!string.IsNullOrEmpty(pdfpath))
                {
                    axFoxitReaderSDK1.OpenFile(pdfpath, "");
                    SetPdf();
                }
                else
                {
                    throw new Exception("pdf文件路径问空");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void SetPdf()
        {
            try
            {
                axFoxitReaderSDK1.ShowTitleBar(false);
                axFoxitReaderSDK1.ShowToolbarButton(0, false);
                axFoxitReaderSDK1.ShowToolbarButton(1, false);
                axFoxitReaderSDK1.ShowToolbarButton(2, false);
                axFoxitReaderSDK1.ShowToolbarButton(3, false);
            }
            catch
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err");
                throw;
            }
        }

        public void ClearPdf()
        {
            try
            {
                axFoxitReaderSDK1.CloseFile();
                Log.Info("close pdf file succ");
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err " + ex);
            }
        }
    }
}