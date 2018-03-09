using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class BeingUpdateFile : Form
    {
        private delegate void SetPos(int ipos);
        private Thread myThread;
        private FileSystem fileSys;
        public BeingUpdateFile(FileSystem sys)
        {
            InitializeComponent();
            fileSys = sys;
        }

        private void BeingUpdateFile_Load(object sender, EventArgs e)
        {
            try
            {
                this.progressBar1.Maximum = 10000;
                Thread fThread = new Thread(new ThreadStart(DoUpdateFile));
                fThread.Start();
            }
            catch (Exception ex)
            {
                Log.Error("[" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error  " + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        public void SetTextMessage(int ipos)
        {
            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(SetTextMessage);
                this.Invoke(setpos, new object[] { ipos });
            }
            else
            {
                //this.label1.Text = ipos.ToString() + "/100";

                this.progressBar1.Value = Convert.ToInt32(ipos);                
                //this.progressBar1.Value++;
                //Log.Debug("ipos = " + this.progressBar1.Value);
            }
        }

        private void DoUpdateFile()
        {
            int res = fileSys.DoUpdateFileList(this);
            Thread.Sleep(1000);
            if (res == 0)
                DialogResult = DialogResult.Yes;
            else
                DialogResult = DialogResult.No;
            this.Close();
        }

        public void SetMaxValue(int max)
        {
            this.progressBar1.Maximum = max;
            //Log.Debug("max = " + max);
        }
    }
}
