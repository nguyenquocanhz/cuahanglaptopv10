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
    public partial class frmChiTietHoaDon: Form
    {
        public string maHoaDon;
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }
        public frmChiTietHoaDon(string maHD)
        {
            InitializeComponent();
            this.maHoaDon = maHD;
            LoadThongTinHoaDon();
        }
        private void LoadThongTinHoaDon()
        {
            // TODO: Kết nối CSDL để lấy thông tin hóa đơn
            // Ví dụ code giả:
            HoaDonDAO hoaDonDAO = new HoaDonDAO();  
            HoaDon hoaDon = hoaDonDAO.GetHoaDonByMaHD(maHoaDon);
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            KhachHangDAO khachHangDAO = new KhachHangDAO();
            KhachHang khachHang = khachHangDAO.GetKhachHangById(hoaDon.MaKH.ToString());
            // txtMaHoaDon.Text = hoaDon.MaHoaDon;
            // txtNhanVien.Text = hoaDon.TenNhanVien;
            // txtKhachHang.Text = hoaDon.TenKhachHang;
            // txtNgayLap.Text = hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm:ss");
            NhanVien nhanVien = nhanVienDAO.GetNhanVienById(hoaDon.MaNV.ToString());
            // Code giả cho demo
            txtMaHoaDon.Text = maHoaDon;
            txtNhanVien.Text = nhanVien.HoTenNV;
            txtKhachHang.Text = khachHang.HoTen;
            txtNgayLap.Text = hoaDon.ngayTao.ToString();
            LoadDanhSachSanPham();
        }

        private void LoadDanhSachSanPham()
        {
            // TODO: Kết nối CSDL để lấy danh sách sản phẩm trong hóa đơn
            // Ví dụ:
            ChiTiethdDAO chiTietHoaDonDAO = new ChiTiethdDAO();
            DataTable danhSachSanPham = chiTietHoaDonDAO.LayDanhSachSanPham(maHoaDon);

            // Code giả cho demo
            dgvSanPhamDaMua.Rows.Clear();

            // Tính tổng tiền
            int tongTien = 0;
            int i = 1;
            foreach (DataRow row in danhSachSanPham.Rows)
            {
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                decimal thanhTien = soLuong * donGia;
                dgvSanPhamDaMua.Rows.Add(i, row["MaSP"], row["TenSP"], soLuong, Convert.ToInt32(donGia), thanhTien);
                tongTien += (int)thanhTien;
                i++;
            }
            txtTongTien.Text = string.Format("{0:N0} VNĐ", tongTien);
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // TODO: Xử lý in hóa đơn
            MessageBox.Show("Chức năng in hóa đơn đang được phát triển.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
