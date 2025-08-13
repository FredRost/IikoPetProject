namespace IikoPetProject.Application.DTOs
{
    /// <summary>
    /// Ответ аутентификации/регистрации с JWT и данными пользователя.
    /// </summary>
    public class AuthResponseDto
    {
        /// <summary>JWT-токен.</summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>Идентификатор пользователя.</summary>
        public Guid UserId { get; set; }

        /// <summary>Имя пользователя.</summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>Email пользователя.</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Роль пользователя.</summary>
        public string Role { get; set; } = string.Empty;
    }
}
