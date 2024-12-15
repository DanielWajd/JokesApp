using JokesApp.Models;

namespace JokesApp.Interfaces
{
    public interface IUserJokeService
    {
        Task<bool> AddAsync(UserJoke userJoke);
        Task<bool> SaveAsync();
    }
}
