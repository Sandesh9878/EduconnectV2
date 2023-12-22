namespace Educonnect.Institute.Service.Context
{
    public class InstituteDbContext : DbContext, IInstituteDbContext
    {
        public InstituteDbContext(DbContextOptions<InstituteDbContext> options)
    : base(options)
        {
        }

        public DbSet<InstituteEntity> Institute { get; set; }

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
