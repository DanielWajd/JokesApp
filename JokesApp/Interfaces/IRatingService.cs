using JokesApp.Models;

namespace JokesApp.Interfaces
{
    public interface IRatingService
    {
        Task<IEnumerable<Rating>> GetAll();
        Task<Rating> GetByIdAsync(int id);
        Task<bool> AddAsync(Rating rating);
        Task<bool> UpdateAsync(Rating rating);
        Task<bool> DeleteAsync(Rating rating);
        Task<bool> SaveAsync();
        Task<Rating> GetRatingByUserAndJokeAsync(string userId, int jokeId);
        Task<List<Rating>> GetRatingsByJokeIdAsync(int jokeId);
    }
}
