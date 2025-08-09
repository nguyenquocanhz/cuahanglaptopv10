using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using PMQuanLyCuaHangLapTopV10.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmLogin : Form
    {
        private Color originalButtonColor;
        private bool isDragging = false;        // Flag to track if the form is being dragged
        private Point offset;                // Offset from the mouse click to the form's top-left corner
        public DbHelpers db = DbHelpers.Instance();


        public frmLogin()
        {
            InitializeComponent();
            originalButtonColor = btnLogin.BackColor; // Assign the initial color of the button

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (!db.CheckConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtAcc.Focus();
        }


        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = ControlPaint.LightLight(originalButtonColor);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = originalButtonColor;
        }

        private void checkShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkShowPwd.Checked ? '\0' : '●';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Close the application
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
        }

        // --- Form Dragging Code ---

        private void pnlDragBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offset = new Point(e.X, e.Y); // Calculate offset from top-left of the panel
            }
        }

        private void pnlDragBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newLocation = this.PointToScreen(new Point(e.X - offset.X, e.Y - offset.Y)); // Convert panel coords to screen coords
                this.Location = newLocation; // Move the form
            }
        }

        private void pnlDragBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Stop dragging
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtAcc.Text;
            string pass = txtPass.Text;
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            NhanVien nv = nhanVienDAO.DangNhap(username, pass);

            if (nv != null)
            {
                // Lưu thông tin phiên đăng nhập
                SessionManager.IsLoggedIn = true;
                SessionManager.Username = nv.HoTenNV;
                SessionManager.Role = nv.QuyenHan;
                SessionManager.MaNV = nv.MaNV;
                SessionManager.sodt = nv.SoDienThoai;
                SessionManager.ChucDanh = nv.ChucDanh;
                // Đăng nhập thành công
                //MessageBox.Show("🔓 Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // phân quyền truy cập giao diện
                if (SessionManager.Role == "Admin")
                {
                    frmAdmin frmAdmin = new frmAdmin();
                    this.Hide();
                    frmAdmin.Show();
                    frmAdmin.WindowState = FormWindowState.Maximized;
                }
                else if (SessionManager.Role == "Staff")
                {

                    frmDashboardEmployee frmDashboardEmployee = new frmDashboardEmployee();
                    this.Hide();
                    frmDashboardEmployee.Show();
                }
                else
                {
                    MessageBox.Show("❌ Không thể xác định quyền truy cập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                  


            }
            else
            {
                // Kiểm tra nếu tài khoản không tồn tại hoặc sai thông tin
                if (!nhanVienDAO.CheckPhoneNumberExists(username))
                {
                    MessageBox.Show("⚠️ Số điện thoại không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!nhanVienDAO.CheckPasswordCorrect(username, pass))
                {
                    MessageBox.Show("🚫 Mật khẩu không chính xác! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("❌ Không thể kết nối đến cơ sở dữ liệu! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtAcc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmQMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQMK frmQMK = new frmQMK();
            frmQMK.ShowDialog();
           
        }
    }
}