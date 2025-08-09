using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class ChiTietHD
    {
        public int MaHD { get; set; } // Mã hóa đơn 
        public int MaSP { get; set; } // Mã sản phẩm
        public int SoLuong { get; set; } // Số lượng sản phẩm
        public decimal DonGia { get; set; } // Đơn giá sản phẩm 
        public decimal ThanhTien { get; set; } // Thành tiền (Số lượng * Đơn giá)

        public ChiTietHD(int maHD, int maSP, int soLuong, decimal donGia, decimal thanhTien)
        {
            MaHD = maHD;
            MaSP = maSP;
            SoLuong = soLuong;
            DonGia = donGia;
            ThanhTien = thanhTien;
        }

        public override string ToString()
        {
            return $"Mã HD: {MaHD}, Mã SP: {MaSP}, Số lượng: {SoLuong}, Đơn giá: {DonGia}, Thành tiền: {ThanhTien}";
        }
    }
}
