using System;

namespace Bai04_.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public string DetailUrl { get; set; }
        public DateTime CrawledDate { get; set; }
    }
}