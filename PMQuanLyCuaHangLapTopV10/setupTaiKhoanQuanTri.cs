using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class setupTaiKhoanQuanTri: Form
    {
        //private string conn = "Data Source=DESKTOP-PVG090N;Initial Catalog=laptopStoreDB;Integrated Security=True;Encrypt=true;TrustServerCertificate=true";
        public setupTaiKhoanQuanTri()
        {
            InitializeComponent();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string hoTen = textBoxHoTen.Text;
            string gioiTinh = textBoxGioiTinh.Text;
            DateTime ngaySinh = dateTimePickerNgaySinh.Value;
            string soDienThoai = textBoxSoDienThoai.Text;
            string password = textBoxPassword.Text;
            string quyenHan = cbQuyenHan.Text;
            string chucDanh = textBoxChucDanh.Text;
            string[] data = new string[20];
            

            //if (InsertValue(conn, "NhanVien", data)) 
            //{

            //}

            // Kết nối đến cơ sở dữ liệu và thực hiện INSERT
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-PVG090N;Initial Catalog=laptopStoreDB;Integrated Security=True;Encrypt=true;TrustServerCertificate=true"))
            {
                conn.Open();
                string query = "INSERT INTO NhanVien (hoTenNV, gioiTinh, ngaySinh, soDienThoai, password, quyenHan, chucDanh) " +
                               "VALUES (@hoTen, @gioiTinh, @ngaySinh, @soDienThoai, @password, @quyenHan, @chucDanh)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hoTen", hoTen);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@quyenHan", quyenHan);
                    cmd.Parameters.AddWithValue("@chucDanh", chucDanh);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Thêm nhân viên thành công!");
        }

        private void setupTaiKhoanQuanTri_Load(object sender, EventArgs e)
        {

        }

        //public bool InsertValue(string conn ,string tableName , string[] values)
        //{
        //    bool isSuccess = false;
        //    if (values.Length == 0) 
        //    { 
        //        return isSuccess; 
        //    }

        //    using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-PVG090N;Initial Catalog=laptopStoreDB;Integrated Security=True;Encrypt=true;TrustServerCertificate=true"))
        //    {
        //        conn.Open();
        //        string query = "INSERT INTO NhanVien (hoTenNV, gioiTinh, ngaySinh, soDienThoai, password, quyenHan, chucDanh) " +
        //                       "VALUES (@hoTen, @gioiTinh, @ngaySinh, @soDienThoai, @password, @quyenHan, @chucDanh)";
        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@hoTen", hoTen);
        //            cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
        //            cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
        //            cmd.Parameters.AddWithValue("@soDienThoai", soDienThoai);
        //            cmd.Parameters.AddWithValue("@password", password);
        //            cmd.Parameters.AddWithValue("@quyenHan", quyenHan);
        //            cmd.Parameters.AddWithValue("@chucDanh", chucDanh);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
