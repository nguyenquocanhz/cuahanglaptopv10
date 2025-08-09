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
                if (dgvListNhanVien.Columns.Contains("Password"))
                    dgvListNhanVien.Columns["Password"].HeaderText = "Mật Khẩu";
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
                GioiTinh = cbGioitinh.SelectedItem?.ToString(), // ComboBox (nếu dùng)
                NgaySinh = dpNgaySinh.Value.Date, // DateTimePicker (nếu dùng)
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Password = txtPwd.Text.Trim(),
                QuyenHan = cbQuyenhan.Text.Trim(),
                ChucDanh = cbChucVu.Text.Trim(),
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
            txtHoTenNV.Text = row.Cells["hoTenNV"].Value.ToString();
            cbGioitinh.DisplayMember = row.Cells["GioiTinh"].Value.ToString();
            dpNgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            cbQuyenhan.Text = row.Cells["QuyenHan"].Value.ToString();
            cbChucVu.Text = row.Cells["ChucDanh"].Value.ToString();
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
            if (string.IsNullOrWhiteSpace(cbChucVu.Text))
            {
                MessageBox.Show("Vui lòng nhập chức danh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(cbGioitinh.Text))
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(dpNgaySinh.Text))
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
            if (string.IsNullOrWhiteSpace(cbQuyenhan.Text))
            {
                MessageBox.Show("Vui lòng nhập quyền hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPwd.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // check số điện thoại đã tồn tại chưa
            if (nhanVienDAO.CheckPhoneNumberExists(txtSoDienThoai.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại đã tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NhanVien nhanVien = new NhanVien
            {
                HoTenNV = txtHoTenNV.Text.Trim(),
                GioiTinh = cbGioitinh.SelectedItem?.ToString(),
                NgaySinh = dpNgaySinh.Value.Date,
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Password = txtPwd.Text.Trim(),
                QuyenHan = cbQuyenhan.Text.Trim(),
                ChucDanh = cbChucVu.Text.Trim(),
                DiaChiNV = txtDiaChi.Text.Trim(),
                CCCD = txtCCCD.Text.Trim()
            };
            // Gọi phương thức thêm nhân viên
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi thêm nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

        private void dgvListNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                txtHoTenNV.Text = row.Cells["HoTenNV"].Value?.ToString();
                cbGioitinh.Text = row.Cells["GioiTinh"].Value?.ToString();
                dpNgaySinh.Text = row.Cells["NgaySinh"].Value?.ToString();
                
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                cbQuyenhan.Text = row.Cells["QuyenHan"].Value?.ToString();
                cbChucVu.Text = row.Cells["ChucDanh"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChiNV"].Value?.ToString();
                txtCCCD.Text = row.Cells["cccd"].Value?.ToString();
            }
        }
        /// <summary>
        /// Xóa trắng nội dung của các ô nhập liệu/hiển thị thông tin nhân viên.
        /// </summary>
        private void ClearFields()
        {
            // Xóa nội dung của từng TextBox
            txtMaNV.Text = string.Empty;        // Hoặc có thể dùng txtMaNV.Clear();
            txtHoTenNV.Text = string.Empty;     // Hoặc txtHoTenNV.Clear();
            cbGioitinh.SelectedIndex = -1;    // Cân nhắc: Nếu đây là ComboBox, dùng: comboBoxGioiTinh.SelectedIndex = -1;
            dpNgaySinh.Value = DateTime.Now;    // Cân nhắc: Nếu đây là DateTimePicker, dùng: dtpNgaySinh.Value = DateTime.Now; hoặc dtpNgaySinh.Checked = false; (nếu cho phép null)
            txtSoDienThoai.Text = string.Empty;
            cbQuyenhan.SelectedIndex =-1;    // Cân nhắc: Nếu đây là ComboBox, dùng: comboBoxQuyenHan.SelectedIndex = -1;
            cbChucVu.SelectedIndex = -1;   // Cân nhắc: Nếu đây là ComboBox, dùng: comboBoxChucDanh.SelectedIndex = -1;
            txtDiaChi.Text = string.Empty;
            txtCCCD.Clear();        // Hoặc txtCCCD.Clear();

            // Tùy chọn: Đặt con trỏ (focus) về ô nhập liệu đầu tiên (ví dụ: Mã NV hoặc Họ tên)
            // để người dùng có thể bắt đầu nhập mới hoặc chọn một dòng khác.
            // Ví dụ:
            // txtMaNV.Focus();
            // Hoặc nếu mã NV thường không được sửa trực tiếp:
            txtHoTenNV.Focus();

            // Tùy chọn: Có thể bạn muốn reset trạng thái của các nút (ví dụ: bật nút Thêm, tắt nút Sửa/Xóa)
            // btnAdd.Enabled = true;
            // btnUpdate.Enabled = false;
            // btnDelete.Enabled = false;
            // txtMaNV.ReadOnly = false; // Cho phép nhập mã nếu là thêm mới
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            string id = txtMaNV.Text.Trim(); // Lấy mã NV và xóa khoảng trắng dư thừa
            string name = txtHoTenNV.Text.Trim(); // Lấy tên NV và xóa khoảng trắng dư thừa

            // --- 1. Kiểm tra xem có mã nhân viên để xóa không ---
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu không có mã NV
            }

            // --- 2. Hiển thị hộp thoại xác nhận ---
            // Tạo nội dung câu hỏi, nên bao gồm cả tên (nếu có) và mã để người dùng chắc chắn
            string confirmationMessage = string.IsNullOrEmpty(name)
                                            ? $"Bạn có chắc chắn muốn xóa nhân viên có mã '{id}' không?"
                                            : $"Bạn có chắc chắn muốn xóa nhân viên '{name}' (Mã: {id}) không?";

            DialogResult confirm = MessageBox.Show(
                confirmationMessage,       // Nội dung câu hỏi
                "Xác nhận xóa",            // Tiêu đề hộp thoại
                MessageBoxButtons.YesNo,   // Hiển thị nút Yes và No
                MessageBoxIcon.Question);  // Hiển thị biểu tượng dấu hỏi

            // --- 3. Kiểm tra kết quả người dùng chọn ---
            if (confirm == DialogResult.Yes) // Nếu người dùng nhấn Yes
            {
                // --- 4. Thực hiện xóa ---
                bool isDelete = nhanVienDAO.DeleteNhanVien(id); // Gọi phương thức xóa đã sửa đổi

                // --- 5. Thông báo kết quả ---
                if (isDelete)
                {
                    MessageBox.Show($"Đã xóa thành công nhân viên '{name}' (Mã: {id}).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // --- Quan trọng: Thêm hành động sau khi xóa thành công ---
                    // Ví dụ: Tải lại danh sách nhân viên trên DataGridView
                    // LoadDataGrid();
                    // Hoặc xóa trắng các ô nhập liệu
                    InitDGV();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show($"Không thể xóa nhân viên '{name}' (Mã: {id}).\nCó thể mã không tồn tại hoặc đã xảy ra lỗi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // else: Người dùng nhấn No, không làm gì cả hoặc có thể thông báo đã hủy
            // {
            //     MessageBox.Show("Thao tác xóa đã được hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // }
        }
    }
}
