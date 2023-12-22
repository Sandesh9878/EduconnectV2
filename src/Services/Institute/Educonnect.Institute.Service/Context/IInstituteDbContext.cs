namespace Educonnect.Institute.Service.Context
{
    public interface IInstituteDbContext
    {
        DbSet<InstituteEntity> Institute { get; set; }
        Task<int> SaveChangesAsync();
    }
}
