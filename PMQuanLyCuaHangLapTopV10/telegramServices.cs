using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PMQuanLyCuaHangLapTopV10
{
    public class TelegramServices
    {
        private readonly HttpClient client;
        private string botToken { get; set; }
        private string chatId { get; set; }
        public string msg { get; set; }

        public TelegramServices()
        {

        }

        public TelegramServices(string[] data)
        {
            client = new HttpClient();
            botToken = "{BOT_TOKEN}";
            chatId = "";
            this.msg = "Vừa có khách hàng gửi phản hồi:\n" +
                       "Nội dung: " + data[1] + "\n" +
                       "From: " + data[0];

        }

        public async Task<bool> SendTelegramMessage()
        {
            string url = $"https://api.telegram.org/bot{botToken}/sendMessage";

            var parameters = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("chat_id", chatId),
                    new KeyValuePair<string, string>("text", msg)
             });

            HttpResponseMessage response = await client.PostAsync(url, parameters);

            if (response.IsSuccessStatusCode)
            {
                // Yêu cầu thành công
                return true;
            }
            else
            {
                // Yêu cầu thất bại
                return false;
            }
        }

    }
}
