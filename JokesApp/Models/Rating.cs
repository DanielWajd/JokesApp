using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JokesApp.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public int JokeId { get; set; } 
        public Joke Joke { get; set; }  

        [Required]
        public string UserId { get; set; } 
        public AppUser User { get; set; }  

        [Required]
        [Range(1, 5)] 
        public int RatingValue { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
