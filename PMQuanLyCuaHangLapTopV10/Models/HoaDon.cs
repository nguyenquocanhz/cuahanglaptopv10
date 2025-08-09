using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Đảm bảo namespace này khớp với cấu trúc project của bạn
namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class HoaDon
    {
        // MaHD INT IDENTITY (1, 1) NOT NULL
        public int MaHD { get; set; }

        // ngayTao DATE NULL
        public DateTime? ngayTao { get; set; } // Sử dụng DateTime? cho cột có thể NULL

        // tongTienTT DECIMAL (18, 2) NULL
        public decimal? tongTienTT { get; set; } // Sử dụng decimal? cho cột có thể NULL

        // ghiChu NVARCHAR (255) NULL
        public string ghiChu { get; set; } // string mặc định là nullable trong C#

        // MaKH INT NULL
        public int? MaKH { get; set; } // Sử dụng int? cho cột có thể NULL

        // MaNV INT NULL
        public int? MaNV { get; set; } // Sử dụng int? cho cột có thể NULL

        // MaHDHienThi VARCHAR (50) NULL
        public string MaHDHienThi { get; set; } // string mặc định là nullable trong C#

        public override string ToString()
        {
            return $"Mã HD hiển thị: {MaHDHienThi}\n" +
                   $"Ngày tạo: {ngayTao?.ToString("dd/MM/yyyy HH:mm:ss")}\n" +
                   $"Tổng tiền thanh toán: {tongTienTT?.ToString("N0")} VND\n" +
                   $"Mã khách hàng: {MaKH}\n" +
                   $"Mã nhân viên: {MaNV}\n" +
                   $"Ghi chú: {ghiChu}";
        }
    }

}