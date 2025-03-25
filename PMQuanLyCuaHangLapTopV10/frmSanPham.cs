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
    public partial class frmSanPham: Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            InitDGV();

        }
        private void InitDGV()
        {
            // Lấy danh sách sản phẩm từ database
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            DataTable dtSanPhams = sanPhamDAO.GetList(); // GetList() trả về DataTable

            if (dtSanPhams.Rows.Count > 0)
            {
                dataGridView1.DataSource = dtSanPhams; // Gán dữ liệu vào DataGridView

                // Tùy chỉnh tiêu đề cột hiển thị
                dataGridView1.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
                dataGridView1.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dataGridView1.Columns["LoaiSP"].HeaderText = "Loại Sản Phẩm";
                dataGridView1.Columns["ThoiGianBaoHanh"].HeaderText = "Thời Gian Bảo Hành";
                dataGridView1.Columns["SoLuongSP"].HeaderText = "Số Lượng";
                dataGridView1.Columns["DonGia"].HeaderText = "Đơn Giá"; // Đúng tên cột trong DB
                dataGridView1.Columns["MaNCC"].HeaderText = "Mã Nhà Cung Cấp";
                dataGridView1.Columns["MoTaChiTiet"].HeaderText = "Mô Tả Chi Tiết Sản Phẩm";
            }
            else
            {
                dataGridView1.DataSource = null; // Không có dữ liệu
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
