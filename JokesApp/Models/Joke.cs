using JokesApp.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace JokesApp.Models
{
    public class Joke
    {
        [Key]
        public int Id { get; set; }
        public JokesCategory Category { get; set; }
        public string JokeContent { get; set; }

    }
}
