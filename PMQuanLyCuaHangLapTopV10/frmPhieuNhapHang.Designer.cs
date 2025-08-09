using System;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    partial class frmPhieuNhapHang : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Label lblTieuDe;
        private Panel pnlThongTinPhieu;
        private DateTimePicker dtpNgayLap;
        private TextBox txtMaPhieuNhap;
        private Label lblNgayLap;
        private Label lblSanPham; // This is for pnlChiTietSP's search label
        private DataGridView dgvChiTietPhieuNhap;
        private Label lblNhaCungCap;
        private Label lblMaPhieuNhap;
        private Panel pnlChiTietSP;
        private Panel pnlBottom;
        private Button btnHuy;
        private Button btnLuu;
        private TextBox txtTongTien;

        // Controls added in pnlThongTinPhieu
        private TextBox txtMaNV;
        private Label label7;
        private TextBox txtMaNCC;
        private Label label6;
        private TextBox txtSDT;
        private Label label1;
        private TextBox txtTenNCC;

        // Controls added in pnlChiTietSP
        private Button btnAdd;
        private TextBox txtTenOrMaSP;

        // ContextMenu for DataGridView
        private ContextMenuStrip menu_thaotac;
        private ToolStripMenuItem act_delete;
        private ToolStripMenuItem act_lammoi;
        private ToolStripMenuItem act_add;

        // Controls for pnlBottom
        private Label label8; // Thanh toán:
        private TextBox txtTongGiaNhap;
        private Label label4;


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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlThongTinPhieu = new System.Windows.Forms.Panel();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.lblMaPhieuNhap = new System.Windows.Forms.Label();
            this.pnlChiTietSP = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTenOrMaSP = new System.Windows.Forms.TextBox();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.ColMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menu_thaotac = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.act_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.act_lammoi = new System.Windows.Forms.ToolStripMenuItem();
            this.act_add = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTongGiaNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.pnlThongTinPhieu.SuspendLayout();
            this.pnlChiTietSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            this.menu_thaotac.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Green;
            this.pnlTop.Controls.Add(this.lblTieuDe);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1246, 93);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(455, 22);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(371, 31);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THÊM PHIẾU NHẬP HÀNG";
            // 
            // pnlThongTinPhieu
            // 
            this.pnlThongTinPhieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinPhieu.Controls.Add(this.txtMaNV);
            this.pnlThongTinPhieu.Controls.Add(this.label7);
            this.pnlThongTinPhieu.Controls.Add(this.txtMaNCC);
            this.pnlThongTinPhieu.Controls.Add(this.label6);
            this.pnlThongTinPhieu.Controls.Add(this.txtSDT);
            this.pnlThongTinPhieu.Controls.Add(this.label1);
            this.pnlThongTinPhieu.Controls.Add(this.txtTenNCC);
            this.pnlThongTinPhieu.Controls.Add(this.dtpNgayLap);
            this.pnlThongTinPhieu.Controls.Add(this.txtMaPhieuNhap);
            this.pnlThongTinPhieu.Controls.Add(this.lblNgayLap);
            this.pnlThongTinPhieu.Controls.Add(this.lblNhaCungCap);
            this.pnlThongTinPhieu.Controls.Add(this.lblMaPhieuNhap);
            this.pnlThongTinPhieu.Location = new System.Drawing.Point(13, 101);
            this.pnlThongTinPhieu.Margin = new System.Windows.Forms.Padding(4);
            this.pnlThongTinPhieu.Name = "pnlThongTinPhieu";
            this.pnlThongTinPhieu.Size = new System.Drawing.Size(1213, 253);
            this.pnlThongTinPhieu.TabIndex = 1;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(854, 78);
            this.txtMaNV.MaxLength = 50;
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(299, 31);
            this.txtMaNV.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(700, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Mã Nhân Viên:";
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNCC.Location = new System.Drawing.Point(201, 75);
            this.txtMaNCC.MaxLength = 50;
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.ReadOnly = true;
            this.txtMaNCC.Size = new System.Drawing.Size(299, 31);
            this.txtMaNCC.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mã Nhà cung cấp:";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(172, 198);
            this.txtSDT.MaxLength = 20;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.ReadOnly = true;
            this.txtSDT.Size = new System.Drawing.Size(299, 31);
            this.txtSDT.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 208);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số điện thoại :";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNCC.Location = new System.Drawing.Point(172, 139);
            this.txtTenNCC.MaxLength = 50;
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.ReadOnly = true;
            this.txtTenNCC.Size = new System.Drawing.Size(299, 31);
            this.txtTenNCC.TabIndex = 6;
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(854, 14);
            this.dtpNgayLap.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(299, 31);
            this.dtpNgayLap.TabIndex = 5;
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(201, 8);
            this.txtMaPhieuNhap.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.ReadOnly = true;
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(299, 31);
            this.txtMaPhieuNhap.TabIndex = 3;
            this.txtMaPhieuNhap.Text = "PN-NH";
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayLap.Location = new System.Drawing.Point(699, 14);
            this.lblNgayLap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(87, 25);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaCungCap.Location = new System.Drawing.Point(19, 142);
            this.lblNhaCungCap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(125, 25);
            this.lblNhaCungCap.TabIndex = 1;
            this.lblNhaCungCap.Text = "Nhà cung cấp:";
            // 
            // lblMaPhieuNhap
            // 
            this.lblMaPhieuNhap.AutoSize = true;
            this.lblMaPhieuNhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuNhap.Location = new System.Drawing.Point(19, 14);
            this.lblMaPhieuNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaPhieuNhap.Name = "lblMaPhieuNhap";
            this.lblMaPhieuNhap.Size = new System.Drawing.Size(135, 25);
            this.lblMaPhieuNhap.TabIndex = 0;
            this.lblMaPhieuNhap.Text = "Mã phiếu nhập:";
            // 
            // pnlChiTietSP
            // 
            this.pnlChiTietSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChiTietSP.Controls.Add(this.btnAdd);
            this.pnlChiTietSP.Controls.Add(this.txtTenOrMaSP);
            this.pnlChiTietSP.Controls.Add(this.lblSanPham);
            this.pnlChiTietSP.Location = new System.Drawing.Point(13, 362);
            this.pnlChiTietSP.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChiTietSP.Name = "pnlChiTietSP";
            this.pnlChiTietSP.Size = new System.Drawing.Size(1213, 75);
            this.pnlChiTietSP.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(447, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 47);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.txtTenOrMaSP.TextChanged += new System.EventHandler(this.txtTenOrMaSP_TextChanged);
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
            this.dgvChiTietPhieuNhap.ContextMenuStrip = this.menu_thaotac;
            this.dgvChiTietPhieuNhap.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(16, 445);
            this.dgvChiTietPhieuNhap.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.RowHeadersWidth = 51;
            this.dgvChiTietPhieuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(1213, 176);
            this.dgvChiTietPhieuNhap.TabIndex = 3;
            this.dgvChiTietPhieuNhap.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuNhap_CellEndEdit);
            this.dgvChiTietPhieuNhap.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPhieuNhap_CellValueChanged);
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
            // 
            // ColThanhTien
            // 
            this.ColThanhTien.HeaderText = "Thành tiền";
            this.ColThanhTien.MinimumWidth = 6;
            this.ColThanhTien.Name = "ColThanhTien";
            this.ColThanhTien.ReadOnly = true;
            // 
            // menu_thaotac
            // 
            this.menu_thaotac.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_thaotac.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.act_delete,
            this.act_lammoi,
            this.act_add});
            this.menu_thaotac.Name = "menu_thaotac";
            this.menu_thaotac.ShowImageMargin = false;
            this.menu_thaotac.Size = new System.Drawing.Size(125, 76);
            this.menu_thaotac.Text = "Xóa sản phẩm";
            this.menu_thaotac.Opening += new System.ComponentModel.CancelEventHandler(this.menu_thaotac_Opening);
            // 
            // act_delete
            // 
            this.act_delete.Name = "act_delete";
            this.act_delete.Size = new System.Drawing.Size(124, 24);
            this.act_delete.Text = "Xóa item";
            this.act_delete.Click += new System.EventHandler(this.act_delete_Click);
            // 
            // act_lammoi
            // 
            this.act_lammoi.Name = "act_lammoi";
            this.act_lammoi.Size = new System.Drawing.Size(124, 24);
            this.act_lammoi.Text = "Làm mới ";
            // 
            // act_add
            // 
            this.act_add.Name = "act_add";
            this.act_add.Size = new System.Drawing.Size(124, 24);
            this.act_add.Text = "Thêm item";
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoScroll = true;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.button1);
            this.pnlBottom.Controls.Add(this.label8);
            this.pnlBottom.Controls.Add(this.txtTongGiaNhap);
            this.pnlBottom.Controls.Add(this.label4);
            this.pnlBottom.Controls.Add(this.btnHuy);
            this.pnlBottom.Controls.Add(this.btnLuu);
            this.pnlBottom.Controls.Add(this.txtTongTien);
            this.pnlBottom.Location = new System.Drawing.Point(16, 629);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1213, 240);
            this.pnlBottom.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1048, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 45);
            this.button1.TabIndex = 16;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(39, 92);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 31);
            this.label8.TabIndex = 15;
            this.label8.Text = "Thanh toán:";
            // 
            // txtTongGiaNhap
            // 
            this.txtTongGiaNhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiaNhap.Location = new System.Drawing.Point(209, 18);
            this.txtTongGiaNhap.Name = "txtTongGiaNhap";
            this.txtTongGiaNhap.ReadOnly = true;
            this.txtTongGiaNhap.Size = new System.Drawing.Size(250, 31);
            this.txtTongGiaNhap.TabIndex = 0;
            this.txtTongGiaNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tổng giá nhập:";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(834, 92);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(140, 45);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(834, 18);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(140, 45);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu Phiếu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(209, 85);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(250, 38);
            this.txtTongTien.TabIndex = 2;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmPhieuNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 882);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvChiTietPhieuNhap);
            this.Controls.Add(this.pnlChiTietSP);
            this.Controls.Add(this.pnlThongTinPhieu);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmPhieuNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu Nhập Hàng";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlThongTinPhieu.ResumeLayout(false);
            this.pnlThongTinPhieu.PerformLayout();
            this.pnlChiTietSP.ResumeLayout(false);
            this.pnlChiTietSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            this.menu_thaotac.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        private DataGridViewTextBoxColumn ColMaSP;
        private DataGridViewTextBoxColumn ColTenSP;
        private DataGridViewTextBoxColumn ColDonGia;
        private DataGridViewTextBoxColumn ColSoLuong;
        private DataGridViewTextBoxColumn ColThanhTien;
        private Button button1;
        #endregion


        // private void btnThemDonNhap_Click(object sender, EventArgs e) { /* TODO: Implement */ }
        // private void txtChietKhau_TextChanged(object sender, EventArgs e) { /* TODO: Implement */ }
        // private void btnHuy_Click(object sender, EventArgs e) { /* TODO: Implement */ }
        // private void btnLuu_Click(object sender, EventArgs e) { /* TODO: Implement */ }
        // private void frmPhieuNhapHang_Load(object sender, EventArgs e) { /* TODO: Implement */ }
    }
}