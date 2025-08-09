using System;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class KhuyenMai
    {
        public string MaKM { get; set; }
        public string TenKm { get; set; }

        // DECIMAL với giá trị lớn hơn, vẫn dùng decimal trong C#
        public decimal GiaTriKM { get; set; }

        public DateTime ngayBatDau { get; set; }
        public DateTime ngayKetThuc { get; set; }

        public string statuskm { get; set; }
        public string moTa { get; set; }

        public string giftcode { get; set; }

        // ➕ Thêm mới loại khuyến mãi: 'phantram' hoặc 'trigia'
        public string LoaiKM { get; set; }

        public KhuyenMai() { }

        public KhuyenMai(string maKM, string tenKm, decimal giaTriKM, DateTime ngayBatDau, DateTime ngayKetThuc, string statuskm, string moTa, string giftcode, string loaiKM)
        {
            MaKM = maKM;
            TenKm = tenKm;
            GiaTriKM = giaTriKM;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.statuskm = statuskm;
            this.moTa = moTa;
            this.giftcode = giftcode;
            this.LoaiKM = loaiKM;
        }
    }
}
