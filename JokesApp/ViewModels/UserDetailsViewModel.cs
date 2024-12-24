using JokesApp.Data.Enum;
using JokesApp.Models;
using System.ComponentModel.DataAnnotations;

namespace JokesApp.ViewModels
{
    public class UserDetailsViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public UserType UserType { get; set; }

        public ICollection<Rating>? Ratings { get; set; }
        public ICollection<UserJoke>? UserJokes { get; set; }
    }
}
