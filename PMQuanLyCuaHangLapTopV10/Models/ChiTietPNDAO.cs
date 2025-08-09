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
    public class ChiTietPNDAO
    {
        public ChiTietPNDAO()
        {

        }
        public bool InsertCTPN(ChiTietPhieuNhapHang ctpn)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Sửa CommandText để INSERT vào bảng ChiTietHoaDon
                    // Liệt kê đúng các cột trong bảng ChiTietHoaDon
                    cmd.CommandText = @"INSERT INTO ChiTietPhieuNhap (MaPN,MaSP, SoLuongNhap, DonGiaNhap, ThanhTien)
                                VALUES (@MaPN, @MaSP, @SoLuong, @DonGia, @ThanhTien)";

                    // Sửa lại parameters: Sử dụng tên parameters khớp với CommandText
                    // và gán giá trị từ đối tượng ChiTietHD (cthd)
                    // Cần xử lý các cột có thể NULL trong database bằng cách gán DBNull.Value
                    // nếu thuộc tính tương ứng trong đối tượng cthd là null

                    // MaHD và MaSP là NOT NULL trong DB và thường sẽ có giá trị
                    cmd.Parameters.AddWithValue("@MaPN", ctpn.MaPNH);
                    cmd.Parameters.AddWithValue("@MaSP", ctpn.MaSP);

                    // SoLuong, DonGia, ThanhTien có thể NULL trong DB, xử lý nullable properties
                    cmd.Parameters.AddWithValue("@SoLuong", ctpn.SoLuongNhap);
                    cmd.Parameters.AddWithValue("@DonGia", ctpn.DonGiaNhap);
                    cmd.Parameters.AddWithValue("@ThanhTien", ctpn.ThanhTien);


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
                 //Logger.Log($"Lỗi khi thêm chi tiết hóa đơn: {ex.Message}\n{(ex.InnerException != null ? "Inner Exception: " + ex.InnerException.Message : "")}");

                // Tùy chọn: Ném lại lỗi để tầng gọi xử lý
                // throw;

                return false; // Trả về false nếu có lỗi xảy ra
            }
        }

        // lấy danh sách chi tiết phiếu nhập hàng theo mã phiếu nhập
        // GetChiTietPhieuNhapByMaPN
        public List<ChiTietPhieuNhapHang> GetChiTietPhieuNhapByMaPN(string maPN)
        {
            List<ChiTietPhieuNhapHang> listCTPN = new List<ChiTietPhieuNhapHang>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM ChiTietPhieuNhap WHERE MaPN = @MaPN";
                    cmd.Parameters.AddWithValue("@MaPN", maPN);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChiTietPhieuNhapHang chiTietPhieuNhap = new ChiTietPhieuNhapHang(
                                reader["MaPN"].ToString(),
                                reader["MaSP"].ToString(),
                                Convert.ToInt32(reader["SoLuongNhap"]),
                                Convert.ToDecimal(reader["DonGiaNhap"]),
                                Convert.ToDecimal(reader["ThanhTien"])
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi tiết phiếu nhập: " + ex.Message);
            }
            return listCTPN;
        }

        // lấy danh sách chi tiết phiếu nhập hàng theo mã phiếu nhập return ChiTietPhieuNhapHang
        public ChiTietPhieuNhapHang GetChiTietPhieuNhapByMaPNv2(string maPN)
        {
            ChiTietPhieuNhapHang chiTietPhieuNhap = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM ChiTietPhieuNhap WHERE MaPN = @MaPN";
                    cmd.Parameters.AddWithValue("@MaPN", maPN);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            chiTietPhieuNhap = new ChiTietPhieuNhapHang(
                                reader["MaPN"].ToString(),
                                reader["MaSP"].ToString(),
                                Convert.ToInt32(reader["SoLuongNhap"]),
                                Convert.ToDecimal(reader["DonGiaNhap"]),
                                Convert.ToDecimal(reader["ThanhTien"])
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách chi tiết phiếu nhập: " + ex.Message);
            }
            return chiTietPhieuNhap;
        }
        public DataTable LayDanhSachSanPham(string maPN)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT ct.MaPN, ct.MaSP, sp.TenSP, ct.SoLuongNhap, ct.DonGiaNhap, ct.ThanhTien 
                        FROM ChiTietPhieuNhap ct
                        INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
                        WHERE ct.MaPN = @MaPN";
                    cmd.Parameters.AddWithValue("@MaPN", maPN);
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
