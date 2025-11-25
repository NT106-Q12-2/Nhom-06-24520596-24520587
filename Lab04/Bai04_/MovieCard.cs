using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai04_.Models;

namespace Bai04_.Controls
{
    public partial class MovieCard : UserControl
    {
        private Movie _movie;
        public event EventHandler<Movie> MovieClicked;

        public Movie Movie
        {
            get => _movie;
            set
            {
                _movie = value;
                UpdateDisplay();
            }
        }

        public MovieCard()
        {
            InitializeComponent();

            this.Click += HandleClick;
            pic_Poster.Click += HandleClick;
            lbl_Title.Click += HandleClick;
            btn_ViewDetails.Click += btn_ViewDetails_Click;
        }

        private async void UpdateDisplay()
        {
            if (_movie == null) return;

            lbl_Title.Text = _movie.Title;
            await LoadPosterImage();
        }

        private async Task LoadPosterImage()
        {
            if (string.IsNullOrEmpty(_movie.PosterUrl))
            {
                pic_Poster.Image = CreatePlaceholderImage();
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);
                    byte[] data = await client.GetByteArrayAsync(_movie.PosterUrl);
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        pic_Poster.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                pic_Poster.Image = CreatePlaceholderImage();
            }
        }

        private Image CreatePlaceholderImage()
        {
            Bitmap bmp = new Bitmap(160, 220);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                using (Font font = new Font("Arial", 9))
                using (StringFormat sf = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                })
                {
                    g.DrawString("Click để xem\nchi tiết phim", font, Brushes.Gray,
                        new Rectangle(0, 0, 160, 220), sf);
                }
            }
            return bmp;
        }

        private void HandleClick(object sender, EventArgs e)
        {
            MovieClicked?.Invoke(this, _movie);
        }

        private void btn_ViewDetails_Click(object sender, EventArgs e)
        {
            OpenMovieDetailForm();
        }

        private void OpenMovieDetailForm()
        {
            if (_movie != null && !string.IsNullOrEmpty(_movie.DetailUrl))
            {
                try
                {
                    var detailForm = new MovieDetailForm(_movie.DetailUrl, _movie.Title);
                    detailForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể mở chi tiết phim: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có thông tin chi tiết cho phim này", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}