using PMQuanLyCuaHangLapTopV10.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmNhanVien: Form
    {
        public DbHelpers db = DbHelpers.Instance();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!db.CheckConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InitDGV();
        }
        // định dạng dgv
        private void InitDGV()
        {
            NhanVienDAO nhanVienDAO = new NhanVienDAO();

            // Lấy dữ liệu nhân viên từ CSDL (đã có đầy đủ cột)
            DataTable listData = nhanVienDAO.GetAllNhanVien();

            // Gán DataTable làm nguồn dữ liệu cho DataGridView
            dataGridView1.DataSource = listData;

            // Tùy chỉnh tiêu đề cột (HeaderText)
            dataGridView1.Columns["MaNV"].HeaderText = "Mã NV";
            dataGridView1.Columns["HoTenNV"].HeaderText = "Họ và Tên";
            dataGridView1.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dataGridView1.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dataGridView1.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dataGridView1.Columns["Password"].HeaderText = "Mật Khẩu";
            dataGridView1.Columns["QuyenHan"].HeaderText = "Quyền Hạn";
            dataGridView1.Columns["ChucDanh"].HeaderText = "Chức Danh";
            dataGridView1.Columns["DiaChiNV"].HeaderText = "Địa Chỉ";

            // Tùy chỉnh hiển thị
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Cột tự giãn
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Font tiêu đề
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
