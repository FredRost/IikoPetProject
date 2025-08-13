namespace IikoPetProject.Application.DTOs
{
    /// <summary>
    /// Входные данные для авторизации.
    /// </summary>
    public class LoginDto
    {
        /// <summary>Email для входа.</summary>
        public string Email { get; set; } = null!;

        /// <summary>Пароль в открытом виде (будет захэширован).</summary>
        public string Password { get; set; } = null!;
    }
}
