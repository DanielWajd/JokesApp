using JokesApp.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace JokesApp.Models
{
    public class Joke
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public JokesCategory Category { get; set; }

        [Required]
        [StringLength(500)]
        public string JokeContent { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Rating> Ratings { get; set; }
        public ICollection<UserJoke> UserJokes { get; set; }

    }
}
