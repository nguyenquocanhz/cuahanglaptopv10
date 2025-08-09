using PMQuanLyCuaHangLapTopV10.DatabaseHelpers;
using PMQuanLyCuaHangLapTopV10.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmThemHoaDon : Form
    {
        public SanPhamDAO SanPhamDAO = new SanPhamDAO();
        public KhachHangDAO khachHangDAO = new KhachHangDAO();
        public NhanVienDAO nhanVienDAO = new NhanVienDAO();
        private ListBox lbxGoiY;
        private DataTable dtChiTietHoaDon = new DataTable(); // <--- Khai báo DataTable cho DataGridView
        public Helpers helpers = new Helpers();
        // Đổi kiểu dữ liệu
        public int tongTienPhaiTra = 0;
        public int tongTienTT = 0;
        public int tienKhachDua = 0;
        public int tienThua = 0;
        public string MaNV = SessionManager.getMaNV();

        public bool isUseGiftcode = false; // Biến kiểm tra có sử dụng mã khuyến mãi hay không

        // Biến để lưu thông tin khuyến mãi đang áp dụng
        private KhuyenMai khuyenMaiDangApDung = null;

        public frmThemHoaDon()
        {
            InitializeComponent();
            InitializeDataGridView(); // Initialize DataGridView
            InitializeAutoComplete();
            InitializeGoiYListBox(); // Initialize suggestion ListBox properly
        }

        public frmThemHoaDon(string MaKH, string sdtnv)
        {
            InitializeComponent();

            InitializeDataGridView(); // Initialize DataGridView
            InitializeAutoComplete();
            InitializeGoiYListBox(); // Initialize suggestion ListBox properly

            try
            {
                KhachHang infoKH = khachHangDAO.GetKhachHangById(MaKH);
                NhanVien infoNV = nhanVienDAO.GetNhanVienBySoDienThoai(sdtnv);

                if (infoNV != null)
                    txtMaNV.Text = infoNV.MaNV;

                if (infoKH != null)
                {
                    txtMaKH.Text = infoKH.MaKhachHang;
                    txtTenKH.Text = infoKH.HoTen;
                    txtSDT.Text = infoKH.SoDienThoai;
                }

                txtMaHoaDon.Text = helpers.RandomHDHienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add method to initialize DataGridView
        private void InitializeDataGridView()
        {
            try
            {
                // Initialize DataTable for DataGridView if it doesn't exist
                if (dtChiTietHoaDon == null)
                {
                    dtChiTietHoaDon = new DataTable();
                }

                // Add columns to DataTable if they don't exist
                if (dtChiTietHoaDon.Columns.Count == 0)
                {
                    dtChiTietHoaDon.Columns.Add("colMaSP", typeof(string));
                    dtChiTietHoaDon.Columns.Add("colTenSP", typeof(string));
                    dtChiTietHoaDon.Columns.Add("colDonGia", typeof(string));
                    dtChiTietHoaDon.Columns.Add("colSoLuong", typeof(int));
                    dtChiTietHoaDon.Columns.Add("colThanhTien", typeof(string));
                }

                // Ensure DataGridView has needed columns
                if (dgvChiTietHoaDon.Columns.Count == 0)
                {
                    // Add columns to DataGridView if needed
                    DataGridViewTextBoxColumn colMaSP = new DataGridViewTextBoxColumn();
                    colMaSP.Name = "colMaSP";
                    colMaSP.HeaderText = "Mã SP";
                    dgvChiTietHoaDon.Columns.Add(colMaSP);

                    DataGridViewTextBoxColumn colTenSP = new DataGridViewTextBoxColumn();
                    colTenSP.Name = "colTenSP";
                    colTenSP.HeaderText = "Tên sản phẩm";
                    colTenSP.Width = 200;
                    dgvChiTietHoaDon.Columns.Add(colTenSP);

                    DataGridViewTextBoxColumn colDonGia = new DataGridViewTextBoxColumn();
                    colDonGia.Name = "colDonGia";
                    colDonGia.HeaderText = "Đơn giá";
                    dgvChiTietHoaDon.Columns.Add(colDonGia);

                    DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
                    colSoLuong.Name = "colSoLuong";
                    colSoLuong.HeaderText = "Số lượng";
                    dgvChiTietHoaDon.Columns.Add(colSoLuong);

                    DataGridViewTextBoxColumn colThanhTien = new DataGridViewTextBoxColumn();
                    colThanhTien.Name = "colThanhTien";
                    colThanhTien.HeaderText = "Thành tiền";
                    dgvChiTietHoaDon.Columns.Add(colThanhTien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo DataGridView: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add method to initialize GoiY ListBox properly
        private void InitializeGoiYListBox()
        {
            try
            {
                // Only create the ListBox if it doesn't exist
                if (lbxGoiY == null)
                {
                    lbxGoiY = new ListBox();
                    lbxGoiY.Visible = false;
                    lbxGoiY.Location = new Point(txtTenOrMaSP.Left, txtTenOrMaSP.Bottom);
                    lbxGoiY.Width = txtTenOrMaSP.Width;
                    lbxGoiY.Height = 120;
                    lbxGoiY.BorderStyle = BorderStyle.FixedSingle;
                    lbxGoiY.DoubleClick += LbxGoiY_DoubleClick;
                    lbxGoiY.KeyPress += LbxGoiY_KeyPress;

                    // Add to form controls
                    Controls.Add(lbxGoiY);
                    // Make sure it's in front of other controls
                    lbxGoiY.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo ListBox gợi ý: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeAutoComplete()
        {
            try
            {
                // Cấu hình AutoComplete cho TextBox
                txtTenOrMaSP.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtTenOrMaSP.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtTenOrMaSP.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo AutoComplete: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmThemHoaDon_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }

        private void LbxGoiY_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lbxGoiY.SelectedItem != null)
                {
                    string selectedSuggestion = lbxGoiY.SelectedItem.ToString();
                    txtTenOrMaSP.Text = selectedSuggestion; // Điền gợi ý đã chọn vào TextBox
                    lbxGoiY.Visible = false; // Ẩn ListBox

                    // Đặt con trỏ về cuối text hoặc chọn toàn bộ
                    txtTenOrMaSP.SelectionStart = txtTenOrMaSP.Text.Length;
                    txtTenOrMaSP.SelectionLength = 0;
                    txtTenOrMaSP.Focus(); // Trả lại focus cho TextBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn gợi ý: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LbxGoiY_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    LbxGoiY_DoubleClick(sender, e); // Giả lập chọn khi nhấn Enter
                    e.Handled = true;
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    lbxGoiY.Visible = false; // Ẩn ListBox khi nhấn Escape
                    txtTenOrMaSP.Focus();
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý phím: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTenOrMaSP_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtTenOrMaSP.Text.Trim();

            if (searchTerm.Length >= 2)
            {
                try
                {
                    // Lấy gợi ý sản phẩm
                    List<string> suggestions = SanPhamDAO.GetProductSuggestionsByTenOrMa(searchTerm) ?? new List<string>();

                    // Tạo AutoCompleteStringCollection mới
                    AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                    foreach (string suggestion in suggestions)
                    {
                        // Kiểm tra null trước khi thêm vào autoComplete
                        if (!string.IsNullOrEmpty(suggestion))
                        {
                            autoComplete.Add(suggestion);
                        }
                    }

                    // Thiết lập lại AutoComplete cho TextBox
                    txtTenOrMaSP.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtTenOrMaSP.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtTenOrMaSP.AutoCompleteCustomSource = autoComplete;
                }
                catch (Exception ex)
                {
                    // Ghi log chi tiết hơn
                    Console.WriteLine("Lỗi trong txtTenOrMaSP_TextChanged: " + ex.Message);
                    Console.WriteLine("Stack trace: " + ex.StackTrace);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string searchInput = txtTenOrMaSP.Text.Trim();

            if (string.IsNullOrEmpty(searchInput))
            {
                MessageBox.Show("Vui lòng nhập Mã hoặc Tên sản phẩm để tìm kiếm.", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                DataRow productRow = SanPhamDAO.GetDataList(searchInput);

                if (productRow != null)
                {
                    string maSP = productRow["MaSP"].ToString();
                    string tenSP = productRow["TenSP"].ToString();
                    int donGia = Convert.ToInt32(productRow["giaBan"]);

                    bool daTonTai = false;

                    foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
                    {
                        if (row.Cells["colMaSP"].Value != null && row.Cells["colMaSP"].Value.ToString() == maSP)
                        {
                            int soLuongHienTai = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                            soLuongHienTai++;
                            int amount = soLuongHienTai * donGia;
                            row.Cells["colSoLuong"].Value = soLuongHienTai;
                            row.Cells["colThanhTien"].Value = helpers.FormatNumber(amount.ToString());
                            daTonTai = true;
                            break;
                        }
                    }

                    if (!daTonTai)
                    {
                        int soLuong = 1;
                        int thanhTien = soLuong * donGia;
                        dgvChiTietHoaDon.Rows.Add(maSP, tenSP, helpers.FormatNumber(donGia.ToString()), soLuong, helpers.FormatNumber(thanhTien.ToString()));
                    }

                    TinhTongTien();
                    txtTenOrMaSP.Clear();
                    txtTenOrMaSP.Focus();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm với mã hoặc tên đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int TinhTienPhaiTra()
        {
            return tienKhachDua - tongTienPhaiTra; // Changed from tongTienTT to tongTienPhaiTra to account for discounts
        }

        // Hàm tính tổng tiền
        private void TinhTongTien()
        {
            try
            {
                tongTienTT = 0; // Reset lại trước khi tính

                if (dgvChiTietHoaDon != null && dgvChiTietHoaDon.Rows != null)
                {
                    foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
                    {
                        if (row.Cells["colThanhTien"].Value != null)
                        {
                            try
                            {
                                tongTienTT += helpers.ParseNumber(row.Cells["colThanhTien"].Value.ToString());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Lỗi khi tính tổng tiền: " + ex.Message);
                            }
                        }
                    }
                }

                // Áp dụng lại khuyến mãi nếu có
                ApDungLaiKhuyenMai();

                // Cập nhật tiền thừa nếu khách đã đưa tiền
                if (tienKhachDua > 0)
                {
                    tienThua = TinhTienPhaiTra();
                    UpdateTienThoiDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tổng tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm áp dụng lại khuyến mãi khi tổng tiền thay đổi
        private void ApDungLaiKhuyenMai()
        {
            try
            {
                // Cập nhật mặc định trước
                tongTienPhaiTra = tongTienTT;

                if (txtTongTienTT != null)
                    txtTongTienTT.Text = helpers.FormatNumber(tongTienTT.ToString());

                // Nếu đang có khuyến mãi, áp dụng lại
                if (khuyenMaiDangApDung != null)
                {
                    int giamGia = 0;

                    if (khuyenMaiDangApDung.LoaiKM.ToLower() == "phantram")
                    {
                        // Giảm theo phần trăm (giá trị từ 0-100)
                        decimal phanTramGiam = khuyenMaiDangApDung.GiaTriKM;
                        giamGia = (int)Math.Round(tongTienTT * (phanTramGiam / 100.0m));
                    }
                    else if (khuyenMaiDangApDung.LoaiKM.ToLower() == "trigia")
                    {
                        // Giảm theo giá trị cố định (từ 0-500,000,000)
                        giamGia = Convert.ToInt32(khuyenMaiDangApDung.GiaTriKM);
                    }

                    // Đảm bảo số tiền giảm không vượt quá tổng tiền
                    if (giamGia > tongTienTT)
                    {
                        giamGia = tongTienTT;
                    }

                    tongTienPhaiTra = tongTienTT - giamGia;

                    // Cập nhật hiển thị tiền giảm
                    if (txtTienGiam != null)
                        txtTienGiam.Text = helpers.FormatNumber(giamGia.ToString()) + " đ";
                }

                // Cập nhật hiển thị tổng tiền phải trả
                if (txtTongTien != null)
                    txtTongTien.Text = helpers.FormatNumber(tongTienPhaiTra.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi áp dụng khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVeryKM_Click(object sender, EventArgs e)
        {
            try
            {
                KhuyenMaiDAO khuyenMaiDAO = new KhuyenMaiDAO();
                string giftcode = txtMaKM.Text.Trim();

                if (string.IsNullOrEmpty(giftcode))
                {
                    MessageBox.Show("Vui lòng nhập mã giảm giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                KhuyenMai infoKM = khuyenMaiDAO.GetKhuyenMaiByGiftcode(giftcode);

                if (infoKM != null)
                {
                    if (infoKM.giftcode.ToLower() == giftcode.ToLower())
                    {
                        // Áp dụng giảm giá vào tổng tiền
                        if (infoKM.statuskm == "Đang áp dụng")
                        {
                            // Kiểm tra đã hết hạn chưa
                            if (DateTime.Now <= infoKM.ngayKetThuc)
                            {
                                int giamGia = 0;
                                string thongBaoGiamGia = "";

                                // Kiểm tra loại giảm giá (phần trăm hoặc giá trị cố định)
                                if (infoKM.LoaiKM.ToLower() == "phantram")
                                {
                                    // Giảm theo phần trăm (giá trị từ 0-100)
                                    decimal phanTramGiam = infoKM.GiaTriKM;
                                    giamGia = (int)Math.Round(tongTienTT * (phanTramGiam / 100.0m));
                                    thongBaoGiamGia = $"Giảm {phanTramGiam}%";
                                }
                                else if (infoKM.LoaiKM.ToLower() == "trigia")
                                {
                                    // Giảm theo giá trị cố định (từ 0-500,000,000)
                                    giamGia = Convert.ToInt32(infoKM.GiaTriKM);
                                    thongBaoGiamGia = $"Giảm {helpers.FormatNumber(giamGia.ToString())} đ";
                                }

                                // Đảm bảo số tiền giảm không vượt quá tổng tiền
                                if (giamGia > tongTienTT)
                                {
                                    giamGia = tongTienTT;
                                }

                                MessageBox.Show($"Áp dụng mã giảm giá thành công! {thongBaoGiamGia}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtMaKM.ReadOnly = true; // Vô hiệu hóa mã giảm giá sau khi áp dụng
                                btnVeryKM.Enabled = false; // Vô hiệu hóa nút áp dụng mã giảm giá

                                // Lưu khuyến mãi đang áp dụng
                                khuyenMaiDangApDung = infoKM;

                                // Tính lại tổng tiền phải trả sau khi áp dụng khuyến mãi
                                tongTienPhaiTra = tongTienTT - giamGia;

                                // Cập nhật hiển thị
                                txtTongTien.Text = helpers.FormatNumber(tongTienPhaiTra.ToString());
                                txtTienGiam.Text = helpers.FormatNumber(giamGia.ToString()) + " đ";
                            }
                            else
                            {
                                MessageBox.Show("Mã giảm giá đã hết hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã giảm giá không còn hiệu lực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã giảm giá không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Mã giảm giá không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi kiểm tra mã giảm giá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTienThoiDisplay()
        {
            try
            {
                if (txtTienGiam != null)
                {
                    if (tienThua < 0)
                    {
                        txtTienGiam.Text = "Khách đưa thiếu!";
                        txtTienGiam.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtTienGiam.Text = helpers.FormatNumber(tienThua.ToString()) + " đ";
                        txtTienGiam.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật tiền thối: " + ex.Message);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTongTien != null && !string.IsNullOrEmpty(txtTongTien.Text) &&
                    txtMaHoaDon != null && !string.IsNullOrEmpty(txtMaHoaDon.Text))
                {
                    frmThanhToan thanhToan = new frmThanhToan(Convert.ToDecimal(helpers.ParseNumber(txtTongTien.Text.Trim())), txtMaHoaDon.Text);
                    thanhToan.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            HoaDonDAO hoaDonDAO = new HoaDonDAO();
            // Kiểm tra xem có sản phẩm nào trong hóa đơn không
            if (dgvChiTietHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào hóa đơn trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra số lượng tồn kho của từng sản phẩm
            bool duHang = true;
            string sanPhamHetHang = "";
            foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
            {
                string maSP = row.Cells["colMaSP"].Value.ToString();
                int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                int soLuongTonKho = sanPhamDAO.GetSoLuongTonKho(maSP);
                if (soLuong > soLuongTonKho)
                {
                    duHang = false;
                    sanPhamHetHang += $"{maSP} ({soLuongTonKho})\n";
                }
            }
            // Nếu có sản phẩm hết hàng, hiển thị thông báo và dừng lại
            if (!duHang)
            {
                MessageBox.Show($"Một số sản phẩm không đủ số lượng trong kho:\n{sanPhamHetHang}",
                    "Hàng không đủ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //string maHd = txtMaHoaDon.Text.Trim();
            // Nếu đủ hàng, tiếp tục xử lý lưu hóa đơn
            string maHdHienThi = txtMaHoaDon.Text.Trim();
            string maKhachHang = txtMaKH.Text.Trim();
            string maNV = txtMaNV.Text.Trim();
            DateTime ngayLapHD = DateTime.Now;
            decimal tongTien = Convert.ToDecimal(helpers.ParseNumber(txtTongTien.Text.Trim()));


            HoaDon hd = new HoaDon
            {
                ngayTao = DateTime.Now,
                tongTienTT = tongTien,
                ghiChu = null,
                MaKH = int.TryParse(txtMaKH.Text, out int makh) ? makh : (int?)null,
                MaNV = int.TryParse(txtMaNV.Text, out int manv) ? manv : (int?)null,
                MaHDHienThi = txtMaHoaDon.Text
            };

            ChiTiethdDAO ctHDdao = new ChiTiethdDAO();
            // Check hàng còn hay không số lượng >= 1 dựa vào isConHang
            // Lưu hóa đơn vào CSDL và lấy ID
            int maHD = hoaDonDAO.InsertHD(hd);
            if (maHD != -1)
            {

                MessageBox.Show($"Lưu hóa đơn thành công với mã hóa đơn: {maHD}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Lưu chi tiết hóa đơn
                foreach (DataGridViewRow row in dgvChiTietHoaDon.Rows)
                {
                    string maSP = row.Cells["colMaSP"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    decimal donGia = Convert.ToDecimal(helpers.ParseNumber(row.Cells["colDonGia"].Value.ToString()));
                    decimal thanhTien = Convert.ToDecimal(helpers.ParseNumber(row.Cells["colThanhTien"].Value.ToString()));
                    // Cập nhật số lượng tồn kho
                    sanPhamDAO.UpdateSoLuong(maSP, soLuong);

                    ChiTietHD chiTietHD = new ChiTietHD(
                        maHD,
                        int.Parse(maSP),
                        soLuong,
                        donGia,
                        thanhTien
                    );
                    // Lưu chi tiết hóa đơn vào CSDL
                    //MessageBox.Show($"Lưu chi tiết hóa đơn thành công: {chiTietHD.ToString()}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bool isLuuCTHD = ctHDdao.InsertCTHD(chiTietHD);
                    if (!isLuuCTHD)
                    {
                        MessageBox.Show($"Lưu chi tiết hóa đơn không thành công cho sản phẩm {maSP}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

            }

            MessageBox.Show("Lưu hóa đơn thành công !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            ResetForm();
            // check có sử dụng mã khuyến mãi không

        }
        private void ResetForm()
        {
            // Xóa danh sách sản phẩm
            dgvChiTietHoaDon.Rows.Clear();

            // Reset các trường thông tin
            txtMaHoaDon.Text = helpers.RandomHDHienThi();
            txtTenOrMaSP.Clear();
            txtTongTienTT.Text = "0";
            txtTongTien.Text = "0";
            txtTienGiam.Text = "0 đ";

            // Reset thông tin khuyến mãi
            txtMaKM.Clear();
            txtMaKM.ReadOnly = false;
            btnVeryKM.Enabled = true;
            khuyenMaiDangApDung = null;

            // Reset các biến tính toán
            tongTienTT = 0;
            tongTienPhaiTra = 0;
            tienKhachDua = 0;
            tienThua = 0;

            // Focus vào trường nhập sản phẩm
            txtTenOrMaSP.Focus();
        }

        private void menu_thaotac_Opening(object sender, CancelEventArgs e)
        {

        }

        private void act_delete_Click(object sender, EventArgs e)
        {
            dgvChiTietHoaDon.Rows.Remove(dgvChiTietHoaDon.CurrentRow);
            TinhTongTien();
        }

        private void dgvChiTietHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChiTietHoaDon.Columns[e.ColumnIndex].HeaderText == "Số lượng")
            {
                // Get the new value
                int soLuong = Convert.ToInt32(dgvChiTietHoaDon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                // Get the price from the "colDonGia" column
                int donGia = helpers.ParseNumber(dgvChiTietHoaDon.Rows[e.RowIndex].Cells["colDonGia"].Value.ToString());
                // Calculate the new total price
                int thanhTien = soLuong * donGia;
                // Update the "colThanhTien" column
                dgvChiTietHoaDon.Rows[e.RowIndex].Cells["colThanhTien"].Value = helpers.FormatNumber(thanhTien.ToString());
                // Recalculate the total amount
                TinhTongTien();
            }
        }
    }
}
