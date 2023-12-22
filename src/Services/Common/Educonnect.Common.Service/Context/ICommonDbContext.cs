namespace Educonnect.Common.Service.Context
{
    public interface ICommonDbContext
    {
        DbSet<ReferenceMasterDetailEntity> ReferenceMasterDetail { get; set; }
        DbSet<Form> Form { get; set; }
        DbSet<FormEntity> FormEntity { get; set; }
        DbSet<FormEntityOption> FormEntityOption { get; set; }
        Task<int> SaveChangesAsync();
    }
}
