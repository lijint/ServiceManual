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
    public partial class PDFControl : UserControl, IMessageFilter
    {
        public PDFControl()
        {
            InitializeComponent();
        }

        private void PDFControl_Load(object sender, EventArgs e)
        {
            try
            {
                //SetPdf();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err" + ex);
                MessageBox.Show(ex.Message);
            }
        }

        public void DisplayPDFFile(string pdfpath)
        {
            try
            {
                if (!string.IsNullOrEmpty(pdfpath))
                {
                    MyaxAcroPDF.LoadFile(pdfpath);
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
                MyaxAcroPDF.setShowToolbar(true);
                MyaxAcroPDF.setShowScrollbars(true);
                MyaxAcroPDF.setPageMode("thumbs");
                MyaxAcroPDF.setView("fit");
                MyaxAcroPDF.AllowDrop = false;
                panel1.Hide();
                panel2.Hide();
                //MyaxAcroPDF.
                //MyaxAcroPDF.
                //MyaxAcroPDF.setPageMode("pages only");
                //MyaxAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill;
                //MyaxAcroPDF
            }
            catch
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] err");
                throw;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                     Color.White, 1, ButtonBorderStyle.None, //左边
                     Color.White, 1, ButtonBorderStyle.None, //上边
                     Color.DimGray, 1, ButtonBorderStyle.Solid, //右边
                     Color.DimGray, 1, ButtonBorderStyle.None);//底边
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                     Color.DimGray, 1, ButtonBorderStyle.Solid, //左边
                     Color.White, 1, ButtonBorderStyle.None, //上边
                     Color.DimGray, 1, ButtonBorderStyle.None, //右边
                     Color.DimGray, 1, ButtonBorderStyle.None);//底边
        }

        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case 513://拦截左键单击事件　
                    //MessageBox.Show("左键被拦截！");
                    return true;
                case 516://拦截左键单击事件　
                    //MessageBox.Show("右键被拦截！");
                    return true;
                case 515:
                    //MessageBox.Show("双击被拦截！");
                    return true;
                default:
                    return false;//返回false则消息未被裁取，系统会处理
            }
        }
    }
}
