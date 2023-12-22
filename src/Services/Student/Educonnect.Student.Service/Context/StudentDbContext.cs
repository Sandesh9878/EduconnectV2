namespace Educonnect.Student.Service.Context
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
: base(options)
        {
        }
        public DbSet<StudentEntity> Person { get; set; }
        public DbSet<StudentApplication> StudentApplication { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }

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
