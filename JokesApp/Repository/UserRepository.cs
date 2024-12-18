using JokesApp.Interfaces;
using JokesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JokesApp.Repository
{
    public class UserRepository : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users
        .Include(u => u.Ratings)
        .ThenInclude(r => r.Joke)  
        .Include(u => u.UserJokes)
        .ThenInclude(uj => uj.Joke) 
        .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
