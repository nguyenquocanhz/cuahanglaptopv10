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
    public partial class frmDashboardEmployee: Form
    {
        Helpers helpers = new Helpers();
        public frmDashboardEmployee()
        {
            InitializeComponent();
            label2.Text = SessionManager.Username;
            label3.Text = SessionManager.Role;
        }
        public frmDashboardEmployee(string username , string role)
        {
            InitializeComponent();


        }
        private void frmDashboardEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        //private void btnProducts_Click(object sender, EventArgs e)
        //{
        //    helpers.OpenChildForm(new frmSanPham(),sender, panelDesktop);   
        //}

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmHoaDon(), sender, panelDesktop);

        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            helpers.OpenChildForm(new frmKhachHang(), sender, panelDesktop);

        }
    }
}
