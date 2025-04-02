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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDoanhSo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.cboThoiGian = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhSo)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDoanhSo
            // 
            this.chartDoanhSo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartDoanhSo.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDoanhSo.Legends.Add(legend2);
            this.chartDoanhSo.Location = new System.Drawing.Point(14, 53);
            this.chartDoanhSo.Name = "chartDoanhSo";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "DoanhThu";
            this.chartDoanhSo.Series.Add(series2);
            this.chartDoanhSo.Size = new System.Drawing.Size(869, 373);
            this.chartDoanhSo.TabIndex = 0;
            this.chartDoanhSo.Text = "chartDoanhSo";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadData.Location = new System.Drawing.Point(514, 13);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(86, 25);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // cboThoiGian
            // 
            this.cboThoiGian.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThoiGian.FormattingEnabled = true;
            this.cboThoiGian.Items.AddRange(new object[] {
            "Thống kê theo ngày",
            "Thống kê theo tháng"});
            this.cboThoiGian.Location = new System.Drawing.Point(274, 13);
            this.cboThoiGian.Name = "cboThoiGian";
            this.cboThoiGian.Size = new System.Drawing.Size(228, 24);
            this.cboThoiGian.TabIndex = 2;
            this.cboThoiGian.SelectedIndexChanged += new System.EventHandler(this.cboThoiGian_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thống kê theo:";
            // 
            // frmThongKeDoanhSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 438);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboThoiGian);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.chartDoanhSo);
            this.Name = "frmThongKeDoanhSo";
            this.Text = "Thống Kê Doanh Số Bán Hàng";
            this.Load += new System.EventHandler(this.frmThongKeDoanhSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhSo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhSo;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.ComboBox cboThoiGian;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}