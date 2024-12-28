using JokesApp.Data.Enum;
using JokesApp.Models;
using System.ComponentModel.DataAnnotations;

namespace JokesApp.ViewModels
{
    public class JokeDetailsViewModel
    {
        public int JokeId { get; set; } 
        public string? JokeContent { get; set; }
        public JokesCategory Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? RatingValue { get; set; }
        public double AverageRating { get; set; } 
        public int RatingsCount { get; set; }
        public string? Name { get; set; }
        public List<Rating>? Ratings { get; set; }
        public int? UserRating   { get; set; }
    }
}
