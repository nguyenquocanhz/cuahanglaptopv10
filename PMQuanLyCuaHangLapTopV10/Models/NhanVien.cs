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
            public string MaNV { get; set; }
            public string TenNV { get; set; }
            public string DiaChiNV { get; set; }
            public string SdtNV { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string MaQuyenHan { get; set; }

            public NhanVien() { }

            public NhanVien(string maNV, string tenNV, string diaChiNV, string sdtNV, string username, string password, string maQuyenHan)
            {
                MaNV = maNV;
                TenNV = tenNV;
                DiaChiNV = diaChiNV;
                SdtNV = sdtNV;
                Username = username;
                Password = password;
                MaQuyenHan = maQuyenHan;
            }

        }
    }

}
