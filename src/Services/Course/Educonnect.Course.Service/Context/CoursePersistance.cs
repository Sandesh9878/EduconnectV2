using Microsoft.EntityFrameworkCore;

namespace Educonnect.Course.Service.Context
{
    public static class CoursePersistance
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CourseDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(CourseDbContext).Assembly.FullName)));

            services.AddScoped<ICourseDbContext>(provider => provider.GetService<CourseDbContext>());
        }
    }
}
