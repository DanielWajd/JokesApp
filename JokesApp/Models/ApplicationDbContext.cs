using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JokesApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        { 
            
        }
        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<UserJoke> UserJokes { get; set; }
    }
}
