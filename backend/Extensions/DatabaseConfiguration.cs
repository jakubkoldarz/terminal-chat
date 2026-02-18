using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Extensions
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
    }
}
