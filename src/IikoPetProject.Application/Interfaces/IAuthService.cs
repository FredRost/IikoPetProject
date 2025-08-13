using IikoPetProject.Application.DTOs;

namespace IikoPetProject.Application.Interfaces
{
    /// <summary>
    /// ������ ��������������/����������� � ������ JWT.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>������������ ������������ � ���������� JWT.</summary>
        Task<AuthResponseDto> RegisterAsync(string username, string email, string password);

        /// <summary>���������� ������������ � ���������� JWT.</summary>
        Task<AuthResponseDto> LoginAsync(string email, string password);
    }
}
