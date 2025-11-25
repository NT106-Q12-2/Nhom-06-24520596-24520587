using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai04_.Models;
using Bai04_.Services;
using Bai04_.Controls;

namespace Bai04_
{
    public partial class Form1 : Form
    {
        private readonly WebCrawlerService _crawlerService;
        private readonly DataService _dataService;
        private List<Movie> _movies;
        private Movie _selectedMovie;

        public Form1()
        {
            InitializeComponent();
            _crawlerService = new WebCrawlerService();
            _dataService = new DataService();
            _movies = new List<Movie>();

            Load += Form1_Load;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (_dataService.HasCachedMovies())
            {
                await LoadMoviesFromFile();
            }
            else
            {
                lbl_Status.Text = "Nhấn 'Cập nhật từ Website' để tải danh sách phim";
            }
        }

        private async void btn_LoadMovies_Click(object sender, EventArgs e)
        {
            await LoadMoviesFromFile();
        }

        private async void btn_RefreshFromWeb_Click(object sender, EventArgs e)
        {
            await LoadMoviesFromWeb();
        }

        private async Task LoadMoviesFromFile()
        {
            try
            {
                SetLoadingState(true, "Đang đọc dữ liệu từ file...");

                _movies = await _dataService.LoadMoviesAsync();

                if (_movies.Count == 0)
                {
                    lbl_Status.Text = "Chưa có dữ liệu. Vui lòng cập nhật từ website";
                    MessageBox.Show("Chưa có dữ liệu phim trong cache. Vui lòng cập nhật từ website!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DisplayMovies();
                    lbl_Status.Text = $"Đã tải {_movies.Count} phim từ cache";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbl_Status.Text = "Lỗi khi đọc dữ liệu";
            }
            finally
            {
                SetLoadingState(false, null);
            }
        }

        private async Task LoadMoviesFromWeb()
        {
            try
            {
                SetLoadingState(true, "Đang tải danh sách phim từ website...");

                var progress = new Progress<int>(value =>
                {
                    if (pb_Loading.InvokeRequired)
                    {
                        pb_Loading.Invoke(new Action(() => pb_Loading.Value = value));
                    }
                    else
                    {
                        pb_Loading.Value = value;
                    }
                });

                _movies = await _crawlerService.CrawlMoviesAsync(progress);

                if (_movies != null && _movies.Count > 0)
                {
                    await _dataService.SaveMoviesAsync(_movies);
                    DisplayMovies();
                    lbl_Status.Text = $"Đã tải {_movies.Count} phim và lưu vào cache";
                    MessageBox.Show($"Đã tải thành công {_movies.Count} phim!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lbl_Status.Text = "Không tìm thấy phim nào hoặc có lỗi xảy ra";
                    MessageBox.Show("Không thể tải danh sách phim. Vui lòng thử lại sau.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu từ web: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbl_Status.Text = "Lỗi khi tải từ website";
            }
            finally
            {
                SetLoadingState(false, null);
            }
        }

        private void DisplayMovies()
        {
            flp_Movies.Controls.Clear();

            int validMovies = 0;
            foreach (var movie in _movies)
            {
                if (movie == null || string.IsNullOrWhiteSpace(movie.Title) ||
                    movie.Title.Contains("xem chi tiết") || movie.Title.Length < 3)
                {
                    continue;
                }

                var movieCard = new MovieCard
                {
                    Movie = movie,
                    Width = 180,
                    Height = 300
                };
                movieCard.MovieClicked += MovieCard_MovieClicked;
                flp_Movies.Controls.Add(movieCard);
                validMovies++;
            }

            lbl_Status.Text = $"Đã hiển thị {validMovies}/{_movies.Count} phim hợp lệ";
        }

        private void MovieCard_MovieClicked(object sender, Movie movie)
        {
            if (movie == null)
            {
                return;
            }

            _selectedMovie = movie;
            btn_BookTicket.Enabled = true;
            lbl_Status.Text = $"Đã chọn: {movie.Title} - Có thể đặt vé ngay!";
            lbl_Status.ForeColor = System.Drawing.Color.Green;
        }

        private void nud_Tickets_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void nud_PricePerTicket_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = nud_Tickets.Value * nud_PricePerTicket.Value;
            lbl_TotalValue.Text = $"{total:N0} VNĐ";
        }

        private async void btn_BookTicket_Click(object sender, EventArgs e)
        {
            if (_selectedMovie == null)
            {
                MessageBox.Show("Vui lòng chọn phim trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_CustomerName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_CustomerName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tb_PhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_PhoneNumber.Focus();
                return;
            }

            try
            {
                var customer = new Customer
                {
                    Name = tb_CustomerName.Text.Trim(),
                    PhoneNumber = tb_PhoneNumber.Text.Trim()
                };

                var ticket = new Ticket
                {
                    Customer = customer,
                    Movie = _selectedMovie,
                    NumberOfTickets = (int)nud_Tickets.Value,
                    PricePerTicket = nud_PricePerTicket.Value
                };

                ticket.CalculateTotal();

                await _dataService.SaveTicketAsync(ticket);

                var message = $"ĐẶT VÉ THÀNH CÔNG!\n\n" +
                    $"Mã vé: {ticket.TicketId}\n" +
                    $"Khách hàng: {customer.Name}\n" +
                    $"SĐT: {customer.PhoneNumber}\n" +
                    $"Phim: {_selectedMovie.Title}\n" +
                    $"Số vé: {ticket.NumberOfTickets}\n" +
                    $"Tổng tiền: {ticket.TotalAmount:N0} VNĐ\n\n" +
                    $"Cảm ơn quý khách!";

                MessageBox.Show(message, "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                tb_CustomerName.Clear();
                tb_PhoneNumber.Clear();
                nud_Tickets.Value = 1;
                lbl_Status.Text = $"Đã đặt vé thành công - Mã: {ticket.TicketId}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt vé: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetLoadingState(bool isLoading, string message)
        {
            btn_LoadMovies.Enabled = !isLoading;
            btn_RefreshFromWeb.Enabled = !isLoading;
            btn_BookTicket.Enabled = !isLoading && _selectedMovie != null;

            pb_Loading.Visible = isLoading;
            pb_Loading.Value = 0;

            if (!string.IsNullOrEmpty(message))
            {
                lbl_Status.Text = message;
            }

            Application.DoEvents();
        }
    }
}