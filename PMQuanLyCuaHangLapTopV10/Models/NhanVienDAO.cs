using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System.Linq;


namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class NhanVienDAO
    {

        public NhanVienDAO()
        {
            // Lấy chuỗi kết nối từ file cấu hình
        }
        public NhanVien DangNhap(string soDienThoai, string password)
        {
            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "SELECT * FROM NhanVien " +
                               "WHERE soDienThoai = @SoDienThoai AND password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    NhanVien nv = new NhanVien
                    {
                        HoTenNV = reader["hoTenNV"].ToString(),
                        SoDienThoai = reader["soDienThoai"].ToString(),
                        Password = reader["password"].ToString(),
                        QuyenHan = reader["quyenHan"].ToString(),
                        ChucDanh = reader["chucDanh"].ToString()
                    };
                    reader.Close();
                    return nv; // Đăng nhập thành công
                }

                reader.Close();
                return null; // Đăng nhập thất bại
            }
        }
        public bool CheckPhoneNumberExists(string soDienThoai)
        {
            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "SELECT COUNT(*) FROM NhanVien WHERE soDienThoai = @SoDienThoai";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        public bool CheckPasswordCorrect(string soDienThoai, string password)
        {
            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "SELECT COUNT(*) FROM NhanVien WHERE soDienThoai = @SoDienThoai AND password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
        // Phương thức lấy danh sách nhân viên
        public DataTable GetAllNhanVien()
        {
            DataTable nhanViens = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                {
                    conn.Open(); // Ensure the connection is opened before executing the command.

                    string sql = "SELECT maNV, hoTenNV, gioiTinh, ngaySinh, soDienThoai, quyenHan, chucDanh, DiaChiNV , cccd FROM NhanVien";
                    using (SqlCommand query = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(query);
                        adapter.Fill(nhanViens);
                    }
                }

                if (nhanViens.Rows.Count == 0)
                {
                    // Optionally log or handle empty results.
                    Console.WriteLine("Không có dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions gracefully.
                Console.WriteLine($"Error: {ex.Message}");
            }

            return nhanViens; // Return the populated DataTable (or empty if no rows).
        }
        public NhanVien GetNhanVienBySoDienThoai(string soDienThoai)
        {
            NhanVien nv = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                SELECT *
                FROM NhanVien
                WHERE soDienThoai = @SoDienThoai";

                    cmd.Parameters.Add("@SoDienThoai", SqlDbType.VarChar).Value = soDienThoai;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nv = new NhanVien();

                            nv.MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")).ToString();
                            nv.HoTenNV = reader.IsDBNull(reader.GetOrdinal("HoTenNV")) ? null : reader.GetString(reader.GetOrdinal("HoTenNV"));
                            nv.GioiTinh = reader.IsDBNull(reader.GetOrdinal("gioiTinh")) ? null : reader.GetString(reader.GetOrdinal("gioiTinh"));
                            nv.NgaySinh = reader.IsDBNull(reader.GetOrdinal("ngaySinh")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ngaySinh"));
                            nv.SoDienThoai = reader.IsDBNull(reader.GetOrdinal("soDienThoai")) ? null : reader.GetString(reader.GetOrdinal("soDienThoai"));
                            nv.Password = reader.IsDBNull(reader.GetOrdinal("password")) ? null : reader.GetString(reader.GetOrdinal("password"));
                            nv.QuyenHan = reader.IsDBNull(reader.GetOrdinal("quyenHan")) ? null : reader.GetString(reader.GetOrdinal("quyenHan"));
                            nv.ChucDanh = reader.IsDBNull(reader.GetOrdinal("chucDanh")) ? null : reader.GetString(reader.GetOrdinal("chucDanh"));
                            nv.DiaChiNV = reader.IsDBNull(reader.GetOrdinal("DiaChiNV")) ? null : reader.GetString(reader.GetOrdinal("DiaChiNV"));
                            nv.CCCD = reader.IsDBNull(reader.GetOrdinal("cccd")) ? null : reader.GetString(reader.GetOrdinal("cccd"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin nhân viên theo số điện thoại: {ex.Message}");
            }

            return nv; // Trả về null nếu không tìm thấy
        }

        // Sửa parameter đầu vào sang int
        public NhanVien GetNhanVienById(string maNhanVien)
        {
            NhanVien nv = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT MaNV, HoTenNV, GioiTinh, NgaySinh, SoDienThoai, 
                                    Password, QuyenHan, ChucDanh, DiaChiNV, CCCD
                                    FROM NhanVien
                                    WHERE MaNV = @manv";

                    // Add parameter using the correct data type (string)
                    cmd.Parameters.Add("@manv", SqlDbType.NVarChar).Value = maNhanVien;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Convert NgaySinh properly
                            DateTime? ngaySinh = null;
                            if (!reader.IsDBNull(reader.GetOrdinal("ngaySinh")))
                            {
                                ngaySinh = reader.GetDateTime(reader.GetOrdinal("ngaySinh"));
                            }

                            nv = new NhanVien(
                                reader["MaNV"].ToString(),
                                reader["hoTenNV"].ToString(),
                                reader["gioiTinh"].ToString(),
                                ngaySinh,
                                reader["soDienThoai"].ToString(),
                                "",
                                "",
                                "",
                                "",
                                ""
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin nhân viên theo ID: {ex.Message}");
                nv = null;
            }
            return nv;
        }
    
        // Phương thức thêm nhân viên mới
        public bool AddNhanVien(NhanVien nhanVien)
        {
            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "INSERT INTO NhanVien (hoTenNV, gioiTinh, ngaySinh, soDienThoai, password, quyenHan, chucDanh, diaChiNV , cccd) " +
                               "VALUES (@HoTenNV, @GioiTinh, @NgaySinh, @SoDienThoai, @Password, @QuyenHan, @ChucDanh, @DiaChiNV , @CCCD)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@HoTenNV", nhanVien.HoTenNV);
                command.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
                command.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai);
                command.Parameters.AddWithValue("@Password", nhanVien.Password);
                command.Parameters.AddWithValue("@QuyenHan", nhanVien.QuyenHan);
                command.Parameters.AddWithValue("@ChucDanh", nhanVien.ChucDanh);
                command.Parameters.AddWithValue("@DiaChiNV", nhanVien.DiaChiNV);
                command.Parameters.AddWithValue("@CCCD", nhanVien.CCCD);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra số dòng bị ảnh hưởng
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi nếu cần
                    Console.WriteLine($"Lỗi khi thêm nhân viên: {ex.Message}");
                    return false;
                }
            }
        }

        public bool CheckQuyenHanNhanVien(string maNV, string quyenHanCanKiemTra)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
                {
                    // Truy vấn kiểm tra quyền hạn của nhân viên
                    string query = @"
                SELECT quyenHan 
                FROM NhanVien 
                WHERE maNV = @MaNV";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số để tránh SQL Injection
                        command.Parameters.AddWithValue("@MaNV", maNV);

                        connection.Open();

                        // Thực thi truy vấn và lấy quyền hạn
                        object result = command.ExecuteScalar();

                        // Kiểm tra kết quả
                        if (result != null)
                        {
                            string quyenHanHienTai = result.ToString();

                            // So sánh quyền hạn
                            // Ví dụ: Quyền hạn được lưu như "Admin,NhanVien,QuanLy"
                            string[] quyenHanCuaNhanVien = quyenHanHienTai.Split(',');
                            string[] quyenHanCanCheck = quyenHanCanKiemTra.Split(',');

                            // Kiểm tra xem nhân viên có quyền không
                            foreach (string quyen in quyenHanCanCheck)
                            {
                                if (quyenHanCuaNhanVien.Contains(quyen.Trim()))
                                {
                                    return true;
                                }
                            }
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Logger.Instance().LogException(ex);
                return false;
            }
        }
        // Phương thức cập nhật thông tin nhân viên
        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
                {
                    // Khởi tạo câu lệnh UPDATE động
                    List<string> updateClauses = new List<string>();
                    SqlCommand command = new SqlCommand();

                    // Kiểm tra từng trường và thêm vào danh sách update nếu không null hoặc empty
                    if (!string.IsNullOrWhiteSpace(nhanVien.HoTenNV))
                    {
                        updateClauses.Add("hoTenNV = @HoTenNV");
                        command.Parameters.AddWithValue("@HoTenNV", nhanVien.HoTenNV);
                    }
                    if (!string.IsNullOrWhiteSpace(nhanVien.GioiTinh))
                    {
                        updateClauses.Add("gioiTinh = @GioiTinh");
                        command.Parameters.AddWithValue("@GioiTinh", nhanVien.GioiTinh);
                    }
                    if (nhanVien.NgaySinh.HasValue)
                    {
                        updateClauses.Add("ngaySinh = @NgaySinh");
                        command.Parameters.AddWithValue("@NgaySinh", nhanVien.NgaySinh.Value);
                    }
                    if (!string.IsNullOrWhiteSpace(nhanVien.SoDienThoai))
                    {
                        updateClauses.Add("soDienThoai = @SoDienThoai");
                        command.Parameters.AddWithValue("@SoDienThoai", nhanVien.SoDienThoai);
                    }
                    if (!string.IsNullOrWhiteSpace(nhanVien.Password))
                    {
                        updateClauses.Add("password = @Password");
                        command.Parameters.AddWithValue("@Password", nhanVien.Password);
                    }
                    if (!string.IsNullOrWhiteSpace(nhanVien.QuyenHan))
                    {
                        updateClauses.Add("quyenHan = @QuyenHan");
                        command.Parameters.AddWithValue("@QuyenHan", nhanVien.QuyenHan);
                    }
                    if (!string.IsNullOrWhiteSpace(nhanVien.ChucDanh))
                    {
                        updateClauses.Add("chucDanh = @ChucDanh");
                        command.Parameters.AddWithValue("@ChucDanh", nhanVien.ChucDanh);
                    }
                    if (!string.IsNullOrWhiteSpace(nhanVien.DiaChiNV))
                    {
                        updateClauses.Add("DiaChiNV = @DiaChiNV");
                        command.Parameters.AddWithValue("@DiaChiNV", nhanVien.DiaChiNV);
                    }
                    if (!string.IsNullOrWhiteSpace(nhanVien.CCCD))
                    {
                        updateClauses.Add("CCCD = @CCCD");
                        command.Parameters.AddWithValue("@CCCD", nhanVien.CCCD);
                    }

                    // Nếu không có trường nào để cập nhật
                    if (updateClauses.Count == 0)
                    {
                        return false;
                    }

                    // Xây dựng câu truy vấn UPDATE
                    string query = $"UPDATE NhanVien SET {string.Join(", ", updateClauses)} WHERE maNV = @MaNV";
                    command.CommandText = query;
                    command.Connection = connection;

                    // Thêm tham số mã nhân viên
                    command.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0; // Trả về true nếu cập nhật thành công
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool UpdateMK(string username, string newpass)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
                {
                    string query = "UPDATE NhanVien SET password = @Password " +
                                   "WHERE soDienThoai = @soDienThoai";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@soDienThoai", username);
                        command.Parameters.AddWithValue("@Password", newpass);

                        connection.Open();

                        // Trả về số dòng bị ảnh hưởng
                        int rowsAffected = command.ExecuteNonQuery();

                        // Nếu có ít nhất 1 dòng bị update thì trả về true
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Logger.Instance().LogException(ex);

                // Trả về false nếu có lỗi
                return false;
            }
        }

        // Phương thức xóa nhân viên
        public bool DeleteNhanVien(string maNV)
        {
            int rowsAffected = 0; // Biến để lưu số lượng dòng bị ảnh hưởng
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
                {
                    string query = "DELETE FROM NhanVien WHERE maNV = @MaNV";
                    using (SqlCommand command = new SqlCommand(query, connection)) // Cũng nên dùng using cho SqlCommand
                    {
                        // Sử dụng Add thay vì AddWithValue để chỉ định rõ kiểu dữ liệu, tốt hơn cho hiệu suất và tránh lỗi tiềm ẩn
                        command.Parameters.Add("@MaNV", System.Data.SqlDbType.VarChar).Value = maNV;
                        // Hoặc nếu maNV là kiểu khác (ví dụ: NVarChar, Int), hãy thay đổi SqlDbType tương ứng

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery(); // Thực thi lệnh và lấy số dòng bị ảnh hưởng
                    } // SqlCommand được giải phóng tại đây
                } // SqlConnection được giải phóng tại đây

                // Trả về true nếu có ít nhất một dòng bị xóa, ngược lại trả về false
                return rowsAffected > 0;
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi SQL cụ thể (ví dụ: log lỗi)
                Console.WriteLine("SQL Error deleting NhanVien: " + ex.Message);
                // Xem xét việc log chi tiết lỗi tại đây (sử dụng một thư viện logging)
                return false; // Trả về false khi có lỗi SQL
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi chung khác (ví dụ: lỗi kết nối)
                Console.WriteLine("General Error deleting NhanVien: " + ex.Message);
                // Xem xét việc log chi tiết lỗi tại đây
                return false; // Trả về false khi có lỗi chung
            }
        }
    }
}

