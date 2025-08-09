using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System.Windows.Forms;
using System.IO;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class KhuyenMaiDAO
    {
        private readonly string _connectionString = DBconnection.strConnection;

        public DataTable GetListKhuyenMai()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM khuyenMaiSP";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dt);
            }
            return dt;
        }
        public KhuyenMai GetKhuyenMaiById(int maKM)
        {
            KhuyenMai km = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT MaKM, TenKM, GiaTriKM, ngayBatDau, ngayKetThuc, trangThaiCT, ghiChu " +
                              "FROM khuyenMaiSP WHERE MaKM = @MaKM";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKM", maKM);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        km = new KhuyenMai
                        {
                            MaKM = reader.GetString(0),
                            TenKm = reader.GetString(1),
                            GiaTriKM = reader.GetDecimal(2),
                            ngayBatDau = reader.GetDateTime(3),
                            ngayKetThuc = reader.GetDateTime(4),
                            statuskm = reader.GetString(5),
                            moTa = reader.IsDBNull(6) ? null : reader.GetString(6),
                            giftcode = reader.GetString(7),
                            LoaiKM = reader.GetString(8)
                        };
                    }
                }
            }
            return km;
        }
        public KhuyenMai GetKhuyenMaiByGiftcode(string giftcode)
        {
            KhuyenMai km = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM khuyenMaiSP WHERE giftcode = @value";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@value", giftcode);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        km = new KhuyenMai
                        {
                            MaKM = reader.GetInt32(0).ToString(),
                            TenKm = reader.GetString(1),
                            GiaTriKM = reader.GetDecimal(2),
                            ngayBatDau = reader.GetDateTime(3),
                            ngayKetThuc = reader.GetDateTime(4),
                            statuskm = reader.GetString(5),
                            moTa = reader.IsDBNull(6) ? null : reader.GetString(6),
                            giftcode = reader.GetString(8),
                            LoaiKM = reader.GetString(9),
                        };
                        // file save to txt
                        string filePath = "giftcode.txt";
                        using (StreamWriter writer = new StreamWriter(filePath, true))
                        {
                            writer.WriteLine(giftcode);
                            writer.WriteLine("Khuyến mãi: " + km.TenKm);
                            writer.WriteLine("Giá trị: " + km.GiaTriKM);
                            writer.WriteLine("Ngày bắt đầu: " + km.ngayBatDau);
                            writer.WriteLine("Ngày kết thúc: " + km.ngayKetThuc);
                            writer.WriteLine("Trạng thái: " + km.statuskm);
                            writer.WriteLine("Ghi chú: " + km.moTa);
                            writer.WriteLine("Loại khuyến mãi: " + km.LoaiKM);
                            writer.WriteLine("------------------------------");
                            writer.Close();
                            
                        }

                    }
                }
            }
            return km;
        }
        public bool IsGiftcodeExists(string giftcode)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Câu lệnh kiểm tra sự tồn tại, chỉ cần đếm số dòng
                string query = "SELECT COUNT(1) FROM khuyenMaiSP WHERE giftcode = @giftcode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@giftcode", giftcode);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar(); // ExecuteScalar trả về giá trị đầu tiên của hàng đầu tiên

                        return count > 0; // Trả về true nếu có ít nhất 1 dòng (giftcode tồn tại)
                    }
                    catch (Exception ex)
                    {
                        // Xử lý hoặc ghi log lỗi nếu cần
                        Console.WriteLine($"Error checking if giftcode exists: {ex.Message}");
                        // Tùy chọn: ném lại lỗi hoặc trả về false/true tùy logic xử lý lỗi của bạn
                        // throw;
                        return false; // Giả định không tồn tại nếu có lỗi
                    }
                }
            }
        }
        public DataTable SearchKhuyenMai(string keyword)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT MaKM, TenKM, GiaTriKM, ngayBatDau AS NgayBatDau, " +
                              "ngayKetThuc AS NgayKetThuc, trangthaiCT , giftcode , LoaiKM , ghiChu FROM KhuyenMaiSP " +
                              "WHERE TenKM LIKE @keyword OR giftcode LIKE @keyword OR TrangThaiCT LIKE @keyword";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public bool Insert(KhuyenMai kh)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO KhuyenMaiSP(TenKM, GiaTriKM, ngayBatDau, ngayKetThuc, trangThaiCT, ghiChu, giftcode , LoaiKM) VALUES (@TenKM, @GiaTriKM, @ngayBatDau, @ngayKetThuc, @TrangThaiCT, @ghiChu, @giftcode , @loaikm)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@TenKM", kh.TenKm);
                    command.Parameters.AddWithValue("@GiaTriKM", kh.GiaTriKM);
                    command.Parameters.AddWithValue("@ngayBatDau", kh.ngayBatDau);
                    command.Parameters.AddWithValue("@ngayKetThuc", kh.ngayKetThuc);
                    command.Parameters.AddWithValue("@TrangThaiCT", kh.statuskm);
                    command.Parameters.AddWithValue("@ghiChu", kh.moTa != null ? kh.moTa : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@giftcode", kh.giftcode);
                    command.Parameters.AddWithValue("@loaikm", kh.LoaiKM);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        // *** Thay thế hoặc bổ sung cách xử lý lỗi ở đây ***
                        // Option 1: Ném lại lỗi để form bắt và hiển thị chi tiết
                        // throw ex;

                        // Option 2: Hiển thị lỗi chi tiết ngay tại đây (chỉ dùng khi debug)
                        MessageBox.Show($"Lỗi khi thêm khuyến mãi vào DB:\n{ex.Message}\n{(ex.InnerException != null ? "Inner Exception: " + ex.InnerException.Message : "")}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Option 3: Log lỗi vào file hoặc hệ thống logging

                        Console.WriteLine($"Error inserting data: {ex.Message}"); // Giữ lại để log vào console nếu cần
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                        }
                        return false; // Trả về false để form biết thất bại
                    }
                }
            }
        }
        // Hàm xóa khuyến mãi theo ID
        public bool DeleteById(int maKM)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM KhuyenMaiSP WHERE MaKM = @MaKM";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số để tránh SQL injection
                    command.Parameters.AddWithValue("@MaKM", maKM);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        // Xử lý hoặc ghi log lỗi nếu cần
                        Console.WriteLine($"Lỗi khi xóa dữ liệu: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        // Hàm cập nhật thông tin khuyến mãi theo MaKM
        public bool Update(int maKM, KhuyenMai infoKM)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE KhuyenMaiSP SET TenKM = @TenKM, GiaTriKM = @GiaTriKM, " +
                              "ngayBatDau = @ngayBatDau, ngayKetThuc = @ngayKetThuc, " +
                              "TrangThaiCT = @TrangThaiCT, ghiChu = @ghiChu, giftcode = @giftcode, LoaiKM = @loaikm " +
                              "WHERE MaKM = @MaKM";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số để tránh SQL injection
                    command.Parameters.AddWithValue("@MaKM", maKM);
                    command.Parameters.AddWithValue("@TenKM", infoKM.TenKm);
                    command.Parameters.AddWithValue("@GiaTriKM", infoKM.GiaTriKM);
                    command.Parameters.AddWithValue("@ngayBatDau", infoKM.ngayBatDau);
                    command.Parameters.AddWithValue("@ngayKetThuc", infoKM.ngayKetThuc);
                    command.Parameters.AddWithValue("@TrangThaiCT", infoKM.statuskm);
                    command.Parameters.AddWithValue("@ghiChu", infoKM.moTa != null ? infoKM.moTa : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@giftcode", infoKM.giftcode);
                    command.Parameters.AddWithValue("@loaikm", infoKM.LoaiKM);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        // Xử lý hoặc ghi log lỗi nếu cần
                        Console.WriteLine($"Lỗi khi cập nhật dữ liệu: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
