using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;


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

            // Thêm cột vào DataTable
            nhanViens.Columns.Add("MaNV", typeof(string));
            nhanViens.Columns.Add("HoTenNV", typeof(string));
            nhanViens.Columns.Add("GioiTinh", typeof(string));
            nhanViens.Columns.Add("NgaySinh", typeof(DateTime));
            nhanViens.Columns.Add("SoDienThoai", typeof(string));
            nhanViens.Columns.Add("Password", typeof(string));
            nhanViens.Columns.Add("QuyenHan", typeof(string));
            nhanViens.Columns.Add("ChucDanh", typeof(string));
            nhanViens.Columns.Add("DiaChiNV", typeof(string));

            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "SELECT maNV, hoTenNV, gioiTinh, ngaySinh, soDienThoai, password, quyenHan, chucDanh, DiaChiNV FROM NhanVien";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nhanViens.Rows.Add(
                        reader["maNV"].ToString(),
                        reader["hoTenNV"].ToString(),
                        reader["gioiTinh"].ToString(),
                        reader["ngaySinh"] == DBNull.Value ? (object)DBNull.Value : (DateTime)reader["ngaySinh"],
                        reader["soDienThoai"].ToString(),
                        reader["password"].ToString(),
                        reader["quyenHan"].ToString(),
                        reader["chucDanh"].ToString(),
                        reader["DiaChiNV"].ToString()
                    );
                }
                reader.Close();
            }

            return nhanViens;
        }


        // Phương thức thêm nhân viên mới
        public void AddNhanVien(NhanVien nhanVien)
        {
            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "INSERT INTO NhanVien (maNV, hoTenNV, gioiTinh, ngaySinh, soDienThoai, password, quyenHan, chucDanh) " +
                               "VALUES (@MaNV, @HoTenNV, @GioiTinh, @NgaySinh, @SoDienThoai, @Password, @QuyenHan, @ChucDanh)";
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

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Phương thức cập nhật thông tin nhân viên
        public void UpdateNhanVien(NhanVien nhanVien)
        {

            // tự động đóng ngắt connection với using
            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "UPDATE NhanVien SET hoTenNV = @HoTenNV, gioiTinh = @GioiTinh, ngaySinh = @NgaySinh, " +
                               "soDienThoai = @SoDienThoai, password = @Password, quyenHan = @QuyenHan, chucDanh = @ChucDanh " +
                               "WHERE maNV = @MaNV";
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

                connection.Open();
                command.ExecuteNonQuery();
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

