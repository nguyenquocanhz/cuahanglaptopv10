using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PMQuanLyCuaHangLapTopV10
{
    public class Helpers
    {
        private Form activeForm;

        public Helpers() { }
        public bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void ActiveButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                //btnLogin.Enabled = false;
                Button btn = (Button)senderBtn;
                btn.BackColor = Color.FromArgb(46, 51, 73);
                btn.ForeColor = Color.White;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Font = new Font("Segoe UI Semibold", 12.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            }
        }
        public void DisableButton(Panel panel)
        {
            foreach (Control previousBtn in panel.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(50, 52, 77);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        public void OpenChildForm(Form childForm, object senderBtn , Panel panel)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            //ActiveButton(senderBtn);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel.Controls.Add(childForm);
            panel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public string RandomHDHienThi()
        {
            Random random = new Random();
            string datePart = DateTime.Today.ToString("yyyyMMdd");

            int randomNumber = random.Next(0, 1000); // rand.Next(min, max) - max là giới hạn trên (độc quyền)
            string randomPart = randomNumber.ToString("D3"); // "D3" format: Decimal, minimum 3 digits
            string maHDHienThi = $"HD-BH-{datePart}-{randomPart}";

            return maHDHienThi;
        }
        public string FormatNumber(string amount)
        {
            // Xóa tất cả ký tự không phải số
            string formattedAmount = System.Text.RegularExpressions.Regex.Replace(amount, @"[^\d]", "");
            // Chuyển đổi thành số nguyên
            if (int.TryParse(formattedAmount, out int number))
            {
                // Định dạng lại thành chuỗi với dấu phẩy
                return string.Format("{0:#,0}", number);
            }
            return amount; // Trả về giá trị gốc nếu không thể chuyển đổi
        }
        public string RemoveFormatting(string amount)
        {
            // Xóa tất cả ký tự không phải số
            string formattedAmount = System.Text.RegularExpressions.Regex.Replace(amount, @"[^\d]", "");
            return formattedAmount; // Trả về giá trị gốc nếu không thể chuyển đổi
        }
        public int ParseNumber(string numberStr)
        {
            if (int.TryParse(numberStr.Replace(",", "").Replace(".", "").Trim(), out int result))
                return result;
            return 0;
        }
        public string CreateSePayQRImageUrl(string account, string bankCode, int amount, string description)
        {
            string baseUrl = "https://qr.sepay.vn/img";
            string query = $"?acc={Uri.EscapeDataString(account)}" +
                           $"&bank={Uri.EscapeDataString(bankCode)}" +
                           $"&amount={amount}" +
                           $"&des={Uri.EscapeDataString(description)}";
            return baseUrl + query;
        }
        public void ShowQRInPictureBox(PictureBox picBox, string account, string bankCode, int amount, string description)
        {
            string qrUrl = CreateSePayQRImageUrl(account, bankCode, amount, description);
            using (var webClient = new System.Net.WebClient())
            {
                try
                {
                    byte[] imageBytes = webClient.DownloadData(qrUrl);
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        picBox.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh QR: " + ex.Message);
                }
            }
        }

        public string FormatNumberV1(string numberStr)
        {
            if (int.TryParse(numberStr, out int number))
                return number.ToString("N0");
            return numberStr;
        }
        public string TaoMaPhieuTuDong(string split)
        {
            // Tạo mã phiếu tự động theo định dạng: PN + Ngày + Số thứ tự
            // Ví dụ: PN20250503001 (phiếu nhập ngày 03/05/2025, số thứ tự 001)
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            string soThuTu = "001"; // Trong thực tế cần truy vấn CSDL để lấy số thứ tự tiếp theo

            return split + ngay + soThuTu;
        }

    }
}
