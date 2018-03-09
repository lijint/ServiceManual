using System;

namespace ServiceManual
{
    partial class PayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRenewal2 = new System.Windows.Forms.RadioButton();
            this.rbRenewal1 = new System.Windows.Forms.RadioButton();
            this.btnCreatQRCode = new System.Windows.Forms.Button();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbTimeTick = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.timerQuery = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbFailrueDateTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAccount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRenewal2);
            this.groupBox1.Controls.Add(this.rbRenewal1);
            this.groupBox1.Location = new System.Drawing.Point(24, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择续费周期";
            // 
            // rbRenewal2
            // 
            this.rbRenewal2.AutoSize = true;
            this.rbRenewal2.Font = new System.Drawing.Font("宋体", 14.25F);
            this.rbRenewal2.Location = new System.Drawing.Point(179, 57);
            this.rbRenewal2.Name = "rbRenewal2";
            this.rbRenewal2.Size = new System.Drawing.Size(65, 23);
            this.rbRenewal2.TabIndex = 3;
            this.rbRenewal2.TabStop = true;
            this.rbRenewal2.Text = "两年";
            this.rbRenewal2.UseVisualStyleBackColor = true;
            this.rbRenewal2.CheckedChanged += new System.EventHandler(this.rbRenewal2_CheckedChanged);
            // 
            // rbRenewal1
            // 
            this.rbRenewal1.AutoSize = true;
            this.rbRenewal1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbRenewal1.Location = new System.Drawing.Point(71, 57);
            this.rbRenewal1.Name = "rbRenewal1";
            this.rbRenewal1.Size = new System.Drawing.Size(65, 23);
            this.rbRenewal1.TabIndex = 2;
            this.rbRenewal1.TabStop = true;
            this.rbRenewal1.Text = "一年";
            this.rbRenewal1.UseVisualStyleBackColor = true;
            this.rbRenewal1.CheckedChanged += new System.EventHandler(this.rbRenewal1_CheckedChanged);
            // 
            // btnCreatQRCode
            // 
            this.btnCreatQRCode.Location = new System.Drawing.Point(465, 251);
            this.btnCreatQRCode.Name = "btnCreatQRCode";
            this.btnCreatQRCode.Size = new System.Drawing.Size(84, 28);
            this.btnCreatQRCode.TabIndex = 4;
            this.btnCreatQRCode.Text = "立即支付";
            this.btnCreatQRCode.UseVisualStyleBackColor = true;
            this.btnCreatQRCode.Click += new System.EventHandler(this.BtnCreatQRCode_Click);
            // 
            // picQRCode
            // 
            this.picQRCode.Location = new System.Drawing.Point(433, 303);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(290, 274);
            this.picQRCode.TabIndex = 2;
            this.picQRCode.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(478, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "请在";
            // 
            // lbTimeTick
            // 
            this.lbTimeTick.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTimeTick.Location = new System.Drawing.Point(524, 191);
            this.lbTimeTick.Name = "lbTimeTick";
            this.lbTimeTick.Size = new System.Drawing.Size(43, 19);
            this.lbTimeTick.TabIndex = 6;
            this.lbTimeTick.Text = "0";
            this.lbTimeTick.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.Location = new System.Drawing.Point(573, 191);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(119, 19);
            this.lbTime.TabIndex = 7;
            this.lbTime.Text = "s内完成支付";
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(608, 251);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(84, 28);
            this.btnCancelOrder.TabIndex = 4;
            this.btnCancelOrder.Text = "取消支付";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.BtnCancelOrder_Click);
            // 
            // timerQuery
            // 
            this.timerQuery.Tick += new System.EventHandler(this.TimerQuery_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbFailrueDateTime);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lbAccount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(24, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(699, 113);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "您的信息";
            // 
            // lbFailrueDateTime
            // 
            this.lbFailrueDateTime.AutoSize = true;
            this.lbFailrueDateTime.Location = new System.Drawing.Point(131, 81);
            this.lbFailrueDateTime.Name = "lbFailrueDateTime";
            this.lbFailrueDateTime.Size = new System.Drawing.Size(0, 12);
            this.lbFailrueDateTime.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "账户失效日期";
            // 
            // lbAccount
            // 
            this.lbAccount.AutoSize = true;
            this.lbAccount.Location = new System.Drawing.Point(131, 28);
            this.lbAccount.Name = "lbAccount";
            this.lbAccount.Size = new System.Drawing.Size(0, 12);
            this.lbAccount.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "账号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(43, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "应支付";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("幼圆", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPrice.ForeColor = System.Drawing.Color.Red;
            this.lbPrice.Location = new System.Drawing.Point(140, 325);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(77, 29);
            this.lbPrice.TabIndex = 10;
            this.lbPrice.Text = "2000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(230, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "元";
            // 
            // PayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 589);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbTimeTick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnCreatQRCode);
            this.Controls.Add(this.picQRCode);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "续费充值";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PayForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PayForm_FormClosed);
            this.Load += new System.EventHandler(this.PayForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRenewal2;
        private System.Windows.Forms.RadioButton rbRenewal1;
        private System.Windows.Forms.Button btnCreatQRCode;
        private System.Windows.Forms.PictureBox picQRCode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTimeTick;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Timer timerQuery;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbFailrueDateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label label6;
    }
}