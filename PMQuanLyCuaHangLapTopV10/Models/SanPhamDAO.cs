using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class SanPhamDAO
    {
        private readonly string _connectionString = DBconnection.strConnection;

        // 📌 Lấy danh sách sản phẩm dưới dạng DataTable
        public DataTable GetList()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM SanPham";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(dt);
            }

            return dt;
        }
        public DataTable GetListSanPham()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT MaSP, TenSP FROM SanPham";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dt);
            }
            return dt;
        }
        // 📌 Thêm sản phẩm (trả về true nếu thành công)
        public bool InsertSP(string tenSP, int thoiGianBaoHanh, int soLuongSP, string moTaChiTiet, decimal donGiaSP, decimal giaNhapSP, int maNCC)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO SanPham (TenSP, ThoiGianBaoHanh, SoLuongSP, MoTaChiTiet, GiaNhap ,GiaBan, MaNCC) " +
                               "VALUES (@TenSP, @ThoiGianBaoHanh, @SoLuongSP, @MoTaChiTiet, @GiaNhap, @GiaBan, @MaNCC)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenSP", tenSP);
                command.Parameters.AddWithValue("@ThoiGianBaoHanh", thoiGianBaoHanh);
                command.Parameters.AddWithValue("@SoLuongSP", soLuongSP);
                command.Parameters.AddWithValue("@MoTaChiTiet", moTaChiTiet);
                command.Parameters.AddWithValue("@GiaBan", donGiaSP);
                command.Parameters.AddWithValue("@GiaNhap", giaNhapSP);
                command.Parameters.AddWithValue("@MaNCC", maNCC);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
        // Đặt trong lớp Data Access của bạn (ví dụ: ProductRepository)
        public List<string> GetProductSuggestionsByTenOrMa(string searchTerm)
        {
            List<string> suggestions = new List<string>();
            string connectionString = _connectionString; // Lấy chuỗi kết nối của bạn

            // Tìm kiếm trên cả TenSP HOẶC MaSP, chỉ SELECT TenSP để hiển thị gợi ý
            // Nếu muốn hiển thị cả MaSP và TenSP trong gợi ý, bạn có thể SELECT cả hai
            // và format lại chuỗi hiển thị trong code C#.
            string query = "SELECT TenSP FROM SanPham WHERE TenSP LIKE @searchTerm OR MaSP LIKE @searchTerm";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số với ký tự đại diện %
                    // Một tham số @searchTerm được dùng cho cả hai điều kiện OR
                    command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Đọc tên sản phẩm và thêm vào danh sách
                                suggestions.Add(reader["TenSP"].ToString());

                                // Nếu bạn SELECT cả MaSP và TenSP và muốn hiển thị combo:
                                // suggestions.Add($"{reader["MaSP"].ToString()} - {reader["TenSP"].ToString()}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi (ghi log)
                        System.Diagnostics.Debug.WriteLine($"Lỗi khi lấy gợi ý sản phẩm theo Tên/Mã: {ex.Message}");
                        return new List<string>(); // Trả về danh sách rỗng nếu có lỗi
                    }
                }
            }
            return suggestions;
        }
        public List<string> GetProductSuggestionsByTenOrMaV1(string searchTerm)
        {
            List<string> suggestions = new List<string>();

            if (string.IsNullOrWhiteSpace(searchTerm))
                return suggestions;

            string query = @"
        SELECT MaSP, TenSP 
        FROM SanPham 
        WHERE TenSP LIKE @searchTerm OR MaSP LIKE @searchTerm
    ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Dùng Add với SqlDbType để kiểm soát dữ liệu tốt hơn
                command.Parameters.Add("@searchTerm", SqlDbType.NVarChar).Value = "%" + searchTerm.Trim() + "%";

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maSP = reader["MaSP"]?.ToString();
                            string tenSP = reader["TenSP"]?.ToString();

                            // Format gợi ý như: "SP001 - Laptop Dell XYZ"
                            suggestions.Add($"{maSP} - {tenSP}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log chi tiết lỗi
                    Console.WriteLine("Lỗi khi lấy gợi ý sản phẩm: " + ex.Message);
                }
            }

            return suggestions;
        }

        public DataRow GetDataList(string valueSearch)
        {
            DataTable dt = new DataTable();
            // Kiểm tra giá trị tìm kiếm
            if (string.IsNullOrWhiteSpace(valueSearch))
            {
                return null; // Trả về null nếu chuỗi tìm kiếm rỗng
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"SELECT * FROM SanPham WHERE TenSP LIKE @searchValue OR MaSP LIKE @searchValue";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@searchValue", "%" + valueSearch + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dt);
            }

            // Trả về dòng đầu tiên nếu có kết quả, ngược lại trả về null
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        // 📌 Cập nhật sản phẩm
        public bool Update(string maSP, string tenSP, string loaiSP, int thoiGianBaoHanh, int soLuongSP, string moTaChiTiet, decimal donGiaSP,decimal giaNhap, int maNCC)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE SanPham SET TenSP = @TenSP,thoigianbaohanh = @ThoiGianBaoHanh, " +
                               "soluongSP = @SoLuongSP, MoTaChiTiet = @MoTaChiTiet, giaban = @DonGiaSP,giaNhap = @GiaNhap, MaNCC = @MaNCC " +
                               "WHERE MaSP = @MaSP";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSP", maSP);
                command.Parameters.AddWithValue("@TenSP", tenSP);
                command.Parameters.AddWithValue("@ThoiGianBaoHanh", thoiGianBaoHanh);
                command.Parameters.AddWithValue("@SoLuongSP", soLuongSP);
                command.Parameters.AddWithValue("@MoTaChiTiet", moTaChiTiet);
                command.Parameters.AddWithValue("@DonGiaSP", donGiaSP);
                command.Parameters.AddWithValue("@GiaNhap", giaNhap);

                command.Parameters.AddWithValue("@MaNCC", maNCC);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // 📌 Xóa sản phẩm
        public bool Delete(string maSP)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSP", maSP);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
        // Thêm phương thức này vào lớp SanPhamDAO
        public bool UpdateSoLuong(string maSP, int soLuongMua)
        {
            try
            {
                // Mở kết nối đến CSDL
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Câu lệnh SQL để cập nhật số lượng tồn kho
                    // Trừ đi số lượng đã bán
                    string query = "UPDATE SanPham SET soLuongSP = soLuongSP - @SoLuongMua WHERE MaSP = @MaSP";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@SoLuongMua", soLuongMua);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Trả về true nếu cập nhật thành công (có ít nhất 1 hàng bị ảnh hưởng)
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật số lượng sản phẩm: " + ex.Message);
                return false;
            }
        }
        // Cộng dồn số lượng tồn kho
        public bool UpdateSoLuongTonV1(string maSP, int soLuong, string type)
        {

            try
            {
                // Mở kết nối đến CSDL
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    // Câu lệnh SQL để cập nhật số lượng tồn kho
                    string query = string.Empty;
                    if (type == "cong") 
                    {
                       query = "UPDATE SanPham SET soLuongSP = soLuongSP + @SoLuong WHERE MaSP = @MaSP";

                    }
                    else
                    {
                        query = "UPDATE SanPham SET soLuongSP = soLuongSP - @SoLuong WHERE MaSP = @MaSP";
                    }
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    // Trả về true nếu cập nhật thành công (có ít nhất 1 hàng bị ảnh hưởng)
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật số lượng sản phẩm: " + ex.Message);
                return false;
            }
        }

        // Thêm phương thức này vào lớp SanPhamDAO
        public int GetSoLuongTonKho(string maSP)
        {
            int soLuongTon = 0;
            try
            {
                // Mở kết nối đến CSDL
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT soLuongSP FROM SanPham WHERE MaSP = @MaSP";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);

                    // Thực thi truy vấn và lấy giá trị
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        soLuongTon = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy số lượng tồn kho: " + ex.Message);
                // Có thể log error hoặc xử lý theo yêu cầu
            }

            return soLuongTon;
        }
        public bool CheckSoLuong(string maSP)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT SoLuongSP FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSP", maSP);
                connection.Open();
                int soLuong = (int)command.ExecuteScalar();
                return soLuong > 0;
            }
        }

        public List<SanPham> GetSanPhamsByKeyword(string keyword)
        {
            List<SanPham> list = new List<SanPham>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT MaSP, TenSP, GiaBan FROM SanPham WHERE TenSP LIKE @kw";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SanPham
                    {
                        MaSP = reader["MaSP"].ToString(),
                        TenSP = reader["TenSP"].ToString(),
                        GiaBan = Convert.ToDecimal(reader["GiaBan"])
                    });
                }
            }
            return list;
        }

    }
}
