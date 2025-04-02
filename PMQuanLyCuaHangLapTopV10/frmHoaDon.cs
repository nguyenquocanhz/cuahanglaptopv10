using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
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
    public partial class frmHoaDon: Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
            InitializeForm();
        }
        private void InitializeForm()
        {
            // Form Layout
            this.Text = "Quản Lý Hóa Đơn";
            this.Size = new System.Drawing.Size(800, 600);

            // Mã Hóa Đơn
            Label lblMaHD = new Label
            {
                Text = "Mã Hóa Đơn:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };
            TextBox txtMaHD = new TextBox
            {
                Location = new System.Drawing.Point(150, 20),
                Width = 200,
                ReadOnly = true
            };

            // Ngày Tạo
            Label lblNgayTao = new Label
            {
                Text = "Ngày Tạo:",
                Location = new System.Drawing.Point(20, 50),
                AutoSize = true
            };
            DateTimePicker dtpNgayTao = new DateTimePicker
            {
                Location = new System.Drawing.Point(150, 50),
                Width = 200,
                Value = DateTime.Now
            };
            dtpNgayTao.Format = DateTimePickerFormat.Custom;
            dtpNgayTao.CustomFormat = "dd/MM/yyyy";
            // Mã Nhân Viên
            Label lblMaNV = new Label
            {
                Text = "Mã Nhân Viên:",
                Location = new System.Drawing.Point(20, 80),
                AutoSize = true
            };
            TextBox txtMaNV = new TextBox
            {
                Location = new System.Drawing.Point(150, 80),
                Width = 200
            };

            // Thông Tin Khách Hàng
            GroupBox gbKhachHang = new GroupBox
            {
                Text = "Thông Tin Khách Hàng",
                Location = new System.Drawing.Point(20, 120),
                Size = new System.Drawing.Size(400, 150)
            };

            Label lblMaKH = new Label
            {
                Text = "Mã Khách Hàng:",
                Location = new System.Drawing.Point(10, 20),
                AutoSize = true
            };
            TextBox txtMaKH = new TextBox
            {
                Location = new System.Drawing.Point(150, 20),
                Width = 200,
                ReadOnly = true
            };

            Label lblTenKH = new Label
            {
                Text = "Tên Khách Hàng:",
                Location = new System.Drawing.Point(10, 50),
                AutoSize = true
            };
            TextBox txtTenKH = new TextBox
            {
                Location = new System.Drawing.Point(150, 50),
                Width = 200
            };

            Label lblSDT = new Label
            {
                Text = "Số Điện Thoại:",
                Location = new System.Drawing.Point(10, 80),
                AutoSize = true
            };
            TextBox txtSDT = new TextBox
            {
                Location = new System.Drawing.Point(150, 80),
                Width = 200
            };

            Label lblDiaChi = new Label
            {
                Text = "Địa Chỉ:",
                Location = new System.Drawing.Point(10, 110),
                AutoSize = true
            };
            TextBox txtDiaChi = new TextBox
            {
                Location = new System.Drawing.Point(150, 110),
                Width = 200
            };

            // Chi Tiết Hóa Đơn DataGridView
            DataGridView dgvChiTietHD = new DataGridView
            {
                Location = new System.Drawing.Point(20, 280),
                Size = new System.Drawing.Size(740, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            };

            // Columns for DataGridView
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Sản Phẩm",
                Name = "MaSP"
            });
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Sản Phẩm",
                Name = "TenSP"
            });
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn Giá",
                Name = "DonGia"
            });
            dgvChiTietHD.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Lượng",
                Name = "SoLuong"
            });

            // Buttons
            Button btnThemSP = new Button
            {
                Text = "Thêm Sản Phẩm",
                Location = new System.Drawing.Point(470, 250),
                Width = 120
            };
            btnThemSP.Click += (sender, e) => ThemSanPham(dgvChiTietHD);

            Button btnLuuHD = new Button
            {
                Text = "Lưu Hóa Đơn",
                Location = new System.Drawing.Point(600, 250),
                Width = 120
            };
            btnLuuHD.Click += (sender, e) => LuuHoaDon(txtMaHD, dtpNgayTao, txtMaNV, txtMaKH, txtTenKH, txtSDT, txtDiaChi, dgvChiTietHD);

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                lblMaHD, txtMaHD, lblNgayTao, dtpNgayTao, lblMaNV, txtMaNV,
                gbKhachHang, btnThemSP, btnLuuHD, dgvChiTietHD
            });

            gbKhachHang.Controls.AddRange(new Control[]
            {
                lblMaKH, txtMaKH, lblTenKH, txtTenKH,
                lblSDT, txtSDT, lblDiaChi, txtDiaChi
            });

            // Auto-generate Mã HĐ and Mã KH
            txtMaHD.Text = GenerateMaHoaDon();
            txtMaKH.Text = GenerateMaKhachHang();
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
    }
}
