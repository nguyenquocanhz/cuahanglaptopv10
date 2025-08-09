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
    public partial class frmPhieuNhapHang2 : Form
    {
        // Khai báo các biến và đối tượng cần thiết
        private DataTable dtChiTietPhieu;
        public NhaCungCapDAO nhaCungCapDAO = new NhaCungCapDAO();
        public NhanVienDAO nhanVienDAO = new NhanVienDAO();
        public frmPhieuNhapHang2()
        {
            InitializeComponent();
        }

        private void frmPhieuNhapHang2_Load(object sender, EventArgs e)
        {
            // Thiết lập các giá trị mặc định khi form được load
            KhoiTao();
            LoadNhaCungCap();
            LoadSanPham();
            TaoMaPhieuTuDong("PN");
        }
        public frmPhieuNhapHang2(string MaNCC, string sdtnv)
        {
            InitializeComponent();

            //InitializeDataGridView(); // Initialize DataGridView
            //InitializeAutoComplete();
            //InitializeGoiYListBox(); // Initialize suggestion ListBox properly
            txtMaNCC.Text = MaNCC;
            NhanVien infoNv = nhanVienDAO.GetNhanVienBySoDienThoai(sdtnv);
            txtNguoiNhap.Text = infoNv.HoTenNV;
            try
            {

                NhaCungCap infoNCC = nhaCungCapDAO.GetNhaCungCapByIdv2(MaNCC);
                if (infoNCC != null)
                    txtMaNCC.Text = infoNCC.MaNCC;

                if (infoNCC != null)
                {
                    txtMaNCC.Text = infoNCC.MaNCC;
                }
                Helpers helpers = new Helpers();
                txtMaPhieu.Text = helpers.RandomHDHienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KhoiTao()
        {
            // Khởi tạo DataTable để lưu trữ thông tin chi tiết phiếu nhập
            dtChiTietPhieu = new DataTable();
            dtChiTietPhieu.Columns.Add("MaSP", typeof(string));
            dtChiTietPhieu.Columns.Add("TenSP", typeof(string));
            dtChiTietPhieu.Columns.Add("SoLuong", typeof(int));
            dtChiTietPhieu.Columns.Add("DonGia", typeof(decimal));
            dtChiTietPhieu.Columns.Add("ThanhTien", typeof(decimal));

            // Gán DataSource cho DataGridView
            dgvChiTietPhieu.DataSource = dtChiTietPhieu;

            // Thiết lập ngày nhập mặc định là ngày hiện tại
            dtpNgayNhap.Value = DateTime.Now;

            // Khởi tạo người nhập là người dùng hiện tại (có thể lấy từ thông tin đăng nhập)
            txtNguoiNhap.Text = "Admin"; // Giả sử người dùng hiện tại là Admin
        }

        private void LoadNhaCungCap()
        {
            // Giả lập dữ liệu nhà cung cấp (trong thực tế sẽ lấy từ CSDL)
            DataTable dtNCC = new DataTable();
            dtNCC.Columns.Add("MaNCC", typeof(string));
            dtNCC.Columns.Add("TenNCC", typeof(string));

            // Thêm một số nhà cung cấp mẫu
            dtNCC.Rows.Add("NCC001", "Công ty TNHH Máy tính ABC");
            dtNCC.Rows.Add("NCC002", "Công ty TNHH Thiết bị điện tử XYZ");
            dtNCC.Rows.Add("NCC003", "Nhà phân phối laptop DEF");
            dtNCC.Rows.Add("NCC004", "Công ty nhập khẩu GHI");


        }

        private void LoadSanPham()
        {
            // Giả lập dữ liệu sản phẩm (trong thực tế sẽ lấy từ CSDL)
            DataTable dtSP = new DataTable();
            dtSP.Columns.Add("MaSP", typeof(string));
            dtSP.Columns.Add("TenSP", typeof(string));
            dtSP.Columns.Add("GiaNhap", typeof(decimal));

            // Thêm một số sản phẩm mẫu
            dtSP.Rows.Add("SP001", "Laptop Dell XPS 13", 20000000);
            dtSP.Rows.Add("SP002", "MacBook Air M1", 24000000);
            dtSP.Rows.Add("SP003", "HP Pavilion 15", 15000000);
            dtSP.Rows.Add("SP004", "Lenovo ThinkPad X1", 22000000);
            dtSP.Rows.Add("SP005", "Asus ROG Strix G15", 25000000);

            // Thiết lập dữ liệu cho ComboBox sản phẩm
            cboSanPham.DataSource = dtSP;
            cboSanPham.DisplayMember = "TenSP";
            cboSanPham.ValueMember = "MaSP";

            // Mặc định hiển thị giá nhập của sản phẩm đầu tiên
            if (dtSP.Rows.Count > 0)
            {
                txtDonGia.Text = dtSP.Rows[0]["GiaNhap"].ToString();
            }

            // Sự kiện khi chọn sản phẩm thì hiển thị giá nhập tương ứng
            cboSanPham.SelectedIndexChanged += (sender, e) =>
            {
                if (cboSanPham.SelectedIndex >= 0)
                {
                    DataRowView drv = (DataRowView)cboSanPham.SelectedItem;
                    txtDonGia.Text = drv["GiaNhap"].ToString();
                }
            };
        }

        private void TaoMaPhieuTuDong(string split)
        {
            // Tạo mã phiếu tự động theo định dạng: PN + Ngày + Số thứ tự
            // Ví dụ: PN20250503001 (phiếu nhập ngày 03/05/2025, số thứ tự 001)
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            string soThuTu = "001"; // Trong thực tế cần truy vấn CSDL để lấy số thứ tự tiếp theo

            txtMaPhieu.Text = split + ngay + soThuTu;
            txtMaPhieu.ReadOnly = true; // Không cho phép sửa mã phiếu
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (cboSanPham.SelectedIndex < 0)
            {
                errorProvider.SetError(cboSanPham, "Vui lòng chọn sản phẩm");
                return;
            }

            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                errorProvider.SetError(txtDonGia, "Vui lòng nhập đơn giá");
                return;
            }

            // Lấy thông tin sản phẩm đã chọn
            string maSP = cboSanPham.SelectedValue.ToString();
            string tenSP = cboSanPham.Text;

            // Kiểm tra sản phẩm đã tồn tại trong danh sách chưa
            foreach (DataRow row in dtChiTietPhieu.Rows)
            {
                if (row["MaSP"].ToString() == maSP)
                {
                    // Nếu sản phẩm đã tồn tại, cập nhật số lượng và thành tiền
                    int soLuongCu = Convert.ToInt32(row["SoLuong"]);
                    int soLuongMoi = soLuongCu + (int)numSoLuong.Value;
                    row["SoLuong"] = soLuongMoi;

                    decimal donGia = Convert.ToDecimal(txtDonGia.Text);
                    row["ThanhTien"] = soLuongMoi * donGia;

                    // Cập nhật lại DataGridView
                    dgvChiTietPhieu.Refresh();
                    TinhTongTien();
                    return;
                }
            }

            // Nếu sản phẩm chưa tồn tại, thêm mới vào DataTable
            DataRow newRow = dtChiTietPhieu.NewRow();
            newRow["MaSP"] = maSP;
            newRow["TenSP"] = tenSP;
            newRow["SoLuong"] = (int)numSoLuong.Value;

            decimal donGiaSP = Convert.ToDecimal(txtDonGia.Text);
            newRow["DonGia"] = donGiaSP;
            newRow["ThanhTien"] = (int)numSoLuong.Value * donGiaSP;

            dtChiTietPhieu.Rows.Add(newRow);

            // Cập nhật lại DataGridView
            TinhTongTien();

            // Reset các điều khiển về giá trị mặc định
            numSoLuong.Value = 1;
            errorProvider.Clear();
        }

        private void TinhTongTien()
        {
            // Tính tổng tiền của phiếu nhập
            decimal tongTien = 0;
            foreach (DataRow row in dtChiTietPhieu.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }

            // Hiển thị tổng tiền với định dạng số
            lblTongTien.Text = string.Format("{0:N0} VNĐ", tongTien);
        }

        private void dgvChiTietPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện khi click vào nút Xóa trong DataGridView
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvChiTietPhieu.Columns["colXoa"].Index)
            {
                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi phiếu nhập?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa dòng được chọn
                    dtChiTietPhieu.Rows.RemoveAt(e.RowIndex);
                    TinhTongTien();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin bắt buộc
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                errorProvider.SetError(txtMaPhieu, "Vui lòng nhập mã phiếu");
                return;
            }

            if (string.IsNullOrEmpty(txtNguoiNhap.Text))
            {
                errorProvider.SetError(txtNguoiNhap, "Vui lòng nhập người nhập hàng");
                return;
            }



            if (dtChiTietPhieu.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm vào phiếu nhập",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thu thập thông tin phiếu nhập
            string maPhieu = txtMaPhieu.Text;
            string nguoiNhap = txtNguoiNhap.Text;
            DateTime ngayNhap = dtpNgayNhap.Value;
            string maNCC = txtMaNCC.Text;
            //string ghiChu = txtGhiChu.Text;

            // Trong thực tế, lưu thông tin vào CSDL ở đây
            // ...

            // Hiển thị thông báo thành công
            MessageBox.Show("Lưu phiếu nhập hàng thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Làm mới form để nhập phiếu mới
            LamMoi();
        }

        private void LamMoi()
        {
            // Làm mới các điều khiển trên form
            dtChiTietPhieu.Clear();
            //txtGhiChu.Clear();
            TaoMaPhieuTuDong("PN");
            dtpNgayNhap.Value = DateTime.Now;
            numSoLuong.Value = 1;
            TinhTongTien();
            errorProvider.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận trước khi hủy
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu nhập hiện tại?",
                "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Làm mới form nếu người dùng xác nhận hủy
                LamMoi();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            PhieuNhapDAO phieuNhapDAO = new PhieuNhapDAO();

        }
    }
}