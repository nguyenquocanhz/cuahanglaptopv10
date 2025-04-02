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
                using (SqlCommand command = new SqlCommand("INSERT INTO NhaCungCap (MaNCC, TenNCC, soDIenThoaiNCC) VALUES (@MaNCC, @TenNCC, @soDIenThoaiNCC)", connection))
                {
                    command.Parameters.Add("@MaNCC", SqlDbType.NVarChar, 50).Value = nhaCungCap.MaNCC;
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
