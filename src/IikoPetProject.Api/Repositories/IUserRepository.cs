using IikoPetProject.Api.Models;
using System.Threading.Tasks;

namespace IikoPetProject.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task SaveChangesAsync();
    }
}
