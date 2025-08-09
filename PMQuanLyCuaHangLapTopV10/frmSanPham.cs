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
    public partial class frmSanPham: Form
    {
        public DbHelpers db = DbHelpers.Instance();

        public Helpers helpers = new Helpers();
        public int MaNhaCungCap;
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            if (!db.CheckConnection())
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InitCB();
            InitDGV();
            if (SessionManager.Role == "Staff")
            {
                panel_action.Visible = false;
                dataGridView1.Dock = DockStyle.Fill;
            }
            for (int i = 6; i <= 60; i += 6)
            {
                cbThoiGianBaoHanh.Items.Add($"{i} tháng");
            }

            // Đặt giá trị mặc định cho ComboBox
            cbThoiGianBaoHanh.SelectedIndex = 0; // Chọn mục đầu tiên trong danh sách
        }
        private void ChecKAdmin()
        {

        }
        private void InitDGV()
        {

            // Lấy danh sách sản phẩm từ database
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            DataTable dtSanPhams = sanPhamDAO.GetList(); // GetList() trả về DataTable

            if (dtSanPhams.Rows.Count > 0)
            {
                dataGridView1.DataSource = dtSanPhams; // Gán dữ liệu vào DataGridView

                // Tùy chỉnh tiêu đề cột hiển thị
                dataGridView1.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
                dataGridView1.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dataGridView1.Columns["ThoiGianBaoHanh"].HeaderText = "Thời Gian Bảo Hành";
                dataGridView1.Columns["SoLuongSP"].HeaderText = "Số Lượng";
                dataGridView1.Columns["GiaNhap"].HeaderText = "Giá nhập"; // Đúng tên cột trong DB
                dataGridView1.Columns["GiaBan"].HeaderText = "Giá bán"; // Đúng tên cột trong DB
                dataGridView1.Columns["MaNCC"].HeaderText = "Mã Nhà Cung Cấp";
                dataGridView1.Columns["MoTaChiTiet"].HeaderText = "Mô Tả Chi Tiết Sản Phẩm";
            }
            else
            {
                dataGridView1.DataSource = null; // Không có dữ liệu
            }
        }
        public void ClearTextBox()
        {
            txtName.Text = "";
            cbThoiGianBaoHanh.Text = "";
            txtSoLuongSP.Text = "";
            txtMoTaSP.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            cbNCC.Text = "";
        }
        public void ClearDataGridView()
        {
            dataGridView1.DataSource = null;
        }
        public int maNCC;
        private void InitCB()
        {
            try
            {
                // Lấy danh sách nhà cung cấp từ database
                NhaCungCapDAO nhaCungCapDAO = new NhaCungCapDAO();
                DataTable dtNhaCungCaps = nhaCungCapDAO.GetListNhaCungCap();

                if (dtNhaCungCaps != null && dtNhaCungCaps.Rows.Count > 0)
                {
                    // Tạo DataTable mới để custom hiển thị
                    DataTable dtComboBox = new DataTable();
                    dtComboBox.Columns.Add("Display", typeof(string));
                    dtComboBox.Columns.Add("Value", typeof(string));

                    // Thêm dòng mặc định
                    dtComboBox.Rows.Add("Chọn nhà cung cấp", "");

                    // Thêm dữ liệu từ DataTable gốc
                    foreach (DataRow row in dtNhaCungCaps.Rows)
                    {
                        string maNCC = row["MaNCC"].ToString();
                        string tenNCC = row["TenNCC"].ToString();
                        dtComboBox.Rows.Add($"{maNCC} - {tenNCC}", maNCC);
                    }

                    // Gán nguồn dữ liệu
                    cbNCC.DataSource = dtComboBox;
                    cbNCC.DisplayMember = "Display";
                    cbNCC.ValueMember = "Value";

                    // Chọn mục đầu tiên
                    cbNCC.SelectedIndex = 0;
                }
                else
                {
                    // Không có dữ liệu
                    cbNCC.DataSource = null;
                    cbNCC.Items.Add("Không có dữ liệu");
                    cbNCC.SelectedIndex = 0;
                }

                // Đăng ký sự kiện
                cbNCC.SelectedIndexChanged += CbNCC_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có item được chọn không
            if (cbNCC.SelectedItem != null)
            {
                // Lấy giá trị được chọn
                DataRowView selectedRow = cbNCC.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    string selectedValue = selectedRow["Value"].ToString();

                    // Nếu không phải mục "Chọn nhà cung cấp"
                    if (!string.IsNullOrEmpty(selectedValue))
                    {
                        // Thực hiện các thao tác khi chọn nhà cung cấp
                        // Ví dụ: load thông tin chi tiết, filter dữ liệu, v.v.
                    }
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClearText()
        {
            txtMaSP.Text = "";
            txtName.Text = "";
            cbThoiGianBaoHanh.Text = "";
            txtSoLuongSP.Text = "";
            txtMoTaSP.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            cbNCC.Text = "";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(cbThoiGianBaoHanh.Text))
            {
                MessageBox.Show("Thời gian bảo hành không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtSoLuongSP.Text))
            {
                MessageBox.Show("Số lượng sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtMoTaSP.Text))
            {
                MessageBox.Show("Mô tả chi tiết sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtGiaBan.Text))
            {
                MessageBox.Show("Đơn giá sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtGiaNhap.Text))
            {
                MessageBox.Show("Đơn giá nhập sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(cbNCC.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int thoigianbaohanh = int.Parse(cbThoiGianBaoHanh.Text.Split(' ')[0]);
            int MaNCC = int.Parse(getMaNCC(cbNCC.Text));
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            bool result = sanPhamDAO.InsertSP(
                txtName.Text,
                thoigianbaohanh,
                int.TryParse(txtSoLuongSP.Text, out int soLuong) ? soLuong : 0,
                txtMoTaSP.Text,
                decimal.TryParse(helpers.RemoveFormatting(txtGiaBan.Text), out decimal giaBan) ? giaBan : 0,
                decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap) ? giaNhap : 0,
                MaNCC // Biến maNCC đã lấy từ ComboBox
            );

            
            if (result) 
            {
                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitDGV();
                ClearText();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string getMaNCC(string cbText)
        {
            string[] parts = cbText.Split('-');
            if (parts.Length > 0)
            {
                return parts[0].Trim(); // Trả về mã nhà cung cấp
            }
            return ""; // Hoặc xử lý theo cách khác nếu không tìm thấy
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            bool result = sanPhamDAO.Delete(txtMaSP.Text);
            if (result)
            {
                MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitDGV();
                ClearText();

            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            txtGiaBan.Text = helpers.FormatNumber(txtGiaBan.Text);
            txtGiaBan.SelectionStart = txtGiaBan.Text.Length; // Đặt con trỏ ở cuối
        }



        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            txtGiaNhap.Text = helpers.FormatNumber(txtGiaNhap.Text);
            txtGiaNhap.SelectionStart = txtGiaNhap.Text.Length; // Đặt con trỏ ở cuối
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnUpdate.Enabled = true;
                btnDel.Enabled = true;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtName.Text = row.Cells["TenSP"].Value.ToString();
                txtSoLuongSP.Text = row.Cells["SoLuongSP"].Value.ToString();
                txtSoLuongSP.ReadOnly = true;
                txtMoTaSP.Text = row.Cells["MoTaChiTiet"].Value.ToString();
                txtGiaBan.Text = helpers.FormatNumber(row.Cells["GiaBan"].Value.ToString());
                txtGiaNhap.Text = helpers.FormatNumber(row.Cells["GiaNhap"].Value.ToString());
                string maNCC = dataGridView1.Rows[e.RowIndex].Cells["MaNCC"].Value?.ToString();
                if (!string.IsNullOrEmpty(maNCC))
                {
                    cbNCC.SelectedValue = maNCC;
                }
                cbThoiGianBaoHanh.Text = row.Cells["ThoiGianBaoHanh"].Value.ToString() + " tháng";

                // ở datagridview giá trị của cột "ThoiGianBaoHanh" là kiểu dữ liệu int ví dụ 6 thì chọn combobox là 6 tháng 
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Mã sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(cbThoiGianBaoHanh.Text))
            {
                MessageBox.Show("Thời gian bảo hành không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtSoLuongSP.Text))
            {
                MessageBox.Show("Số lượng sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtMoTaSP.Text))
            {
                MessageBox.Show("Mô tả chi tiết sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtGiaBan.Text))
            {
                MessageBox.Show("Đơn giá sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(txtGiaNhap.Text))
            {
                MessageBox.Show("Đơn giá nhập sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(cbNCC.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int thoigianbaohanh = int.Parse(cbThoiGianBaoHanh.Text.Split(' ')[0]);
            int MaNCC = int.Parse(getMaNCC(cbNCC.Text));
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            bool result = sanPhamDAO.Update(
                txtMaSP.Text,
                txtName.Text,
                "",
                thoigianbaohanh,
                int.TryParse(txtSoLuongSP.Text, out int soLuong) ? soLuong : 0,
                txtMoTaSP.Text,
                decimal.TryParse(helpers.RemoveFormatting(txtGiaBan.Text), out decimal giaBan) ? giaBan : 0,
                decimal.TryParse(helpers.RemoveFormatting(txtGiaNhap.Text), out decimal giaNhap) ? giaNhap : 0,
                MaNCC // Biến maNCC đã lấy từ ComboBox
                );
            if (result)
            {
                MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitDGV();
                ClearText();
            }
            else
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            InitDGV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // --- 1. Kiểm tra xem người dùng có nhấp vào một hàng hợp lệ không ---
            // e.RowIndex >= 0 để bỏ qua việc nhấp vào tiêu đề cột (header)
            if (e.RowIndex >= 0)
            {
                // --- 2. Lấy tên của cột được nhấp vào ---
                // Lấy đối tượng cột dựa trên chỉ số cột (e.ColumnIndex)
                DataGridViewColumn clickedColumn = dataGridView1.Columns[e.ColumnIndex];

                // --- 3. Kiểm tra xem cột được nhấp có phải là cột "MaNCC" không ---
                // So sánh tên của cột được nhấp với tên cột bạn muốn ("MaNCC")
                if (clickedColumn != null && clickedColumn.Name == "MaNCC")
                {
                    // --- 4. Lấy giá trị MaNCC từ ô được nhấp ---
                    // Lấy giá trị từ ô cụ thể trong hàng (e.RowIndex) và cột (e.ColumnIndex hoặc tên cột "MaNCC")
                    // Sử dụng ?.ToString() để tránh lỗi nếu giá trị là null
                    object cellValue = dataGridView1.Rows[e.RowIndex].Cells["MaNCC"].Value;

                    // Kiểm tra xem giá trị có tồn tại không
                    if (cellValue != null)
                    {
                        string maNhaCungCap = cellValue.ToString();

                        // --- 5. Tạo và hiển thị Form thông tin nhà cung cấp ---
                        // Tạo một thể hiện (instance) của FormThongTinNhaCungCap
                        // **Quan trọng:** Truyền mã nhà cung cấp (maNhaCungCap) cho Form mới
                        // Cách phổ biến là qua Constructor hoặc một Property công khai.

                        // Ví dụ: Sử dụng Constructor
                        frmXemTT formChiTietNCC = new frmXemTT(maNhaCungCap);

                        // Hiển thị Form dưới dạng Dialog (chặn tương tác với Form chính cho đến khi đóng Form chi tiết)
                        formChiTietNCC.ShowDialog();

                        // Hoặc hiển thị Form không chặn (người dùng có thể tương tác cả hai Form)
                        // formChiTietNCC.Show();

                        // Tùy chọn: Sau khi Form chi tiết đóng (nếu dùng ShowDialog),
                        // bạn có thể muốn làm mới dữ liệu trên DataGridView chính
                        // LoadDataGridViewData(); // Gọi lại phương thức tải dữ liệu của bạn
                    }
                    else
                    {
                        // Xử lý trường hợp giá trị trong ô MaNCC là null (nếu có thể xảy ra)
                        MessageBox.Show("Ô Mã nhà cung cấp không chứa giá trị.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // Nếu nhấp vào cột khác, không làm gì cả (hoặc thêm xử lý khác nếu cần)
            }
            // Nếu nhấp vào header (e.RowIndex < 0), không làm gì cả
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmNhaCungCap nhaCungCap = new frmNhaCungCap();
            nhaCungCap.StartPosition = FormStartPosition.CenterParent; // Đặt vị trí khởi đầu của form
            nhaCungCap.ShowDialog();
        }
    }
}
