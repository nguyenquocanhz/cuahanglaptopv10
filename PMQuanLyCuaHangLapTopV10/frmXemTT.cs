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
    public partial class frmXemTT: Form
    {
        public NhaCungCapDAO NhaCungCapDAO;
        public frmXemTT()
        {
            InitializeComponent();
        }
        public frmXemTT(string maNCC)
        {
            InitializeComponent();

            // 1. Gán mã NCC vào TextBox đầu tiên (nếu cần)
            txtMaNCC.Text = maNCC;

            // 2. Khởi tạo DAO và gọi phương thức lấy dữ liệu
            var nccDao = new NhaCungCapDAO(); // Đổi tên biến để rõ ràng hơn
            DataTable dtNhaCungCap = nccDao.GetNhaCungCapById(maNCC);

            // 3. Kiểm tra xem DataTable có dữ liệu không (tìm thấy NCC không?)
            if (dtNhaCungCap != null && dtNhaCungCap.Rows.Count > 0)
            {
                // Lấy dòng đầu tiên (vì tìm theo ID nên chỉ có 1 dòng nếu tìm thấy)
                DataRow row = dtNhaCungCap.Rows[0];

                // 4. Gán dữ liệu từ các cột của DataRow vào TextBoxes
                // Sử dụng tên cột CHÍNH XÁC như trong DataTable được trả về từ GetNhaCungCapById
                // Dùng ?.ToString() ?? "" để tránh lỗi nếu giá trị là null và gán chuỗi rỗng thay thế

                txtName.Text = row["TenNCC"]?.ToString() ?? "";         // Gán Tên NCC
                txtSdt.Text = row["SoDienThoaiNCC"]?.ToString() ?? ""; // Gán Số Điện Thoại

                // Giả sử cột địa chỉ trong DataTable tên là "DiaChi"
                // Nếu tên cột khác, hãy thay đổi cho đúng
                if (dtNhaCungCap.Columns.Contains("DiaChi")) // Kiểm tra xem cột địa chỉ có tồn tại không
                {
                    txtDiachi.Text = row["DiaChi"]?.ToString() ?? ""; // Gán Địa chỉ
                }
                else
                {
                    txtDiachi.Text = "N/A"; // Hoặc để trống nếu không có cột địa chỉ
                                           // Có thể bạn cần cập nhật lại phương thức GetNhaCungCapById để lấy thêm cột DiaChi
                }

                // Gán các thông tin khác vào các TextBox/Control tương ứng nếu có
            }
            else
            {
                // Trường hợp không tìm thấy Nhà Cung Cấp hoặc có lỗi xảy ra
                MessageBox.Show($"Không tìm thấy thông tin cho Nhà cung cấp có mã: {maNCC}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Có thể xóa trống các ô hoặc đóng form tùy theo yêu cầu
                txtName.Text = "";
                txtSdt.Text = "";
                txtDiachi.Text = "";
                // Ví dụ: this.Close(); // Đóng form nếu không tìm thấy NCC
            }
        }


    }
}
