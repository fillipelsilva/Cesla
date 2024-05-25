using Serilog;

namespace Cesla.API.Configurations
{
    public static class SerilogConfig
    {
        public static void AddSerilogCongiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json")
                                .Build();

            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Information()
                                .ReadFrom.Configuration(config)
                                .CreateLogger();
        }
    }
}
