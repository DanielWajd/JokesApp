using JokesApp.Data.Enum;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JokesApp.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public override string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public UserType UserType { get; set; }

        public ICollection<Rating> Ratings { get; set; }
        public ICollection<UserJoke> UserJokes { get; set; }

    }
}
