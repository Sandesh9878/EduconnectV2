namespace Educonnect.Common.Service.Context
{
    public class CommonDbContext : DbContext, ICommonDbContext
    {
        public CommonDbContext(DbContextOptions<CommonDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ReferenceMasterDetailEntity> ReferenceMasterDetail { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<FormEntity> FormEntity { get; set; }
        public DbSet<FormEntityOption> FormEntityOption { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
