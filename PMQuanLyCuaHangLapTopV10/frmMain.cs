using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }
        // display form child 
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Menu1.Controls.Add(childForm);
            Menu1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SessionManager.Username))
            {
                label2.Text = "Xin chào : " + SessionManager.Username;
                label3.Text = "Chức vụ : " + SessionManager.Role;

            }
            else
            {
                label2.Text = "Xin chào : [Không có dữ liệu]";
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // message box :Bạn có chắc chắn muốn đăng xuất ?
            // Hiển thị hộp thoại xác nhận đăng xuất
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất ?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả trả về từ hộp thoại
            if (dialogResult == DialogResult.Yes)
            {
                // Thực hiện hành động đăng xuất nếu người dùng chọn Yes
                // Ví dụ:
                // 1. Xóa thông tin đăng nhập đã lưu (nếu có)
                // 2. Chuyển hướng người dùng về màn hình đăng nhập
                // 3. Đóng form hiện tại (nếu cần)

                // Ví dụ về chuyển hướng về màn hình đăng nhập (giả sử bạn có form đăng nhập tên là frmLogin)
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide(); // Ẩn form hiện tại (form chứa chức năng đăng xuất)
                             // Hoặc this.Close(); nếu bạn muốn đóng form hiện tại hoàn toàn
            }
            else if (dialogResult == DialogResult.No)
            {
                // Không làm gì cả nếu người dùng chọn No (hủy đăng xuất)
                // Người dùng vẫn ở lại ứng dụng và không đăng xuất
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnKhachHang_MouseHover(object sender, EventArgs e)
        {
            Thread.Sleep(100);
        }

        private void pnKhachHang_MouseLeave(object sender, EventArgs e)
        {
            Thread.Sleep(100);

        }

        private void btnOpenFormKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frmKhachHang = new frmKhachHang();
            frmKhachHang.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frmSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham frmSanPham = new frmSanPham();
            frmSanPham.ShowDialog();
        }

        private void frmNhaCungCap_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frmNhaCungCap = new frmNhaCungCap();
            frmNhaCungCap.ShowDialog();
        }

        private void frmNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNhanVien = new frmNhanVien();
            frmNhanVien.ShowDialog();
        }

        private void frmThongKeDoanhSo_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhSo frmThongKeDoanhSo = new frmThongKeDoanhSo();
            frmThongKeDoanhSo.ShowDialog();
        }
    }
}
