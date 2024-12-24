using JokesApp.Data.Enum;
using JokesApp.Models;

namespace JokesApp.Interfaces
{
    public interface IJokeService
    {
        Task<IEnumerable<Joke>> GetAll();
        Task<Joke> GetByIdAsync(int id);
        Task<bool> AddAsync(Joke joke); 
        Task<bool> UpdateAsync(Joke joke); 
        Task<bool> DeleteAsync(Joke joke); 
        Task<bool> SaveAsync();
        Task<IEnumerable<Joke>> GetFilteredJokes(string category);
    }
}
