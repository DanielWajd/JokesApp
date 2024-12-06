using Microsoft.EntityFrameworkCore;

namespace JokesApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        { 
            
        }
        public DbSet<Joke> Jokes { get; set; }
    }
}
