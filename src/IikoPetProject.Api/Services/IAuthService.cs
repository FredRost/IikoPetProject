using IikoPetProject.Api.DTOs;
using System.Threading.Tasks;

namespace IikoPetProject.Api.Services
{
    public interface IAuthService
    {
        Task<UserDto?> AuthenticateAsync(string username, string password);
        Task RegisterAsync(string username, string password, string email);
    }
}
