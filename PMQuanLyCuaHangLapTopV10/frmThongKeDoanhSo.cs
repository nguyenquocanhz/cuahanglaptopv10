using OfficeOpenXml;
using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using PMQuanLyCuaHangLapTopV10.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Metadata.Edm;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace PMQuanLyCuaHangLapTopV10
{    // Lớp DoanhThu dùng để lưu dữ liệu doanh thu
    public partial class frmThongKeDoanhSo: Form
    {
        HoaDonDAO hdDAO = new HoaDonDAO();
        PhieuNhapDAO pnDAO = new PhieuNhapDAO();
        public frmThongKeDoanhSo()
        {
            InitializeComponent();
            int doanhThuHomNay = hdDAO.DoanhThuHomNay();
            lblLuongBanHang.Text = doanhThuHomNay.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
            lblDoanhThuThang.Text = hdDAO.DoanhThuThangNay().ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
            lblChiPhi.Text = pnDAO.TongCPNhap().ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
            lblLoiNhuanNgay.Text = hdDAO.GetLoiNhuanHomNay().ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
            //lblLoiNhuanNgay
            lblLoiNhuanThang.Text = (hdDAO.GetLoiNhuanThangNay()).ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
        }
        // Event Handler for Load Data
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            //// Example to load data into chart
            //DataTable data = GetData(); // Replace with actual data fetching method

            //chartDoanhSo.Series["DoanhThu"].Points.Clear();
            //foreach (DataRow row in data.Rows)
            //{
            //    string time = row["ThoiGian"].ToString();
            //    decimal revenue = Convert.ToDecimal(row["DoanhThu"]);

            //    chartDoanhSo.Series["DoanhThu"].Points.AddXY(time, revenue);
            //}
        }
        // Example Data Fetching Method
        private DataTable GetViewData(string viewName)
        {
            DataTable table = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
                {
                    // Form the query dynamically based on the view name
                    string query = $"SELECT * FROM {viewName}";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    connection.Open();
                    adapter.Fill(table); // Fill the DataTable with the view results
                }
            }
            catch (Exception ex)
            {
                // Handle any potential exceptions
                MessageBox.Show($"Error fetching data from {viewName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return table;
        }

        private void LoadChart(string viewName, Chart chart, string seriesName, string xValueMember, string yValueMember)
        {
            DataTable data = GetViewData(viewName);

            if (!chart.Series.IsUniqueName(seriesName))
            {
                chart.Series.Remove(chart.Series[seriesName]);
            }

            Series series = new Series(seriesName)
            {
                ChartType = SeriesChartType.Column,
                XValueMember = xValueMember,
                YValueMembers = yValueMember
            };
            chart.Series.Add(series);

            chart.DataSource = data;
            chart.DataBind();
        }


        private void cboThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmThongKeDoanhSo_Load(object sender, EventArgs e)
        {
            // Set the default date range to the last 30 days
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            // Load the chart with initial data
            InitChart();
            LoadDgvNhatKy();

            //LoadChart("DoanhThuTheoThang", chartDoanhSo, "DoanhThu", "ThoiGian", "DoanhThu");
            //LoadChart("DoanhThuTheoNgay", chartDoanhSo, "DoanhThu", "ThoiGian", "DoanhThu");
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Lấy ngày bắt đầu từ dtpStartDate
            DateTime startDate, ngayKetThuc;
            startDate = dtpStartDate.Value.Date;
            ngayKetThuc = dtpEndDate.Value.Date;
            if (startDate > ngayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InitChart();
            // 
            //MessageBox.Show(startDate.ToString("yyyy-MM-dd"));
            LoadDgvNhatKy();

        }

        private void InitChart()
        {
            HoaDonDAO hdDAO = new HoaDonDAO();
            chartDoanhSo.Series.Clear();
            chartDoanhSo.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("MainArea");
            chartDoanhSo.ChartAreas.Add(chartArea);
            // Set the chart type
            Series series = new Series("Doanh Thu")
            {
                ChartType = SeriesChartType.Column,  // Biểu đồ cột
                IsValueShownAsLabel = true,          // Hiển thị giá trị trên cột
                Color = System.Drawing.Color.Red // Màu cột
            };
            DataTable doanhThuData = hdDAO.ThongKeDoanhThu(dtpStartDate.Value.Date, dtpEndDate.Value.Date);

            // Tạo dữ liệu ảo cho 30 ngày gần đây
            //for (int i = 0; i < 7; i++)
            //{
            //    var ngay = DateTime.Today.AddDays(-i).ToString("yyyy-MM-dd");
            //    var doanhThu = Faker.RandomNumber.Next(10000000, 500000000); // Giá trị doanh thu ngẫu nhiên từ 100 triệu đến 500 triệu

            //    doanhThuTheoNgay.Add(new DoanhThu
            //    {
            //        Ngay = ngay,
            //        DoanhThuValue = doanhThu
            //    });
            //}
            // Thêm các điểm dữ liệu vào Series
            // Thêm các điểm dữ liệu vào Series từ DataTable
            foreach (DataRow row in doanhThuData.Rows)
            {
                // XValue là ngày, YValue là doanh thu
                string ngay = row["Ngay"].ToString();
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                Helpers helpers = new Helpers();
                series.Points.AddXY(ngay, helpers.FormatNumberV1(doanhThu.ToString()));
            }
            chartDoanhSo.Series.Add(series);
            chartDoanhSo.ChartAreas[0].AxisY.Maximum = 200000000;

        }
        private string FormatCurrency(decimal value)
        {
            return string.Format("{0:N0} VND", value); // Định dạng theo kiểu 100,000,000 VND
        }

        private void frmThongKeDoanhSo_Load_1(object sender, EventArgs e)
        {
            LoadDgvNhatKy();
        }

        private void LoadDgvNhatKy()
        {
            HoaDonDAO hdDAO = new HoaDonDAO();
            dgvChiTietLoiNhuanTheoSP.DataSource = hdDAO.GetChiTietDoanhSo(dtpStartDate.Value.Date, dtpEndDate.Value.Date);
            // fill col header
            dgvChiTietLoiNhuanTheoSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietLoiNhuanTheoSP.Columns["MaHD"].HeaderText = "Mã hóa đơn";
            dgvChiTietLoiNhuanTheoSP.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgvChiTietLoiNhuanTheoSP.Columns["Ngay"].HeaderText = "Ngày bán";
            dgvChiTietLoiNhuanTheoSP.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvChiTietLoiNhuanTheoSP.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTietLoiNhuanTheoSP.Columns["DonGia"].HeaderText = "Đơn giá bán";
            dgvChiTietLoiNhuanTheoSP.Columns["giaNhap"].HeaderText = "Giá nhập";
            dgvChiTietLoiNhuanTheoSP.Columns["DoanhThu"].HeaderText = "Doanh thu";
            dgvChiTietLoiNhuanTheoSP.Columns["LoiNhuan"].HeaderText = "Lợi nhuận";
            dgvChiTietLoiNhuanTheoSP.Columns["SoLuong"].DefaultCellStyle.Format = "N0";
            dgvChiTietLoiNhuanTheoSP.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTietLoiNhuanTheoSP.Columns["giaNhap"].DefaultCellStyle.Format = "N0";
            dgvChiTietLoiNhuanTheoSP.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
            dgvChiTietLoiNhuanTheoSP.Columns["LoiNhuan"].DefaultCellStyle.Format = "N0";
            dgvChiTietLoiNhuanTheoSP.Columns["DonGia"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            dgvChiTietLoiNhuanTheoSP.Columns["giaNhap"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            dgvChiTietLoiNhuanTheoSP.Columns["DoanhThu"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            dgvChiTietLoiNhuanTheoSP.Columns["LoiNhuan"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

        }
    }
}
