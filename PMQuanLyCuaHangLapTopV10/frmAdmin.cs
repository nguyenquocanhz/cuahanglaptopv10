using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
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
    public partial class frmAdmin: Form
    {
        public Helpers helpers = new Helpers();
        public frmAdmin()
        {
            InitializeComponent();

            label2.Text = "Xin chào : " + SessionManager.Username;
            label3.Text = SessionManager.Role;
        }

        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tabSanPham_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            helpers.ActiveButton(sender);

        }


        private void btnProducts_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmSanPham(), sender, panelDesktop);
            Button button = (Button)sender;
            button.BackColor = Color.FromArgb(46, 51, 73);
            button.ForeColor = Color.White;
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmHoaDon(), sender, panelDesktop);

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmKhachHang(), sender, panelDesktop);

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmThongKeDoanhSo(), sender, panelDesktop);

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmCauHinhHT() , sender , panelDesktop);

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Đăng xuất
                SessionManager.IsLoggedIn = false;
                SessionManager.Username = null;
                SessionManager.Role = null;
                // Hiển thị lại form đăng nhập
                frmLogin loginForm = new frmLogin();
                this.Hide();
                loginForm.Show();
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmNhanVien(), sender, panelDesktop);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnDiscounts_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmKhuyenMai(), sender, panelDesktop);

        }

        private void frmNhaCungCap_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmNhaCungCap(), sender, panelDesktop);

        }
    }
}
