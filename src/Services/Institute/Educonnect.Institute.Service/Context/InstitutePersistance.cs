namespace Educonnect.Institute.Service.Context
{
    public static class InstitutePersistance
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InstituteDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(InstituteDbContext).Assembly.FullName)));

            services.AddScoped<IInstituteDbContext>(provider => provider.GetService<InstituteDbContext>());
        }
    }
}
