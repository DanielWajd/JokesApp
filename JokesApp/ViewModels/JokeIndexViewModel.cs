using JokesApp.Data.Enum;

namespace JokesApp.ViewModels
{
    public class JokeIndexViewModel
    {
        public int Id { get; set; }
        public JokesCategory Category { get; set; }
        public string JokeContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public double AverageRating { get; set; } 
        public int RatingsCount { get; set; }    
    }
}
