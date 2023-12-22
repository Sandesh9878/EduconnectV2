using Educonnect.Identity.Service.API.Models.Entities;
using Educonnect.Identity.Service.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Educonnect.Identity.Service.API.Models.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(b=>
            {
                b.HasKey(u => u.Id);
                b.ToTable("Users", "dbo");
            });
            builder.Entity<ApplicationRole>(b =>
            {
                b.ToTable("Roles", "dbo");
            });
            builder.Entity<IdentityRole>(b =>
            {
                b.ToTable("Roles", "dbo");
            });
            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("UserRoles", "dbo");
            });
            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("UserClaims", "dbo");
            });
            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("UserLogins", "dbo");
            });
        }
    }
}
