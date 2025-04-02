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
    public partial class frmNhanVien: Form
    {
        public NhanVienDAO nhanVienDAO = new NhanVienDAO();
        public DbHelpers db = DbHelpers.Instance();
        public frmNhanVien()
        {
            InitializeComponent();
            txtMaNV.ReadOnly = true;
            if (!db.CheckConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InitDGV();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!db.CheckConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InitDGV();
        }
        // định dạng dgv
        private void InitDGV()
        {
            try
            {
                // Lấy dữ liệu nhân viên từ cơ sở dữ liệu
                DataTable listData = nhanVienDAO.GetAllNhanVien();

                if (listData == null || listData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán DataTable làm nguồn dữ liệu cho DataGridView
                dgvListNhanVien.DataSource = listData;

                // Tùy chỉnh tiêu đề cột nếu cột tồn tại
                if (dgvListNhanVien.Columns.Contains("MaNV"))
                    dgvListNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
                if (dgvListNhanVien.Columns.Contains("HoTenNV"))
                    dgvListNhanVien.Columns["HoTenNV"].HeaderText = "Họ và Tên";
                if (dgvListNhanVien.Columns.Contains("GioiTinh"))
                    dgvListNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                if (dgvListNhanVien.Columns.Contains("NgaySinh"))
                    dgvListNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                if (dgvListNhanVien.Columns.Contains("SoDienThoai"))
                    dgvListNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                //if (dataGridView1.Columns.Contains("Password"))
                //    dataGridView1.Columns["Password"].HeaderText = "Mật Khẩu";
                if (dgvListNhanVien.Columns.Contains("QuyenHan"))
                    dgvListNhanVien.Columns["QuyenHan"].HeaderText = "Quyền Hạn";
                if (dgvListNhanVien.Columns.Contains("ChucDanh"))
                    dgvListNhanVien.Columns["ChucDanh"].HeaderText = "Chức Danh";
                if (dgvListNhanVien.Columns.Contains("DiaChiNV"))
                    dgvListNhanVien.Columns["DiaChiNV"].HeaderText = "Địa Chỉ";
                if (dgvListNhanVien.Columns.Contains("cccd"))
                    dgvListNhanVien.Columns["cccd"].HeaderText = "Số CCCD";

                // Tùy chỉnh hiển thị
                dgvListNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Cột tự giãn
                dgvListNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Font tiêu đề
                dgvListNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi khởi tạo DataGridView: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu trường mã nhân viên (txtMaNV) để trống
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo đối tượng NhanVien từ dữ liệu nhập trong các TextBox
            NhanVien nhanVien = new NhanVien
            {
                MaNV = txtMaNV.Text.Trim(),
                HoTenNV = txtHoTenNV.Text.Trim(),
                GioiTinh = txtGioiTinh.SelectedItem?.ToString(), // ComboBox (nếu dùng)
                NgaySinh = txtNgaySinh.Value.Date, // DateTimePicker (nếu dùng)
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Password = txtPwd.Text.Trim(),
                QuyenHan = txtQuyenHan.Text.Trim(),
                ChucDanh = txtChucDanh.Text.Trim(),
                DiaChiNV = txtDiaChi.Text.Trim(),
                CCCD = txtCCCD.Text.Trim()
            };

            // Gọi phương thức cập nhật
            bool isUpdateCmd = nhanVienDAO.UpdateNhanVien(nhanVien);

            // Kiểm tra kết quả
            if (isUpdateCmd)
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload dữ liệu sau khi cập nhật
                ReloadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thất bại. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức reload dữ liệu
        private void ReloadData()
        {
            try
            {
                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable data = nhanVienDAO.GetAllNhanVien();

                // Gán dữ liệu vào DataGridView
                dgvListNhanVien.DataSource = data;
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                MessageBox.Show($"Lỗi khi tải lại dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvListNhanVien_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListNhanVien.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = dgvListNhanVien.SelectedRows[0];
            txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
            txtHoTenNV.Text = row.Cells["HoTenNV"].Value.ToString();
            txtGioiTinh.DisplayMember = row.Cells["GioiTinh"].Value.ToString();
            txtNgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            txtQuyenHan.Text = row.Cells["QuyenHan"].Value.ToString();
            txtChucDanh.Text = row.Cells["ChucDanh"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChiNV"].Value.ToString();
            txtCCCD.Text = row.Cells["cccd"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtChucDanh.Text))
            {
                MessageBox.Show("Vui lòng nhập chức danh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtGioiTinh.Text))
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                MessageBox.Show("Vui lòng chọn ngày sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập số CCCD.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtQuyenHan.Text))
            {
                MessageBox.Show("Vui lòng nhập quyền hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPwd.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            NhanVien nhanVien = new NhanVien
            {
                HoTenNV = txtHoTenNV.Text.Trim(),
                GioiTinh = txtGioiTinh.SelectedItem?.ToString(),
                NgaySinh = txtNgaySinh.Value.Date,
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Password = txtPwd.Text.Trim(),
                QuyenHan = txtQuyenHan.Text.Trim(),
                ChucDanh = txtChucDanh.Text.Trim(),
                DiaChiNV = txtDiaChi.Text.Trim(),
                CCCD = txtCCCD.Text.Trim()
            };
            bool isAddCmd = nhanVienDAO.AddNhanVien(nhanVien);
            if (isAddCmd)
            {
                MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReloadData();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
