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

            if (txtUsername.Text != "0123")
            {
                MessageBox.Show("⚠️ Số điện thoại không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                panel1.Visible = true;
                MessageBox.Show("❌ Không thể kết nối đến cơ sở dữ liệu! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
