namespace PMQuanLyCuaHangLapTopV10
{
    partial class frmMain
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stripLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu1 = new System.Windows.Forms.Panel();
            this.frmSanPham = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.frmThongKeDoanhSo = new System.Windows.Forms.Button();
            this.frmNhanVien = new System.Windows.Forms.Button();
            this.frmNhaCungCap = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.Menu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(43)))), ((int)(((byte)(91)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1172, 102);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(813, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thời gian:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(37, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Xin chào:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1172, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.stripLogout});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // stripLogout
            // 
            this.stripLogout.Name = "stripLogout";
            this.stripLogout.Size = new System.Drawing.Size(220, 26);
            this.stripLogout.Text = "Đăng xuất";
            this.stripLogout.Click += new System.EventHandler(this.stripLogout_Click);
            // 
            // Menu1
            // 
            this.Menu1.AutoScroll = true;
            this.Menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(73)))), ((int)(((byte)(122)))));
            this.Menu1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Menu1.Controls.Add(this.frmSanPham);
            this.Menu1.Controls.Add(this.button7);
            this.Menu1.Controls.Add(this.button4);
            this.Menu1.Controls.Add(this.frmThongKeDoanhSo);
            this.Menu1.Controls.Add(this.frmNhanVien);
            this.Menu1.Controls.Add(this.frmNhaCungCap);
            this.Menu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Menu1.Location = new System.Drawing.Point(0, 102);
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(1172, 621);
            this.Menu1.TabIndex = 4;
            // 
            // frmSanPham
            // 
            this.frmSanPham.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmSanPham.Image = global::PMQuanLyCuaHangLapTopV10.Properties.Resources.icons8_laptop_25;
            this.frmSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmSanPham.Location = new System.Drawing.Point(470, 271);
            this.frmSanPham.Name = "frmSanPham";
            this.frmSanPham.Size = new System.Drawing.Size(218, 134);
            this.frmSanPham.TabIndex = 0;
            this.frmSanPham.Text = "Sản phẩm";
            this.frmSanPham.UseVisualStyleBackColor = true;
            this.frmSanPham.Click += new System.EventHandler(this.frmSanPham_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = global::PMQuanLyCuaHangLapTopV10.Properties.Resources.icons8_spanner_25;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(470, 29);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(218, 134);
            this.button7.TabIndex = 1;
            this.button7.Text = "Bảo hành";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::PMQuanLyCuaHangLapTopV10.Properties.Resources.icons8_create_order_25;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(139, 271);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(218, 134);
            this.button4.TabIndex = 0;
            this.button4.Text = "Hóa đơn";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // frmThongKeDoanhSo
            // 
            this.frmThongKeDoanhSo.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmThongKeDoanhSo.Image = global::PMQuanLyCuaHangLapTopV10.Properties.Resources.icons8_chart_25;
            this.frmThongKeDoanhSo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmThongKeDoanhSo.Location = new System.Drawing.Point(816, 29);
            this.frmThongKeDoanhSo.Name = "frmThongKeDoanhSo";
            this.frmThongKeDoanhSo.Size = new System.Drawing.Size(218, 134);
            this.frmThongKeDoanhSo.TabIndex = 0;
            this.frmThongKeDoanhSo.Text = "Thống kê";
            this.frmThongKeDoanhSo.UseVisualStyleBackColor = true;
            this.frmThongKeDoanhSo.Click += new System.EventHandler(this.frmThongKeDoanhSo_Click);
            // 
            // frmNhanVien
            // 
            this.frmNhanVien.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmNhanVien.Image = global::PMQuanLyCuaHangLapTopV10.Properties.Resources.icons8_employee_25;
            this.frmNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmNhanVien.Location = new System.Drawing.Point(816, 271);
            this.frmNhanVien.Name = "frmNhanVien";
            this.frmNhanVien.Size = new System.Drawing.Size(218, 134);
            this.frmNhanVien.TabIndex = 0;
            this.frmNhanVien.Text = "Nhân viên";
            this.frmNhanVien.UseVisualStyleBackColor = true;
            this.frmNhanVien.Click += new System.EventHandler(this.frmNhanVien_Click);
            // 
            // frmNhaCungCap
            // 
            this.frmNhaCungCap.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmNhaCungCap.Image = global::PMQuanLyCuaHangLapTopV10.Properties.Resources.icons8_supplier_25__1_;
            this.frmNhaCungCap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmNhaCungCap.Location = new System.Drawing.Point(139, 29);
            this.frmNhaCungCap.Name = "frmNhaCungCap";
            this.frmNhaCungCap.Size = new System.Drawing.Size(218, 134);
            this.frmNhaCungCap.TabIndex = 0;
            this.frmNhaCungCap.Text = "Nhà cung cấp";
            this.frmNhaCungCap.UseVisualStyleBackColor = true;
            this.frmNhaCungCap.Click += new System.EventHandler(this.frmNhaCungCap_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 723);
            this.Controls.Add(this.Menu1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnTechZ Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Menu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button frmNhaCungCap;
        private System.Windows.Forms.Button frmSanPham;
        private System.Windows.Forms.Button frmNhanVien;
        private System.Windows.Forms.Button frmThongKeDoanhSo;
        private System.Windows.Forms.Panel Menu1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripLogout;
        private System.Windows.Forms.Label label1;
    }
}