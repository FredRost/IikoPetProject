using IikoPetProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IikoPetProject.Infrastructure.Data
{
    /// <summary>
    /// Контекст EF Core для приложения.
    /// </summary>
    public class IikoDbContext : DbContext
    {
        /// <summary>Создаёт новый экземпляр DbContext.</summary>
        public IikoDbContext(DbContextOptions<IikoDbContext> options) : base(options) { }

        /// <summary>Набор пользователей.</summary>
        public DbSet<User> Users => Set<User>();

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Явно укажем, что Guid генерируется на клиенте и Email уникален.
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
                b.HasIndex(x => x.Email).IsUnique();
            });
        }
    }
}
