using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class HoaDonDAO
    {
        public HoaDonDAO() { }

        public int InsertHD(HoaDon hd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // CommandText: thêm OUTPUT để lấy ID vừa tạo
                    cmd.CommandText = @"INSERT INTO HoaDon (ngayTao, tongTienTT, ghiChu, MaKH, MaNV, MaHDHienThi)
                                VALUES (@ngayTao, @tongTienTT, @ghiChu, @MaKH, @MaNV, @MaHDHienThi);
                                SELECT SCOPE_IDENTITY();";

                    // Parameters
                    cmd.Parameters.AddWithValue("@ngayTao", hd.ngayTao.HasValue ? (object)hd.ngayTao.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@tongTienTT", hd.tongTienTT.HasValue ? (object)hd.tongTienTT.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ghiChu", string.IsNullOrEmpty(hd.ghiChu) ? (object)DBNull.Value : hd.ghiChu);
                    cmd.Parameters.AddWithValue("@MaKH", hd.MaKH.HasValue ? (object)hd.MaKH.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNV", hd.MaNV.HasValue ? (object)hd.MaNV.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaHDHienThi", string.IsNullOrEmpty(hd.MaHDHienThi) ? (object)DBNull.Value : hd.MaHDHienThi);

                    conn.Open();

                    // ExecuteScalar trả về giá trị từ câu lệnh SELECT SCOPE_IDENTITY()
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }

                    return -1; // Trả về -1 nếu không lấy được ID
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                // Có thể ghi log lỗi ở đây
                // Logger.Log("Lỗi khi thêm hóa đơn: " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Thống kê doanh thu theo ngày
        /// </summary>
        /// <param name="startDate">Ngày bắt đầu</param>
        /// <param name="endDate">Ngày kết thúc (tùy chọn)</param>
        /// <returns>DataTable chứa thông tin doanh thu theo ngày</returns>
        public DataTable ThongKeDoanhThuTheoNgay(DateTime startDate, DateTime? endDate = null)
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                {
                    string query = @"
                        SELECT 
                            CONVERT(date, hd.ngayTao) AS Ngay,
                            COUNT(DISTINCT hd.MaHD) AS SoHoaDon,
                            SUM(cthd.SoLuong) AS TongSoSanPham,
                            SUM(cthd.ThanhTien) AS DoanhThu
                        FROM 
                            HoaDon hd
                        INNER JOIN 
                            ChiTietHoaDon cthd ON hd.MaHD = cthd.MaHD
                        WHERE 
                            hd.ngayTao >= @StartDate " +
                            (endDate.HasValue ? "AND hd.ngayTao <= @EndDate " : "") +
                        @"GROUP BY 
                            CONVERT(date, hd.ngayTao)
                        ORDER BY 
                            Ngay";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);

                        if (endDate.HasValue)
                        {
                            // Đặt thời gian kết thúc là cuối ngày để bao gồm cả ngày endDate
                            DateTime endOfDay = endDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                            cmd.Parameters.AddWithValue("@EndDate", endOfDay);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        conn.Open();
                        adapter.Fill(result);
                    }
                }

                // Thêm cột phần trăm đóng góp nếu có nhiều hơn 1 ngày
                if (result.Rows.Count > 1)
                {
                    // Tính tổng doanh thu trong khoảng thời gian
                    decimal totalRevenue = 0;
                    foreach (DataRow row in result.Rows)
                    {
                        totalRevenue += Convert.ToDecimal(row["DoanhThu"]);
                    }

                    // Thêm cột phần trăm
                    result.Columns.Add("PhanTram", typeof(string));

                    // Tính phần trăm cho mỗi ngày
                    foreach (DataRow row in result.Rows)
                    {
                        decimal dailyRevenue = Convert.ToDecimal(row["DoanhThu"]);
                        decimal percentage = (dailyRevenue / totalRevenue) * 100;
                        row["PhanTram"] = Math.Round(percentage, 2) + "%";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thống kê doanh thu theo ngày: " + ex.Message);
                // Tạo DataTable rỗng với các cột cần thiết để không làm hỏng UI
                result = CreateEmptyRevenueTable();
            }

            return result;
        }

        /// <summary>
        /// Tạo DataTable rỗng với cấu trúc giống với kết quả thống kê
        /// </summary>
        /// <returns>DataTable rỗng</returns>
        private DataTable CreateEmptyRevenueTable()
        {
            DataTable emptyTable = new DataTable();
            emptyTable.Columns.Add("Ngay", typeof(DateTime));
            emptyTable.Columns.Add("SoHoaDon", typeof(int));
            emptyTable.Columns.Add("TongSoSanPham", typeof(int));
            emptyTable.Columns.Add("DoanhThu", typeof(decimal));
            emptyTable.Columns.Add("PhanTram", typeof(string));
            return emptyTable;
        }
        // Lợi nhuận theo ngày

        public int DoanhThuHomNay()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT CONVERT(INT, SUM(tongTienTT))
                        FROM HoaDon
                        WHERE CONVERT(DATE, ngayTao) = CONVERT(DATE, GETDATE());
                    ";
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính doanh thu hôm nay: " + ex.Message);
                return 0;
            }
        }

        public int DoanhThuThangNay()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Sửa câu lệnh SQL để tính tổng doanh thu trong tháng hiện tại
                    cmd.CommandText = @"
                SELECT CONVERT(INT, SUM(tongTienTT))
                FROM HoaDon
                WHERE YEAR(ngayTao) = YEAR(GETDATE()) 
                AND MONTH(ngayTao) = MONTH(GETDATE());
            ";

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính doanh thu tháng này: " + ex.Message);
                return 0;
            }
        }
        /// <summary>
        /// Thống kê doanh thu theo ngày cho ngày hiện tại
        /// </summary>
        /// <returns>DataTable chứa thông tin doanh thu cho ngày hiện tại</returns>
        public DataTable ThongKeDoanhThuNgayHienTai()
        {
            return ThongKeDoanhThuTheoNgay(DateTime.Today);
        }

        /// <summary>
        /// Thống kê doanh thu theo ngày cho 7 ngày gần nhất
        /// </summary>
        /// <returns>DataTable chứa thông tin doanh thu 7 ngày gần nhất</returns>
        public DataTable ThongKeDoanhThu7NgayGanNhat()
        {
            return ThongKeDoanhThuTheoNgay(DateTime.Today.AddDays(-6), DateTime.Today);
        }

        /// <summary>
        /// Thống kê doanh thu theo ngày cho tháng hiện tại
        /// </summary>
        /// <returns>DataTable chứa thông tin doanh thu tháng hiện tại</returns>
        public DataTable ThongKeDoanhThuThangHienTai()
        {
            DateTime firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            return ThongKeDoanhThuTheoNgay(firstDayOfMonth, DateTime.Today);
        }
        public DataTable ThongKeDoanhThu(DateTime startDate, DateTime? endDate = null)
        {
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                {
                    string query = @"
                SELECT 
                    CONVERT(date, hd.ngayTao) AS Ngay,
                    SUM(cthd.ThanhTien) AS DoanhThu
                FROM 
                    HoaDon hd
                INNER JOIN 
                    ChiTietHoaDon cthd ON hd.MaHD = cthd.MaHD
                WHERE 
                    hd.ngayTao >= @StartDate " +
                            (endDate.HasValue ? "AND hd.ngayTao <= @EndDate " : "") +
                    @"GROUP BY 
                CONVERT(date, hd.ngayTao)
            ORDER BY 
                Ngay";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", startDate);

                        if (endDate.HasValue)
                        {
                            // Đặt thời gian kết thúc là cuối ngày để bao gồm cả ngày endDate
                            DateTime endOfDay = endDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                            cmd.Parameters.AddWithValue("@EndDate", endOfDay);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        conn.Open();
                        adapter.Fill(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thống kê doanh thu theo ngày: " + ex.Message);
                result = CreateEmptyRevenueTable(); // Tạo bảng rỗng trong trường hợp có lỗi
            }

            return result;
        }
        public int LoiNhuanNgayHienTai()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT 
                    ISNULL(SUM(hd.tongTienTT), 0) - ISNULL(SUM(ct.SoLuong * sp.GiaNhap), 0) AS LoiNhuan
                FROM 
                    HoaDon hd
                    INNER JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                    INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                WHERE 
                    CAST(hd.ngayTao AS DATE) = CAST(GETDATE() AS DATE);
            ";

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(Math.Floor(Convert.ToDecimal(result))) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính lợi nhuận hôm nay: " + ex.Message);
                return 0;
            }
        }

        public int LoiNhuanTheoNgay(DateTime ngay)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT 
                    ISNULL(SUM(hd.tongTienTT), 0) - ISNULL(SUM(ct.SoLuong * sp.GiaNhap), 0) AS LoiNhuan
                FROM 
                    HoaDon hd
                    INNER JOIN ChiTietHoaDon ct ON hd.MaHD = ct.MaHD
                    INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                WHERE 
                    CAST(hd.ngayTao AS DATE) = @ngay;
            ";

                    cmd.Parameters.AddWithValue("@ngay", ngay.Date);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(Math.Floor(Convert.ToDecimal(result))) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính lợi nhuận theo ngày: " + ex.Message);
                return 0;
            }
        }

        // get datatable hoadon
        public DataTable GetDTHoaDon()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM HoaDon";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
                return null;
            }
        }
        // 
        public DataTable GetDTHoaDonByMaNV(string manv)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM HoaDon WHERE MaNV = @manv";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@manv", manv);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
                return null;
            }
        }
        public int GetCountHD()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM HoaDon";
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đếm số lượng hóa đơn: " + ex.Message);
                return 0;
            }
        }
        // lọc đơn hàng theo ngày 
        public DataTable GetHoaDonByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM HoaDon WHERE ngayTao BETWEEN @startDate AND @endDate";
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn theo ngày: " + ex.Message);
                return null;
            }
        }
        public DataTable TimKiemHoaDonTheoDateVaMaNV(DateTime startDate, DateTime endDate, string MaNV)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM HoaDon WHERE ngayTao BETWEEN @startDate AND @endDate";
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    cmd.CommandText += " AND MaNV = @MaNV";
                    cmd.Parameters.AddWithValue("@MaNV", MaNV);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn theo ngày: " + ex.Message);
                return null;
            }
        }
        public DataTable GetChiTietDoanhSo(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ViewLoiNhuan WHERE Ngay BETWEEN @startDate AND @endDate;";
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn theo ngày: " + ex.Message);
                return null;
            }
        }
        public int GetLoiNhuanHomNay()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT SUM(LoiNhuan) 
                FROM ViewLoiNhuan 
                WHERE CONVERT(date, Ngay) = CONVERT(date, GETDATE());";

                    conn.Open();
                    object result = cmd.ExecuteScalar(); // lấy 1 giá trị duy nhất

                    if (result != DBNull.Value && result != null)
                        return Convert.ToInt32(result);
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy lợi nhuận hôm nay: " + ex.Message);
                return 0;
            }
        }
        public int GetLoiNhuanThangNay()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT SUM(LoiNhuan)
                FROM ViewLoiNhuan
                WHERE Ngay >= DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0)
                  AND Ngay <  DATEADD(month, DATEDIFF(month, 0, GETDATE()) + 1, 0);
            ";

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                        return Convert.ToInt32(result);
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy lợi nhuận tháng này: " + ex.Message);
                return 0;
            }
        }

        // tổng doanh thu bình quân trong tháng
        public int GetDoanhThuBinhQuanThang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT AVG(tongTienTT) FROM HoaDon WHERE MONTH(ngayTao) = MONTH(GETDATE())";
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính doanh thu bình quân tháng: " + ex.Message);
                return 0;
            }
        }

        // lợi nhuận bình quân trong tháng
        public long GetLoiNhuanBinhQuanThang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT AVG(tongTienTT) FROM HoaDon WHERE MONTH(ngayTao) = MONTH(GETDATE())";
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null && result != DBNull.Value ? Convert.ToInt64(result) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính lợi nhuận bình quân tháng: " + ex.Message);
                return 0;
            }
        }
        public HoaDon GetHoaDonByMaHD(string maHD)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM HoaDon WHERE MaHD = @maHD";
                        cmd.Parameters.AddWithValue("@maHD", maHD);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                HoaDon hoaDon = new HoaDon();
                                hoaDon.MaHD = Convert.ToInt32(reader["MaHD"]);
                                hoaDon.MaHDHienThi = reader["MaHDHienThi"].ToString();

                                if (!reader.IsDBNull(reader.GetOrdinal("ngayTao")))
                                    hoaDon.ngayTao = Convert.ToDateTime(reader["ngayTao"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("tongTienTT")))
                                    hoaDon.tongTienTT = Convert.ToDecimal(reader["tongTienTT"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("ghiChu")))
                                    hoaDon.ghiChu = reader["ghiChu"].ToString();

                                if (!reader.IsDBNull(reader.GetOrdinal("MaKH")))
                                    hoaDon.MaKH = Convert.ToInt32(reader["MaKH"]);

                                if (!reader.IsDBNull(reader.GetOrdinal("MaNV")))
                                    hoaDon.MaNV = Convert.ToInt32(reader["MaNV"]);

                                return hoaDon;
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin hóa đơn: " + ex.Message);
                return null;
            }
        }
        // tìm kiếm hóa đơn theo mã 
        public DataTable TimKiemHoaDon(string maHD)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM HoaDon WHERE MaHDHienThi LIKE @maHD";
                    cmd.Parameters.AddWithValue("@maHD", "%" + maHD + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
                return null;
            }
        }
        public DataTable TimKiemHoaDonByMaHDAnvMaNV(string maHD, string maNV)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM HoaDon WHERE MaHDHienThi LIKE @maHD ";
                    cmd.CommandText += " AND MaNV = @maNV";
                    cmd.Parameters.AddWithValue("@maHD", "%" + maHD + "%");
                    cmd.Parameters.AddWithValue("@maNV", maNV);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
                return null;
            }
        }
        // tìm kiếm hóa đơn theo date
        public DataTable TimKiemHoaDonTheoDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM HoaDon WHERE ngayTao BETWEEN @startDate AND @endDate";
                    cmd.Parameters.AddWithValue("@startDate", startDate);
                    cmd.Parameters.AddWithValue("@endDate", endDate);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm hóa đơn theo ngày: " + ex.Message);
                return null;
            }
        }
    }
}
