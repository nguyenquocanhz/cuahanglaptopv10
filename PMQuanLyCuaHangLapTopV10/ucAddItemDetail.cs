using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class ucAddItemDetail : UserControl
    {
        // Khai báo biến
        private decimal tongTien = 0;
        private DataTable dtSanPham = new DataTable(); // DataTable chứa danh sách sản phẩm
        private DataTable dtChiTietHoaDon = new DataTable(); // DataTable chứa chi tiết hóa đơn hiện tại

        public ucAddItemDetail()
        {
            InitializeComponent();
        }

        private void ucAddItemDetail_Load(object sender, EventArgs e)
        {
            // Khởi tạo DataTable cho chi tiết hóa đơn
            KhoiTaoDataTable();

            // Load danh sách loại sản phẩm vào combobox
            LoadLoaiSanPham();

            // Làm sạch form
            LamSachForm();
        }

        private void KhoiTaoDataTable()
        {
            // Tạo DataTable cho chi tiết hóa đơn
            dtChiTietHoaDon = new DataTable();
            dtChiTietHoaDon.Columns.Add("MaSP", typeof(string));
            dtChiTietHoaDon.Columns.Add("TenSP", typeof(string));
            dtChiTietHoaDon.Columns.Add("SoLuong", typeof(int));
            dtChiTietHoaDon.Columns.Add("DonGia", typeof(decimal));
            dtChiTietHoaDon.Columns.Add("ThanhTien", typeof(decimal));

            // Gán DataTable cho DataGridView
            dgvChiTietHoaDon.DataSource = dtChiTietHoaDon;
        }

        private void LoadLoaiSanPham()
        {
            // Trong thực tế, sẽ lấy dữ liệu từ database
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.Add("Dell");
            cboLoaiSP.Items.Add("HP");
            cboLoaiSP.Items.Add("Asus");
            cboLoaiSP.Items.Add("Lenovo");
            cboLoaiSP.Items.Add("Acer");
        }

        private void LamSachForm()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaBan.Text = "";
            cboLoaiSP.SelectedIndex = -1;
            numSoLuong.Value = 1;

            // Focus vào ô tìm kiếm
            txtTimKiem.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Xử lý tìm kiếm
            if (string.IsNullOrEmpty(txtTimKiem.Text))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thực hiện tìm kiếm dựa vào loại tìm kiếm được chọn
            string loaiTimKiem = cboLoaiTimKiem.SelectedItem.ToString();
            string tuKhoa = txtTimKiem.Text.Trim();

            DataRow[] found = null;

            switch (loaiTimKiem)
            {
                case "Mã sản phẩm":
                    found = dtSanPham.Select("MaSP LIKE '%" + tuKhoa + "%'");
                    break;
                case "Tên sản phẩm":
                    found = dtSanPham.Select("TenSP LIKE '%" + tuKhoa + "%'");
                    break;
                case "Loại sản phẩm":
                    found = dtSanPham.Select("LoaiSP LIKE '%" + tuKhoa + "%'");
                    break;
            }

            if (found != null && found.Length > 0)
            {
                // Lấy sản phẩm đầu tiên tìm thấy
                DataRow row = found[0];

                // Hiển thị thông tin sản phẩm
                txtMaSP.Text = row["MaSP"].ToString();
                txtTenSP.Text = row["TenSP"].ToString();
                cboLoaiSP.Text = row["LoaiSP"].ToString();
                txtGiaBan.Text = string.Format("{0:#,##0}", row["GiaBan"]);

                // Kiểm tra số lượng tồn
                int soLuongTon = Convert.ToInt32(row["SoLuongTon"]);
                if (soLuongTon > 0)
                {
                    numSoLuong.Maximum = soLuongTon;
                    numSoLuong.Value = 1;
                }
                else
                {
                    MessageBox.Show("Sản phẩm này đã hết hàng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamSachForm();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamSachForm();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn sản phẩm chưa
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng tìm kiếm và chọn sản phẩm trước khi thêm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSP = txtMaSP.Text;
            string tenSP = txtTenSP.Text;
            int soLuong = (int)numSoLuong.Value;
            decimal donGia = decimal.Parse(txtGiaBan.Text.Replace(",", ""));
            decimal thanhTien = soLuong * donGia;

            // Kiểm tra sản phẩm đã có trong chi tiết hóa đơn chưa
            DataRow[] existingRows = dtChiTietHoaDon.Select("MaSP = '" + maSP + "'");

            if (existingRows.Length > 0)
            {
                // Cập nhật số lượng và thành tiền
                int soLuongCu = Convert.ToInt32(existingRows[0]["SoLuong"]);
                int soLuongMoi = soLuongCu + soLuong;

                // Kiểm tra số lượng tồn kho
                DataRow[] productRows = dtSanPham.Select("MaSP = '" + maSP + "'");
                int soLuongTon = Convert.ToInt32(productRows[0]["SoLuongTon"]);

                if (soLuongMoi > soLuongTon)
                {
                    MessageBox.Show("Số lượng vượt quá tồn kho! Chỉ còn " + soLuongTon + " sản phẩm.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                existingRows[0]["SoLuong"] = soLuongMoi;
                existingRows[0]["ThanhTien"] = soLuongMoi * donGia;
            }
            else
            {
                // Thêm mới vào chi tiết hóa đơn
                dtChiTietHoaDon.Rows.Add(maSP, tenSP, soLuong, donGia, thanhTien);
            }

            // Cập nhật tổng tiền
            TinhTongTien();

            // Làm sạch form
            LamSachForm();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LamSachForm();
        }

        private void dgvChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện click vào nút xóa trong DataGridView
            if (e.RowIndex >= 0 && e.ColumnIndex == colXoa.Index)
            {
                // Xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này khỏi đơn hàng?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Xóa dòng khỏi chi tiết hóa đơn
                    dtChiTietHoaDon.Rows.RemoveAt(e.RowIndex);

                    // Cập nhật tổng tiền
                    TinhTongTien();
                }
            }
        }

        private void TinhTongTien()
        {
            tongTien = 0;

            foreach (DataRow row in dtChiTietHoaDon.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }

            txtTongTien.Text = string.Format("{0:#,##0}", tongTien);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra có sản phẩm nào trong hóa đơn chưa
            if (dtChiTietHoaDon.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào hóa đơn trước khi thanh toán!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận thanh toán
            DialogResult result = MessageBox.Show("Xác nhận thanh toán hóa đơn với tổng tiền: " +
                txtTongTien.Text + " VNĐ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Trong thực tế sẽ lưu hóa đơn vào database tại đây

                MessageBox.Show("Thanh toán thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa toàn bộ chi tiết hóa đơn
                dtChiTietHoaDon.Rows.Clear();

                // Cập nhật tổng tiền
                TinhTongTien();

                // Làm sạch form
                LamSachForm();
            }
        }
    }
}