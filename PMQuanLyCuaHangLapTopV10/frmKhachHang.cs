using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using PMQuanLyCuaHangLapTopV10.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{

    public partial class frmKhachHang: Form
    {
        
        public DataTable khachHangs = new DataTable();
        public KhachHangDAO KhachHangDAO = new KhachHangDAO();
        public DataTable fitlerKh = new DataTable();
        public frmKhachHang()
        {
            InitializeComponent();
            txtMaKH.ReadOnly = true;
            LoadKhachHangData();
            dgvListKhachHang.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            if (SessionManager.Role == "Staff" || SessionManager.ChucDanh == "Nhân viên bán hàng" || SessionManager.ChucDanh == "Nhân viên kỹ thuật")
            {
                btnDel.Enabled = false;
            }
            else
            {
                //btnnewHD.Enabled = true;
                btnDel.Enabled = true;
                btnSua.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tenKH = txtHoten.Text.Trim();
            string sdt   = txtPhone.Text.Trim();
            string sex = cbGioiTinh.Text;
            string diachi = txtDiaChi.Text.Trim();
            // Đây là thêm mới, không cần kiểm tra MaNCC



            //if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(sdt))
            //{
            //    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            //    return;
            //}
            if (string.IsNullOrEmpty(tenKH))
            {
                MessageBox.Show("Vui lòng nhập tên Khách hàng");
                txtHoten.Focus();
                return;
            }
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
                txtPhone.Focus();
                return;
            }
            if (sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có 10 số");
                txtPhone.Clear();
                txtPhone.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(sex))
            {
                MessageBox.Show("Vui lòng chọn giới tính");
                cbGioiTinh.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(diachi))
            {
                MessageBox.Show("Vui lòng điền địa chỉ !");
                cbGioiTinh.Focus();
                return;
            }

            // Nếu đang cập nhật (đã chọn một NCC từ datagridview)
            bool isExist = KhachHangDAO.CheckExistKHByPhone(sdt);
            if (isExist) // Chỉ tiếp tục nếu NCC này KHÔNG tồn tại (nghĩa là không tìm thấy)
            {
                MessageBox.Show("Số Khách hàng đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            KhachHang kh = new KhachHang
            {
                HoTen = tenKH,
                GioiTinh = sex,
                SoDienThoai = sdt,
                DiaChiKH = txtDiaChi.Text
            };
            bool isCreated = KhachHangDAO.InsertKhachHang(kh);
            if (isCreated)
            {
                MessageBox.Show("Thêm Khách hàng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadKhachHangData();
                // Reset form
                txtHoten.Text = "";
                txtPhone.Text = "";
                txtMaKH.Text = "";
                return;
            }
            else
            {
                MessageBox.Show("Lỗi không xác định !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadKhachHangData()
        {
            // Giả sử khachHangs là danh sách chứa dữ liệu khách hàng
            khachHangs = KhachHangDAO.GetListKhachHangDatatable();

            // Thiết lập DataGridView
            dgvListKhachHang.DataSource = null;
            dgvListKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListKhachHang.DataSource = khachHangs;

            // Đặt lại tiêu đề cột sau khi gán nguồn dữ liệu
            SetupColumnHeaders();
        }
        private void SetupColumnHeaders()
        {
            dgvListKhachHang.Columns["MaKH"].HeaderText = "Mã Khách hàng";
            dgvListKhachHang.Columns["HotenKH"].HeaderText = "Họ Tên";
            dgvListKhachHang.Columns["gioiTinh"].HeaderText = "Giới tính";
            dgvListKhachHang.Columns["soDienThoai"].HeaderText = "Số Điện Thoại";
            dgvListKhachHang.Columns["diaChiKH"].HeaderText = "Địa chỉ KH";
        }


        private void dgvListNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvListKhachHang.Rows[e.RowIndex];
                // Gán giá trị của các ô vào các TextBox tương ứng
                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtHoten.Text = row.Cells["HotenKH"].Value.ToString();
                string gioiTinh = row.Cells["gioiTinh"].Value.ToString().Trim();
                cbGioiTinh.SelectedIndex = gioiTinh == "Nam" ? 0 : 1; 
                txtPhone.Text = row.Cells["soDienThoai"].Value.ToString();
                txtDiaChi.Text = row.Cells["diaChiKH"].Value.ToString();
            }
        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            searchBox.Clear();
            searchBox.Focus();
        }


        private void searchBox_Leave(object sender, EventArgs e)
        {
            searchBox.Text = "Nhập từ khóa cần tìm";
            LoadKhachHangData();
        }

        private void searchBox_TabIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Xin chào bạn !");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadKhachHangData();
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    // Gọi phương thức tìm kiếm
            //    PerformSearch();

            //    // Đánh dấu là đã xử lý sự kiện này
            //    // để ngăn TextBox phát ra tiếng 'ding' hoặc xử lý phím Enter theo cách mặc định
            //    e.Handled = true;
            //}
        }
        private void PerformSearch()
        {
            string keyword = searchBox.Text.Trim(); // Lấy từ khóa và loại bỏ khoảng trắng thừa

            try
            {
                DataTable searchResults;
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu ô tìm kiếm trống, hiển thị lại tất cả khách hàng
                    // Hoặc bạn có thể chọn không làm gì cả hoặc xóa kết quả cũ
                    searchResults = KhachHangDAO.GetListKhachHangDatatable(); // Lấy lại tất cả
                                                                              // LoadAllCustomers(); // Hoặc gọi phương thức tải tất cả nếu có
                }
                else
                {
                    // Gọi phương thức tìm kiếm từ DAO
                    searchResults = KhachHangDAO.SearchKhachHang(keyword);
                }

                // Hiển thị kết quả lên DataGridView (ví dụ)
                dgvListKhachHang.DataSource = searchResults;

                // Optional: Hiển thị thông báo nếu không tìm thấy kết quả
                if (searchResults.Rows.Count == 0 && !string.IsNullOrWhiteSpace(keyword))
                {
                    // Ví dụ: hiển thị trên một Label trạng thái
                    // lblStatus.Text = "Không tìm thấy khách hàng phù hợp.";
                }
                else
                {
                    // lblStatus.Text = $"Tìm thấy {searchResults.Rows.Count} kết quả.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Bạn nên ghi log lỗi ở đây
                // Logger.Log($"Lỗi tìm kiếm khách hàng: {ex.Message}");
            }
        }

        //private void btnAdd_Click_1(object sender, EventArgs e)
        //{
        //    tenNcc = txtHoten.Text.Trim();
        //    sdt = txtSdtNCC.Text.Trim();

        //    if (string.IsNullOrEmpty(tenNcc) || string.IsNullOrEmpty(sdt))
        //    {
        //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        //        return;
        //    }
        //    if (sdt.Length != 10)
        //    {
        //        MessageBox.Show("Số điện thoại phải có 10 số");
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(tenNcc))
        //    {
        //        MessageBox.Show("Vui lòng nhập tên nhà cung cấp");
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(sdt))
        //    {
        //        MessageBox.Show("Vui lòng nhập số điện thoại");
        //        return;
        //    }
        //}

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn khách hàng hay chưa
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để cập nhật!",
                               "Thông báo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức nếu chưa chọn khách hàng
            }

            // Kiểm tra các thông tin bắt buộc
            if (string.IsNullOrEmpty(txtHoten.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!",
                               "Thông báo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng KhachHang với đầy đủ thông tin
            KhachHang kh = new KhachHang
            {
                MaKhachHang = txtMaKH.Text, // Thêm MaKH để có thể cập nhật đúng khách hàng
                HoTen = txtHoten.Text,
                GioiTinh = cbGioiTinh.Text,
                SoDienThoai = txtPhone.Text,
                DiaChiKH = txtDiaChi.Text
            };

            bool isUpdated = KhachHangDAO.UpdateKhachHang(kh);
            if (isUpdated)
            {
                MessageBox.Show("Đã cập nhật thông tin thành công",
                               "Thông báo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                LoadKhachHangData();

                // Có thể thêm code để reset các trường nhập liệu sau khi cập nhật
                ResetFields();
            }
            else
            {
                MessageBox.Show("Không thể cập nhật khách hàng này!",
                               "Thông báo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        // Phương thức hỗ trợ để reset các trường nhập liệu
        private void ResetFields()
        {
            txtMaKH.Text = "";
            txtHoten.Text = "";
            txtPhone.Text = "";
            txtDiaChi.Text = "";
            cbGioiTinh.SelectedIndex = -1; // Hoặc chọn giá trị mặc định
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng cần xóa!",
                               "Thông báo",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return; // Thoát khỏi phương thức nếu chưa chọn khách hàng
            }
            DialogResult confirmDelete = MessageBox.Show($"Bạn có muốn xóa khách hàng có tên {txtHoten.Text.Trim()}","Cảnh bảo",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (confirmDelete == DialogResult.OK) 
            {
                bool isDelete = KhachHangDAO.DeleteKhachHang(txtMaKH.Text);
                if (isDelete)
                {
                    MessageBox.Show("Đã xóa khách hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKhachHangData();
                }
                else 
                {
                    MessageBox.Show("Không thể khách hàng này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khóa tìm kiếm từ searchBox
            string searchKeyword = searchBox.Text.ToLower().Trim();

            // Kiểm tra nếu khachHangs không null
            if (khachHangs != null)
            {
                // Tạo DataView từ DataTable khachHangs
                DataView dv = new DataView(khachHangs);

                // Nếu từ khóa rỗng, hiển thị tất cả
                if (string.IsNullOrEmpty(searchKeyword))
                {
                    dv.RowFilter = string.Empty;
                }
                else
                {
                    // Lọc theo mã khách hàng, họ tên, số điện thoại hoặc địa chỉ
                    dv.RowFilter = string.Format("HotenKH LIKE '%{0}%' OR soDienThoai LIKE '%{0}%' OR diaChiKH LIKE '%{0}%'",
                        searchKeyword.Replace("'", "''"));
                }

                // Gán DataView đã lọc làm DataSource mới cho DataGridView
                dgvListKhachHang.DataSource = dv;
            }
        }

        private void btnnewHD_Click(object sender, EventArgs e)
        {

        }

        private void btnTaoPhieuBH_Click(object sender, EventArgs e)
        {

        }

        private void act_lap_hd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng cần lập hóa đơn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmThemHoaDon newHD = new frmThemHoaDon(txtMaKH.Text, SessionManager.sodt);
            newHD.Show();
        }

        private void act_tao_phieubh_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng cần lập hóa đơn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmBaoHanh newPBH = new frmBaoHanh();
            newPBH.ShowDialog();
        }







        //private void btnAdd_Click_1(object sender, EventArgs e)
        //{
        //    tenNcc = txtHoten.Text.Trim();
        //    sdt = txtSdtNCC.Text.Trim();

        //    if (string.IsNullOrEmpty(tenNcc) || string.IsNullOrEmpty(sdt))
        //    {
        //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        //        return;
        //    }
        //    if (sdt.Length != 10)
        //    {
        //        MessageBox.Show("Số điện thoại phải có 10 số");
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(tenNcc))
        //    {
        //        MessageBox.Show("Vui lòng nhập tên nhà cung cấp");
        //        return;
        //    }
        //    if (string.IsNullOrEmpty(sdt))
        //    {
        //        MessageBox.Show("Vui lòng nhập số điện thoại");
        //        return;
        //    }
        //    // Nếu đang cập nhật (đã chọn một NCC từ datagridview)
        //    bool isExist = NhaCungCapDAO.CheckExistNCCByPhoneOrName(sdt, tenNcc);
        //    if (!isExist) // Chỉ tiếp tục nếu NCC này KHÔNG tồn tại (nghĩa là không tìm thấy)
        //    {
        //        MessageBox.Show("Nhà cung cấp đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    // Đây là thêm mới, không cần kiểm tra MaNCC
        //    NhaCungCap nhaCungCap = new NhaCungCap
        //    {
        //        TenNCC = tenNcc,
        //        SoDienThoai = sdt,
        //    };

        //    bool isCreated = NhaCungCapDAO.InsertNCC(nhaCungCap);
        //    if (isCreated)
        //    {
        //        MessageBox.Show("Thêm nhà cung cấp thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        LoadData();
        //        // Reset form
        //        txtTenNCC.Text = "";
        //        txtSdtNCC.Text = "";
        //        MaNCC = null;
        //        return;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Lỗi không xác định !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }


}
