using Educonnect.Identity.Service.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Educonnect.Identity.Service.Context
{
    public interface IIdentityDbContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync();

    }
}
