using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string SoDienThoai { get; set; }

        public NhaCungCap() { }

        public NhaCungCap(string maNCC, string tenNCC, string soDienThoai)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SoDienThoai = soDienThoai;
        }
    }
}
