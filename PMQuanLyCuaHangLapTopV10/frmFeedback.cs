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
    public partial class frmFeedback: Form
    {
        public bool isSuccessed = false;  
        public frmFeedback()
        {
            InitializeComponent();
        }

        private async void btnSubmitFeedback_Click(object sender, EventArgs e)
        {
            string email = txtEmailGuest.Text;
            string msg = richFeedbackmsg.Text;
            Helpers helpers = new Helpers();
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(msg)) 
            {
                MessageBox.Show("Vui lòng nhập email hoặc nội dung phản hồi");
                return;
            }
            if (!helpers.IsValidEmail(email))
            {
                MessageBox.Show("Vui lòng nhập lại email !");
                txtEmailGuest.Clear();
                txtEmailGuest.Focus();
                return;

            }
            else 
            {
                string[] data = { email, msg };


                TelegramServices telegramServices = new TelegramServices(data);
                isSuccessed = await telegramServices.SendTelegramMessage();

            }

            // Chờ gửi tin nhắn về Telegram

            // Hiển thị thông báo dựa trên kết quả gửi tin nhắn
            if (isSuccessed)
            {
                MessageBox.Show("Đã gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Gửi không thành công. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
