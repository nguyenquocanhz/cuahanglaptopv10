using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using PMQuanLyCuaHangLapTopV10.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmHoaDon: Form
    {
        private readonly Logger _logger = new Logger();

        private readonly HoaDonDAO _hoaDonDAO;
        private readonly NhanVienDAO _nhanVienDAO;
        private readonly PhieuNhapDAO _phieuNhapDAO;
        public frmHoaDon()
        {
            InitializeComponent();
            //InitializeForm();
            _hoaDonDAO = new HoaDonDAO();
            _nhanVienDAO = new NhanVienDAO();
            _phieuNhapDAO = new PhieuNhapDAO();
        }
        private void ThemSanPham(DataGridView dgv)
        {
            // Form nhập thông tin sản phẩm
            Form frmNhapSP = new Form
            {
                Text = "Thêm Sản Phẩm",
                Size = new System.Drawing.Size(400, 300)
            };

            Label lblMaSP = new Label { Text = "Mã Sản Phẩm:", Location = new System.Drawing.Point(20, 20) };
            TextBox txtMaSP = new TextBox { Location = new System.Drawing.Point(150, 20), Width = 200 };

            Label lblTenSP = new Label { Text = "Tên Sản Phẩm:", Location = new System.Drawing.Point(20, 50) };
            TextBox txtTenSP = new TextBox { Location = new System.Drawing.Point(150, 50), Width = 200 };

            Label lblDonGia = new Label { Text = "Đơn Giá:", Location = new System.Drawing.Point(20, 80) };
            NumericUpDown nudDonGia = new NumericUpDown
            {
                Location = new System.Drawing.Point(150, 80),
                Width = 200,
                Minimum = 0,
                Maximum = 1000000,
                DecimalPlaces = 0
            };

            Label lblSoLuong = new Label { Text = "Số Lượng:", Location = new System.Drawing.Point(20, 110) };
            NumericUpDown nudSoLuong = new NumericUpDown
            {
                Location = new System.Drawing.Point(150, 110),
                Width = 200,
                Minimum = 1,
                Maximum = 1000
            };

            Button btnXacNhan = new Button
            {
                Text = "Xác Nhận",
                Location = new System.Drawing.Point(150, 200),
                DialogResult = DialogResult.OK
            };

            frmNhapSP.Controls.AddRange(new Control[]
            {
                lblMaSP, txtMaSP, lblTenSP, txtTenSP,
                lblDonGia, nudDonGia, lblSoLuong, nudSoLuong, btnXacNhan
            });

            if (frmNhapSP.ShowDialog() == DialogResult.OK)
            {
                dgv.Rows.Add(txtMaSP.Text, txtTenSP.Text, nudDonGia.Value, nudSoLuong.Value);
            }
        }

        private void LuuHoaDon(TextBox txtMaHD, DateTimePicker dtpNgayTao,
            TextBox txtMaNV, TextBox txtMaKH, TextBox txtTenKH,
            TextBox txtSDT, TextBox txtDiaChi, DataGridView dgvChiTietHD)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DBconnection.strConnection))
                {
                    conn.Open();

                    // Lưu thông tin khách hàng
                    string queryKH = @"
                        INSERT INTO KhachHang (HoTenKH, soDienThoai, diaChiKH) 
                        VALUES (@MaKH, @TenKH, @SDT, @DiaChi)";

                    using (SqlCommand cmdKH = new SqlCommand(queryKH, conn))
                    {
                        cmdKH.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                        cmdKH.Parameters.AddWithValue("@SDT", txtSDT.Text);
                        cmdKH.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        cmdKH.ExecuteNonQuery();
                    }

                    // Lưu thông tin hóa đơn
                    string queryHD = @"
                        INSERT INTO HoaDon (NgayTao, MaNV, MaKH) 
                        VALUES (@NgayTao, @MaNV, @MaKH)";

                    using (SqlCommand cmdHD = new SqlCommand(queryHD, conn))
                    {
                        cmdHD.Parameters.AddWithValue("@NgayTao", dtpNgayTao.Value);
                        cmdHD.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                        cmdHD.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                        cmdHD.ExecuteNonQuery();
                    }

                    // Lưu chi tiết hóa đơn
                    string queryCTHD = @"
                        INSERT INTO ChiTietHoaDon (MaHD, MaSP, TenSP, DonGia, SoLuong, ThanhTien) 
                        VALUES (@MaHD, @MaSP, @TenSP, @DonGia, @SoLuong, @DonGia * @SoLuong);";

                    foreach (DataGridViewRow row in dgvChiTietHD.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            using (SqlCommand cmdCTHD = new SqlCommand(queryCTHD, conn))
                            {
                                cmdCTHD.Parameters.AddWithValue("@MaHD", txtMaHD.Text);
                                cmdCTHD.Parameters.AddWithValue("@MaSP", row.Cells["MaSP"].Value);
                                cmdCTHD.Parameters.AddWithValue("@TenSP", row.Cells["TenSP"].Value);
                                cmdCTHD.Parameters.AddWithValue("@DonGia", row.Cells["DonGia"].Value);
                                cmdCTHD.Parameters.AddWithValue("@SoLuong", row.Cells["SoLuong"].Value);
                                
                                cmdCTHD.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Lưu hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateMaHoaDon()
        {
            // Logic sinh mã hóa đơn tự động
            // Ví dụ: HD + năm hiện tại + số thứ tự
            return $"HD{DateTime.Now.Year}{DateTime.Now.Month:D2}{GetNextHoaDonSequence():D4}";
        }

        private string GenerateMaKhachHang()
        {
            // Logic sinh mã khách hàng tự động
            // Ví dụ: KH + năm hiện tại + số thứ tự
            return $"KH{DateTime.Now.Year}{DateTime.Now.Month:D2}{GetNextKhachHangSequence():D4}";
        }

        private int GetNextHoaDonSequence()
        {
            // Trong thực tế, bạn sẽ truy vấn CSDL để lấy số thứ tự tiếp theo
            // Đây là một ví dụ đơn giản
            return 1;
        }

        private int GetNextKhachHangSequence()
        {
            // Trong thực tế, bạn sẽ truy vấn CSDL để lấy số thứ tự tiếp theo
            // Đây là một ví dụ đơn giản
            return 1;
        }
        private void frmHoaDon_Load(object sender, System.EventArgs e)
        {
            // Khởi tạo dữ liệu và hiển thị danh sách hóa đơn
            if (SessionManager.Role == "Staff")
            {
                LoadHoaDonDataV1();
                return;
            }
            LoadHoaDonData();
        }
        private void LoadHoaDonData()
        {
            // Tải dữ liệu hóa đơn từ cơ sở dữ liệu và hiển thị lên DataGridView
            HoaDonDAO hoaDon = new HoaDonDAO();

            DataTable tbHoaDon = hoaDon.GetDTHoaDon();
            ConfigureDataGridView(tbHoaDon);


        }
        private void LoadHoaDonDataV1()
        {
            // Tải dữ liệu hóa đơn từ cơ sở dữ liệu và hiển thị lên DataGridView
            HoaDonDAO hoaDon = new HoaDonDAO();
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            NhanVien infoNV = nhanVienDAO.GetNhanVienBySoDienThoai(SessionManager.sodt);

            DataTable tbHoaDon = hoaDon.GetDTHoaDonByMaNV(infoNV.MaNV);
            ConfigureDataGridView(tbHoaDon);
        }

        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            // Xử lý tìm kiếm hóa đơn
            string maHD = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(maHD))
            {
                HoaDonDAO hoaDon = new HoaDonDAO();
                DataTable tbHoaDon;
                NhanVien infoNV = _nhanVienDAO.GetNhanVienBySoDienThoai(SessionManager.sodt);

                // Filter by user role
                if (SessionManager.Role.Equals("Staff", StringComparison.OrdinalIgnoreCase))
                {
                    tbHoaDon = _hoaDonDAO.TimKiemHoaDonByMaHDAnvMaNV(maHD, infoNV.MaNV);
                }
                else
                {
                    tbHoaDon = _hoaDonDAO.TimKiemHoaDon(maHD);
                }
                dgvHoaDon.DataSource = tbHoaDon;
            }
            else
            {
                if (SessionManager.Role.Equals("Staff", StringComparison.OrdinalIgnoreCase))
                {
                    LoadHoaDonDataV1(); // Nếu không có từ khóa tìm kiếm, tải lại hóa đơn của nhân viên
                }
                else
                {
                    LoadHoaDonData(); // Nếu không có từ khóa tìm kiếm, tải lại tất cả hóa đơn
                }
            }
        }

        private void btnXemChiTiet_Click(object sender, System.EventArgs e)
        {
            // Hiển thị form chi tiết hóa đơn
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                string maHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();
                frmChiTietHoaDon frm = new frmChiTietHoaDon(maHD);
                frm.ShowDialog();
            }
        }
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã đăng nhập chưa (nếu cần)
                Form frmThemHD = new Form();

                
                // Tạo form thêm hóa đơn mới
                //frmThemHoaDon frmThemHD = new frmThemHoaDon();

                // Truyền dữ liệu cần thiết sang form (nếu cần)
                // frmThemHD.MaNV = GlobalValues.currentUser.MaNV;

                // Hiển thị form dưới dạng dialog
                DialogResult result = frmThemHD.ShowDialog();

                // Xử lý kết quả trả về từ form thêm hóa đơn
                if (result == DialogResult.OK)
                {
                    // Nếu thêm hóa đơn thành công, cập nhật lại datagridview
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log lỗi nếu cần
                Logger logger = new Logger();
                logger.LogError("Lỗi khi mở form thêm hóa đơn: " + ex.Message);
            }
        }
        private void btnThem_Click(object sender, System.EventArgs e)
        {
            // Mở form thêm mới hóa đơn
            frmThemHoaDon formAddHd = new frmThemHoaDon();
            formAddHd.ShowDialog();
        }

        private void btnSua_Click(object sender, System.EventArgs e)
        {
            // Mở form sửa hóa đơn
        }

        private void btnXoa_Click(object sender, System.EventArgs e)
        {
            // Xử lý xóa hóa đơn
        }

        private void btnIn_Click(object sender, System.EventArgs e)
        {
            // Xử lý in hóa đơn
        }

        private void dgvHoaDon_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            // Xử lý khi double click vào một dòng trong datagridview
            btnXemChiTiet_Click(sender, e);
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            btnXemChiTiet_Click(sender, e);
        }

        private void xóaHóaĐơnToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            btnXoa_Click(sender, e);
        }

        private void btnTimKiemByDate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = dtpNgayBatDau.Value.Date;
                DateTime endDate = dtpNgayKetThuc.Value.Date;

                if (startDate > endDate)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable tbHoaDon;

                // Filter by user role
                if (SessionManager.Role.Equals("Staff", StringComparison.OrdinalIgnoreCase))
                {
                    NhanVien infoNV = _nhanVienDAO.GetNhanVienBySoDienThoai(SessionManager.sodt);
                    tbHoaDon = _hoaDonDAO.TimKiemHoaDonTheoDateVaMaNV(startDate, endDate, infoNV.MaNV);
                }
                else
                {
                    tbHoaDon = _hoaDonDAO.TimKiemHoaDonTheoDate(startDate, endDate);
                }
                if (tbHoaDon.Rows.Count > 0)
                {
                    dgvHoaDon.DataSource = tbHoaDon;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn trong khoảng thời gian này", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex, "Lỗi khi tìm kiếm hóa đơn theo ngày");
            }
        }
        private void HandleException(Exception ex, string message)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.LogError($"{message}: {ex.Message}\n{ex.StackTrace}");
        }
        private void menu_act_lap_pbh_Click(object sender, EventArgs e)
        {
            if(dgvHoaDon.SelectedRows.Count > 0)
            {
                string maHD = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();
                string[] jsonData = new string[3];
                jsonData[0] = maHD;
                jsonData[1] = dgvHoaDon.SelectedRows[0].Cells["MaNV"].Value.ToString();
                jsonData[2] = dgvHoaDon.SelectedRows[0].Cells["MaKH"].Value.ToString();
                frmBaoHanh formBaoHanh = new frmBaoHanh(jsonData);
                formBaoHanh.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để lập phiếu bảo hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCalcLoiNhuan_Click(object sender, EventArgs e)
        {
            // Tính toán lợi nhuận tháng
            HoaDonDAO hoaDon = new HoaDonDAO();
            PhieuNhapDAO phieuNhap = new PhieuNhapDAO();
            decimal doanhThu = hoaDon.DoanhThuThangNay();
            decimal chiPhi = phieuNhap.TongCPNhap();
            decimal loiNhuan = doanhThu - chiPhi;
            MessageBox.Show($"Lợi nhuận tháng này là: {loiNhuan.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"))}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Tính toán lợi nhuận theo ngày đã chọn
        }
        private void ConfigureDataGridView(DataTable dataSource)
        {
            dgvHoaDon.DataSource = dataSource;

            // Set column properties
            dgvHoaDon.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
            dgvHoaDon.Columns["ngayTao"].HeaderText = "Ngày Tạo";
            dgvHoaDon.Columns["tongTienTT"].HeaderText = "Tổng Tiền";
            dgvHoaDon.Columns["tongTienTT"].DefaultCellStyle.Format = "N0"; // Format currency
            dgvHoaDon.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvHoaDon.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            dgvHoaDon.Columns["ghiChu"].HeaderText = "Ghi Chú";
            dgvHoaDon.Columns["MaHDHienThi"].HeaderText = "Mã Hóa Đơn Hiển Thị";

            // Set column alignments
            dgvHoaDon.Columns["MaHD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.Columns["ngayTao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.Columns["tongTienTT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDon.Columns["MaNV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.Columns["MaKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDon.Columns["ghiChu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHoaDon.Columns["MaHDHienThi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set column read-only
            foreach (DataGridViewColumn column in dgvHoaDon.Columns)
            {
                column.ReadOnly = true;
            }

            // Set grid options
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.AllowUserToResizeRows = false;
            dgvHoaDon.AllowUserToResizeColumns = false;
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.MultiSelect = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ConfigureUIForAdminRole()
        {
            // Enable all buttons and features for admin
            // Additional admin-only UI configuration here
        }

        private void ConfigureUIForStaffRole()
        {
            // Disable admin-only features for staff
            // You can configure other restrictions here

            // Optionally hide buttons from staff
            // btnXoa.Visible = false;
            // btnCalcLoiNhuan.Visible = false;
        }
    }
}
