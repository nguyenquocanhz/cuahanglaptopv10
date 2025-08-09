using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class KhachHangDAO
    {
        public KhachHangDAO() { }

        // Phương thức thêm khách hàng mới
        public bool InsertKhachHang(KhachHang kh)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO KhachHang (HoTenKH, gioiTinh, soDienThoai, diaChiKH) VALUES (@hoTen, @gioiTinh, @sdt, @diaChi)";
                    // Sử dụng AddWithValue cẩn thận, nên chỉ định rõ DbType nếu có thể để tránh lỗi ép kiểu ngầm
                    cmd.Parameters.AddWithValue("@hoTen", kh.HoTen);
                    cmd.Parameters.AddWithValue("@gioiTinh", kh.GioiTinh);
                    cmd.Parameters.AddWithValue("@sdt", kh.SoDienThoai);
                    cmd.Parameters.AddWithValue("@diaChi", kh.DiaChiKH);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm khách hàng: " + ex.Message);
                // Có thể ghi log lỗi ở đây
                // Logger.Log("Lỗi khi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        // Phương thức cập nhật thông tin khách hàng
        public bool UpdateKhachHang(KhachHang kh)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE KhachHang SET HoTenKH = @hoTen, gioiTinh = @gioiTinh, soDienThoai = @sdt, diaChiKH = @diaChi WHERE MaKH = @maKH";
                    cmd.Parameters.AddWithValue("@hoTen", kh.HoTen);
                    cmd.Parameters.AddWithValue("@gioiTinh", kh.GioiTinh);
                    cmd.Parameters.AddWithValue("@sdt", kh.SoDienThoai);
                    cmd.Parameters.AddWithValue("@diaChi", kh.DiaChiKH);
                    cmd.Parameters.AddWithValue("@maKH", kh.MaKhachHang); // Điều kiện WHERE

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật khách hàng: " + ex.Message);
                // Logger.Log("Lỗi khi cập nhật khách hàng: " + ex.Message);
                return false;
            }
        }

        // Phương thức xóa khách hàng
        public bool DeleteKhachHang(string maKhachHang)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM KhachHang WHERE MaKH = @maKH";
                    cmd.Parameters.AddWithValue("@maKH", maKhachHang);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa khách hàng: " + ex.Message);
                // Logger.Log("Lỗi khi xóa khách hàng: " + ex.Message);
                return false;
            }
        }

        // Phương thức lấy thông tin khách hàng bằng mã
        public KhachHang GetKhachHangById(string maKhachHang)
        {
            KhachHang kh = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM KhachHang WHERE MaKH = @maKH";
                    cmd.Parameters.AddWithValue("@maKH", maKhachHang);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            kh = new KhachHang(
                                reader["MaKH"].ToString(),
                                reader["HoTenKH"].ToString(),
                                reader["gioiTinh"].ToString(),
                                reader["soDienThoai"].ToString(),
                                reader["diaChiKH"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy khách hàng theo ID: " + ex.Message);
                // Logger.Log("Lỗi khi lấy khách hàng theo ID: " + ex.Message);
                kh = null; // Đảm bảo trả về null nếu có lỗi
            }
            return kh;
        }

        // Phương thức lấy danh sách tất cả khách hàng dạng DataTable
        public DataTable GetListKhachHangDatatable()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                {
                    string sql = "SELECT * FROM KhachHang";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                    {
                        // Không cần mở kết nối thủ công, SqlDataAdapter sẽ tự quản lý
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                // Logger.Log("Lỗi khi lấy danh sách khách hàng: " + ex.Message);
                // Trả về DataTable rỗng nếu có lỗi
                dt = new DataTable();
            }
            return dt;
        }

        // Phương thức tìm kiếm khách hàng (ví dụ: theo tên hoặc SĐT)
        public DataTable SearchKhachHang(string keyword)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Tìm kiếm gần đúng trong họ tên hoặc số điện thoại
                    cmd.CommandText = "SELECT * FROM KhachHang WHERE HoTenKH LIKE @keyword OR soDienThoai LIKE @keyword";
                    // Thêm % để tìm kiếm gần đúng
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
                // Logger.Log("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
                dt = new DataTable();
            }
            return dt;
        }
        public bool CheckExistKHByPhone(string phone)
        {
            DataTable dt = new DataTable();
            string query = "SELECT COUNT(*) FROM KhachHang WHERE soDienThoai = @Phone ";

            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Phone", phone);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }
    }
}