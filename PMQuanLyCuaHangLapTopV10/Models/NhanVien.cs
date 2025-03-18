using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    namespace PMQuanLyCuaHangLaptop.Models
    {
        public class NhanVien
        {
            public string MaNV { get; set; }             // INT NOT NULL
            public string HoTenNV { get; set; }       // NVARCHAR(100) NULL
            public string GioiTinh { get; set; }      // NVARCHAR(10) NULL
            public DateTime? NgaySinh { get; set; }   // DATE NULL (nullable DateTime)
            public string SoDienThoai { get; set; }   // VARCHAR(15) NULL
            public string Password { get; set; }      // VARCHAR(255) NULL
            public string QuyenHan { get; set; }      // NVARCHAR(50) NULL
            public string ChucDanh { get; set; }      // NVARCHAR(50) NULL
            public string DiaChiNV { get; set; }
            public NhanVien() { }

            public NhanVien(string maNV, string hoTenNV, string gioiTinh, DateTime? ngaySinh, string soDienThoai, string password, string quyenHan, string chucDanh, string diachiNV)
            {
                MaNV = maNV;
                HoTenNV = hoTenNV;
                GioiTinh = gioiTinh;
                NgaySinh = ngaySinh;
                SoDienThoai = soDienThoai;
                Password = password;
                QuyenHan = quyenHan;
                ChucDanh = chucDanh;
                DiaChiNV = diachiNV;
            }
        }
    }

}
