using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChiKH { get; set; }

        public KhachHang() { }

        public KhachHang(string maKhachHang, string hoTen, string gioiTinh, string soDienThoai, string diaChiKH)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            SoDienThoai = soDienThoai;
            DiaChiKH = diaChiKH;
        }
    }
}
