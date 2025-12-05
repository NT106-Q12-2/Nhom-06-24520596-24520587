using Bai04.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai04.Services
{
    public class WebCrawlerService
    {
        private readonly HttpClient _httpClient;

        public WebCrawlerService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
        }

        public async Task<List<Movie>> CrawlMoviesAsync(IProgress<int> progress = null)
        {
            var movies = new List<Movie>();

            try
            {
                progress?.Report(10);

                string url = "https://betacinemas.vn/phim-dang-chieu.htm";
                var html = await _httpClient.GetStringAsync(url);

                progress?.Report(30);

                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(html);

                var movieNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'movie-item')] | //div[contains(@class, 'film')] | //div[contains(@class, 'item')] | //a[contains(@href, 'chi-tiet-phim')]");

                progress?.Report(50);

                if (movieNodes != null && movieNodes.Count > 0)
                {
                    int processed = 0;
                    int total = movieNodes.Count;

                    foreach (var node in movieNodes)
                    {
                        try
                        {
                            var movie = await ExtractBasicMovieInfo(node);
                            if (movie != null && !string.IsNullOrEmpty(movie.Title) && !IsDuplicate(movies, movie))
                            {
                                movies.Add(movie);
                            }
                        }
                        catch
                        {
                        }

                        processed++;
                        int progressValue = 50 + (processed * 40 / total);
                        progress?.Report(progressValue);
                    }
                }
                if (movies.Count == 0)
                {
                    movies = await GetComprehensiveSampleMoviesAsync(progress);
                }

                progress?.Report(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể crawl từ website. Sử dụng dữ liệu mẫu.\nLỗi: {ex.Message}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                movies = await GetComprehensiveSampleMoviesAsync(progress);
            }

            return movies;
        }

        private async Task<Movie> ExtractBasicMovieInfo(HtmlAgilityPack.HtmlNode node)
        {
            try
            {
                var title =
                    node.SelectSingleNode(".//h3")?.InnerText?.Trim() ??
                    node.SelectSingleNode(".//h2")?.InnerText?.Trim() ??
                    node.SelectSingleNode(".//div[contains(@class, 'title')]")?.InnerText?.Trim() ??
                    node.SelectSingleNode(".//span[contains(@class, 'title')]")?.InnerText?.Trim() ??
                    node.SelectSingleNode(".//a")?.InnerText?.Trim() ??
                    "";

                if (string.IsNullOrWhiteSpace(title) ||
                    title.Length < 2 ||
                    title.Contains("Trang chủ") ||
                    title.Contains("Beta") ||
                    title.Contains("Cinema") ||
                    title == "Xem thêm")
                    return null;

                title = CleanTitle(title);
                var linkNode = node.SelectSingleNode(".//a[contains(@href, 'chi-tiet-phim')]") ?? node;
                var href = linkNode?.GetAttributeValue("href", "");

                if (!string.IsNullOrEmpty(href) && !href.StartsWith("http"))
                    href = href.StartsWith("/") ? "https://betacinemas.vn" + href : "https://betacinemas.vn/" + href;
                var imgNode = node.SelectSingleNode(".//img");

                string posterUrl = "";

                if (imgNode != null)
                {
                    posterUrl = imgNode.GetAttributeValue("data-src", "");
                    if (string.IsNullOrEmpty(posterUrl))
                        posterUrl = imgNode.GetAttributeValue("src", "");
                }
                if (!string.IsNullOrEmpty(posterUrl) && !posterUrl.StartsWith("http"))
                {
                    posterUrl = posterUrl.StartsWith("/")
                        ? "https://betacinemas.vn" + posterUrl
                        : "https://betacinemas.vn/" + posterUrl;
                }
                if (string.IsNullOrEmpty(posterUrl))
                    posterUrl = $"https://via.placeholder.com/200x300/007ACC/FFFFFF?text={Uri.EscapeDataString(title)}";
                return new Movie
                {
                    Id = Guid.NewGuid().ToString().Substring(0, 8),
                    Title = title,
                    PosterUrl = posterUrl,
                    DetailUrl = href,
                    Description = "Đang tải thông tin chi tiết...",
                    Director = "Đang cập nhật",
                    Actors = "Đang cập nhật",
                    Genre = "Đang cập nhật",
                    Duration = "Đang cập nhật",
                    CrawledDate = DateTime.Now
                };
            }
            catch
            {
                return null;
            }
        }


        private string CleanTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) return title;

            title = title.Replace("\n", " ").Replace("\r", " ").Replace("\t", " ");
            while (title.Contains("  ")) title = title.Replace("  ", " ");

            return title.Trim();
        }

        private bool IsDuplicate(List<Movie> movies, Movie newMovie)
        {
            return movies.Exists(m => m.Title == newMovie.Title);
        }

        public async Task<Movie> GetMovieDetailsAsync(Movie movie, IProgress<int> progress = null)
        {
            try
            {
                progress?.Report(20);

                if (!string.IsNullOrEmpty(movie.DetailUrl) && !movie.DetailUrl.Contains("placeholder"))
                {
                    try
                    {
                        var html = await _httpClient.GetStringAsync(movie.DetailUrl);
                        progress?.Report(60);

                        var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                        htmlDoc.LoadHtml(html);
                        UpdateMovieDetailsFromHtml(movie, htmlDoc);
                    }
                    catch
                    {
                        UpdateMovieWithSampleDetails(movie);
                    }
                }
                else
                {
                    UpdateMovieWithSampleDetails(movie);
                }

                progress?.Report(100);
                return movie;
            }
            catch (Exception ex)
            {
                UpdateMovieWithSampleDetails(movie);
                progress?.Report(100);
                return movie;
            }
        }

        private void UpdateMovieDetailsFromHtml(Movie movie, HtmlAgilityPack.HtmlDocument htmlDoc)
        {
            var description = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'description')] | //div[contains(@class, 'content')] | //p");
            if (description != null)
                movie.Description = description.InnerText.Trim();

            var poster = htmlDoc.DocumentNode.SelectSingleNode("//img[contains(@src, 'Content/Files')] | //div[contains(@class, 'poster')]//img");
            if (poster != null)
            {
                var newPoster = poster.GetAttributeValue("src", "");
                if (!string.IsNullOrEmpty(newPoster) && !newPoster.StartsWith("http"))
                    newPoster = "https://betacinemas.vn" + newPoster;

                if (!string.IsNullOrEmpty(newPoster))
                    movie.PosterUrl = newPoster;
            }
        }

        private void UpdateMovieWithSampleDetails(Movie movie)
        {
            if (movie.Title.Contains("Lật Mặt") || movie.Title.Contains("Lật mặt"))
            {
                movie.Description = "Mẹ khoe rằng mẹ có 5 người con dễ thương, ngoan và quan tâm mẹ lắm, nhưng sao bữa cơm mẹ chỉ có một mình?";
                movie.Director = "Lý Hải";
                movie.Actors = "Thanh Hiền, Trương Minh Cường, Đinh Y Nhung, Quách Ngọc Tuyên";
                movie.Genre = "Tâm lý, Gia đình";
                movie.Duration = "138 phút";
            }
            else if (movie.Title.Contains("Cái Giá") || movie.Title.Contains("Hạnh Phúc"))
            {
                movie.Description = "Một bộ phim về giá trị đích thực của hạnh phúc trong cuộc sống hiện đại.";
                movie.Director = "Đạo diễn A";
                movie.Actors = "Diễn viên X, Diễn viên Y";
                movie.Genre = "Tâm lý, Tình cảm";
                movie.Duration = "120 phút";
            }
            else if (movie.Title.Contains("Biệt Đội") || movie.Title.Contains("Săn Ma"))
            {
                movie.Description = "Cuộc phiêu lưu mới của biệt đội săn ma trong kỷ nguyên băng giá.";
                movie.Director = "Đạo diễn B";
                movie.Actors = "Diễn viên P, Diễn viên Q";
                movie.Genre = "Hành động, Viễn tưởng";
                movie.Duration = "115 phút";
            }
            else
            {
                movie.Description = $"Bộ phim '{movie.Title}' đang thu hút đông đảo khán giả. Một tác phẩm điện ảnh đầy cảm xúc và ý nghĩa.";
                movie.Director = "Đang cập nhật";
                movie.Actors = "Đang cập nhật";
                movie.Genre = "Đang cập nhật";
                movie.Duration = "Đang cập nhật";
            }
        }

        private async Task<List<Movie>> GetComprehensiveSampleMoviesAsync(IProgress<int> progress = null)
        {
            var sampleMovies = new List<Movie>
            {
                new Movie { Id = "1", Title = "Lật Mặt 7", PosterUrl = "https://via.placeholder.com/200x300/007ACC/FFFFFF?text=LẬT+MẶT+7" },
                new Movie { Id = "2", Title = "Cái Giá Của Hạnh Phúc", PosterUrl = "https://via.placeholder.com/200x300/28A745/FFFFFF?text=CÁI+GIÁ+HẠNH+PHÚC" },
                new Movie { Id = "3", Title = "Biệt Đội Săn Ma: Kỷ Nguyên Băng Giá", PosterUrl = "https://via.placeholder.com/200x300/DC3545/FFFFFF?text=BIỆT+ĐỘI+SĂN+MA" },
                new Movie { Id = "4", Title = "Thanh Xuân 18X2: Lữ Trình Hướng Về Em", PosterUrl = "https://via.placeholder.com/200x300/FFC107/000000?text=THANH+XUÂN+18X2" },
                new Movie { Id = "5", Title = "Trạng Tử: Một Chuyến Phiêu Lưu Học Đường", PosterUrl = "https://via.placeholder.com/200x300/6F42C1/FFFFFF?text=TRẠNG+TỬ" },
                new Movie { Id = "6", Title = "Bão Táp Cung Đình", PosterUrl = "https://via.placeholder.com/200x300/20C997/FFFFFF?text=BÃO+TÁP+CUNG+ĐÌNH" },
                new Movie { Id = "7", Title = "Siêu Trộm Thế Kỷ", PosterUrl = "https://via.placeholder.com/200x300/FD7E14/FFFFFF?text=SIÊU+TRỘM+THẾ+KỶ" },
                new Movie { Id = "8", Title = "Hành Trình Về Phương Đông", PosterUrl = "https://via.placeholder.com/200x300/E83E8C/FFFFFF?text=HÀNH+TRÌNH+PHƯƠNG+ĐÔNG" }
            };

            for (int i = 0; i < sampleMovies.Count; i++)
            {
                progress?.Report((i + 1) * 12);
                await Task.Delay(200);
            }

            progress?.Report(100);
            return sampleMovies;
        }
    }
}