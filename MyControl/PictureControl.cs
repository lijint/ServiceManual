using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ServiceManual
{
    public partial class PictureControl : UserControl
    {
        private Point mouseDownPoint;
        private bool isMove = false;    //判断鼠标在picturebox上移动时，是否处于拖拽过程(鼠标左键是否按下)
        private int zoomStep = 20;      //缩放步长
        private int ControlWidth;
        private int ControlHeight;
        private int PicOriginaLLocationX;
        private int PicOriginaLLocationY;
        private string picPath;
        private bool IsVertical;   //是否是竖图
        
        public PictureControl()
        {
            InitializeComponent();
        }

        private void PictureControl_Load(object sender, EventArgs e)
        {
            try
            {
                mouseDownPoint = new Point();
                SetParms();
                //DisplayPic();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                MessageBox.Show(ex.Message);
            }
            //mouseDownPoint.X = this.Width / 2;
            //mouseDownPoint.Y = this.Height / 2;
        }

        public void SetPicPath(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    if (string.Compare(path, picPath) != 0)
                    {
                        picPath = path;
                    }
                    DisplayPic();
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                throw;
            }
        }

        private void DisplayPic()
        {
            try
            {
                if (!string.IsNullOrEmpty(picPath))
                {
                    //picPath = picpath;
                    ClearPic();
                    Image picImage = Image.FromFile(picPath);
                    pictureBox1.Image = picImage;
                    double imagePro = (double)picImage.Width / picImage.Height;
                    double controlPro = (double)ControlWidth / ControlHeight;
                    if (imagePro > controlPro)
                    {
                        //横屏图片
                        pictureBox1.Width = ControlWidth;
                        pictureBox1.Height = (int)(pictureBox1.Width * (double)picImage.Height / picImage.Width);
                        pictureBox1.Location = new Point(0, (ControlHeight-pictureBox1.Height)/2);
                        IsVertical = false;
                    }
                    else
                    {
                        //竖屏图片
                        pictureBox1.Height = ControlHeight;
                        pictureBox1.Width = (int)(pictureBox1.Height * (double)picImage.Width / picImage.Height);
                        pictureBox1.Location = new Point((ControlWidth - pictureBox1.Width) / 2, 0);
                        IsVertical = true;
                    }
                }
                else
                {
                    throw new Exception("图片路径为空");
                }
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
         public  void ClearPic()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                Log.Info("pic dispose successful");
            }
        }

         public void btnPicAdd_Click()
         {
             try
             {
                 //Image im = pictureBox1.BackgroundImage;
                 //im.Size = new System.Drawing.Size(im.Width + 50, im.Height + 50);
                 int x = pictureBox1.Location.X;
                 int y = pictureBox1.Location.Y;
                 pictureBox1.Size = new Size(pictureBox1.Width + zoomStep, pictureBox1.Height + (int)(zoomStep * (double)pictureBox1.Height / pictureBox1.Width));
                 x -= (zoomStep/2);
                 y -= ((int)(zoomStep * (double)pictureBox1.Height / pictureBox1.Width) / 2);
                 pictureBox1.Location = new Point(x, y);
                 Log.Debug("Pic new size width = " + pictureBox1.Width + " height = " + pictureBox1.Height);
             }
             catch (Exception ex)
             {
                 Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                MessageBox.Show(ex.Message);
             }
         }

         public void btnPicCut_Click()
         {
             try
             {
                 int x = pictureBox1.Location.X;
                 int y = pictureBox1.Location.Y;
                 //if (pictureBox1.Width - zoomStep <= ControlWidth || pictureBox1.Height - zoomStep * pictureBox1.Height / pictureBox1.Width < ControlHeight || pictureBox1.Location.X >= 0 || pictureBox1.Location.Y >= 0)
                 //{
                 //    pictureBox1.Location = new Point(PicOriginaLLocationX, PicOriginaLLocationY);
                 //    return;
                 //}
                 if (IsVertical)
                 {
                     if (pictureBox1.Height - (int)(zoomStep * (double)pictureBox1.Height / pictureBox1.Width) < ControlHeight)
                     {
                         return;
                     }
                 }
                 else
                 {
                     if (pictureBox1.Width - zoomStep < ControlWidth)
                     {
                         return;
                     }
                 }

                 pictureBox1.Size = new Size(pictureBox1.Width - zoomStep, pictureBox1.Height - (int)(zoomStep * (double)pictureBox1.Height / pictureBox1.Width));
                 x += (zoomStep / 2);
                 y += ((int)(zoomStep * (double)pictureBox1.Height / pictureBox1.Width) / 2);
                 //设置图片在窗体居中
                 pictureBox1.Location = new Point(x, y);
                 Log.Debug("Pic new size width = " + pictureBox1.Width + " height = " + pictureBox1.Height);

             }
             catch (Exception ex)
             {
                 Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                 MessageBox.Show(ex.Message);
             }
         }

         private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
         {
             try
             {
                 pictureBox1.Focus();
                 if (isMove)
                 {
                     int x, y;
                     int moveX, moveY;
                     moveX = Cursor.Position.X - mouseDownPoint.X;
                     moveY = Cursor.Position.Y - mouseDownPoint.Y;
                     x = pictureBox1.Location.X + moveX;
                     y = pictureBox1.Location.Y + moveY;
                     if (moveX > 0)
                     {
                         if (x >= 0)
                         {
                             x = pictureBox1.Location.X;
                             //return;
                         }
                     }
                     else
                     {
                         if (x + pictureBox1.Width <= ControlWidth)
                         {
                             x = pictureBox1.Location.X;
                             //return;
                         }
                     }
                     if (moveY > 0)
                     {
                         if (y >= 0)
                         {
                             y = pictureBox1.Location.Y;
                             //return;
                         }
                     }
                     else
                     {
                         if (y + pictureBox1.Height <= ControlHeight)
                         {
                             y = pictureBox1.Location.Y;
                         }
                     }
                     pictureBox1.Location = new Point(x, y);
                     mouseDownPoint.X = Cursor.Position.X;
                     mouseDownPoint.Y = Cursor.Position.Y;
                     //Log.Debug("Pic location is x = " + pictureBox1.Location.X + " y = " + pictureBox1.Location.Y);
                     //Thread.Sleep(1000);
                 }
             }
             catch (Exception ex)
             {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                MessageBox.Show(ex.Message);
             }
         }

         private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
         {
             if (e.Button == MouseButtons.Left)
             {
                 mouseDownPoint.X = Cursor.Position.X;
                 mouseDownPoint.Y = Cursor.Position.Y;
                 isMove = true;
                 pictureBox1.Focus();
             }
         }

         private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
         {
             if (e.Button == MouseButtons.Left)
             {
                 isMove = false;
             }
         }

         private void SetParms()
         {
             ControlWidth = this.Width;
             ControlHeight = this.Height;
             if (pictureBox1.Location.X >= 0)
                 PicOriginaLLocationX = pictureBox1.Location.X;
             if (pictureBox1.Location.Y >= 0)
                 PicOriginaLLocationY = pictureBox1.Location.Y;
             //Log.Debug("Control Size is width = " + ControlWidth + " height = " + ControlHeight);
             //Log.Debug("Pic original Size is width = " + pictureBox1.Width + " height = " + pictureBox1.Height);
             //Log.Debug("Pic original location is x = " + pictureBox1.Location.X + " y = " + pictureBox1.Location.Y);

         }

         private void PictureControl_SizeChanged(object sender, EventArgs e)
         {
             try
             {
                 SetParms();
                 //int changeLocationX = pictureBox1.Location.X >= 0 ? 0 : pictureBox1.Location.X;
                 //int changeLocationY = pictureBox1.Location.Y >= 0 ? 0 : pictureBox1.Location.Y;
                 //pictureBox1.Location = new Point(changeLocationX, changeLocationY);
                 if (!string.IsNullOrEmpty(picPath))
                     DisplayPic();
             }
             catch (Exception ex)
             {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                MessageBox.Show(ex.Message);
             }
         }
    }
}
