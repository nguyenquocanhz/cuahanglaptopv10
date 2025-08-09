using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10.Models
{
    public class PhieuNhapDAO
    {
        public PhieuNhapDAO()
        {
            // Constructor logic here
        }

        public int InsertPN(infoPhieuNhapHang phieuNhapHang)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // CommandText: thêm OUTPUT để lấy ID vừa tạo
                    cmd.CommandText = @"INSERT INTO PhieuNhapHang (tongTienNhap, ngayLapPhieu, MaNCC, MaPNHienThi, MaNV)
                                VALUES (@tongTienTT, @ngayTao, @MaNCC, @MaPNHienThi, @MaNV);
                                SELECT SCOPE_IDENTITY();";

                    // Parameters
                    cmd.Parameters.AddWithValue("@tongTienTT", phieuNhapHang.TongTienNhap);
                    cmd.Parameters.AddWithValue("@ngayTao", phieuNhapHang.NgayLap);
                    cmd.Parameters.AddWithValue("@MaNCC", phieuNhapHang.MaNCC);
                    cmd.Parameters.AddWithValue("@MaNV", phieuNhapHang.MaNV);
                    cmd.Parameters.AddWithValue("@MaPNHienThi", string.IsNullOrEmpty(phieuNhapHang.MaPNHienThi) ? (object)DBNull.Value : phieuNhapHang.MaPNHienThi);

                    conn.Open();

                    // ExecuteScalar trả về giá trị từ câu lệnh SELECT SCOPE_IDENTITY()
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }

                    return -1; // Trả về -1 nếu không lấy được ID
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                // Có thể ghi log lỗi ở đây
                // Logger.Log("Lỗi khi thêm hóa đơn: " + ex.Message);
                return -1;
            }
        }
        // Phương thức này sẽ lấy tất cả các phiếu nhập hàng từ cơ sở dữ liệu 
        public List<infoPhieuNhapHang> GetAllPhieuNhap()
        {
            List<infoPhieuNhapHang> phieuNhaps = new List<infoPhieuNhapHang>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM PhieuNhapHang";
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            infoPhieuNhapHang phieuNhap = new infoPhieuNhapHang(
                                reader["MaPNHienThi"].ToString(),
                                reader["MaNCC"].ToString(),
                                reader["MaNV"].ToString(),
                                Convert.ToDateTime(reader["ngayLapPhieu"]),
                                Convert.ToDecimal(reader["tongTienNhap"]),
                                reader["MaPNHienThi"].ToString()
                            );
                            phieuNhaps.Add(phieuNhap);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách phiếu nhập: " + ex.Message);
            }
            return phieuNhaps;
        }
        // lấy phiếu nhập theo mã nhà cung cấp
        public List<infoPhieuNhapHang> GetPhieuNhapByNCC(string maNCC)
        {
            List<infoPhieuNhapHang> phieuNhaps = new List<infoPhieuNhapHang>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM PhieuNhapHang WHERE MaNCC = @MaNCC";
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            infoPhieuNhapHang phieuNhap = new infoPhieuNhapHang(
                                reader["MaPN"].ToString(),
                                reader["MaNCC"].ToString(),
                                reader["MaNV"].ToString(),
                                Convert.ToDateTime(reader["ngayLapPhieu"]),
                                Convert.ToDecimal(reader["tongTienNhap"]),
                                reader["MaPNHienThi"].ToString()
                            );
                            phieuNhaps.Add(phieuNhap);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách phiếu nhập theo nhà cung cấp: " + ex.Message);
            }
            return phieuNhaps;
        }

        // get phiếu nhập theo mã phiếu nhập
        public infoPhieuNhapHang GetPhieuNhapByMaPN(string maPN)
        {
            infoPhieuNhapHang phieuNhap = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM PhieuNhapHang WHERE MaPN = @MaPN";
                    cmd.Parameters.AddWithValue("@MaPN", maPN);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            phieuNhap = new infoPhieuNhapHang(
                                reader["MaPN"].ToString(),
                                reader["MaNCC"].ToString(),
                                reader["MaNV"].ToString(),
                                Convert.ToDateTime(reader["ngayLapPhieu"]),
                                Convert.ToDecimal(reader["tongTienNhap"]),
                                reader["MaPNHienThi"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy phiếu nhập theo mã: " + ex.Message);
            }
            return phieuNhap;
        }
        public int TongCPNhap()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT SUM(tongTienNhap) FROM PhieuNhapHang";
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0; // Trả về 0 nếu không có dữ liệu
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tính tổng chi phí nhập: " + ex.Message);
                return 0;
            }
        }
    }
}
