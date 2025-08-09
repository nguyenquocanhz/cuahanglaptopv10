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
    public partial class frmPhieuNhapHang : Form
    {
        public SanPhamDAO SanPhamDAO = new SanPhamDAO();
        public NhaCungCapDAO nhaCungCapDAO = new NhaCungCapDAO();
        public NhanVienDAO nhanVienDAO = new NhanVienDAO();
        private ListBox lbxGoiY;
        private DataTable dtChiTietPhieuNhap = new DataTable(); // <--- Khai báo DataTable cho DataGridView
        public Helpers helpers = new Helpers();

        // Đổi kiểu dữ liệu
        public int tongTienPhaiTra = 0;
        public int tongTienTT = 0;
        public int daThanhToan = 0;
        public int conNo = 0;
        public string MaNV = SessionManager.getMaNV();

        public frmPhieuNhapHang()
        {
            InitializeComponent();
            InitializeDataGridView(); // Initialize DataGridView
            InitializeAutoComplete();
            InitializeGoiYListBox(); // Initialize suggestion ListBox properly
        }

        public frmPhieuNhapHang(string[] jsonData)
        {
            InitializeComponent();

            InitializeDataGridView(); // Initialize DataGridView
            InitializeAutoComplete();
            InitializeGoiYListBox(); // Initialize suggestion ListBox properly

            try
            {
                NhaCungCap infoNCC = nhaCungCapDAO.GetNhaCungCapByIdv2(jsonData[0]);
                NhanVien infoNV = nhanVienDAO.GetNhanVienBySoDienThoai(jsonData[1]);

                if (infoNV != null)
                    txtMaNV.Text = infoNV.MaNV;

                if (infoNCC != null)
                {
                    txtMaNCC.Text = infoNCC.MaNCC;
                    txtTenNCC.Text = infoNCC.TenNCC;
                    txtSDT.Text = infoNCC.SoDienThoai;
                }

                txtMaPhieuNhap.Text = helpers.TaoMaPhieuTuDong("PN");
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
                if (dtChiTietPhieuNhap == null)
                {
                    dtChiTietPhieuNhap = new DataTable();
                }

                // Add columns to DataTable if they don't exist
                if (dtChiTietPhieuNhap.Columns.Count == 0)
                {
                    dtChiTietPhieuNhap.Columns.Add("colMaSP", typeof(string));
                    dtChiTietPhieuNhap.Columns.Add("colTenSP", typeof(string));
                    dtChiTietPhieuNhap.Columns.Add("colDonGia", typeof(string));
                    dtChiTietPhieuNhap.Columns.Add("colSoLuong", typeof(int));
                    dtChiTietPhieuNhap.Columns.Add("colThanhTien", typeof(string));
                }

                // Ensure DataGridView has needed columns
                if (dgvChiTietPhieuNhap.Columns.Count == 0)
                {
                    // Add columns to DataGridView if needed
                    DataGridViewTextBoxColumn colMaSP = new DataGridViewTextBoxColumn();
                    colMaSP.Name = "colMaSP";
                    colMaSP.HeaderText = "Mã SP";
                    dgvChiTietPhieuNhap.Columns.Add(colMaSP);

                    DataGridViewTextBoxColumn colTenSP = new DataGridViewTextBoxColumn();
                    colTenSP.Name = "colTenSP";
                    colTenSP.HeaderText = "Tên sản phẩm";
                    colTenSP.Width = 200;
                    dgvChiTietPhieuNhap.Columns.Add(colTenSP);

                    DataGridViewTextBoxColumn colDonGia = new DataGridViewTextBoxColumn();
                    colDonGia.Name = "colDonGia";
                    colDonGia.HeaderText = "Đơn giá nhập";
                    dgvChiTietPhieuNhap.Columns.Add(colDonGia);

                    DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
                    colSoLuong.Name = "colSoLuong";
                    colSoLuong.HeaderText = "Số lượng";
                    dgvChiTietPhieuNhap.Columns.Add(colSoLuong);

                    DataGridViewTextBoxColumn colThanhTien = new DataGridViewTextBoxColumn();
                    colThanhTien.Name = "colThanhTien";
                    colThanhTien.HeaderText = "Thành tiền";
                    dgvChiTietPhieuNhap.Columns.Add(colThanhTien);
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

        private void frmPhieuNhapHang_Load(object sender, EventArgs e)
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
                    List<string> suggestions = SanPhamDAO.GetProductSuggestionsByTenOrMa(searchTerm);

                    AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
                    autoComplete.AddRange(suggestions.ToArray());

                    txtTenOrMaSP.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtTenOrMaSP.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtTenOrMaSP.AutoCompleteCustomSource = autoComplete;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi gợi ý: " + ex.Message);
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

                // Nếu tìm thấy sản phẩm, hiển thị form nhập thông tin số lượng và giá nhập
                if (productRow != null)
                {
                    string maSP = productRow["MaSP"].ToString();
                    string tenSP = productRow["TenSP"].ToString();
                    int donGia = int.Parse(productRow["giaNhap"].ToString());
                    int thanhTien = donGia * 1; // Giả sử số lượng là 1
                    // Kiểm tra xem sản phẩm đã có trong danh sách chưa
                    bool daTonTai = false;
                    foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                    {
                        if (row.Cells["ColMaSP"].Value != null && row.Cells["ColMaSP"].Value.ToString() == maSP)
                        {
                            daTonTai = true;
                            row.Cells["ColSoLuong"].Value = Convert.ToInt32(row.Cells["ColSoLuong"].Value) + 1;
                            row.Cells["ColThanhTien"].Value = Convert.ToInt32(row.Cells["ColSoLuong"].Value) * donGia;
                            TinhTongTien();
                        }
                    }

                    if (!daTonTai)
                    {
                        dgvChiTietPhieuNhap.Rows.Add(maSP, tenSP, donGia, 1, thanhTien);
                        TinhTongTien();
                        txtTenOrMaSP.Clear();
                        txtTenOrMaSP.Focus();
                    }
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

        public int TinhTienConNo()
        {
            return tongTienPhaiTra - daThanhToan;
        }

        // Hàm tính tổng tiền
        private void TinhTongTien()
        {
            try
            {
                tongTienTT = 0; // Reset lại trước khi tính

                if (dgvChiTietPhieuNhap != null && dgvChiTietPhieuNhap.Rows != null)
                {
                    foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
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

                // Cập nhật tổng tiền phải trả
                tongTienPhaiTra = tongTienTT;

                // Cập nhật hiển thị
                if (txtTongGiaNhap != null)
                    txtTongGiaNhap.Text = helpers.FormatNumber(tongTienTT.ToString());

                if (txtTongTien != null)
                    txtTongTien.Text = helpers.FormatNumber(tongTienPhaiTra.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tổng tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtTongTien != null && !string.IsNullOrEmpty(txtTongTien.Text) &&
            //        txtMaPhieuNhap != null && !string.IsNullOrEmpty(txtMaPhieuNhap.Text))
            //    {
            //        frmThanhToanNhapHang thanhToan = new frmThanhToanNhapHang(Convert.ToDecimal(helpers.ParseNumber(txtTongTien.Text.Trim())), txtMaPhieuNhap.Text);

            //        if (thanhToan.ShowDialog() == DialogResult.OK)
            //        {
            //            // Lấy số tiền đã thanh toán từ form thanh toán
            //            daThanhToan = thanhToan.SoTienThanhToan;

            //            // Cập nhật hiển thị
            //            txtDaThanhToan.Text = helpers.FormatNumber(daThanhToan.ToString()) + " đ";

            //            // Tính lại tiền còn nợ
            //            conNo = TinhTienConNo();
            //            txtConNo.Text = helpers.FormatNumber(conNo.ToString()) + " đ";
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Vui lòng kiểm tra lại thông tin phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            PhieuNhapDAO phieuNhapDAO = new PhieuNhapDAO();

            // Kiểm tra xem có sản phẩm nào trong phiếu nhập không
            if (dgvChiTietPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào phiếu nhập trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra thông tin nhà cung cấp
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng PhieuNhap
            string maPhieuNhapHienThi = txtMaPhieuNhap.Text.Trim();
            string maNhaCungCap = txtMaNCC.Text.Trim();
            string maNV = txtMaNV.Text.Trim();
            DateTime ngayLapPN = DateTime.Now;
            decimal tongTien = Convert.ToDecimal(helpers.ParseNumber(txtTongTien.Text.Trim()));
            //decimal daTra = Convert.ToDecimal(helpers.ParseNumber(txtDaThanhToan.Text.Replace(" đ", "").Trim()));
            //decimal conLai = Convert.ToDecimal(helpers.ParseNumber(txtConNo.Text.Replace(" đ", "").Trim()));

            //infoPhieuNhapHang pn = new infoPhieuNhapHang
            //{
            //    MaNCC = maNhaCungCap,
            //    MaNV = maNV,
            //    NgayLap = ngayLapPN,
            //    TongTienNhap = tongTien,
            //    MaPNHienThi = maPhieuNhapHienThi
            //};

            //ChiTietPNDAO ctPNdao = new ChiTietPNDAO();

            // Lưu phiếu nhập vào CSDL và lấy ID
            //int maPN = phieuNhapDAO.Insert(pn);

        //    if (maPN != -1)
        //    {
        //        MessageBox.Show($"Lưu phiếu nhập thành công với mã phiếu nhập: {maPN}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        // Lưu chi tiết phiếu nhập
        //        bool allSuccess = true;
        //        foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
        //        {
        //            string maSP = row.Cells["colMaSP"].Value.ToString();
        //            int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
        //            decimal donGia = Convert.ToDecimal(helpers.ParseNumber(row.Cells["colDonGia"].Value.ToString()));
        //            decimal thanhTien = Convert.ToDecimal(helpers.ParseNumber(row.Cells["colThanhTien"].Value.ToString()));

        //            //// Cập nhật số lượng tồn kho
        //            //SanPhamDAO.IncreaseInventory(maSP, soLuong);

        //            //ChiTietPN chiTietPN = new ChiTietPN(
        //            //    maPN,
        //            //    int.Parse(maSP),
        //            //    soLuong,
        //            //    donGia,
        //            //    thanhTien
        //            //);

        //            // Lưu chi tiết phiếu nhập vào CSDL
        //            bool isLuuCTPN = ctPNdao.InsertCTPN(chiTietPN);

        //            if (!isLuuCTPN)
        //            {
        //                MessageBox.Show($"Lưu chi tiết phiếu nhập không thành công cho sản phẩm {maSP}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                allSuccess = false;
        //            }
        //        }

        //        if (allSuccess)
        //        {
        //            MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            ResetForm();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Lưu phiếu nhập không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        }

        private void ResetForm()
        {
            // Xóa danh sách sản phẩm
            dgvChiTietPhieuNhap.Rows.Clear();

            // Reset các trường thông tin
            txtMaPhieuNhap.Text = helpers.TaoMaPhieuTuDong("PN");
            txtTenOrMaSP.Clear();
            txtTongGiaNhap.Text = "0";
            txtTongTien.Text = "0";
            //txtDaThanhToan.Text = "0 đ";
            //txtConNo.Text = "0 đ";
            //txtGhiChu.Clear();

            // Reset các biến tính toán
            tongTienTT = 0;
            tongTienPhaiTra = 0;
            daThanhToan = 0;
            conNo = 0;

            // Focus vào trường nhập sản phẩm
            txtTenOrMaSP.Focus();
        }

        private void menu_thaotac_Opening(object sender, CancelEventArgs e)
        {
            // Logic for context menu opening
        }

        private void act_delete_Click(object sender, EventArgs e)
        {
            // Xóa sản phẩm được chọn khỏi DataGridView
            if (dgvChiTietPhieuNhap.CurrentRow != null)
            {
                dgvChiTietPhieuNhap.Rows.Remove(dgvChiTietPhieuNhap.CurrentRow);
                TinhTongTien();
            }
        }

        private void act_edit_Click(object sender, EventArgs e)
        {
            //// Sửa thông tin sản phẩm được chọn
            //if (dgvChiTietPhieuNhap.CurrentRow != null)
            //{
            //    string tenSP = dgvChiTietPhieuNhap.CurrentRow.Cells["colTenSP"].Value.ToString();
            //    int donGiaHienTai = helpers.ParseNumber(dgvChiTietPhieuNhap.CurrentRow.Cells["colDonGia"].Value.ToString());
            //    int soLuongHienTai = Convert.ToInt32(dgvChiTietPhieuNhap.CurrentRow.Cells["colSoLuong"].Value);

            //    using (var formNhapThongTin = new frmNhapGiaSoLuong(tenSP, donGiaHienTai, soLuongHienTai))
            //    {
            //        if (formNhapThongTin.ShowDialog() == DialogResult.OK)
            //        {
            //            int donGiaMoi = formNhapThongTin.DonGia;
            //            int soLuongMoi = formNhapThongTin.SoLuong;
            //            int thanhTienMoi = soLuongMoi * donGiaMoi;

            //            dgvChiTietPhieuNhap.CurrentRow.Cells["colDonGia"].Value = helpers.FormatNumber(donGiaMoi.ToString());
            //            dgvChiTietPhieuNhap.CurrentRow.Cells["colSoLuong"].Value = soLuongMoi;
            //            dgvChiTietPhieuNhap.CurrentRow.Cells["colThanhTien"].Value = helpers.FormatNumber(thanhTienMoi.ToString());

            //            TinhTongTien();
            //        }
            //    }
            //}
        }

        private void btnSearchNCC_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmTimNhaCungCap timNCC = new frmTimNhaCungCap();
            //    if (timNCC.ShowDialog() == DialogResult.OK)
            //    {
            //        NhaCungCap selectedNCC = timNCC.SelectedNhaCungCap;
            //        if (selectedNCC != null)
            //        {
            //            txtMaNCC.Text = selectedNCC.MaNhaCungCap;
            //            txtTenNCC.Text = selectedNCC.TenNhaCungCap;
            //            txtSDT.Text = selectedNCC.SoDienThoai;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi tìm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dgvChiTietPhieuNhap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // check if the cell is in the "colSoLuong" column
            // check if the cell is in the "colSoLuong" column
            if (dgvChiTietPhieuNhap.Columns[e.ColumnIndex].HeaderText == "Số lượng")
            {
                // Get the new value
                int soLuong = Convert.ToInt32(dgvChiTietPhieuNhap.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                // Get the price from the "colDonGia" column
                int donGia = helpers.ParseNumber(dgvChiTietPhieuNhap.Rows[e.RowIndex].Cells["colDonGia"].Value.ToString());
                // Calculate the new total price
                int thanhTien = soLuong * donGia;
                // Update the "colThanhTien" column
                dgvChiTietPhieuNhap.Rows[e.RowIndex].Cells["colThanhTien"].Value = helpers.FormatNumber(thanhTien.ToString());
                // Recalculate the total amount
                TinhTongTien();
            }
        }

        private void dgvChiTietPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
            this.FormClosed += (s, args) => this.Dispose();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            PhieuNhapDAO phieuNhapDAO = new PhieuNhapDAO();
            // Kiểm tra xem có sản phẩm nào trong phiếu nhập không
            if (dgvChiTietPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào phiếu nhập trước khi lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // khoi tao phieu nhap
            string maPhieuNhapHienThi = txtMaPhieuNhap.Text.Trim();
            string maNhaCungCap = txtMaNCC.Text.Trim();
            string maNV = txtMaNV.Text.Trim();
            DateTime ngayLapPN = DateTime.Now;
            decimal tongTien = Convert.ToDecimal(helpers.ParseNumber(txtTongTien.Text.Trim()));

            // Fix the issue by providing the required arguments to the constructor of infoPhieuNhapHang
            infoPhieuNhapHang pn = new infoPhieuNhapHang(
                null, // maPhieuNhap
                maNhaCungCap,       // maNCC
                maNV,               // maNV
                ngayLapPN,          // ngayLap
                tongTien,           // tongTien
                maPhieuNhapHienThi  // MaPNHienThi
            );
            // Lưu phiếu nhập vào CSDL và lấy ID
            int maPN = phieuNhapDAO.InsertPN(pn);
            if (maPN != -1)
            {
                MessageBox.Show($"Lưu phiếu nhập thành công với mã phiếu nhập: {maPN}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Lưu chi tiết phiếu nhập
                ChiTietPNDAO ctPNdao = new ChiTietPNDAO();
                bool allSuccess = true;
                foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                {
                    string maSP = row.Cells["colMaSP"].Value.ToString();
                    int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                    int donGia = Convert.ToInt32(helpers.ParseNumber(row.Cells["colDonGia"].Value.ToString()));
                    int thanhTien = Convert.ToInt32(helpers.ParseNumber(row.Cells["colThanhTien"].Value.ToString()));
                    ChiTietPhieuNhapHang chiTietPN = new ChiTietPhieuNhapHang(
                        maPN.ToString(),
                        maSP.ToString(),
                        soLuong,
                        donGia,
                        thanhTien
                    );
                    // Lưu chi tiết phiếu nhập vào CSDL
                    bool isLuuCTPN = ctPNdao.InsertCTPN(chiTietPN);
                    if (!isLuuCTPN)
                    {
                        MessageBox.Show($"Lưu chi tiết phiếu nhập không thành công cho sản phẩm {maSP}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        allSuccess = false;
                    }
                }
                if (allSuccess)
                {
                    MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cập nhật số lượng tồn kho
                    foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                    {
                        string maSP = row.Cells["colMaSP"].Value.ToString();
                        int soLuong = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                        // Cập nhật số lượng tồn kho
                        SanPhamDAO.UpdateSoLuongTonV1(maSP, soLuong,"cong");
                    }
                    ResetForm();
                }
            }
            else
            {
                MessageBox.Show("Lưu phiếu nhập không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    