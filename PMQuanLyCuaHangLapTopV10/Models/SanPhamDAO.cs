using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Data;
using System.Data.SqlClient;

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

        // 📌 Thêm sản phẩm (trả về true nếu thành công)
        public bool InsertSP(string tenSP, int thoiGianBaoHanh, int soLuongSP, string moTaChiTiet, decimal donGiaSP, decimal giaNhapSP, int maNCC)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO SanPham (TenSP, ThoiGianBaoHanh, SoLuongSP, MoTaChiTiet, GiaNhap ,GiaBan, MaNCC) " +
                               "VALUES (@TenSP, @ThoiGianBaoHanh, @SoLuongSP, @MoTaChiTiet, @GiaBan, @GiaNhap, @MaNCC)";

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

        // 📌 Cập nhật sản phẩm
        public bool Update(string maSP, string tenSP, string loaiSP, int thoiGianBaoHanh, int soLuongSP, string moTaChiTiet, decimal donGiaSP, int maNCC)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE SanPham SET TenSP = @TenSP, LoaiSP = @LoaiSP, ThoiGianBaoHanh = @ThoiGianBaoHanh, " +
                               "SoLuongSP = @SoLuongSP, MoTaChiTiet = @MoTaChiTiet, DonGia = @DonGiaSP, MaNCC = @MaNCC " +
                               "WHERE MaSP = @MaSP";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaSP", maSP);
                command.Parameters.AddWithValue("@TenSP", tenSP);
                command.Parameters.AddWithValue("@LoaiSP", loaiSP);
                command.Parameters.AddWithValue("@ThoiGianBaoHanh", thoiGianBaoHanh);
                command.Parameters.AddWithValue("@SoLuongSP", soLuongSP);
                command.Parameters.AddWithValue("@MoTaChiTiet", moTaChiTiet);
                command.Parameters.AddWithValue("@DonGiaSP", donGiaSP);
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
    }
}
