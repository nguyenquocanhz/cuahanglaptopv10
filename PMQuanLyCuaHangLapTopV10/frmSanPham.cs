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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

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
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            bool result = sanPhamDAO.InsertSP(
                txtName.Text,
                thoigianbaohanh,
                int.TryParse(txtSoLuongSP.Text, out int soLuong) ? soLuong : 0,
                txtMoTaSP.Text,
                decimal.TryParse(txtGiaBan.Text, out decimal giaBan) ? giaBan : 0,
                decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap) ? giaNhap : 0,
                int.Parse(cbNCC.Text) // Biến maNCC đã lấy từ ComboBox
            );

            if (result) 
            {
                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitDGV();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
