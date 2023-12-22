using Educonnect.Identity.Service.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Educonnect.Identity.Service.Context
{
    public class IdentityDbContext : DbContext, IIdentityDbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
