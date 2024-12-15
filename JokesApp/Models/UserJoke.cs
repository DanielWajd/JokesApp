using System.ComponentModel.DataAnnotations;

namespace JokesApp.Models
{
    public class UserJoke
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }

        [Required]
        public int JokeId { get; set; }
        public Joke Joke { get; set; }

    }
}
