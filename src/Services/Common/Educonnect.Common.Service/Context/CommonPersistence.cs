namespace Educonnect.Common.Service.Context
{
    public static class CommonPersistence
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommonDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(CommonDbContext).Assembly.FullName)));

            services.AddScoped<ICommonDbContext>(provider => provider.GetService<CommonDbContext>());
        }
    }
}
