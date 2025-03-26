using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTenNV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Password { get; set; }
        public string QuyenHan { get; set; }
        public string ChucDanh { get; set; }
        public string DiaChiNV { get; set; }

        public string CCCD { get; set; }
        public NhanVien() { }

        public NhanVien(string maNV, string hoTenNV, string gioiTinh, DateTime? ngaySinh, string soDienThoai, string password, string quyenHan, string chucDanh, string diaChiNV, string maCCCD)
        {
            MaNV = maNV;
            HoTenNV = hoTenNV;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            SoDienThoai = soDienThoai;
            Password = password;
            QuyenHan = quyenHan;
            ChucDanh = chucDanh;
            DiaChiNV = diaChiNV;
            CCCD = maCCCD;
        }
    }
}
