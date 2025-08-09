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
    public partial class frmChiTietNhapHang : Form
    {
        public string maPhieuNhap;
        public frmChiTietNhapHang()
        {
            InitializeComponent();
        }
        public frmChiTietNhapHang(string maPN)
        {
            InitializeComponent();
            this.maPhieuNhap = maPN;
        }

        private void frmChiTietNhapHang_Load(object sender, EventArgs e)
        {
            LoadThongTinPhieuNhap();
            LoadDanhSachSanPham();

        }

        public void InitDGV()
        {
            dgvSanPhamDaMua.Columns.Clear();
            dgvSanPhamDaMua.Columns.Add("STT", "STT");
            dgvSanPhamDaMua.Columns.Add("MaSP", "Mã Sản Phẩm");
            dgvSanPhamDaMua.Columns.Add("TenSP", "Tên Sản Phẩm");
            dgvSanPhamDaMua.Columns.Add("SoLuongNhap", "Số Lượng");
            dgvSanPhamDaMua.Columns.Add("DonGiaNhap", "Đơn Giá");
            dgvSanPhamDaMua.Columns.Add("ThanhTien", "Thành Tiền");
            // Định dạng các cột tiền tệ
            dgvSanPhamDaMua.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
            dgvSanPhamDaMua.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            // Căn phải các cột số
            dgvSanPhamDaMua.Columns["SoLuongNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSanPhamDaMua.Columns["DonGiaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSanPhamDaMua.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadThongTinPhieuNhap()
        {
            PhieuNhapDAO phieuNhapDAO = new PhieuNhapDAO();
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            NhaCungCapDAO nhaCungCapDAO = new NhaCungCapDAO();

            // Lấy thông tin phiếu nhập theo mã
            infoPhieuNhapHang phieuNhap = phieuNhapDAO.GetPhieuNhapByMaPN(maPhieuNhap);
            if (phieuNhap == null)
            {
                MessageBox.Show("Không tìm thấy thông tin phiếu nhập.");
                return;
            }

            // Lấy thông tin nhân viên và nhà cung cấp
            NhanVien nhanVien = nhanVienDAO.GetNhanVienById(phieuNhap.MaNV.ToString());
            NhaCungCap nhaCungCap = nhaCungCapDAO.GetNhaCungCapByIdv2(phieuNhap.MaNCC.ToString());

            // Hiển thị thông tin lên các textbox
            txtMaPN.Text = phieuNhap.MaPhieuNhap;
            txtNhanVien.Text = nhanVien?.HoTenNV ?? "Không rõ";
            txtKhachHang.Text = nhaCungCap?.TenNCC ?? "Không rõ";
            txtNgayLap.Text = phieuNhap.NgayLap.ToString("dd/MM/yyyy HH:mm:ss");

            // Load danh sách sản phẩm đã nhập
        }

        private void LoadDanhSachSanPham()
        {
            ChiTietPNDAO chiTietPNDAO = new ChiTietPNDAO();
            DataTable danhSachSanPham = chiTietPNDAO.LayDanhSachSanPham(maPhieuNhap);

            dgvSanPhamDaMua.Rows.Clear();

            decimal tongTien = 0;
            int stt = 1;

            foreach (DataRow row in danhSachSanPham.Rows)
            {
                string maSP = row["MaSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuongNhap"]);
                decimal donGia = Convert.ToDecimal(row["DonGiaNhap"]);
                decimal thanhTien = Convert.ToDecimal(row["ThanhTien"]);

                dgvSanPhamDaMua.Rows.Add(stt, maSP, tenSP, soLuong, donGia, thanhTien);
                tongTien += thanhTien;
                stt++;
            }

            txtTongTien.Text = string.Format("{0:N0} VNĐ", tongTien);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // TODO: Xử lý in hóa đơn
            MessageBox.Show("Chức năng in hóa đơn đang được phát triển.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
