using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IikoPetProject.Application.DTOs;
using IikoPetProject.Application.Interfaces;
using IikoPetProject.Domain.Entities;
using IikoPetProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IikoPetProject.Infrastructure.Services
{
    /// <summary>
    /// Сервис регистрации/логина и генерации JWT.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IikoDbContext _context;
        private readonly IConfiguration _configuration;

        /// <summary>Конструктор.</summary>
        public AuthService(IikoDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <inheritdoc />
        public async Task<AuthResponseDto> RegisterAsync(string username, string email, string password)
        {
            if (await _context.Users.AnyAsync(u => u.Email == email))
                throw new Exception("User already exists");

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password),
                Role = "User"
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return GenerateJwt(user);
        }

        /// <inheritdoc />
        public async Task<AuthResponseDto> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || user.PasswordHash != HashPassword(password))
                throw new Exception("Invalid credentials");

            return GenerateJwt(user);
        }

        /// <summary>
        /// Генерирует JWT для пользователя.
        /// </summary>
        private AuthResponseDto GenerateJwt(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }

        /// <summary>
        /// Хэширует пароль алгоритмом SHA-256 и возвращает Base64 строку.
        /// </summary>
        private string HashPassword(string password)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
