using JokesApp.Interfaces;
using JokesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JokesApp.Repository
{
    public class RatingRepository : IRatingService
    {
        private readonly ApplicationDbContext _context;
        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
            return await SaveAsync();
        }

        public Task<bool> DeleteAsync(Rating rating)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rating>> GetAll()
        {
            return await _context.Ratings.ToListAsync();
        }

        public Task<Rating> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Rating> GetRatingByUserAndJokeAsync(string userId, int jokeId)
        {
            return await _context.Ratings.FirstOrDefaultAsync(r => r.UserId == userId && r.JokeId == jokeId);
        }

        public async Task<List<Rating>> GetRatingsByJokeIdAsync(int jokeId)
        {
            return await _context.Ratings.Where(r => r.JokeId == jokeId).ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Rating rating)
        {
            _context.Ratings.Update(rating);
            return await SaveAsync();
        }

    }
}
