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

    public partial class frmKhachHang: Form
    {
        
        public List<KhachHang> khachHangs = new List<KhachHang>();
        public frmKhachHang()
        {
            InitializeComponent();
            txtMaKH.ReadOnly = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang(txtMaKH?.Text, txtHoten?.Text, "", txtPhone?.Text, txtEmail?.Text);
            khachHangs.Add(kh);
            LoadData();

        }
        private void LoadData()
        {
            
            // Giả sử khachHangs là danh sách chứa dữ liệu khách hàng
            dgvListNhanVien.DataSource = null;
            dgvListNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListNhanVien.DataSource = khachHangs;
            // Đặt lại tiêu đề cột sau khi gán nguồn dữ liệu
            dgvListNhanVien.Columns["MaKhachHang"].HeaderText = "Mã Khách hàng";
            dgvListNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvListNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvListNhanVien.Columns["Email"].HeaderText = "Email";
        }


        private void dgvListNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListNhanVien.Rows[e.RowIndex];
                // Gán giá trị của các ô vào các TextBox tương ứng
                txtMaKH.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtHoten.Text = row.Cells["HoTen"].Value.ToString();
                txtPhone.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }
    }


}
