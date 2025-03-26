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
    public partial class frmNhaCungCap: Form
    {
        public DataTable listNhaCungCap;
        public DbHelpers db = DbHelpers.Instance();

        public frmNhaCungCap()
        {
            InitializeComponent();
            txtMaNCC.ReadOnly = true;
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            if (!db.CheckConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tenNcc = txtMaNCC.Text;
            string sdt = txtSdtNCC.Text;

            if (string.IsNullOrEmpty(tenNcc) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 số");
                return;
            }
            if (string.IsNullOrEmpty(tenNcc))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp");
                return;
            }
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
                return;
            }

        }
        private void LoadData()
        {
            NhaCungCapDAO nhaCungCapDAO = new NhaCungCapDAO();
            listNhaCungCap = nhaCungCapDAO.GetListNhaCungCap();

            dgvNhaCungCap.DataSource = listNhaCungCap;
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhaCungCap.Columns["MaNCC"].HeaderText = "Mã NCC";
            dgvNhaCungCap.Columns["TenNCC"].HeaderText = "Tên NCC";
            dgvNhaCungCap.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvNhaCungCap_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
            txtSdtNCC.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["SoDienThoai"].Value.ToString();
        }
    }
}
