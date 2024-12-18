using JokesApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JokesApp.Interfaces
{
    public interface IUserService 
    {
        Task<AppUser> GetUserById(string id);
    }
}
