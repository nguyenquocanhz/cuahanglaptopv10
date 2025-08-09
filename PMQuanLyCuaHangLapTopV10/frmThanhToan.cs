using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace PMQuanLyCuaHangLapTopV10
{
    public partial class frmThanhToan : Form
    {
        private decimal tongTienThanhToan = 0;
        private string maHoaDon = "";
        private PictureBox picQRCode;
        private Panel pnlThongTinThanhToan;
        private Panel pnlQRCode;
        private Label lblTitle;
        private Label lblMaHoaDon;
        private Label lblMaHoaDonValue;
        private Label lblTongTien;
        private Label lblTongTienValue;
        private Label lblThoiHan;
        private Label lblThoiHanValue;
        private Label lblTrangThai;
        private Label lblTrangThaiValue;
        private Button btnKiemTraThanhToan;
        private Button btnHuyThanhToan;
        private Button btnInHoaDon;
        private Timer timerKiemTraThanhToan;
        private System.Windows.Forms.Timer timerThoiGian;
        private int thoiGianConLai = 900; // 15 phút tính bằng giây

        public frmThanhToan(decimal tongTien, string maHD)
        {
            InitializeComponent();
            this.tongTienThanhToan = tongTien;
            this.maHoaDon = maHD;

            // Đăng ký sự kiện Load form
            this.Load += FrmThanhToan_Load;
        }

        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            // Khởi tạo giao diện
            KhoiTaoGiaoDien();

            // Tạo mã QR giả lập cho SePay
            TaoQRCode();

            // Khởi động timer đếm ngược thời gian
            KhoiDongTimer();
        }

        private void KhoiTaoGiaoDien()
        {
            // Thiết lập các thuộc tính cơ bản của form
            this.Text = "Thanh toán qua SePay QR Code";
            this.Size = new Size(800, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            // Panel thông tin thanh toán
            pnlThongTinThanhToan = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(760, 150),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Panel QR Code
            pnlQRCode = new Panel
            {
                Location = new Point(20, 180),
                Size = new Size(760, 420),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Tiêu đề
            lblTitle = new Label
            {
                Text = "THANH TOÁN QUA SEPAY",
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(740, 40),
                Location = new Point(10, 10)
            };

            // Mã hóa đơn
            lblMaHoaDon = new Label
            {
                Text = "Mã hóa đơn:",
                Font = new Font("Arial", 12),
                Size = new Size(120, 30),
                Location = new Point(20, 60)
            };

            lblMaHoaDonValue = new Label
            {
                Text = maHoaDon,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Size = new Size(250, 30),
                Location = new Point(150, 60)
            };

            // Tổng tiền
            lblTongTien = new Label
            {
                Text = "Tổng tiền:",
                Font = new Font("Arial", 12),
                Size = new Size(120, 30),
                Location = new Point(400, 60)
            };

            lblTongTienValue = new Label
            {
                Text = string.Format("{0:#,##0} VNĐ", tongTienThanhToan),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Red,
                Size = new Size(250, 30),
                Location = new Point(520, 60)
            };

            // Thời hạn thanh toán
            lblThoiHan = new Label
            {
                Text = "Thời hạn:",
                Font = new Font("Arial", 12),
                Size = new Size(120, 30),
                Location = new Point(20, 100)
            };

            lblThoiHanValue = new Label
            {
                Text = "15:00",
                Font = new Font("Arial", 12, FontStyle.Bold),
                Size = new Size(250, 30),
                Location = new Point(150, 100)
            };

            // Trạng thái thanh toán
            lblTrangThai = new Label
            {
                Text = "Trạng thái:",
                Font = new Font("Arial", 12),
                Size = new Size(120, 30),
                Location = new Point(400, 100)
            };

            lblTrangThaiValue = new Label
            {
                Text = "Chờ thanh toán",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Blue,
                Size = new Size(250, 30),
                Location = new Point(520, 100)
            };

            // QR Code
            picQRCode = new PictureBox
            {
                Size = new Size(300, 300),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(230, 20),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Hướng dẫn thanh toán
            Label lblHuongDan = new Label
            {
                Text = "Quét mã QR bằng ứng dụng SePay để thanh toán",
                Font = new Font("Arial", 12),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(500, 30),
                Location = new Point(130, 330)
            };

            Label lblThongBao = new Label
            {
                Text = "Vui lòng không đóng cửa sổ này cho đến khi thanh toán hoàn tất",
                Font = new Font("Arial", 10),
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(500, 30),
                Location = new Point(130, 360)
            };

            // Button Kiểm tra thanh toán
            btnKiemTraThanhToan = new Button
            {
                Text = "Kiểm tra thanh toán",
                Font = new Font("Arial", 12),
                Size = new Size(200, 40),
                Location = new Point(60, 610),
                BackColor = Color.LightBlue
            };
            btnKiemTraThanhToan.Click += BtnKiemTraThanhToan_Click;

            // Button Hủy thanh toán
            btnHuyThanhToan = new Button
            {
                Text = "Hủy thanh toán",
                Font = new Font("Arial", 12),
                Size = new Size(200, 40),
                Location = new Point(300, 610),
                BackColor = Color.LightCoral
            };
            btnHuyThanhToan.Click += BtnHuyThanhToan_Click;

            // Button In hóa đơn
            btnInHoaDon = new Button
            {
                Text = "In hóa đơn",
                Font = new Font("Arial", 12),
                Size = new Size(200, 40),
                Location = new Point(540, 610),
                BackColor = Color.LightGreen,
                Enabled = false
            };
            btnInHoaDon.Click += BtnInHoaDon_Click;

            // Thêm controls vào panel và form
            pnlThongTinThanhToan.Controls.Add(lblTitle);
            pnlThongTinThanhToan.Controls.Add(lblMaHoaDon);
            pnlThongTinThanhToan.Controls.Add(lblMaHoaDonValue);
            pnlThongTinThanhToan.Controls.Add(lblTongTien);
            pnlThongTinThanhToan.Controls.Add(lblTongTienValue);
            pnlThongTinThanhToan.Controls.Add(lblThoiHan);
            pnlThongTinThanhToan.Controls.Add(lblThoiHanValue);
            pnlThongTinThanhToan.Controls.Add(lblTrangThai);
            pnlThongTinThanhToan.Controls.Add(lblTrangThaiValue);

            pnlQRCode.Controls.Add(picQRCode);
            pnlQRCode.Controls.Add(lblHuongDan);
            pnlQRCode.Controls.Add(lblThongBao);

            this.Controls.Add(pnlThongTinThanhToan);
            this.Controls.Add(pnlQRCode);
            this.Controls.Add(btnKiemTraThanhToan);
            this.Controls.Add(btnHuyThanhToan);
            this.Controls.Add(btnInHoaDon);
        }

        private void TaoQRCode()
        {
            Helpers helper = new Helpers();
            string qrUrl = helper.CreateSePayQRImageUrl("96247C4QAY", "BIDV", 100000, "DH102969");
            helper.ShowQRInPictureBox(picQRCode, "96247C4QAY", "BIDV", Convert.ToInt32(tongTienThanhToan), maHoaDon);

        }

        private void KhoiDongTimer()
        {
            // Timer cho thời gian thanh toán
            timerThoiGian = new System.Windows.Forms.Timer();
            timerThoiGian.Interval = 1000; // 1 giây
            timerThoiGian.Tick += TimerThoiGian_Tick;
            timerThoiGian.Start();

            // Timer kiểm tra thanh toán (giả lập)
            timerKiemTraThanhToan = new System.Windows.Forms.Timer();
            timerKiemTraThanhToan.Interval = 5000; // 5 giây
            timerKiemTraThanhToan.Tick += TimerKiemTraThanhToan_Tick;
            timerKiemTraThanhToan.Start();
        }

        private void TimerThoiGian_Tick(object sender, EventArgs e)
        {
            thoiGianConLai--;
            if (thoiGianConLai <= 0)
            {
                timerThoiGian.Stop();
                lblThoiHanValue.Text = "00:00";
                lblTrangThaiValue.Text = "Hết hạn";
                lblTrangThaiValue.ForeColor = Color.Red;

                MessageBox.Show("Thời gian thanh toán đã hết hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int phut = thoiGianConLai / 60;
            int giay = thoiGianConLai % 60;
            lblThoiHanValue.Text = string.Format("{0:00}:{1:00}", phut, giay);
        }

        private void TimerKiemTraThanhToan_Tick(object sender, EventArgs e)
        {
            // Giả lập việc kiểm tra trạng thái thanh toán từ server
            // Trong thực tế, bạn cần tích hợp API của SePay để kiểm tra

            // Ngẫu nhiên mô phỏng thanh toán thành công (khoảng 5% mỗi lần kiểm tra)
            Random random = new Random();
            if (random.Next(100) < 5)
            {
                ThanhToanThanhCong();
            }
        }

        private void BtnKiemTraThanhToan_Click(object sender, EventArgs e)
        {
            // Giả lập kiểm tra thanh toán thủ công
            Random random = new Random();
            if (random.Next(100) < 30) // 30% khả năng thanh toán thành công khi nhấn nút
            {
                ThanhToanThanhCong();
            }
            else
            {
                MessageBox.Show("Chưa nhận được thông tin thanh toán. Vui lòng thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ThanhToanThanhCong()
        {
            timerThoiGian.Stop();
            timerKiemTraThanhToan.Stop();

            lblTrangThaiValue.Text = "Đã thanh toán";
            lblTrangThaiValue.ForeColor = Color.Green;

            btnKiemTraThanhToan.Enabled = false;
            btnHuyThanhToan.Enabled = false;
            btnInHoaDon.Enabled = true;

            MessageBox.Show("Thanh toán thành công! Cảm ơn quý khách đã mua hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnHuyThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy thanh toán này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                timerThoiGian.Stop();
                timerKiemTraThanhToan.Stop();
                this.Close();
            }
        }

        private void BtnInHoaDon_Click(object sender, EventArgs e)
        {
            InHoaDon();
        }

        private void InHoaDon()
        {
            // Tạo đối tượng PrintDocument
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintDoc_PrintPage;

            // Hiển thị PrintPreviewDialog
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDoc;
            printPreviewDialog.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Mô phỏng in hóa đơn
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Arial", 14, FontStyle.Bold);
            Font fontNormal = new Font("Arial", 12);
            Font fontBold = new Font("Arial", 12, FontStyle.Bold);

            // Tiêu đề
            g.DrawString("HÓA ĐƠN BÁN HÀNG", fontTitle, Brushes.Black, 300, 40);

            // Thông tin cửa hàng
            g.DrawString("CỬA HÀNG LAPTOP XXX", fontBold, Brushes.Black, 100, 80);
            g.DrawString("Địa chỉ: 123 Đường ABC, Quận XYZ, TP.HCM", fontNormal, Brushes.Black, 100, 110);
            g.DrawString("Số điện thoại: 0123456789", fontNormal, Brushes.Black, 100, 140);

            // Thông tin hóa đơn
            g.DrawString("Mã hóa đơn: " + maHoaDon, fontBold, Brushes.Black, 100, 180);
            g.DrawString("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal, Brushes.Black, 100, 210);
            g.DrawString("Phương thức thanh toán: SePay QR Code", fontNormal, Brushes.Black, 100, 240);

            // Vẽ đường kẻ
            g.DrawLine(new Pen(Color.Black, 1), 100, 270, 700, 270);

            // Không hiển thị chi tiết sản phẩm vì không có dữ liệu trong bài toán này
            g.DrawString("Chi tiết sản phẩm đã mua:", fontBold, Brushes.Black, 100, 290);
            g.DrawString("(Chi tiết sản phẩm được lưu trong hệ thống)", fontNormal, Brushes.Black, 100, 320);

            // Vẽ đường kẻ
            g.DrawLine(new Pen(Color.Black, 1), 100, 350, 700, 350);

            // Tổng tiền
            g.DrawString("Tổng tiền thanh toán:", fontBold, Brushes.Black, 400, 380);
            g.DrawString(string.Format("{0:#,##0} VNĐ", tongTienThanhToan), fontBold, Brushes.Black, 600, 380);

            // Chân trang
            g.DrawString("Cảm ơn quý khách đã mua hàng!", fontBold, Brushes.Black, 300, 450);
            g.DrawString("Hotline hỗ trợ: 1800 xxxx", fontNormal, Brushes.Black, 300, 480);
        }
    }
}