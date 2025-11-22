using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Bai02_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            string url = txt_url.Text.Trim();
            string path = txt_save_path.Text.Trim();

            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Vui lòng nhập URL và đường dẫn lưu file!");
                return;
            }

            try
            {
                btn_download.Enabled = false;

                WebClient myClient = new WebClient();

                Stream response = myClient.OpenRead(url);
                using (StreamReader reader = new StreamReader(response))
                {
                    string html = reader.ReadToEnd();
                    rtb_html.Text = html;
                }

                myClient.DownloadFile(url, path);

                myClient.Dispose();

                MessageBox.Show("Tải file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                btn_download.Enabled = true;
            }
        }
    }
}