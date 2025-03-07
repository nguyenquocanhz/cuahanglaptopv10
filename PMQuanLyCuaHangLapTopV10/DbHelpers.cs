using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PMQuanLyCuaHangLapTopV10
{
    
public class DbHelpers
    {
        public string strConnection = "Data Source=DESKTOP-PVG090N;Initial Catalog=laptopStoreDB;Integrated Security=True;Trust Server Certificate=True";
        public SqlConnection conn = null;
        public SqlCommand cmd = null;
        public SqlDataAdapter adapter = null;

        public DbHelpers() { }

        public void GetConnection()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(strConnection);
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("An error occurred: " + ex.Message);
                
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
