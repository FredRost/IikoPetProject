using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IikoPetProject.Domain.Entities
{
    /// <summary>
    /// �������� �������� ������������ �������.
    /// </summary>
    public class User
    {
        /// <summary>
        /// ���������� ������������� ������������ (UUID). ������������ �� ������� ����������.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// ������������ ��� ������������.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Email (����������).
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// ��� ������ (������� �� ������� ������ � �������� ����).
        /// </summary>
        [Required]
        public string PasswordHash { get; set; } = null!;

        /// <summary>
        /// ���� ������������ (��������, User/Admin).
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = "User";
    }
}
