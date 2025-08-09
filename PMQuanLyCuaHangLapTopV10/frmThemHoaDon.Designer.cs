using System;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    partial class frmThemHoaDon : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTop;
        private Label lblTieuDe;
        private Panel pnlThongTinHoaDon;
        private DateTimePicker dtpNgayLap;
        private TextBox txtMaHoaDon;
        private Label lblNgayLap;
        private Label lblSanPham;
        private DataGridView dgvChiTietHoaDon;
        private Label lblKhachHang;
        private Label lblMaHoaDon;
        private Panel pnlChiTietSP;
        private Panel pnlBottom;
        private Button btnHuy;
        private Button btnLuu;
        private TextBox txtTongTien;

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
            this.pnlThongTinHoaDon = new System.Windows.Forms.Panel();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtMaHoaDon = new System.Windows.Forms.TextBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.pnlChiTietSP = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTenOrMaSP = new System.Windows.Forms.TextBox();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.menu_thaotac = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.act_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.act_lammoi = new System.Windows.Forms.ToolStripMenuItem();
            this.act_add = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnVeryKM = new System.Windows.Forms.Button();
            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongTienTT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTienGiam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.ColMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.pnlThongTinHoaDon.SuspendLayout();
            this.pnlChiTietSP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
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
            this.lblTieuDe.Location = new System.Drawing.Point(505, 22);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(237, 31);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THÊM HÓA ĐƠN";
            // 
            // pnlThongTinHoaDon
            // 
            this.pnlThongTinHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinHoaDon.Controls.Add(this.txtMaNV);
            this.pnlThongTinHoaDon.Controls.Add(this.label7);
            this.pnlThongTinHoaDon.Controls.Add(this.txtMaKH);
            this.pnlThongTinHoaDon.Controls.Add(this.label6);
            this.pnlThongTinHoaDon.Controls.Add(this.txtSDT);
            this.pnlThongTinHoaDon.Controls.Add(this.label1);
            this.pnlThongTinHoaDon.Controls.Add(this.txtTenKH);
            this.pnlThongTinHoaDon.Controls.Add(this.dtpNgayLap);
            this.pnlThongTinHoaDon.Controls.Add(this.txtMaHoaDon);
            this.pnlThongTinHoaDon.Controls.Add(this.lblNgayLap);
            this.pnlThongTinHoaDon.Controls.Add(this.lblKhachHang);
            this.pnlThongTinHoaDon.Controls.Add(this.lblMaHoaDon);
            this.pnlThongTinHoaDon.Location = new System.Drawing.Point(13, 101);
            this.pnlThongTinHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.pnlThongTinHoaDon.Name = "pnlThongTinHoaDon";
            this.pnlThongTinHoaDon.Size = new System.Drawing.Size(1213, 253);
            this.pnlThongTinHoaDon.TabIndex = 1;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(682, 78);
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
            this.label7.Location = new System.Drawing.Point(528, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "Mã Nhân Viên:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKH.Location = new System.Drawing.Point(172, 75);
            this.txtMaKH.MaxLength = 50;
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(299, 31);
            this.txtMaKH.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mã Khách Hàng:";
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
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(172, 139);
            this.txtTenKH.MaxLength = 50;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.ReadOnly = true;
            this.txtTenKH.Size = new System.Drawing.Size(299, 31);
            this.txtTenKH.TabIndex = 6;
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(682, 14);
            this.dtpNgayLap.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(299, 31);
            this.dtpNgayLap.TabIndex = 5;
            // 
            // txtMaHoaDon
            // 
            this.txtMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoaDon.Location = new System.Drawing.Point(172, 8);
            this.txtMaHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.ReadOnly = true;
            this.txtMaHoaDon.Size = new System.Drawing.Size(299, 31);
            this.txtMaHoaDon.TabIndex = 3;
            this.txtMaHoaDon.Text = "HD-BH";
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayLap.Location = new System.Drawing.Point(527, 14);
            this.lblNgayLap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(87, 25);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhachHang.Location = new System.Drawing.Point(19, 142);
            this.lblKhachHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(108, 25);
            this.lblKhachHang.TabIndex = 1;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHoaDon.Location = new System.Drawing.Point(19, 14);
            this.lblMaHoaDon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(113, 25);
            this.lblMaHoaDon.TabIndex = 0;
            this.lblMaHoaDon.Text = "Mã hóa đơn:";
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
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(452, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 47);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTenOrMaSP
            // 
            this.txtTenOrMaSP.Location = new System.Drawing.Point(151, 23);
            this.txtTenOrMaSP.MaxLength = 100;
            this.txtTenOrMaSP.Name = "txtTenOrMaSP";
            this.txtTenOrMaSP.Size = new System.Drawing.Size(239, 22);
            this.txtTenOrMaSP.TabIndex = 5;
            this.txtTenOrMaSP.TextChanged += new System.EventHandler(this.txtTenOrMaSP_TextChanged);
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Location = new System.Drawing.Point(31, 26);
            this.lblSanPham.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(65, 16);
            this.lblSanPham.TabIndex = 0;
            this.lblSanPham.Text = "Tìm kiếm:";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.AllowUserToAddRows = false;
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColMaSP,
            this.ColTenSP,
            this.ColDonGia,
            this.ColSoLuong,
            this.ColThanhTien});
            this.dgvChiTietHoaDon.ContextMenuStrip = this.menu_thaotac;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(16, 445);
            this.dgvChiTietHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dgvChiTietHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(1213, 176);
            this.dgvChiTietHoaDon.TabIndex = 3;
            this.dgvChiTietHoaDon.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietHoaDon_CellEndEdit);
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
            this.pnlBottom.Controls.Add(this.label8);
            this.pnlBottom.Controls.Add(this.btnVeryKM);
            this.pnlBottom.Controls.Add(this.txtMaKM);
            this.pnlBottom.Controls.Add(this.label5);
            this.pnlBottom.Controls.Add(this.txtTongTienTT);
            this.pnlBottom.Controls.Add(this.label4);
            this.pnlBottom.Controls.Add(this.txtTienGiam);
            this.pnlBottom.Controls.Add(this.label2);
            this.pnlBottom.Controls.Add(this.btnHuy);
            this.pnlBottom.Controls.Add(this.btnLuu);
            this.pnlBottom.Controls.Add(this.txtTongTien);
            this.pnlBottom.Location = new System.Drawing.Point(16, 629);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1213, 574);
            this.pnlBottom.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(107, 166);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 31);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tổng TT:";
            // 
            // btnVeryKM
            // 
            this.btnVeryKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnVeryKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeryKM.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeryKM.ForeColor = System.Drawing.Color.White;
            this.btnVeryKM.Location = new System.Drawing.Point(1019, 24);
            this.btnVeryKM.Margin = new System.Windows.Forms.Padding(4);
            this.btnVeryKM.Name = "btnVeryKM";
            this.btnVeryKM.Size = new System.Drawing.Size(145, 41);
            this.btnVeryKM.TabIndex = 14;
            this.btnVeryKM.Text = "Áp dụng";
            this.btnVeryKM.UseVisualStyleBackColor = false;
            this.btnVeryKM.Click += new System.EventHandler(this.btnVeryKM_Click);
            // 
            // txtMaKM
            // 
            this.txtMaKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKM.Location = new System.Drawing.Point(771, 25);
            this.txtMaKM.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaKM.Name = "txtMaKM";
            this.txtMaKM.Size = new System.Drawing.Size(195, 26);
            this.txtMaKM.TabIndex = 13;
            this.txtMaKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(537, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mã giảm giá (nếu có):";
            // 
            // txtTongTienTT
            // 
            this.txtTongTienTT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTongTienTT.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienTT.ForeColor = System.Drawing.Color.Olive;
            this.txtTongTienTT.Location = new System.Drawing.Point(279, 21);
            this.txtTongTienTT.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongTienTT.Name = "txtTongTienTT";
            this.txtTongTienTT.ReadOnly = true;
            this.txtTongTienTT.Size = new System.Drawing.Size(241, 38);
            this.txtTongTienTT.TabIndex = 11;
            this.txtTongTienTT.Text = "0";
            this.txtTongTienTT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tổng giá trị đơn:";
            // 
            // txtTienGiam
            // 
            this.txtTienGiam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTienGiam.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienGiam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTienGiam.Location = new System.Drawing.Point(279, 87);
            this.txtTienGiam.Margin = new System.Windows.Forms.Padding(4);
            this.txtTienGiam.Name = "txtTienGiam";
            this.txtTienGiam.ReadOnly = true;
            this.txtTienGiam.Size = new System.Drawing.Size(241, 38);
            this.txtTienGiam.TabIndex = 7;
            this.txtTienGiam.Text = "0";
            this.txtTienGiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tổng tiền giảm:";
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Red;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(1019, 107);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(146, 41);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(1019, 169);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(146, 41);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTongTien.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTongTien.Location = new System.Drawing.Point(279, 159);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(241, 38);
            this.txtTongTien.TabIndex = 1;
            this.txtTongTien.Text = "0";
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.ColDonGia.HeaderText = "Đơn giá";
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
            // frmThemHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 1055);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.pnlChiTietSP);
            this.Controls.Add(this.pnlThongTinHoaDon);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmThemHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Hóa Đơn";
            this.Load += new System.EventHandler(this.frmThemHoaDon_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlThongTinHoaDon.ResumeLayout(false);
            this.pnlThongTinHoaDon.PerformLayout();
            this.pnlChiTietSP.ResumeLayout(false);
            this.pnlChiTietSP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.menu_thaotac.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox txtTenOrMaSP;
        private TextBox txtSDT;
        private Label label1;
        private TextBox txtTenKH;
        private TextBox txtTienGiam;
        private Label label2;
        private TextBox txtTongTienTT;
        private Label label4;
        private ContextMenuStrip menu_thaotac;
        private ToolStripMenuItem act_delete;
        private ToolStripMenuItem act_lammoi;
        private ToolStripMenuItem act_add;
        private Button btnAdd;
        private TextBox txtMaKM;
        private Label label5;
        private Button btnVeryKM;
        private TextBox txtMaNV;
        private Label label7;
        private TextBox txtMaKH;
        private Label label6;
        private Label label8;
        private DataGridViewTextBoxColumn ColMaSP;
        private DataGridViewTextBoxColumn ColTenSP;
        private DataGridViewTextBoxColumn ColDonGia;
        private DataGridViewTextBoxColumn ColSoLuong;
        private DataGridViewTextBoxColumn ColThanhTien;
    }
}