using JokesApp.Interfaces;
using JokesApp.Models;

namespace JokesApp.Repository
{
    public class UserRepository : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
