using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using HtmlAgilityPack;
using System.Linq;

namespace Bai03_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeAsync();
        }
        private async void InitializeAsync()
        {
            try
            {
                await webView2_browser.EnsureCoreWebView2Async(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo WebView2: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            string url = tb_url.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
                tb_url.Text = url;
            }

            try
            {
                webView2_browser.CoreWebView2.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải trang: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_reload_Click(object sender, EventArgs e)
        {
            try
            {
                if (webView2_browser.CoreWebView2 != null)
                {
                    webView2_browser.CoreWebView2.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi reload: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_down_files_Click(object sender, EventArgs e)
        {
            string url = tb_url.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Chưa có trang web để tải!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "HTML Files|*.html|All Files|*.*",
                FileName = "index.html",
                Title = "Lưu file HTML"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Encoding = System.Text.Encoding.UTF8;
                        string html = client.DownloadString(url);
                        File.WriteAllText(saveDialog.FileName, html, System.Text.Encoding.UTF8);
                    }

                    MessageBox.Show($"Đã lưu file thành công!\n{saveDialog.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tải file: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_down_resources_Click(object sender, EventArgs e)
        {
            string url = tb_url.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Chưa có trang web để tải!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FolderBrowserDialog folderDialog = new FolderBrowserDialog
            {
                Description = "Chọn thư mục lưu hình ảnh"
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    HtmlWeb web = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = web.Load(url);

                    var imgNodes = doc.DocumentNode.SelectNodes("//img[@src]");

                    if (imgNodes == null || imgNodes.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy hình ảnh nào!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int count = 0;
                    using (WebClient client = new WebClient())
                    {
                        foreach (var img in imgNodes)
                        {
                            try
                            {
                                string imgUrl = img.GetAttributeValue("src", "");

                                if (!imgUrl.StartsWith("http"))
                                {
                                    Uri baseUri = new Uri(url);
                                    Uri fullUri = new Uri(baseUri, imgUrl);
                                    imgUrl = fullUri.ToString();
                                }

                                string fileName = Path.GetFileName(new Uri(imgUrl).LocalPath);
                                if (string.IsNullOrEmpty(fileName))
                                {
                                    fileName = $"image_{count}.jpg";
                                }

                                string savePath = Path.Combine(folderDialog.SelectedPath, fileName);

                                client.DownloadFile(imgUrl, savePath);
                                count++;
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }

                    MessageBox.Show($"Đã tải thành công {count} hình ảnh!\nThư mục: {folderDialog.SelectedPath}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi tải resources: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void viewSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = tb_url.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Chưa có trang web để xem!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    string html = client.DownloadString(url);
                    SourceViewerForm sourceForm = new SourceViewerForm(html);
                    sourceForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xem source: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_load_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}