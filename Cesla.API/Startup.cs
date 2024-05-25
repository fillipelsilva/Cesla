using Cesla.API.Abstractions;
using Cesla.API.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using System.Reflection;

namespace Cesla.API
{
    public class Startup
    {
        public readonly IConfiguration config;
        public Startup(IConfiguration config)
        {
            this.config = config;
            var builder = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Serilog
            services.AddSerilogCongiguration(config);

            // Internacionalização
            services.AddLocalization(options => options.ResourcesPath = "");

            //WebAPI Config
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(LogRequestFilterAttribute));
            });

            // Setting DBContext
            services.AddDatabaseConfiguration(config);

            // AutoMapper Settings
            services.AddAutoMapperConfiguration();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration();

            // Swagger Config
            services.AddSwaggerConfiguration();

            //Mediatr Config
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[] { "pt-BR" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                                                                      .AddSupportedCultures(supportedCultures);
            app.UseSerilogRequestLogging();

            app.UseRequestLocalization(localizationOptions);

            app.UseRouting();

            loggerFactory.AddSerilog();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();

        }
    }
}
