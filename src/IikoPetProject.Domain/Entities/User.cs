using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IikoPetProject.Domain.Entities
{
    /// <summary>
    /// Доменная сущность пользователя системы.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя (UUID). Генерируется на стороне приложения.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Отображаемое имя пользователя.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Email (уникальный).
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Хэш пароля (никогда не хранить пароль в открытом виде).
        /// </summary>
        [Required]
        public string PasswordHash { get; set; } = null!;

        /// <summary>
        /// Роль пользователя (например, User/Admin).
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = "User";
    }
}
