using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string getHTML(string szURL)
        {
            // Khởi tạo WebRequest
            WebRequest request = WebRequest.Create(szURL);

            // Lấy WebResponse
            WebResponse response = request.GetResponse();

            // Nhận Stream dữ liệu trả về
            Stream dataStream = response.GetResponseStream();

            // Đọc dữ liệu bằng StreamReader
            StreamReader reader = new StreamReader(dataStream);

            // Đọc toàn bộ nội dung HTML
            string responseFromServer = reader.ReadToEnd();

            // Đóng kết nối
            response.Close();

            return responseFromServer;
        }

        private void btn_get_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txt_url.Text.Trim();

                if (url == "")
                {
                    MessageBox.Show("Vui lòng nhập URL!");
                    return;
                }

                // Gọi hàm lấy HTML
                string html = getHTML(url);

                // Hiển thị nội dung vào RichTextBox
                txt_html.Text = html;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
    
}
