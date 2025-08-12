using IikoPetProject.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IikoPetProject.Api.Data
{
    public class IikoDbContext : DbContext
    {
        public IikoDbContext(DbContextOptions<IikoDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
    }
}
