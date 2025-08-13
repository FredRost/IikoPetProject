using IikoPetProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IikoPetProject.Infrastructure.Data
{
    /// <summary>
    /// �������� EF Core ��� ����������.
    /// </summary>
    public class IikoDbContext : DbContext
    {
        /// <summary>������ ����� ��������� DbContext.</summary>
        public IikoDbContext(DbContextOptions<IikoDbContext> options) : base(options) { }

        /// <summary>����� �������������.</summary>
        public DbSet<User> Users => Set<User>();

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ���� ������, ��� Guid ������������ �� ������� � Email ��������.
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedNever();
                b.HasIndex(x => x.Email).IsUnique();
            });
        }
    }
}
