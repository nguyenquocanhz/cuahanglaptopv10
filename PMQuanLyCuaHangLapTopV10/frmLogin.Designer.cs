namespace PMQuanLyCuaHangLapTopV10
{
    partial class frmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.checkShowPwd = new System.Windows.Forms.CheckBox();
            this.formFadeInTimer = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Label();
            this.pnlDragBar = new System.Windows.Forms.Panel();
            this.btnClosed = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlDragBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 675);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::PMQuanLyCuaHangLapTopV10.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 675);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(84)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(480, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số điện thoại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(84)))), ((int)(((byte)(127)))));
            this.label2.Location = new System.Drawing.Point(480, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu:";
            // 
            // txtAcc
            // 
            this.txtAcc.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcc.Location = new System.Drawing.Point(484, 245);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(450, 39);
            this.txtAcc.TabIndex = 1;
            this.txtAcc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcc_KeyPress);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(484, 345);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.Size = new System.Drawing.Size(450, 39);
            this.txtPass.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(101)))), ((int)(((byte)(106)))));
            this.label3.Location = new System.Drawing.Point(476, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 46);
            this.label3.TabIndex = 1;
            this.label3.Text = "Đăng Nhập Tài Khoản";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(84)))), ((int)(((byte)(127)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(484, 470);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 55);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.btnLogin_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.btnLogin_MouseLeave);
            // 
            // checkShowPwd
            // 
            this.checkShowPwd.AutoSize = true;
            this.checkShowPwd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkShowPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(84)))), ((int)(((byte)(127)))));
            this.checkShowPwd.Location = new System.Drawing.Point(484, 415);
            this.checkShowPwd.Name = "checkShowPwd";
            this.checkShowPwd.Size = new System.Drawing.Size(212, 28);
            this.checkShowPwd.TabIndex = 3;
            this.checkShowPwd.Text = "Hiển thị mật khẩu";
            this.checkShowPwd.UseVisualStyleBackColor = true;
            this.checkShowPwd.CheckedChanged += new System.EventHandler(this.checkShowPwd_CheckedChanged);
            // 
            // formFadeInTimer
            // 
            this.formFadeInTimer.Interval = 20;
            this.formFadeInTimer.Tick += new System.EventHandler(this.formFadeInTimer_Tick);
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(945, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 32);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "X";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // pnlDragBar
            // 
            this.pnlDragBar.BackColor = System.Drawing.Color.White;
            this.pnlDragBar.Controls.Add(this.btnClosed);
            this.pnlDragBar.Controls.Add(this.btnExit);
            this.pnlDragBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDragBar.Location = new System.Drawing.Point(450, 0);
            this.pnlDragBar.Name = "pnlDragBar";
            this.pnlDragBar.Size = new System.Drawing.Size(533, 40);
            this.pnlDragBar.TabIndex = 6;
            this.pnlDragBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlDragBar_MouseDown);
            this.pnlDragBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDragBar_MouseMove);
            this.pnlDragBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlDragBar_MouseUp);
            // 
            // btnClosed
            // 
            this.btnClosed.AutoSize = true;
            this.btnClosed.Location = new System.Drawing.Point(508, 5);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(22, 24);
            this.btnClosed.TabIndex = 7;
            this.btnClosed.Text = "X";
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(983, 675);
            this.Controls.Add(this.pnlDragBar);
            this.Controls.Add(this.checkShowPwd);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtAcc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmLogin";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập Tài Khoản";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlDragBar.ResumeLayout(false);
            this.pnlDragBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox checkShowPwd;
        private System.Windows.Forms.Timer formFadeInTimer;
        private System.Windows.Forms.Label btnExit;
        private System.Windows.Forms.Panel pnlDragBar;
        private System.Windows.Forms.Label btnClosed;
    }
}