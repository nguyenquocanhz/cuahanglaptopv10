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
            public string gioiTinh {  get; set; }
            public string DiaChiNV { get; set; }
            public string SdtNV { get; set; }
            public string UsernameNV { get; set; }
            public string PasswordNV { get; set; }
            public string quyenHan { get; set; }

            public NhanVien() { }

            public NhanVien(string maNV, string tenNV, string diaChiNV, string sdtNV,string password, string _quyenHan)
            {
                MaNV = maNV;
                TenNV = tenNV;
                DiaChiNV = diaChiNV;
                SdtNV = sdtNV;
                UsernameNV = sdtNV;
                PasswordNV = password;
                quyenHan = _quyenHan;
            }

        }
    }

}
