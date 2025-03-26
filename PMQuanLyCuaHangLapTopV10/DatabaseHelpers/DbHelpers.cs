using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PMQuanLyCuaHangLapTopV10
{
    public class DbHelpers
    {
        // Static instance for easier access
        private static DbHelpers _instance;
        public static DbHelpers Instance()
        {
            if (_instance == null)
            {
                _instance = new DbHelpers();
            }
            return _instance;
        }
        private readonly Logger logger = Logger.Instance();
        public string ConnectionString => DBconnection.strConnection;

        private DbHelpers() { }
        // Khởi tạo kết nối SQL
        private SqlConnection GetConnection()
        {
            try
            {
                var conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                throw new Exception("Không thể kết nối đến cơ sở dữ liệu.", ex);
            }
        }
        public bool CheckConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
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
