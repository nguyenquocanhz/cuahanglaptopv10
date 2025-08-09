using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.DatabaseHelpers
{
    public static class SessionManager
    {
        public static bool IsLoggedIn { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static string MaNV {  get; set; }
        public static string sodt { get; set; }

        public static string ChucDanh { get; set; }
        public static string getMaNV()
        {
            return MaNV;
        }
    }
}
