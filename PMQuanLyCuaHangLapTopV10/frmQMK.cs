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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmQMK : Form
    {
        NhanVienDAO nhanVienDAO = new NhanVienDAO();
        public frmQMK()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("⚠️ Số điện thoại không được để trống !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!nhanVienDAO.CheckPhoneNumberExists(txtUsername.Text.Trim()))
            {
                MessageBox.Show("⚠️ Số điện thoại không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtUsername.ReadOnly = true;
                panel1.Visible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtConfirmPassword.Text) || String.IsNullOrEmpty(txtNewPassword.Text)) 
            {
                MessageBox.Show("⚠️ Vui lòng điền đủ thông tin !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                MessageBox.Show("⚠️ Mật khẩu không khớp   !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool isUpdate = nhanVienDAO.UpdateMK(txtUsername.Text.Trim(), txtNewPassword.Text.Trim());
            if (isUpdate)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else 
            {
                MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
