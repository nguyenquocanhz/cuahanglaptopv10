using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PMQuanLyCuaHangLapTopV10
{
    partial class frmThongKeDoanhSo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStatCards = new System.Windows.Forms.Panel();
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblLoiNhuanNgay = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlLuongBanHang = new System.Windows.Forms.Panel();
            this.picSalesIcon = new System.Windows.Forms.PictureBox();
            this.lblLuongBanHang = new System.Windows.Forms.Label();
            this.lblLuongBanHangTitle = new System.Windows.Forms.Label();
            this.pnlDoanhThuThang = new System.Windows.Forms.Panel();
            this.picRevenueIcon = new System.Windows.Forms.PictureBox();
            this.lblDoanhThuThang = new System.Windows.Forms.Label();
            this.lblDoanhThuThangTitle = new System.Windows.Forms.Label();
            this.pnlHangTon = new System.Windows.Forms.Panel();
            this.picInventoryIcon = new System.Windows.Forms.PictureBox();
            this.lblChiPhi = new System.Windows.Forms.Label();
            this.lblHangTonTitle = new System.Windows.Forms.Label();
            this.pnlLoiNhuan = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLoiNhuanThang = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picProfitIcon = new System.Windows.Forms.PictureBox();
            this.lblLoiNhuan = new System.Windows.Forms.Label();
            this.lblLoiNhuanTitle = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.tabControlThongKe = new System.Windows.Forms.TabControl();
            this.tabPageDoanhSo = new System.Windows.Forms.TabPage();
            this.tlpTabContent = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.chartDoanhSo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvChiTietLoiNhuanTheoSP = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlStatCards.SuspendLayout();
            this.tlpCards.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlLuongBanHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalesIcon)).BeginInit();
            this.pnlDoanhThuThang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRevenueIcon)).BeginInit();
            this.pnlHangTon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInventoryIcon)).BeginInit();
            this.pnlLoiNhuan.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfitIcon)).BeginInit();
            this.pnlMainContent.SuspendLayout();
            this.tabControlThongKe.SuspendLayout();
            this.tabPageDoanhSo.SuspendLayout();
            this.tlpTabContent.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhSo)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietLoiNhuanTheoSP)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1277, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(303, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THỐNG KÊ DOANH SỐ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlStatCards, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlMainContent, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1277, 839);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlStatCards
            // 
            this.pnlStatCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlStatCards.Controls.Add(this.tlpCards);
            this.pnlStatCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatCards.Location = new System.Drawing.Point(3, 3);
            this.pnlStatCards.Name = "pnlStatCards";
            this.pnlStatCards.Padding = new System.Windows.Forms.Padding(10);
            this.pnlStatCards.Size = new System.Drawing.Size(1271, 203);
            this.pnlStatCards.TabIndex = 0;
            // 
            // tlpCards
            // 
            this.tlpCards.ColumnCount = 5;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpCards.Controls.Add(this.panel2, 4, 0);
            this.tlpCards.Controls.Add(this.pnlLuongBanHang, 0, 0);
            this.tlpCards.Controls.Add(this.pnlDoanhThuThang, 1, 0);
            this.tlpCards.Controls.Add(this.pnlHangTon, 2, 0);
            this.tlpCards.Controls.Add(this.pnlLoiNhuan, 3, 0);
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpCards.Location = new System.Drawing.Point(10, 10);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCards.Size = new System.Drawing.Size(1251, 120);
            this.tlpCards.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblLoiNhuanNgay);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1010, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 100);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackColor = System.Drawing.Color.Magenta;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 98);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // lblLoiNhuanNgay
            // 
            this.lblLoiNhuanNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoiNhuanNgay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoiNhuanNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblLoiNhuanNgay.Location = new System.Drawing.Point(-28, 62);
            this.lblLoiNhuanNgay.Name = "lblLoiNhuanNgay";
            this.lblLoiNhuanNgay.Size = new System.Drawing.Size(254, 28);
            this.lblLoiNhuanNgay.TabIndex = 2;
            this.lblLoiNhuanNgay.Text = "0 VNĐ";
            this.lblLoiNhuanNgay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(15, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Lợi nhuận hôm nay";
            // 
            // pnlLuongBanHang
            // 
            this.pnlLuongBanHang.BackColor = System.Drawing.Color.White;
            this.pnlLuongBanHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLuongBanHang.Controls.Add(this.picSalesIcon);
            this.pnlLuongBanHang.Controls.Add(this.lblLuongBanHang);
            this.pnlLuongBanHang.Controls.Add(this.lblLuongBanHangTitle);
            this.pnlLuongBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLuongBanHang.Location = new System.Drawing.Point(10, 10);
            this.pnlLuongBanHang.Margin = new System.Windows.Forms.Padding(10);
            this.pnlLuongBanHang.Name = "pnlLuongBanHang";
            this.pnlLuongBanHang.Size = new System.Drawing.Size(230, 100);
            this.pnlLuongBanHang.TabIndex = 0;
            // 
            // picSalesIcon
            // 
            this.picSalesIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picSalesIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.picSalesIcon.Location = new System.Drawing.Point(0, 0);
            this.picSalesIcon.Name = "picSalesIcon";
            this.picSalesIcon.Size = new System.Drawing.Size(10, 98);
            this.picSalesIcon.TabIndex = 2;
            this.picSalesIcon.TabStop = false;
            // 
            // lblLuongBanHang
            // 
            this.lblLuongBanHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLuongBanHang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLuongBanHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.lblLuongBanHang.Location = new System.Drawing.Point(-27, 62);
            this.lblLuongBanHang.Name = "lblLuongBanHang";
            this.lblLuongBanHang.Size = new System.Drawing.Size(252, 28);
            this.lblLuongBanHang.TabIndex = 1;
            this.lblLuongBanHang.Text = "0 VNĐ";
            this.lblLuongBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLuongBanHangTitle
            // 
            this.lblLuongBanHangTitle.AutoSize = true;
            this.lblLuongBanHangTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLuongBanHangTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLuongBanHangTitle.Location = new System.Drawing.Point(15, 10);
            this.lblLuongBanHangTitle.Name = "lblLuongBanHangTitle";
            this.lblLuongBanHangTitle.Size = new System.Drawing.Size(164, 23);
            this.lblLuongBanHangTitle.TabIndex = 0;
            this.lblLuongBanHangTitle.Text = "Doanh thu hôm nay";
            // 
            // pnlDoanhThuThang
            // 
            this.pnlDoanhThuThang.BackColor = System.Drawing.Color.White;
            this.pnlDoanhThuThang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDoanhThuThang.Controls.Add(this.picRevenueIcon);
            this.pnlDoanhThuThang.Controls.Add(this.lblDoanhThuThang);
            this.pnlDoanhThuThang.Controls.Add(this.lblDoanhThuThangTitle);
            this.pnlDoanhThuThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDoanhThuThang.Location = new System.Drawing.Point(260, 10);
            this.pnlDoanhThuThang.Margin = new System.Windows.Forms.Padding(10);
            this.pnlDoanhThuThang.Name = "pnlDoanhThuThang";
            this.pnlDoanhThuThang.Size = new System.Drawing.Size(230, 100);
            this.pnlDoanhThuThang.TabIndex = 1;
            // 
            // picRevenueIcon
            // 
            this.picRevenueIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picRevenueIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.picRevenueIcon.Location = new System.Drawing.Point(0, 0);
            this.picRevenueIcon.Name = "picRevenueIcon";
            this.picRevenueIcon.Size = new System.Drawing.Size(10, 98);
            this.picRevenueIcon.TabIndex = 3;
            this.picRevenueIcon.TabStop = false;
            // 
            // lblDoanhThuThang
            // 
            this.lblDoanhThuThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDoanhThuThang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuThang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblDoanhThuThang.Location = new System.Drawing.Point(-27, 62);
            this.lblDoanhThuThang.Name = "lblDoanhThuThang";
            this.lblDoanhThuThang.Size = new System.Drawing.Size(252, 28);
            this.lblDoanhThuThang.TabIndex = 2;
            this.lblDoanhThuThang.Text = "0 VNĐ";
            this.lblDoanhThuThang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDoanhThuThangTitle
            // 
            this.lblDoanhThuThangTitle.AutoSize = true;
            this.lblDoanhThuThangTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDoanhThuThangTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDoanhThuThangTitle.Location = new System.Drawing.Point(15, 10);
            this.lblDoanhThuThangTitle.Name = "lblDoanhThuThangTitle";
            this.lblDoanhThuThangTitle.Size = new System.Drawing.Size(174, 23);
            this.lblDoanhThuThangTitle.TabIndex = 0;
            this.lblDoanhThuThangTitle.Text = "Doanh thu tháng này";
            // 
            // pnlHangTon
            // 
            this.pnlHangTon.BackColor = System.Drawing.Color.White;
            this.pnlHangTon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHangTon.Controls.Add(this.picInventoryIcon);
            this.pnlHangTon.Controls.Add(this.lblChiPhi);
            this.pnlHangTon.Controls.Add(this.lblHangTonTitle);
            this.pnlHangTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHangTon.Location = new System.Drawing.Point(510, 10);
            this.pnlHangTon.Margin = new System.Windows.Forms.Padding(10);
            this.pnlHangTon.Name = "pnlHangTon";
            this.pnlHangTon.Size = new System.Drawing.Size(230, 100);
            this.pnlHangTon.TabIndex = 2;
            // 
            // picInventoryIcon
            // 
            this.picInventoryIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picInventoryIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.picInventoryIcon.Location = new System.Drawing.Point(0, 0);
            this.picInventoryIcon.Name = "picInventoryIcon";
            this.picInventoryIcon.Size = new System.Drawing.Size(10, 98);
            this.picInventoryIcon.TabIndex = 3;
            this.picInventoryIcon.TabStop = false;
            // 
            // lblChiPhi
            // 
            this.lblChiPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChiPhi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChiPhi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblChiPhi.Location = new System.Drawing.Point(-27, 62);
            this.lblChiPhi.Name = "lblChiPhi";
            this.lblChiPhi.Size = new System.Drawing.Size(252, 28);
            this.lblChiPhi.TabIndex = 2;
            this.lblChiPhi.Text = "0 VNĐ";
            this.lblChiPhi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHangTonTitle
            // 
            this.lblHangTonTitle.AutoSize = true;
            this.lblHangTonTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHangTonTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHangTonTitle.Location = new System.Drawing.Point(15, 10);
            this.lblHangTonTitle.Name = "lblHangTonTitle";
            this.lblHangTonTitle.Size = new System.Drawing.Size(152, 23);
            this.lblHangTonTitle.TabIndex = 0;
            this.lblHangTonTitle.Text = "Chi phi nhập hàng";
            // 
            // pnlLoiNhuan
            // 
            this.pnlLoiNhuan.BackColor = System.Drawing.Color.White;
            this.pnlLoiNhuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoiNhuan.Controls.Add(this.panel1);
            this.pnlLoiNhuan.Controls.Add(this.picProfitIcon);
            this.pnlLoiNhuan.Controls.Add(this.lblLoiNhuan);
            this.pnlLoiNhuan.Controls.Add(this.lblLoiNhuanTitle);
            this.pnlLoiNhuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoiNhuan.Location = new System.Drawing.Point(760, 10);
            this.pnlLoiNhuan.Margin = new System.Windows.Forms.Padding(10);
            this.pnlLoiNhuan.Name = "pnlLoiNhuan";
            this.pnlLoiNhuan.Size = new System.Drawing.Size(230, 100);
            this.pnlLoiNhuan.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblLoiNhuanThang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 98);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 96);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblLoiNhuanThang
            // 
            this.lblLoiNhuanThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoiNhuanThang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoiNhuanThang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblLoiNhuanThang.Location = new System.Drawing.Point(-31, 60);
            this.lblLoiNhuanThang.Name = "lblLoiNhuanThang";
            this.lblLoiNhuanThang.Size = new System.Drawing.Size(254, 28);
            this.lblLoiNhuanThang.TabIndex = 2;
            this.lblLoiNhuanThang.Text = "0 VNĐ";
            this.lblLoiNhuanThang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(15, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lời nhuận tháng";
            // 
            // picProfitIcon
            // 
            this.picProfitIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.picProfitIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.picProfitIcon.Location = new System.Drawing.Point(0, 0);
            this.picProfitIcon.Name = "picProfitIcon";
            this.picProfitIcon.Size = new System.Drawing.Size(10, 98);
            this.picProfitIcon.TabIndex = 3;
            this.picProfitIcon.TabStop = false;
            // 
            // lblLoiNhuan
            // 
            this.lblLoiNhuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoiNhuan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLoiNhuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblLoiNhuan.Location = new System.Drawing.Point(-29, 62);
            this.lblLoiNhuan.Name = "lblLoiNhuan";
            this.lblLoiNhuan.Size = new System.Drawing.Size(254, 28);
            this.lblLoiNhuan.TabIndex = 2;
            this.lblLoiNhuan.Text = "0 VNĐ";
            this.lblLoiNhuan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLoiNhuanTitle
            // 
            this.lblLoiNhuanTitle.AutoSize = true;
            this.lblLoiNhuanTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoiNhuanTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLoiNhuanTitle.Location = new System.Drawing.Point(15, 10);
            this.lblLoiNhuanTitle.Name = "lblLoiNhuanTitle";
            this.lblLoiNhuanTitle.Size = new System.Drawing.Size(126, 23);
            this.lblLoiNhuanTitle.TabIndex = 0;
            this.lblLoiNhuanTitle.Text = "Tổng lợi nhuận";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.tabControlThongKe);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(3, 212);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1271, 624);
            this.pnlMainContent.TabIndex = 1;
            // 
            // tabControlThongKe
            // 
            this.tabControlThongKe.Controls.Add(this.tabPageDoanhSo);
            this.tabControlThongKe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControlThongKe.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControlThongKe.Location = new System.Drawing.Point(0, 3);
            this.tabControlThongKe.Name = "tabControlThongKe";
            this.tabControlThongKe.SelectedIndex = 0;
            this.tabControlThongKe.Size = new System.Drawing.Size(1271, 621);
            this.tabControlThongKe.TabIndex = 0;
            // 
            // tabPageDoanhSo
            // 
            this.tabPageDoanhSo.Controls.Add(this.tlpTabContent);
            this.tabPageDoanhSo.Location = new System.Drawing.Point(4, 32);
            this.tabPageDoanhSo.Name = "tabPageDoanhSo";
            this.tabPageDoanhSo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDoanhSo.Size = new System.Drawing.Size(1263, 585);
            this.tabPageDoanhSo.TabIndex = 0;
            this.tabPageDoanhSo.Text = "Thống Kê Doanh Số";
            this.tabPageDoanhSo.UseVisualStyleBackColor = true;
            // 
            // tlpTabContent
            // 
            this.tlpTabContent.ColumnCount = 1;
            this.tlpTabContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTabContent.Controls.Add(this.pnlFilter, 0, 0);
            this.tlpTabContent.Controls.Add(this.pnlChart, 0, 1);
            this.tlpTabContent.Controls.Add(this.panel3, 0, 2);
            this.tlpTabContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTabContent.Location = new System.Drawing.Point(3, 3);
            this.tlpTabContent.Name = "tlpTabContent";
            this.tlpTabContent.RowCount = 4;
            this.tlpTabContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpTabContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.3341F));
            this.tlpTabContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.6659F));
            this.tlpTabContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTabContent.Size = new System.Drawing.Size(1257, 579);
            this.tlpTabContent.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.dtpEndDate);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.dtpStartDate);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(3, 3);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1251, 54);
            this.pnlFilter.TabIndex = 0;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(793, 10);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(120, 35);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(593, 12);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 30);
            this.dtpEndDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(493, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến ngày:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(323, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 30);
            this.dtpStartDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(233, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Từ ngày:";
            // 
            // pnlChart
            // 
            this.pnlChart.Controls.Add(this.chartDoanhSo);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(3, 63);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(5);
            this.pnlChart.Size = new System.Drawing.Size(1251, 205);
            this.pnlChart.TabIndex = 1;
            // 
            // chartDoanhSo
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhSo.ChartAreas.Add(chartArea1);
            this.chartDoanhSo.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartDoanhSo.Legends.Add(legend1);
            this.chartDoanhSo.Location = new System.Drawing.Point(5, 5);
            this.chartDoanhSo.Name = "chartDoanhSo";
            this.chartDoanhSo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhSo";
            this.chartDoanhSo.Series.Add(series1);
            this.chartDoanhSo.Size = new System.Drawing.Size(1241, 195);
            this.chartDoanhSo.TabIndex = 0;
            this.chartDoanhSo.Text = "chartDoanhSo";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvChiTietLoiNhuanTheoSP);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 274);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1251, 281);
            this.panel3.TabIndex = 2;
            // 
            // dgvChiTietLoiNhuanTheoSP
            // 
            this.dgvChiTietLoiNhuanTheoSP.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvChiTietLoiNhuanTheoSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietLoiNhuanTheoSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietLoiNhuanTheoSP.Location = new System.Drawing.Point(0, 0);
            this.dgvChiTietLoiNhuanTheoSP.Name = "dgvChiTietLoiNhuanTheoSP";
            this.dgvChiTietLoiNhuanTheoSP.RowHeadersWidth = 51;
            this.dgvChiTietLoiNhuanTheoSP.RowTemplate.Height = 24;
            this.dgvChiTietLoiNhuanTheoSP.Size = new System.Drawing.Size(1251, 281);
            this.dgvChiTietLoiNhuanTheoSP.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelInfo,
            this.statusLabelVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 899);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1277, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabelInfo
            // 
            this.statusLabelInfo.Name = "statusLabelInfo";
            this.statusLabelInfo.Size = new System.Drawing.Size(68, 20);
            this.statusLabelInfo.Text = "Sẵn sàng";
            // 
            // statusLabelVersion
            // 
            this.statusLabelVersion.Name = "statusLabelVersion";
            this.statusLabelVersion.Size = new System.Drawing.Size(1192, 20);
            this.statusLabelVersion.Spring = true;
            this.statusLabelVersion.Text = "Phiên bản 1.0";
            this.statusLabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmThongKeDoanhSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 925);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip);
            this.Name = "frmThongKeDoanhSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng Điều Khiển - Thống Kê Doanh Số";
            this.Load += new System.EventHandler(this.frmThongKeDoanhSo_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlStatCards.ResumeLayout(false);
            this.tlpCards.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlLuongBanHang.ResumeLayout(false);
            this.pnlLuongBanHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSalesIcon)).EndInit();
            this.pnlDoanhThuThang.ResumeLayout(false);
            this.pnlDoanhThuThang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRevenueIcon)).EndInit();
            this.pnlHangTon.ResumeLayout(false);
            this.pnlHangTon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInventoryIcon)).EndInit();
            this.pnlLoiNhuan.ResumeLayout(false);
            this.pnlLoiNhuan.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfitIcon)).EndInit();
            this.pnlMainContent.ResumeLayout(false);
            this.tabControlThongKe.ResumeLayout(false);
            this.tabPageDoanhSo.ResumeLayout(false);
            this.tlpTabContent.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhSo)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietLoiNhuanTheoSP)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlStatCards;
        private System.Windows.Forms.TableLayoutPanel tlpCards;
        private System.Windows.Forms.Panel pnlLuongBanHang;
        private System.Windows.Forms.Label lblLuongBanHang;
        private System.Windows.Forms.Label lblLuongBanHangTitle;
        private System.Windows.Forms.Panel pnlDoanhThuThang;
        private System.Windows.Forms.Label lblDoanhThuThang;
        private System.Windows.Forms.Label lblDoanhThuThangTitle;
        private System.Windows.Forms.Panel pnlHangTon;
        private System.Windows.Forms.Label lblChiPhi;
        private System.Windows.Forms.Label lblHangTonTitle;
        private System.Windows.Forms.Panel pnlLoiNhuan;
        private System.Windows.Forms.Label lblLoiNhuan;
        private System.Windows.Forms.Label lblLoiNhuanTitle;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.PictureBox picSalesIcon;
        private System.Windows.Forms.PictureBox picRevenueIcon;
        private System.Windows.Forms.PictureBox picInventoryIcon;
        private System.Windows.Forms.PictureBox picProfitIcon;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelInfo;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelVersion;
        private TabControl tabControlThongKe;
        private TabPage tabPageDoanhSo;
        private TableLayoutPanel tlpTabContent;
        private Panel pnlFilter;
        private Button btnFilter;
        private DateTimePicker dtpEndDate;
        private Label label2;
        private DateTimePicker dtpStartDate;
        private Label label1;
        private Panel pnlChart;
        private Chart chartDoanhSo;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label lblLoiNhuanNgay;
        private Label label6;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label4;
        private Panel panel3;
        private DataGridView dgvChiTietLoiNhuanTheoSP;
        private Label lblLoiNhuanThang;
    }
}