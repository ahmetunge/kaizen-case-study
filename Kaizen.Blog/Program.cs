using Kaizen.Blog.DataAccess.EFCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>
                ();
                var logger = loggerFactory.CreateLogger<Program>();

                try
                {
                    var context = services.GetRequiredService<KaizenContext>();
                    await context.Database.MigrateAsync();
                    await Seed.SeedDataAsync(context, loggerFactory);
                    logger.LogInformation("Migration is applied");
                }
                catch (System.Exception ex)
                {
                    logger.LogError(ex, "An error occured during migration");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) =>
                {
                    configuration.Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                    .Enrich.WithProperty("Environment",context.HostingEnvironment.EnvironmentName)
                    .ReadFrom.Configuration(context.Configuration)
                    ;
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
