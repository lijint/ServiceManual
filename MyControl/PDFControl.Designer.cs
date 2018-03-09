namespace ServiceManual
{
    partial class PDFControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MyaxAcroPDF = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.MyaxAcroPDF)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 36);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(534, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 36);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // MyaxAcroPDF
            // 
            this.MyaxAcroPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyaxAcroPDF.Enabled = true;
            this.MyaxAcroPDF.Location = new System.Drawing.Point(3, 3);
            this.MyaxAcroPDF.Name = "MyaxAcroPDF";
            this.MyaxAcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MyaxAcroPDF.OcxState")));
            this.MyaxAcroPDF.Size = new System.Drawing.Size(689, 513);
            this.MyaxAcroPDF.TabIndex = 0;
            // 
            // PDFControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MyaxAcroPDF);
            this.Name = "PDFControl";
            this.Size = new System.Drawing.Size(695, 519);
            this.Load += new System.EventHandler(this.PDFControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyaxAcroPDF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private AxAcroPDFLib.AxAcroPDF MyaxAcroPDF;



    }
}
