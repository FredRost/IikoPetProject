using IikoPetProject.Domain.Entities;

namespace IikoPetProject.Application.Interfaces
{
    /// <summary>
    /// Репозиторий пользователей.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>Получить пользователя по Id.</summary>
        Task<User?> GetByIdAsync(Guid id);

        /// <summary>Получить всех пользователей.</summary>
        Task<IReadOnlyList<User>> GetAllAsync();

        /// <summary>Добавить нового пользователя.</summary>
        Task AddAsync(User user);
    }
}
