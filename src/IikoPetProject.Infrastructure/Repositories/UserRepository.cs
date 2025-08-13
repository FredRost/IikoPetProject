using IikoPetProject.Application.Interfaces;
using IikoPetProject.Domain.Entities;
using IikoPetProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IikoPetProject.Infrastructure.Repositories
{
    /// <summary>
    /// ���������� ����������� ������������� ����� EF Core.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IikoDbContext _db;

        /// <summary>�����������.</summary>
        public UserRepository(IikoDbContext db) => _db = db;

        /// <inheritdoc />
        public async Task<User?> GetByIdAsync(Guid id) =>
            await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

        /// <inheritdoc />
        public async Task<IReadOnlyList<User>> GetAllAsync() =>
            await _db.Users.AsNoTracking().OrderBy(u => u.Username).ToListAsync();

        /// <inheritdoc />
        public async Task AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }
    }
}
