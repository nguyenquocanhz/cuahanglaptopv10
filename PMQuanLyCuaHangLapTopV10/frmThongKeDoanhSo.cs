using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmThongKeDoanhSo: Form
    {
        public frmThongKeDoanhSo()
        {
            InitializeComponent();
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
            string selectedOption = cboThoiGian.SelectedItem.ToString();

            if (selectedOption == "Thống kê theo ngày")
            {
                LoadChart("View_ThongKeDoanhSoNgay", chartDoanhSo, "DoanhThu", "ThoiGian", "DoanhThu");
            }
            else if (selectedOption == "Thống kê theo tháng")
            {
                LoadChart("View_ThongKeDoanhSoThang", chartDoanhSo, "DoanhThu", "ThoiGian", "DoanhThu");
            }
        }

        private void frmThongKeDoanhSo_Load(object sender, EventArgs e)
        {
            cboThoiGian.SelectedIndex = 0; // Default to "Thống kê theo ngày"

            // Load the default chart
            cboThoiGian_SelectedIndexChanged(sender, e);
        }

    }
}
