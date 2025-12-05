using Microsoft.Web.WebView2.WinForms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai04
{
    public partial class MovieDetailForm : Form
    {
        private string _url;
        private string _movieTitle;

        public MovieDetailForm(string url, string movieTitle)
        {
            InitializeComponent();
            _url = url;
            _movieTitle = movieTitle;
            this.Text = $"Beta Cinemas - {movieTitle}";
        }

        private async void MovieDetailForm_Load(object sender, EventArgs e)
        {
            await LoadUrl(_url);
        }

        private async Task LoadUrl(string url)
        {
            try
            {
                await webView.EnsureCoreWebView2Async(null);
                webView.CoreWebView2.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải trang: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}