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
    public class ChiTiethdDAO
    {
        public ChiTiethdDAO() 
        {

        }
        public bool InsertCTHD(ChiTietHD cthd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Sửa CommandText để INSERT vào bảng ChiTietHoaDon
                    // Liệt kê đúng các cột trong bảng ChiTietHoaDon
                    cmd.CommandText = @"INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia, ThanhTien)
                                VALUES (@MaHD, @MaSP, @SoLuong, @DonGia, @ThanhTien)";
    
                    // Sửa lại parameters: Sử dụng tên parameters khớp với CommandText
                    // và gán giá trị từ đối tượng ChiTietHD (cthd)
                    // Cần xử lý các cột có thể NULL trong database bằng cách gán DBNull.Value
                    // nếu thuộc tính tương ứng trong đối tượng cthd là null

                    // MaHD và MaSP là NOT NULL trong DB và thường sẽ có giá trị
                     cmd.Parameters.AddWithValue("@MaHD", cthd.MaHD);
                     cmd.Parameters.AddWithValue("@MaSP", cthd.MaSP);

                    // SoLuong, DonGia, ThanhTien có thể NULL trong DB, xử lý nullable properties
                    cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                    cmd.Parameters.AddWithValue("@DonGia", cthd.DonGia);
                    cmd.Parameters.AddWithValue("@ThanhTien", cthd.ThanhTien);


                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu có ít nhất 1 dòng được thêm thành công
                }
            }
            catch (Exception ex)
            {
                // Sửa thông báo lỗi để phản ánh đúng nghiệp vụ
                Console.WriteLine("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                // Có thể ghi log lỗi chi tiết hơn, bao gồm InnerException nếu có
                // Logger.Log($"Lỗi khi thêm chi tiết hóa đơn: {ex.Message}\n{(ex.InnerException != null ? "Inner Exception: " + ex.InnerException.Message : "")}");

                // Tùy chọn: Ném lại lỗi để tầng gọi xử lý
                // throw;

                return false; // Trả về false nếu có lỗi xảy ra
            }
        }

        public DataTable LayDanhSachSanPham(string maHD)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT ct.MaHD, ct.MaSP, sp.TenSP, ct.SoLuong, ct.DonGia, ct.ThanhTien 
                              FROM ChiTietHoaDon ct
                              INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                              WHERE ct.MaHD = @MaHD";
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
            return dt;
        }
    }
}
