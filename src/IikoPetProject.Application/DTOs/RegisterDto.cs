namespace IikoPetProject.Application.DTOs
{
    /// <summary>
    /// Входные данные для регистрации нового пользователя.
    /// </summary>
    public class RegisterDto
    {
        /// <summary>Имя пользователя.</summary>
        public string Username { get; set; } = null!;

        /// <summary>Email.</summary>
        public string Email { get; set; } = null!;

        /// <summary>Пароль в открытом виде (будет захэширован).</summary>
        public string Password { get; set; } = null!;
    }
}
