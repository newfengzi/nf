namespace QQWinFarm
{
    partial class FrmFramVerify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFramVerify));
            this.lblVerifyCode = new System.Windows.Forms.Label();
            this.txtVerify = new System.Windows.Forms.TextBox();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.picVerify = new System.Windows.Forms.PictureBox();
            this.butVerify = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picVerify)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVerifyCode
            // 
            this.lblVerifyCode.AutoSize = true;
            this.lblVerifyCode.Location = new System.Drawing.Point(16, 81);
            this.lblVerifyCode.Name = "lblVerifyCode";
            this.lblVerifyCode.Size = new System.Drawing.Size(53, 12);
            this.lblVerifyCode.TabIndex = 21;
            this.lblVerifyCode.Text = "验证码：";
            // 
            // txtVerify
            // 
            this.txtVerify.Location = new System.Drawing.Point(75, 78);
            this.txtVerify.MaxLength = 4;
            this.txtVerify.Name = "txtVerify";
            this.txtVerify.Size = new System.Drawing.Size(112, 21);
            this.txtVerify.TabIndex = 0;
            this.txtVerify.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVerify_KeyDown);
            // 
            // btnsubmit
            // 
            this.btnsubmit.Location = new System.Drawing.Point(28, 105);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(75, 23);
            this.btnsubmit.TabIndex = 1;
            this.btnsubmit.Text = "确认";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // picVerify
            // 
            this.picVerify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picVerify.Location = new System.Drawing.Point(75, 14);
            this.picVerify.Name = "picVerify";
            this.picVerify.Size = new System.Drawing.Size(112, 49);
            this.picVerify.TabIndex = 18;
            this.picVerify.TabStop = false;
            // 
            // butVerify
            // 
            this.butVerify.Location = new System.Drawing.Point(109, 105);
            this.butVerify.Name = "butVerify";
            this.butVerify.Size = new System.Drawing.Size(87, 23);
            this.butVerify.TabIndex = 2;
            this.butVerify.Text = "重获验证码";
            this.butVerify.UseVisualStyleBackColor = true;
            this.butVerify.Click += new System.EventHandler(this.butVerify_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picVerify);
            this.panel1.Controls.Add(this.butVerify);
            this.panel1.Controls.Add(this.btnsubmit);
            this.panel1.Controls.Add(this.lblVerifyCode);
            this.panel1.Controls.Add(this.txtVerify);
            this.panel1.Location = new System.Drawing.Point(10, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 156);
            this.panel1.TabIndex = 23;
            // 
            // FrmFramVerify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 177);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFramVerify";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "验证码";
            this.Load += new System.EventHandler(this.FrmFramVerify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picVerify)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblVerifyCode;
        private System.Windows.Forms.TextBox txtVerify;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.PictureBox picVerify;
        private System.Windows.Forms.Button butVerify;
        private System.Windows.Forms.Panel panel1;
    }
}