using IikoPetProject.Domain.Entities;

namespace IikoPetProject.Application.Interfaces
{
    /// <summary>
    /// ����������� �������������.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>�������� ������������ �� Id.</summary>
        Task<User?> GetByIdAsync(Guid id);

        /// <summary>�������� ���� �������������.</summary>
        Task<IReadOnlyList<User>> GetAllAsync();

        /// <summary>�������� ������ ������������.</summary>
        Task AddAsync(User user);
    }
}
