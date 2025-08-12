using IikoPetProject.Api.DTOs;
using IikoPetProject.Api.Models;
using IikoPetProject.Api.Repositories;
using System;
using System.Threading.Tasks;
using BCrypt.Net;

namespace IikoPetProject.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task RegisterAsync(string username, string password, string email)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = new User
            {
                Username = username,
                PasswordHash = passwordHash,
                Email = email,
                Role = "User"
            };

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();
        }
    }
}
