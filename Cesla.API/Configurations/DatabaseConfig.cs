using Cesla.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Cesla.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<CeslaContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
