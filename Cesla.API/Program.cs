using Cesla.API;
using Microsoft.AspNetCore.Hosting;
using Serilog;

var builder = Host.CreateDefaultBuilder(args);

// Add services to the container.

builder.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
}).UseSerilog();

var app = builder.Build();

app.Run();
