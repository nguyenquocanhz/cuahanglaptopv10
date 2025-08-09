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
    public partial class frmKhuyenMai : Form
    {
        private KhuyenMaiDAO _khuyenMaiDAO;
        private bool isAdding = false;
        public frmKhuyenMai()
        {
            InitializeComponent();
        }

        private void frmKhuyenMai_Load(object sender, EventArgs e)
        {
            _khuyenMaiDAO = new KhuyenMaiDAO();
            ResetForm();
            LoadDanhSachKhuyenMai();
            cbTrangThai.SelectedIndex = 0;
            // Assuming cbLoaikm exists on your form and has items "%" and "VND"
            // If not, you need to add it in the form designer and populate its items.
            // Example of populating items if not done in designer:
            // cbLoaikm.Items.AddRange(new object[] { "%", "VND" });
            // cbLoaikm.SelectedIndex = 0;
            dgvDanhSachKM.DefaultCellStyle.Font = new Font("Segoe UI", 12);


            txtMaKM.Enabled = false;

        }
        private void ResetForm()
        {
            txtMaKM.Text = "";
            txtTenKM.Text = "";
            txtPhanTramGiam.Text = "";
            txtMoTa.Text = "";
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today.AddMonths(1);
            cbTrangThai.SelectedIndex = 0;
            // Reset cbLoaikm as well if it exists
            // cbLoaikm.SelectedIndex = 0;
            // txtVoucherGiftcode.Text = ""; // Assuming you have this textbox

            isAdding = false;
            errorProvider.Clear();
        }
        private bool ValidateData()
        {
            bool isValid = true;

            // Validate tên khuyến mãi
            if (string.IsNullOrWhiteSpace(txtTenKM.Text))
            {
                errorProvider.SetError(txtTenKM, "Vui lòng nhập tên khuyến mãi");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtTenKM, "");
            }

            // Validate phần trăm giảm giá based on LoaiKM
            if (string.IsNullOrWhiteSpace(txtPhanTramGiam.Text))
            {
                errorProvider.SetError(txtPhanTramGiam, "Vui lòng nhập giá trị giảm giá");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtPhanTramGiam, ""); // Clear previous error first

                if (cbLoaikm.SelectedItem == null)
                {
                    errorProvider.SetError(cbLoaikm, "Vui lòng chọn loại khuyến mãi");
                    isValid = false;
                }
                else if (cbLoaikm.SelectedItem.ToString() == "%")
                {
                    if (decimal.TryParse(txtPhanTramGiam.Text, out decimal phanTram))
                    {
                        if (phanTram < 0 || phanTram > 100)
                        {
                            errorProvider.SetError(txtPhanTramGiam, "Phần trăm giảm giá phải từ 0 đến 100");
                            isValid = false;
                        }
                    }
                    else
                    {
                        errorProvider.SetError(txtPhanTramGiam, "Vui lòng nhập số hợp lệ cho phần trăm giảm giá");
                        isValid = false;
                    }
                }
                else if (cbLoaikm.SelectedItem.ToString() == "VND")
                {
                    if (decimal.TryParse(txtPhanTramGiam.Text, out decimal tienMat))
                    {
                        if (tienMat < 0 || tienMat > 500000)
                        {
                            errorProvider.SetError(txtPhanTramGiam, "Giá trị giảm tiền mặt phải từ 0 đến 500,000 VND");
                            isValid = false;
                        }
                    }
                    else
                    {
                        errorProvider.SetError(txtPhanTramGiam, "Vui lòng nhập số tiền hợp lệ cho giá trị giảm");
                        isValid = false;
                    }
                }
            }

            // Validate ngày bắt đầu và kết thúc
            if (dtpNgayKetThuc.Value <= dtpNgayBatDau.Value)
            {
                errorProvider.SetError(dtpNgayKetThuc, "Ngày kết thúc phải sau ngày bắt đầu");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(dtpNgayKetThuc, "");
            }

            return isValid;
        }
        private KhuyenMai GetKhuyenMaiFromForm()
        {
            KhuyenMai km = new KhuyenMai();
            if (!string.IsNullOrEmpty(txtMaKM.Text) && txtMaKM.Text != "(Tự động)")
            {
                km.MaKM = txtMaKM.Text;
            }
            km.TenKm = txtTenKM.Text.Trim();
            km.GiaTriKM = decimal.Parse(txtPhanTramGiam.Text);
            km.ngayBatDau = dtpNgayBatDau.Value;
            km.ngayKetThuc = dtpNgayKetThuc.Value;
            km.statuskm = cbTrangThai.SelectedItem.ToString();
            km.moTa = txtMoTa.Text.Trim();
            km.giftcode = txtVoucherGiftcode.Text.Trim();
            km.LoaiKM = GetLoaiKMValue(cbLoaikm.SelectedItem.ToString()); // Get the actual value to store

            return km;
        }

        // Helper to get the string value for LoaiKM based on selected text
        private string GetLoaiKMValue(string selectedText)
        {
            switch (selectedText)
            {
                case "%":
                    return "phantram";
                case "VND":
                    return "trigia";
                default:
                    return "null"; // Or handle appropriately
            }
        }


        private void LoadDanhSachKhuyenMai()
        {
            try
            {
                // Get the data from your DAO
                DataTable khuyenMaiTable = _khuyenMaiDAO.GetListKhuyenMai();

                // Clear existing bindings and columns
                dgvDanhSachKM.DataSource = null;
                dgvDanhSachKM.Columns.Clear();

                // Set the new data source
                dgvDanhSachKM.DataSource = khuyenMaiTable;

                // Map specific columns and set their properties
                dgvDanhSachKM.Columns["MaKM"].HeaderText = "Mã KM";
                dgvDanhSachKM.Columns["TenKM"].HeaderText = "Tên khuyến mãi";
                dgvDanhSachKM.Columns["GiaTriKM"].HeaderText = "Giá trị giảm"; // Changed header text
                dgvDanhSachKM.Columns["NgayBatDau"].HeaderText = "Ngày bắt đầu";
                dgvDanhSachKM.Columns["NgayKetThuc"].HeaderText = "Ngày kết thúc";
                dgvDanhSachKM.Columns["ghiChu"].HeaderText = "Ghi chú";
                dgvDanhSachKM.Columns["trangThaiCT"].HeaderText = "Trạng thái";
                dgvDanhSachKM.Columns["LoaiKM"].HeaderText = "Loại KM"; // Added column header
                dgvDanhSachKM.Columns["giftcode"].HeaderText = "Giftcode"; // Assuming giftcode is in the DataTable


                // Optionally format columns
                dgvDanhSachKM.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvDanhSachKM.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // Refresh the grid
                dgvDanhSachKM.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khuyến mãi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (isAdding)
            {
                // Đang ở chế độ thêm mới và người dùng nhấn lưu
                if (!ValidateData())
                {
                    return;
                }
                if(_khuyenMaiDAO.IsGiftcodeExists(txtVoucherGiftcode.Text.Trim()))
                {
                    MessageBox.Show("Giftcode đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    KhuyenMai km = GetKhuyenMaiFromForm();
                    bool result = _khuyenMaiDAO.Insert(km);

                    if (result)
                    {
                        MessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachKhuyenMai();
                        ResetForm();
                        btnThem.Text = "Thêm";
                        isAdding = false; // Set back to not adding
                    }
                    else
                    {
                        MessageBox.Show("Thêm khuyến mãi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Chuyển sang chế độ thêm mới
                ResetForm();
                txtMaKM.Text = "(Tự động)";
                txtMaKM.Enabled = false;
                btnThem.Text = "Lưu";
                isAdding = true;
                txtTenKM.Focus();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKM.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateData())
            {
                return;
            }

            try
            {
                KhuyenMai km = GetKhuyenMaiFromForm();
                // Ensure MaKM is correctly retrieved and parsed for update
                if (int.TryParse(txtMaKM.Text, out int maKM))
                {
                    bool result = _khuyenMaiDAO.Update(maKM, km);

                    if (result)
                    {
                        MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachKhuyenMai();
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật khuyến mãi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lấy Mã KM để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKM.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int maKM = Convert.ToInt32(dgvDanhSachKM.SelectedRows[0].Cells["MaKM"].Value);
            string tenKM = dgvDanhSachKM.SelectedRows[0].Cells["TenKM"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khuyến mãi '{tenKM}'?", "Xác nhận xóa",
                                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    bool deleteResult = _khuyenMaiDAO.DeleteById(maKM);

                    if (deleteResult)
                    {
                        MessageBox.Show("Xóa khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachKhuyenMai();
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khuyến mãi thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            try
            {
                DataTable dt = _khuyenMaiDAO.SearchKhuyenMai(keyword);
                dgvDanhSachKM.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khuyến mãi phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvDanhSachKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                isAdding = false;
                btnThem.Text = "Thêm";
                errorProvider.Clear(); // Clear errors when selecting a new row


                DataGridViewRow row = dgvDanhSachKM.Rows[e.RowIndex];

                txtMaKM.Text = row.Cells["MaKM"].Value.ToString();
                txtTenKM.Text = row.Cells["TenKM"].Value.ToString();
                txtPhanTramGiam.Text = row.Cells["GiaTriKM"].Value.ToString();
                txtMoTa.Text = row.Cells["ghiChu"].Value.ToString();
                // Handle potential null for giftcode cell before accessing Value
                if (row.Cells["giftcode"].Value != null)
                {
                    txtVoucherGiftcode.Text = row.Cells["giftcode"].Value.ToString();
                }
                else
                {
                    txtVoucherGiftcode.Text = ""; // Set to empty if null
                }


                if (DateTime.TryParse(row.Cells["NgayBatDau"].Value.ToString(), out DateTime ngayBD))
                {
                    dtpNgayBatDau.Value = ngayBD;
                }
                else
                {
                    dtpNgayBatDau.Value = DateTime.Today; // Default if parsing fails
                }


                if (DateTime.TryParse(row.Cells["NgayKetThuc"].Value.ToString(), out DateTime ngayKT))
                {
                    dtpNgayKetThuc.Value = ngayKT;
                }
                else
                {
                    dtpNgayKetThuc.Value = DateTime.Today.AddMonths(1); // Default if parsing fails
                }


                string trangThai = row.Cells["trangThaiCT"].Value.ToString();
                cbTrangThai.SelectedIndex = cbTrangThai.FindStringExact(trangThai);

                // Set the LoaiKM combobox based on the value from the grid
                string loaiKMValue = row.Cells["LoaiKM"].Value.ToString();
                SetLoaiKMComboBox(loaiKMValue);


                // Lấy thêm thông tin mô tả (giả sử mô tả không hiển thị trên grid) - This part might be redundant if ghiChu is already showing it.
                // If "ghiChu" in your DataTable is the same as "moTa", you don't need this extra database call.
                // If "ghiChu" and "moTa" are different columns in your database/model, keep this.
                try
                {
                    int maKM = Convert.ToInt32(row.Cells["MaKM"].Value);
                    KhuyenMai km = _khuyenMaiDAO.GetKhuyenMaiById(maKM);
                    if (km != null)
                    {
                        // Only update txtMoTa if it's different from what's in the grid or if ghiChu isn't moTa
                        // if (txtMoTa.Text != km.moTa)
                        // {
                        txtMoTa.Text = km.moTa;
                        // }
                        // You might also want to set the voucher/giftcode here if it's not in the main grid data
                        txtVoucherGiftcode.Text = km.giftcode;
                    }
                }
                catch { /* Xử lý ngoại lệ nếu cần */ }
            }
        }

        // Helper to set the LoaiKM combobox based on the stored value
        private void SetLoaiKMComboBox(string loaiKMValue)
        {
            switch (loaiKMValue.ToLower()) // Use ToLower() for case-insensitive comparison
            {
                case "phantram":
                    cbLoaikm.SelectedItem = "%";
                    break;
                case "trigia":
                    cbLoaikm.SelectedItem = "VND";
                    break;
                default:
                    cbLoaikm.SelectedIndex = -1; // Or a default item like "Chọn loại"
                    break;
            }
        }


        private string GetLoaiKM(int selectedIndex)
        {
            // Using ternary operator: if selectedIndex is 0, return "phantram", otherwise return "tienmat"
            return selectedIndex == 0 ? "phantram" : "trigia";
        }

        private void cbLoaikm_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can add logic here to clear or pre-fill txtPhanTramGiam
            // based on the selected type, but the primary validation
            // should remain in ValidateData().
            // For example, you could clear the text to avoid confusion:
            // txtPhanTramGiam.Text = "";
            // Or provide a hint to the user via a label or tooltip.
            // The validation in ValidateData is crucial before saving.
        }

        // You might want to add validation for txtPhanTramGiam on its Leave event
        // to provide immediate feedback to the user, but ValidateData will be the final check.
        private void txtPhanTramGiam_Leave(object sender, EventArgs e)
        {
            ValidateData(); // Re-validate when the user leaves the textbox
        }

    }
}