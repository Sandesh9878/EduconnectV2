namespace Educonnect.Student.Service.Context
{
    public static class StudentPersistance
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(StudentDbContext).Assembly.FullName)));

            services.AddScoped<IStudentDbContext>(provider => provider.GetService<StudentDbContext>());
        }
    }
}
