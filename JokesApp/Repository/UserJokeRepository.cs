using JokesApp.Interfaces;
using JokesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JokesApp.Repository
{
    public class UserJokeRepository : IUserJokeService
    {
        private readonly ApplicationDbContext _context;
        public UserJokeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(UserJoke userJoke)
        {
            await _context.UserJokes.AddAsync(userJoke);
            return await SaveAsync();
        }
        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
