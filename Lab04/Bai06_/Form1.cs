using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;


namespace Bai06_
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            string token = tb_token.Text.Trim();

            if (string.IsNullOrEmpty(token))
            {
                MessageBox.Show("Vui lòng nhập token từ Bài 5!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnGet.Enabled = false;
                rtb_result.Text = "Đang gửi request...";

                string result = await GetUserInfo(token);
                rtb_result.Text = result;
            }
            catch (Exception ex)
            {
                rtb_result.Text = "Lỗi: " + ex.Message;
            }
            finally
            {
                btnGet.Enabled = true;
            }
        }

        private async Task<string> GetUserInfo(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var getUserUrl = "https://nt106.uitiot.vn/api/v1/user/me";
            var getUserResponse = await client.GetAsync(getUserUrl);
            var getUserResponseString = await getUserResponse.Content.ReadAsStringAsync();

            if (getUserResponse.IsSuccessStatusCode)
            {
                JObject json = JObject.Parse(getUserResponseString);

                string id = json["id"]?.ToString() ?? "Not Available";
                string username = json["username"]?.ToString() ?? "Not Available";
                string email = json["email"]?.ToString() ?? "Not Available";
                string created_at = json["created_at"]?.ToString() ?? "Not Available\n";

                string result = "THÔNG TIN USER\r\n\n";
                result += $"ID: {id}\r\n";
                result += $"Username: {username}\r\n";
                result += $"Email: {email}\r\n";
                result += $"Created At: {created_at}\r\n";
                result += "JSON RESPONSE\r\n";
                result += json.ToString(Newtonsoft.Json.Formatting.Indented);

                return result;
            }
            else
            {
                return $"Lỗi: {getUserResponse.StatusCode}\n\n{getUserResponseString}";
            }
        }
    }
}