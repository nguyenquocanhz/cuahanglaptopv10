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
        public string LoaiSP { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public int SoLuongSP { get; set; }
        public string MoTaChiTiet { get; set; }

        public decimal DonGia { get; set; }
        public int MaNCC { get; set; }

        
        public SanPham() { }

        public SanPham(string maSP, string tenSP, string loaiSP, int thoiGianBaoHanh, int soLuongSP, string moTaChiTiet, decimal donGia, int maNCC)
        {
            MaSP = maSP;
            TenSP = tenSP;
            LoaiSP = loaiSP;
            ThoiGianBaoHanh = thoiGianBaoHanh;
            SoLuongSP = soLuongSP;
            MoTaChiTiet = moTaChiTiet;
            DonGia = donGia;
            MaNCC = maNCC;
        }
    }
}
