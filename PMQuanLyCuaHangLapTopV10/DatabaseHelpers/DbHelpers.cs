using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PMQuanLyCuaHangLapTopV10
{
    public class DbHelpers
    {
        
        private readonly Logger logger = Logger.Instance();

        // Khởi tạo kết nối SQL
        private SqlConnection GetConnection()
        {
            try
            {
                var conn = new SqlConnection(DBconnection.strConnection);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.", ex);
            }
        }

        // Thực thi truy vấn trả về DataTable
        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogException(ex);
                    throw new Exception("Lỗi khi thực thi truy vấn.", ex);
                }
            }

            return dt;
        }

        // Lấy danh sách dữ liệu từ bảng
        public DataTable GetListTable(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentException("Tên bảng không hợp lệ.");

            string query = $"SELECT * FROM {tableName}";
            return ExecuteQuery(query);
        }
    }
}
