using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai05_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_dangnhap_Click(object sender, EventArgs e)
        {
            await DangNhapAPI(tb_taikhoan.Text.Trim(), tb_matkhau.Text);
        }

        private async Task DangNhapAPI(string username, string password)
        {
            string url = "https://nt106.uitiot.vn/auth/token";

            btn_dangnhap.Enabled = false;
            btn_dangnhap.Text = "ĐANG XỬ LÝ...";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("accept", "application/json");

                    var formData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", ""),
                        new KeyValuePair<string, string>("username", username),
                        new KeyValuePair<string, string>("password", password),
                        new KeyValuePair<string, string>("scope", ""),
                        new KeyValuePair<string, string>("client_id", ""),
                        new KeyValuePair<string, string>("client_secret", "")
                    };

                    var content = new FormUrlEncodedContent(formData);

                    tb_ketqua.Text = $"Testing: {username}\r\n";
                    tb_ketqua.Text += "Connecting to server...\r\n";

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseString = await response.Content.ReadAsStringAsync();

                    tb_ketqua.Text += $"Response Code: {(int)response.StatusCode}\r\n\r\n";

                    if (response.IsSuccessStatusCode)
                    {
                        JObject responseObject = JObject.Parse(responseString);
                        string tokenType = responseObject["token_type"].ToString();
                        string accessToken = responseObject["access_token"].ToString();

                        tb_ketqua.Text += $"{tokenType} {accessToken}\r\n";
                        tb_ketqua.Text += "Đăng nhập thành công";
                    }
                    else
                    {
                        JObject responseObject = JObject.Parse(responseString);
                        string detail = responseObject["detail"]?.ToString() ?? responseString;
                        tb_ketqua.Text += $"Error: {detail}";
                    }
                }
            }
            catch (Exception ex)
            {
                tb_ketqua.Text += $"System Error: {ex.Message}";
            }
            finally
            {
                btn_dangnhap.Enabled = true;
                btn_dangnhap.Text = "ĐĂNG NHẬP";
            }
        }
    }
}