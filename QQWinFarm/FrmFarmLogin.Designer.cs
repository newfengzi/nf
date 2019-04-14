namespace QQWinFarm
{
    partial class FrmFarmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFarmLogin));
            this.picVerify = new System.Windows.Forms.PictureBox();
            this.lblVerifyCode = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblQQ = new System.Windows.Forms.Label();
            this.txtVerify = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtQQ = new System.Windows.Forms.TextBox();
            this.butVerify = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picVerify)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picVerify
            // 
            this.picVerify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picVerify.Location = new System.Drawing.Point(70, 90);
            this.picVerify.Name = "picVerify";
            this.picVerify.Size = new System.Drawing.Size(112, 49);
            this.picVerify.TabIndex = 13;
            this.picVerify.TabStop = false;
            // 
            // lblVerifyCode
            // 
            this.lblVerifyCode.AutoSize = true;
            this.lblVerifyCode.Location = new System.Drawing.Point(8, 66);
            this.lblVerifyCode.Name = "lblVerifyCode";
            this.lblVerifyCode.Size = new System.Drawing.Size(53, 12);
            this.lblVerifyCode.TabIndex = 10;
            this.lblVerifyCode.Text = "验证码：";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(20, 39);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(41, 12);
            this.lblPwd.TabIndex = 11;
            this.lblPwd.Text = "密码：";
            // 
            // lblQQ
            // 
            this.lblQQ.AutoSize = true;
            this.lblQQ.Location = new System.Drawing.Point(20, 12);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(41, 12);
            this.lblQQ.TabIndex = 12;
            this.lblQQ.Text = "QQ号：";
            // 
            // txtVerify
            // 
            this.txtVerify.Location = new System.Drawing.Point(70, 63);
            this.txtVerify.MaxLength = 4;
            this.txtVerify.Name = "txtVerify";
            this.txtVerify.Size = new System.Drawing.Size(112, 21);
            this.txtVerify.TabIndex = 2;
            this.txtVerify.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVerify_KeyDown);
            this.txtVerify.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVerify_KeyPress);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(11, 146);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录农场";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(70, 36);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(112, 21);
            this.txtPwd.TabIndex = 1;
            // 
            // txtQQ
            // 
            this.txtQQ.Location = new System.Drawing.Point(70, 9);
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.Size = new System.Drawing.Size(112, 21);
            this.txtQQ.TabIndex = 0;
            this.txtQQ.Text = "361071552";
            // 
            // butVerify
            // 
            this.butVerify.Location = new System.Drawing.Point(92, 146);
            this.butVerify.Name = "butVerify";
            this.butVerify.Size = new System.Drawing.Size(87, 23);
            this.butVerify.TabIndex = 4;
            this.butVerify.Text = "重获验证码";
            this.butVerify.UseVisualStyleBackColor = true;
            this.butVerify.Click += new System.EventHandler(this.butVerify_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblQQ);
            this.panel1.Controls.Add(this.butVerify);
            this.panel1.Controls.Add(this.txtQQ);
            this.panel1.Controls.Add(this.picVerify);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.lblVerifyCode);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.lblPwd);
            this.panel1.Controls.Add(this.txtVerify);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 183);
            this.panel1.TabIndex = 15;
            // 
            // FrmFarmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 203);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmFarmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FrmFarmLogin_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmFarmLogin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picVerify)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picVerify;
        private System.Windows.Forms.Label lblVerifyCode;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblQQ;
        private System.Windows.Forms.TextBox txtVerify;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtQQ;
        private System.Windows.Forms.Button butVerify;
        private System.Windows.Forms.Panel panel1;
    }
}