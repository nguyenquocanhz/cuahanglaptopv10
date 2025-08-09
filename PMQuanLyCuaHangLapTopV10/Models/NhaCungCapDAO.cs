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
    public class NhaCungCapDAO
    {
        public NhaCungCapDAO() { }

        // Phương thức thêm nhà cung cấp mới
        public bool InsertNCC(NhaCungCap nhaCungCap)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand command = new SqlCommand("INSERT INTO NhaCungCap (TenNCC, soDIenThoaiNCC) VALUES (@TenNCC, @soDIenThoaiNCC)", connection))
                {
                    command.Parameters.Add("@TenNCC", SqlDbType.NVarChar, 255).Value = nhaCungCap.TenNCC;
                    command.Parameters.Add("@soDIenThoaiNCC", SqlDbType.VarChar, 15).Value = nhaCungCap.SoDienThoai;

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có dòng được chèn
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý theo cách phù hợp
                Logger logger = new Logger();
                logger.LogError("Lỗi khi chèn nhà cung cấp: " + ex.Message);
                return false;
            }
        }
        public bool UpdateNCC(string tenNCC, string sdt , string MaNCC)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand command = new SqlCommand("UPDATE NhaCungCap SET TenNCC = @TenNCC, soDienThoaiNCC = @soDienThoaiNCC WHERE MaNCC = @MaNCC", connection))
                {
                    command.Parameters.Add("@TenNCC", SqlDbType.NVarChar, 255).Value = tenNCC;
                    command.Parameters.Add("@soDienThoaiNCC", SqlDbType.VarChar, 15).Value = sdt;
                    command.Parameters.Add("@MaNCC", SqlDbType.Int).Value = MaNCC;

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có dòng được cập nhật
                }
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc xử lý theo cách phù hợp
                Logger logger = new Logger();
                logger.LogError("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
                return false;
            }
        }
        public bool RemoveNCC(int MaNCC)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand command = new SqlCommand("DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC", connection))
                {
                    command.Parameters.Add("@MaNCC", SqlDbType.Int).Value = MaNCC; // Đúng kiểu dữ liệu

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có dòng bị xóa
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi với nội dung chính xác
                Logger logger = new Logger();
                logger.LogError("Lỗi khi xóa nhà cung cấp: " + ex.Message);
                return false;
            }
        }


        public DataTable GetListNhaCungCap()
        {
            DataTable nhaCungCap = new DataTable();

            // Thêm cột vào DataTable
            nhaCungCap.Columns.Add("MaNCC", typeof(string));
            nhaCungCap.Columns.Add("TenNCC", typeof(string));
            nhaCungCap.Columns.Add("SoDienThoai", typeof(string));

            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                string query = "SELECT * FROM NhaCungCap";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nhaCungCap.Rows.Add(
                        reader["MaNCC"].ToString(),
                        reader["TenNCC"].ToString(),
                        reader["soDienThoaiNCC"].ToString()
                    );
                }
                reader.Close();
            }

            return nhaCungCap;

        }
        public DataTable GetNhaCungCapById(string maNCC)
        {
            DataTable nhaCungCap = new DataTable();

            // Thêm cột vào DataTable (Nên đặt tên cột khớp với tên cột trong DB hoặc dữ liệu trả về)
            nhaCungCap.Columns.Add("MaNCC", typeof(string));
            nhaCungCap.Columns.Add("TenNCC", typeof(string));
            // Giả sử cột trong DB tên là soDienThoaiNCC, đổi tên cột trong DataTable cho nhất quán
            nhaCungCap.Columns.Add("SoDienThoaiNCC", typeof(string));

            // Kiểm tra đầu vào cơ bản
            if (string.IsNullOrEmpty(maNCC))
            {
                // Có thể throw Exception hoặc trả về DataTable rỗng tùy theo logic ứng dụng
                Console.WriteLine("Mã NCC không được để trống.");
                return nhaCungCap; // Trả về DataTable rỗng
            }

            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                // Sử dụng parameterized query để tránh SQL Injection
                string query = "SELECT MaNCC, TenNCC, soDienThoaiNCC FROM NhaCungCap WHERE MaNCC = @MaNCC";
                SqlCommand command = new SqlCommand(query, connection);

                // Thêm parameter
                command.Parameters.AddWithValue("@MaNCC", maNCC);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Chỉ đọc một dòng nếu tìm thấy
                    if (reader.Read())
                    {
                        nhaCungCap.Rows.Add(
                            reader["MaNCC"]?.ToString(), // Sử dụng ?. để tránh lỗi nếu giá trị là null
                            reader["TenNCC"]?.ToString(),
                            reader["soDienThoaiNCC"]?.ToString()
                        );
                    }
                    // else: không tìm thấy NCC với mã này, DataTable sẽ rỗng

                    reader.Close();
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi kết nối hoặc truy vấn SQL
                    Console.WriteLine("Lỗi SQL: " + ex.Message);
                    // Có thể throw lại lỗi hoặc ghi log tùy theo yêu cầu
                }
                catch (Exception ex)
                {
                    // Xử lý các lỗi khác
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
                // connection sẽ tự động đóng khi ra khỏi khối using
            }

            return nhaCungCap;
        }
        public NhaCungCap GetNhaCungCapByIdv2(string maNCC)
        {
            // Check input validation
            if (string.IsNullOrEmpty(maNCC))
            {
                Console.WriteLine("Mã NCC không được để trống.");
                return null; // Return null instead of empty DataTable for better use in business logic
            }

            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                // Use parameterized query to prevent SQL Injection
                string query = "SELECT MaNCC, TenNCC, soDienThoaiNCC FROM NhaCungCap WHERE MaNCC = @MaNCC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNCC", maNCC);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Return the NhaCungCap object if found
                    if (reader.Read())
                    {
                        return new NhaCungCap(
                            reader["MaNCC"]?.ToString(),
                            reader["TenNCC"]?.ToString(),
                            reader["soDienThoaiNCC"]?.ToString() // Map database field to model property
                        );
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi SQL: " + ex.Message);
                    // Consider logging the error or throwing a custom exception
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
            return null; // Return null if supplier not found or error occurred
        }
        public bool CheckExistNCC(string maNCC)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(maNCC))
            {
                Console.WriteLine("Mã NCC không được để trống.");
                return false;
            }

            // Sử dụng hàm GetNhaCungCapById để lấy dữ liệu
            DataTable dtNhaCungCap = GetNhaCungCapById(maNCC);

            // Kiểm tra xem DataTable có dữ liệu hay không
            // Nếu có dòng dữ liệu, tức là nhà cung cấp tồn tại
            return dtNhaCungCap.Rows.Count > 0;
        }
        // Thêm vào lớp NhaCungCapDAO
        public bool CheckExistNCCByPhoneOrName(string phone, string name)
        {
            DataTable dt = new DataTable();
            string query = "SELECT COUNT(*) FROM NhaCungCap WHERE soDienThoaiNCC = @Phone OR TenNCC = @Name";

            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Name", name);

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
        public bool CheckExistNCCByName(string name)
        {
            string query = "SELECT COUNT(*) FROM NhaCungCap WHERE TenNCC = @Name";

            using (SqlConnection connection = new SqlConnection(DBconnection.strConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0; // Trả về true nếu có nhà cung cấp
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                    return false;
                }
            }
        }

        // Lấy danh sách nhà cung cấp với Sql Connection . SqlCommand , SqlAdapter return DataTable
        public DataTable GetListNhaCungCapDatatable()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                {
                    conn.Open(); // Ensure the connection is opened before executing the command.

                    string sql = "SELECT * FROM NhaCungCap";
                    using (SqlCommand query = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(query);
                        adapter.Fill(dt);
                    }
                }

                if (dt.Rows.Count == 0)
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

            return dt; // Return the populated DataTable (or empty if no rows).
        }

    }
}
