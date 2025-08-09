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

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmNhapHang : Form
    {
        public DataTable listPhieuNhap;
        public NhaCungCapDAO nccDAO = new NhaCungCapDAO();
        public NhaCungCap infoNcc;
        public ChiTietPNDAO ChiTietPNDAO = new ChiTietPNDAO();
        public ChiTietPhieuNhapHang ChiTietPhieuNhapHang;
        public PhieuNhapDAO phieuNhapDAO = new PhieuNhapDAO();
        public string maNhaCungCap;
        public frmNhapHang()
        {
            InitializeComponent();
        }
        public frmNhapHang(string maNCC)
        {
            InitializeComponent();
            this.maNhaCungCap = maNCC;
            infoNcc = nccDAO.GetNhaCungCapByIdv2(maNhaCungCap);

        }
        private void frmNhapHang_Load(object sender, System.EventArgs e)
        {
            // Khởi tạo danh sách cột cho DataGridView

            // Thiết lập giá trị mặc định cho ngày bắt đầu và kết thúc
            dtpNgayBatDau.Value = System.DateTime.Now.AddMonths(-1);
            dtpNgayKetThuc.Value = System.DateTime.Now;

            // Tải dữ liệu phiếu nhập
            LoadNhapHangData();
        }

        private void InitializeDataGridView()
        {
            // Khởi tạo các cột cho DataGridView
            dgvNhapHang.Columns.Clear();
            dgvNhapHang.Columns.Add("MaPN", "Mã Phiếu Nhập");
            dgvNhapHang.Columns.Add("tongTienNhap", "Tổng Tiền");
            dgvNhapHang.Columns.Add("ngayLapPhieu", "Ngày Nhập");

            // Định dạng các cột tiền tệ
            //dgvNhapHang.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
            //dgvNhapHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvNhapHang.Columns["tongTienNhap"].DefaultCellStyle.Format = "N0";

            // Căn phải các cột số
            //dgvNhapHang.Columns["SoLuong"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //dgvNhapHang.Columns["DonGiaNhap"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dgvNhapHang.Columns["ThanhTien"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dgvNhapHang.Columns["TongTien"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadNhapHangData()
        {
            // TODO: Tải dữ liệu từ cơ sở dữ liệu
            // Đây chỉ là code mẫu, cần được thay thế bằng truy vấn thực tế
            InitDGV();
        }
        public void InitDGV()
        {
            List<infoPhieuNhapHang> phieuNhaps = phieuNhapDAO.GetPhieuNhapByNCC(maNhaCungCap);

            listPhieuNhap = new DataTable();
            listPhieuNhap.Columns.Add("Mã phiếu nhập", typeof(string));
            listPhieuNhap.Columns.Add("Mã NCC", typeof(string));
            listPhieuNhap.Columns.Add("Mã NV", typeof(string));
            listPhieuNhap.Columns.Add("Ngày lập phiếu", typeof(DateTime));
            listPhieuNhap.Columns.Add("Tổng tiền nhập", typeof(decimal));
            listPhieuNhap.Columns.Add("Mã phiếu nhập hiển thị", typeof(string));

            foreach (var phieuNhap in phieuNhaps)
            {
                listPhieuNhap.Rows.Add(phieuNhap.MaPhieuNhap, phieuNhap.MaNCC, phieuNhap.MaNV, phieuNhap.NgayLap, phieuNhap.TongTienNhap, phieuNhap.MaPNHienThi);
            }
            dgvNhapHang.DataSource = listPhieuNhap;
            //InitializeDataGridView();


        }
        private void btnTimKiem_Click(object sender, System.EventArgs e)
        {
            // TODO: Xử lý tìm kiếm dựa trên các điều kiện
            string searchText = txtTimKiem.Text.Trim();
            System.DateTime tuNgay = dtpNgayBatDau.Value;
            System.DateTime denNgay = dtpNgayKetThuc.Value;

            // Thực hiện tìm kiếm và cập nhật DataGridView
            // Đây là ví dụ, cần thay thế bằng code tìm kiếm thực tế
            MessageBox.Show("Đang tìm kiếm với từ khóa: " + searchText +
                            "\nTừ ngày: " + tuNgay.ToShortDateString() +
                            " đến ngày: " + denNgay.ToShortDateString(),
                            "Thông báo",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
        }

        private void btnXemChiTiet_Click(object sender, System.EventArgs e)
        {
            if (dgvNhapHang.SelectedRows.Count > 0)
            {
                string maPhieuNhap = dgvNhapHang.SelectedRows[0].Cells["Mã phiếu nhập"].Value.ToString();
                ShowDetailForm(maPhieuNhap);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xem chi tiết!",
                                "Thông báo",
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Warning);
            }
        }

        private void ShowDetailForm(string maPhieuNhap)
        {
            // TODO: Mở form chi tiết phiếu nhập
            MessageBox.Show("Đang mở chi tiết phiếu nhập: " + maPhieuNhap,
                            "Thông báo",
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);

            // Mở form chi tiết (đây là ví dụ)
            frmChiTietNhapHang frm = new frmChiTietNhapHang(maPhieuNhap);
            frm.ShowDialog();
        }

        private void dgvNhapHang_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maPhieuNhap = dgvNhapHang.Rows[e.RowIndex].Cells["Mã phiếu nhập"].Value.ToString();
                ShowDetailForm(maPhieuNhap);
            }
        }

        private void act_view_detail_Click(object sender, System.EventArgs e)
        {
            if (dgvNhapHang.SelectedRows.Count > 0)
            {
                string maPhieuNhap = dgvNhapHang.SelectedRows[0].Cells["Mã phiếu nhập"].Value.ToString();
                ShowDetailForm(maPhieuNhap);
            }
        }

        private void act_delete_Click(object sender, System.EventArgs e)
        {
            if (dgvNhapHang.SelectedRows.Count > 0)
            {
                string maPhieuNhap = dgvNhapHang.SelectedRows[0].Cells["Mã phiếu nhập"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa phiếu nhập " + maPhieuNhap + "?",
                    "Xác nhận xóa",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    // TODO: Xóa phiếu nhập từ cơ sở dữ liệu
                    MessageBox.Show("Đã xóa phiếu nhập: " + maPhieuNhap,
                                   "Thông báo",
                                   System.Windows.Forms.MessageBoxButtons.OK,
                                   System.Windows.Forms.MessageBoxIcon.Information);

                    // Cập nhật lại danh sách
                    LoadNhapHangData();
                }
            }
        }

        private void act_edit_Click(object sender, System.EventArgs e)
        {
            if (dgvNhapHang.SelectedRows.Count > 0)
            {
                string maPhieuNhap = dgvNhapHang.SelectedRows[0].Cells["Mã phiếu nhập"].Value.ToString();

                // TODO: Mở form cập nhật phiếu nhập
                MessageBox.Show("Đang mở form cập nhật phiếu nhập: " + maPhieuNhap,
                               "Thông báo",
                               System.Windows.Forms.MessageBoxButtons.OK,
                               System.Windows.Forms.MessageBoxIcon.Information);

                // Mở form cập nhật (đây là ví dụ)
                // frmCapNhatPhieuNhap frm = new frmCapNhatPhieuNhap(maPhieuNhap);
                // if (frm.ShowDialog() == DialogResult.OK)
                // {
                //     LoadNhapHangData();
                // }
            }
        }

    }
}
