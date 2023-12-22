using Educonnect.Course.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Educonnect.Course.Service.Entitites;

namespace Educonnect.Course.Service.Context
{
    public class CourseDbContext : DbContext, ICourseDbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<CourseSearchEntity> InstituteCourse { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public async Task<IEnumerable<CourseSearchEntity>> CourseDataSP()
        {
            var param = new SqlParameter("@publishedStatus",1);
            var param1 = new SqlParameter("@instituteImageType",1);
            var result = this.InstituteCourse.FromSqlRaw("exec sp_SearchServices_GetAll_Records @publishedStatus,@instituteImageType", param, param1);
            return result;
        }
    }
}
