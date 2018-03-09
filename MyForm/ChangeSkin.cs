using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManual
{
    public partial class ChangeSkin : Form
    {

        private string OldSkinName;
        private string NewSkinName;

        public ChangeSkin()
        {
            InitializeComponent();
        }

        private void ChangeSkin_Load(object sender, EventArgs e)
        {
            comboBox1.Text = Global.SkinName;
            
            LoadSkin();
        }

        private void LoadSkin()
        {
            string[] skins = Directory.GetFiles("Skins\\");
            //string[] skinnames
            if (skins.Length > 0)
            {
                for (int i = 0; i < skins.Length; i++)
                {
                    string fileskinname = Path.GetFileNameWithoutExtension(skins[i]);
                    //SkinNames.Add(fileskinname);
                    comboBox1.Items.Add(fileskinname);
                    //if(string.Compare(fileskinname))
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = "Skins\\" + comboBox1.Text + ".ssk";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Global.SkinName = comboBox1.Text;
        }
    }
}
