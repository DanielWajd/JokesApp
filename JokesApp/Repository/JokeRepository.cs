using JokesApp.Interfaces;
using JokesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JokesApp.Repository
{
    public class JokeRepository : IJokeService
    {
        private readonly ApplicationDbContext _context;
        public JokeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Joke joke)
        {
            await _context.Jokes.AddAsync(joke);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(Joke joke)
        {
            _context.Jokes.Remove(joke); 
            return await SaveAsync();
        }

        public async Task<IEnumerable<Joke>> GetAll()
        {
            return await _context.Jokes.Include(j=>j.Ratings).ToListAsync();
        }

        public async Task<Joke> GetByIdAsync(int id)
        {
            return await _context.Jokes.FirstOrDefaultAsync(j => j.Id == id);
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync(); 
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Joke joke)
        {
            _context.Jokes.Update(joke); 
            return await SaveAsync();
        }
    }
}
