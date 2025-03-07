using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PMQuanLyCuaHangLapTopV10.Models.PMQuanLyCuaHangLaptop.Models;


namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class NhanVienDAO
    {
        private string connectionString;

        public NhanVienDAO()
        {
            // Lấy chuỗi kết nối từ file cấu hình
            connectionString = ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString;
        }

        // Phương thức lấy danh sách nhân viên
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> nhanViens = new List<NhanVien>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT maNV, tenNV, diaChiNV, sdtNV, username, password, maQuyenHan FROM NhanVien";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNV = reader["maNV"].ToString(),
                        TenNV = reader["tenNV"].ToString(),
                        DiaChiNV = reader["diaChiNV"].ToString(),
                        SdtNV = reader["sdtNV"].ToString(),
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        MaQuyenHan = reader["maQuyenHan"].ToString()
                    };
                    nhanViens.Add(nv);
                }
                reader.Close();
            }

            return nhanViens;
        }

        // Phương thức thêm nhân viên mới
        public void AddNhanVien(NhanVien nhanVien)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO NhanVien (maNV, tenNV, diaChiNV, sdtNV, username, password, maQuyenHan) " +
                               "VALUES (@MaNV, @TenNV, @DiaChiNV, @SdtNV, @Username, @Password, @MaQuyenHan)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                command.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                command.Parameters.AddWithValue("@DiaChiNV", nhanVien.DiaChiNV);
                command.Parameters.AddWithValue("@SdtNV", nhanVien.SdtNV);
                command.Parameters.AddWithValue("@Username", nhanVien.Username);
                command.Parameters.AddWithValue("@Password", nhanVien.Password);
                command.Parameters.AddWithValue("@MaQuyenHan", nhanVien.MaQuyenHan);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Phương thức cập nhật thông tin nhân viên
        public void UpdateNhanVien(NhanVien nhanVien)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE NhanVien SET tenNV = @TenNV, diaChiNV = @DiaChiNV, sdtNV = @SdtNV, " +
                               "username = @Username, password = @Password, maQuyenHan = @MaQuyenHan " +
                               "WHERE maNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", nhanVien.MaNV);
                command.Parameters.AddWithValue("@TenNV", nhanVien.TenNV);
                command.Parameters.AddWithValue("@DiaChiNV", nhanVien.DiaChiNV);
                command.Parameters.AddWithValue("@SdtNV", nhanVien.SdtNV);
                command.Parameters.AddWithValue("@Username", nhanVien.Username);
                command.Parameters.AddWithValue("@Password", nhanVien.Password);
                command.Parameters.AddWithValue("@MaQuyenHan", nhanVien.MaQuyenHan);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Phương thức xóa nhân viên
        public void DeleteNhanVien(string maNV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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

