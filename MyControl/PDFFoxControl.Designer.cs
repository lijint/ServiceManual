namespace ServiceManual
{
    partial class PDFFoxControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFFoxControl));
            this.axFoxitReaderSDK1 = new AxFoxitReaderSDKProLib.AxFoxitReaderSDK();
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitReaderSDK1)).BeginInit();
            this.SuspendLayout();
            // 
            // axFoxitReaderSDK1
            // 
            this.axFoxitReaderSDK1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axFoxitReaderSDK1.Enabled = true;
            this.axFoxitReaderSDK1.Location = new System.Drawing.Point(3, 3);
            this.axFoxitReaderSDK1.Name = "axFoxitReaderSDK1";
            this.axFoxitReaderSDK1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFoxitReaderSDK1.OcxState")));
            this.axFoxitReaderSDK1.Size = new System.Drawing.Size(861, 692);
            this.axFoxitReaderSDK1.TabIndex = 0;
            // 
            // PDFFoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axFoxitReaderSDK1);
            this.Name = "PDFFoxControl";
            this.Size = new System.Drawing.Size(867, 698);
            this.Load += new System.EventHandler(this.PDFFoxControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axFoxitReaderSDK1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxFoxitReaderSDKProLib.AxFoxitReaderSDK axFoxitReaderSDK1;
    }
}
