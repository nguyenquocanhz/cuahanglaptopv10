using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class infoPhieuNhapHang
    {
        public string MaPhieuNhap { get; set; } // Mã phiếu nhập tự tăng
        public string MaNCC { get; set; } // Mã nhà cung cấp
        public string MaNV { get; set; } // Mã nhân viên
        public DateTime NgayLap { get; set; } // Ngày lập phiếu nhập
        public decimal TongTienNhap { get; set; } // Tổng tiền
        public string MaPNHienThi { get; set; } // Mã phiếu nhập hiện tại
        public infoPhieuNhapHang(string maPhieuNhap, string maNCC, string maNV, DateTime ngayLap, decimal tongTien, string MaPNHienthi)
        {
            MaPhieuNhap = maPhieuNhap;
            MaNCC = maNCC;
            MaNV = maNV;
            NgayLap = ngayLap;
            TongTienNhap = tongTien;
            MaPNHienThi = maPhieuNhap;
        }
        public override string ToString()
        {
            return $"Mã phiếu nhập: {MaPhieuNhap}, Mã NCC: {MaNCC}, Mã NV: {MaNV}, Ngày lập: {NgayLap}, Tổng tiền: {TongTienNhap}";
        }
    }
}
