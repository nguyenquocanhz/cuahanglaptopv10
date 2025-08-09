namespace PMQuanLyCuaHangLapTopV10
{
    partial class frmPhieuBaoHanh
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
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.ColMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlChiTietSP = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTenOrMaSP = new System.Windows.Forms.TextBox();
            this.lblSanPham = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            this.pnlChiTietSP.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvChiTietPhieuNhap
            // 
            this.dgvChiTietPhieuNhap.AllowUserToAddRows = false;
            this.dgvChiTietPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhieuNhap.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMaSP,
            this.ColTenSP,
            this.ColDonGia,
            this.ColSoLuong,
            this.ColThanhTien});
            this.dgvChiTietPhieuNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(0, 75);
            this.dgvChiTietPhieuNhap.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.RowHeadersWidth = 51;
            this.dgvChiTietPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(1216, 312);
            this.dgvChiTietPhieuNhap.TabIndex = 5;
            // 
            // ColMaSP
            // 
            this.ColMaSP.HeaderText = "Mã SP";
            this.ColMaSP.MinimumWidth = 6;
            this.ColMaSP.Name = "ColMaSP";
            this.ColMaSP.ReadOnly = true;
            // 
            // ColTenSP
            // 
            this.ColTenSP.HeaderText = "Tên sản phẩm";
            this.ColTenSP.MinimumWidth = 6;
            this.ColTenSP.Name = "ColTenSP";
            this.ColTenSP.ReadOnly = true;
            // 
            // ColDonGia
            // 
            this.ColDonGia.HeaderText = "Đơn giá nhập";
            this.ColDonGia.MinimumWidth = 6;
            this.ColDonGia.Name = "ColDonGia";
            this.ColDonGia.ReadOnly = true;
            // 
            // ColSoLuong
            // 
            this.ColSoLuong.HeaderText = "Số lượng";
            this.ColSoLuong.MinimumWidth = 6;
            this.ColSoLuong.Name = "ColSoLuong";
            this.ColSoLuong.ReadOnly = true;
            // 
            // ColThanhTien
            // 
            this.ColThanhTien.HeaderText = "Thành tiền";
            this.ColThanhTien.MinimumWidth = 6;
            this.ColThanhTien.Name = "ColThanhTien";
            this.ColThanhTien.ReadOnly = true;
            // 
            // pnlChiTietSP
            // 
            this.pnlChiTietSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChiTietSP.Controls.Add(this.btnAdd);
            this.pnlChiTietSP.Controls.Add(this.txtTenOrMaSP);
            this.pnlChiTietSP.Controls.Add(this.lblSanPham);
            this.pnlChiTietSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChiTietSP.Location = new System.Drawing.Point(0, 0);
            this.pnlChiTietSP.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChiTietSP.Name = "pnlChiTietSP";
            this.pnlChiTietSP.Size = new System.Drawing.Size(1216, 75);
            this.pnlChiTietSP.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1072, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 47);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Tạo mới";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtTenOrMaSP
            // 
            this.txtTenOrMaSP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenOrMaSP.Location = new System.Drawing.Point(151, 23);
            this.txtTenOrMaSP.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenOrMaSP.MaxLength = 100;
            this.txtTenOrMaSP.Name = "txtTenOrMaSP";
            this.txtTenOrMaSP.Size = new System.Drawing.Size(270, 30);
            this.txtTenOrMaSP.TabIndex = 5;
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSanPham.Location = new System.Drawing.Point(31, 26);
            this.lblSanPham.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(83, 23);
            this.lblSanPham.TabIndex = 0;
            this.lblSanPham.Text = "Tìm kiếm:";
            // 
            // frmPhieuBaoHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 450);
            this.Controls.Add(this.dgvChiTietPhieuNhap);
            this.Controls.Add(this.pnlChiTietSP);
            this.Name = "frmPhieuBaoHanh";
            this.Text = "Phiếu bảo hành";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            this.pnlChiTietSP.ResumeLayout(false);
            this.pnlChiTietSP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvChiTietPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColThanhTien;
        private System.Windows.Forms.Panel pnlChiTietSP;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTenOrMaSP;
        private System.Windows.Forms.Label lblSanPham;
    }
}