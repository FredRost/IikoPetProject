using IikoPetProject.Application.DTOs;

namespace IikoPetProject.Application.Interfaces
{
    /// <summary>
    /// Сервис аутентификации/регистрации и выдачи JWT.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>Регистрирует пользователя и возвращает JWT.</summary>
        Task<AuthResponseDto> RegisterAsync(string username, string email, string password);

        /// <summary>Авторизует пользователя и возвращает JWT.</summary>
        Task<AuthResponseDto> LoginAsync(string email, string password);
    }
}
