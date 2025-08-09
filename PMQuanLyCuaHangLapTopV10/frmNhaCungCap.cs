using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
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
        public NhaCungCapDAO NhaCungCapDAO = new NhaCungCapDAO();
        public string tenNcc;
        public string sdt;
        public string maNhaCungCap;
        public frmNhaCungCap()
        {
            InitializeComponent();
            //txtMaNCC.ReadOnly = true;
            dgvNhaCungCap.DefaultCellStyle.Font = new Font("Segoe UI", 12);

        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            if (!db.CheckConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadData();
            dgvNhaCungCap.DefaultCellStyle.Font = new Font("Segoe UI", 12);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tenNcc = txtTenNCC.Text.Trim();
            sdt = txtSdtNCC.Text.Trim();

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
            // Nếu đang cập nhật (đã chọn một NCC từ datagridview)
            bool isExist = NhaCungCapDAO.CheckExistNCCByPhoneOrName(sdt,tenNcc);
            if (isExist) // Chỉ tiếp tục nếu NCC này KHÔNG tồn tại (nghĩa là không tìm thấy)
            {
                MessageBox.Show("Nhà cung cấp đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Đây là thêm mới, không cần kiểm tra MaNCC
                NhaCungCap nhaCungCap = new NhaCungCap
                {
                    TenNCC = tenNcc,
                    SoDienThoai = sdt,
                };

                bool isCreated = NhaCungCapDAO.InsertNCC(nhaCungCap);
                if (isCreated)
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    // Reset form
                    txtTenNCC.Text = "";
                    txtSdtNCC.Text = "";
                    MaNCC = null;
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi không xác định !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

        }
        private void LoadData()
        {
            NhaCungCapDAO nhaCungCapDAO = new NhaCungCapDAO();
            listNhaCungCap = nhaCungCapDAO.GetListNhaCungCapDatatable();

            dgvNhaCungCap.DataSource = listNhaCungCap;
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhaCungCap.Columns["MaNCC"].HeaderText = "Mã NCC";
            dgvNhaCungCap.Columns["TenNCC"].HeaderText = "Tên NCC";
            dgvNhaCungCap.Columns["soDienThoaiNCC"].HeaderText = "Số Điện Thoại";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvNhaCungCap_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.maNhaCungCap = dgvNhaCungCap.Rows[e.RowIndex].Cells["colMaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
            txtSdtNCC.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["soDienThoaiNCC"].Value.ToString();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra để tránh lỗi khi click vào header hoặc cell trống
                if (e.RowIndex < 0 || e.RowIndex >= dgvNhaCungCap.Rows.Count)
                    return;

                this.maNhaCungCap = dgvNhaCungCap.Rows[e.RowIndex].Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["TenNCC"].Value.ToString();
                txtSdtNCC.Text = dgvNhaCungCap.Rows[e.RowIndex].Cells["soDienThoaiNCC"].Value.ToString();
                //MessageBox.Show($"Mã NCC : {MaNCC}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bool isDelete = NhaCungCapDAO.RemoveNCC(int.Parse(maNhaCungCap));
            if (isDelete)
            {
                MessageBox.Show("Đã xóa nhà cung cấp thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadData();
            }
            else
            {
                MessageBox.Show("Không thể xóa nhà cung cấp này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tenNcc = txtTenNCC.Text.Trim();
            sdt = txtSdtNCC.Text.Trim();
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
            bool isUpdate = NhaCungCapDAO.UpdateNCC(tenNcc,sdt,maNhaCungCap);
            if (isUpdate) 
            {
                MessageBox.Show("Đã cập nhật dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Không thể cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadData();
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maNhaCungCap))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để tạo phiếu nhập hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] jsonData = new string[2]
            {
                maNhaCungCap,
                SessionManager.sodt
            };
            frmPhieuNhapHang frmPhieuNhapHang = new frmPhieuNhapHang(jsonData);
            frmPhieuNhapHang.Show();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            frmNhapHang frmNhapHang = new frmNhapHang(maNhaCungCap);
            frmNhapHang.StartPosition = FormStartPosition.CenterParent;
            frmNhapHang.ShowDialog();
        }
    }
}
