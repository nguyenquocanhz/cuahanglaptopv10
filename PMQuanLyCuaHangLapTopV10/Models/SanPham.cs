using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public int SoLuongSP { get; set; }
        public string MoTaChiTiet { get; set; }

        public decimal GiaBan { get; set; }
        public decimal GiaNhap { get; set; }
        public int MaNCC { get; set; }

        
        public SanPham() { }

        public SanPham(string maSP, string tenSP, string loaiSP, int thoiGianBaoHanh, int soLuongSP, string moTaChiTiet, decimal donGia,decimal giaNhap , int maNCC)
        {
            MaSP = maSP;
            TenSP = tenSP;
            ThoiGianBaoHanh = thoiGianBaoHanh;
            SoLuongSP = soLuongSP;
            MoTaChiTiet = moTaChiTiet;
            GiaBan = donGia;
            GiaNhap = giaNhap;
            MaNCC = maNCC;
        }
    }
}
