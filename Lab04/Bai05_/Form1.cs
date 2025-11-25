using System;
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
            await LoginAPI(tb_taikhoan.Text.Trim(), tb_matkhau.Text.Trim());
        }

        private async Task LoginAPI(string username, string password)
        {
            var url = "https://nt106.uitiot.vn/auth/token";

            btn_dangnhap.Enabled = false;
            btn_dangnhap.Text = "ĐANG XỬ LÝ...";

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new MultipartFormDataContent
                    {
                        { new StringContent(username), "username" },
                        { new StringContent(password), "password" }
                    };

                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    var responseObject = JObject.Parse(responseString);

                    if (!response.IsSuccessStatusCode)
                    {
                        var detail = responseObject["detail"].ToString();
                        tb_ketqua.Text = $"Detail: {detail}";
                        return;
                    }

                    var tokenType = responseObject["token_type"].ToString();
                    var accessToken = responseObject["access_token"].ToString();

                    tb_ketqua.Text = $"Token Type: {tokenType}\r\n";
                    tb_ketqua.Text += $"Access Token: {accessToken}\r\n\r\n";

                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                    var getUserUrl = "https://nt106.uitiot.vn/api/v1/user/me";
                    var getUserResponse = await client.GetAsync(getUserUrl);
                    var getUserResponseString = await getUserResponse.Content.ReadAsStringAsync();

                    tb_ketqua.Text += "User Info:\r\n";
                    tb_ketqua.Text += getUserResponseString;
                }
            }
            catch (Exception ex)
            {
                tb_ketqua.Text = $"System Error: {ex.Message}";
            }
            finally
            {
                btn_dangnhap.Enabled = true;
                btn_dangnhap.Text = "ĐĂNG NHẬP";
            }
        }
    }
}
