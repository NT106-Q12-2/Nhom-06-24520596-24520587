using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using Bai04_.Models;

namespace Bai04_.Services
{
    public class DataService
    {
        private readonly string _moviesFilePath = "movies.json";
        private readonly string _ticketsFilePath = "tickets.json";

        public Task<List<Movie>> LoadMoviesAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    if (!File.Exists(_moviesFilePath))
                        return new List<Movie>();

                    var json = File.ReadAllText(_moviesFilePath);
                    return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
                }
                catch
                {
                    return new List<Movie>();
                }
            });
        }

        public Task SaveMoviesAsync(List<Movie> movies)
        {
            return Task.Run(() =>
            {
                try
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    var json = JsonSerializer.Serialize(movies, options);
                    File.WriteAllText(_moviesFilePath, json);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi lưu danh sách phim: {ex.Message}");
                }
            });
        }

        public Task SaveTicketAsync(Ticket ticket)
        {
            return Task.Run(() =>
            {
                try
                {
                    var tickets = LoadTicketsAsync().Result;
                    tickets.Add(ticket);

                    var options = new JsonSerializerOptions { WriteIndented = true };
                    var json = JsonSerializer.Serialize(tickets, options);
                    File.WriteAllText(_ticketsFilePath, json);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi lưu vé: {ex.Message}");
                }
            });
        }

        public Task<List<Ticket>> LoadTicketsAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    if (!File.Exists(_ticketsFilePath))
                        return new List<Ticket>();

                    var json = File.ReadAllText(_ticketsFilePath);
                    return JsonSerializer.Deserialize<List<Ticket>>(json) ?? new List<Ticket>();
                }
                catch
                {
                    return new List<Ticket>();
                }
            });
        }

        public bool HasCachedMovies()
        {
            return File.Exists(_moviesFilePath) && new FileInfo(_moviesFilePath).Length > 0;
        }
    }
}