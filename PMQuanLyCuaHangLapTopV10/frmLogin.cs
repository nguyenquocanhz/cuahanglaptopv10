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
    public partial class frmLogin: Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void checkShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShowPwd.Checked)
            {
                txtPass.PasswordChar = '\0'; // Hiển thị mật khẩu dưới dạng văn bản bình thường
            }
            else
            {
                txtPass.PasswordChar = '*'; // Ẩn mật khẩu với dấu *
            }
        }




        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
