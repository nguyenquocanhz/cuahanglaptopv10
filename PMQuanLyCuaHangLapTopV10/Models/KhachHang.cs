using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class KhachHang
    {
        public KhachHang() { }
        public string MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        // Constructor để khởi tạo các giá trị cho đối tượng KhachHang
        public KhachHang(string maKhachHang, string hoTen, string diaChi, string soDienThoai, string email)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
        }
    }
}

