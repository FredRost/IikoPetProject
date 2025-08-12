using IikoPetProject.Api.Data;
using IikoPetProject.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IikoPetProject.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IikoDbContext _context;

        public UserRepository(IikoDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
