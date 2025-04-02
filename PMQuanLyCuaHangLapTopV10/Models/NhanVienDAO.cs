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
                string query = "SELECT hoTenNV, soDienThoai, password, quyenHan, chucDanh FROM NhanVien " +
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


        // Phương thức thêm nhân viên mới
        public bool AddNhanVien(NhanVien nhanVien)
        {
            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "INSERT INTO NhanVien (maNV, hoTenNV, gioiTinh, ngaySinh, soDienThoai, password, quyenHan, chucDanh, diaChiNV , cccd) " +
                               "VALUES (@MaNV, @HoTenNV, @GioiTinh, @NgaySinh, @SoDienThoai, @Password, @QuyenHan, @ChucDanh, @DiaChiNV , @CCCD)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
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
                                   "WHERE maNV = @MaNV";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNV", username);
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
        public void DeleteNhanVien(string maNV)
        {
            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "DELETE FROM NhanVien WHERE maNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}

