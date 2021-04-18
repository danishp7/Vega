using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vega.Data;
using Vega.Helpers;

namespace Vega
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args);
            SeedDb(host);
            host.Run();
        }
        public static void SeedDb(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            var _logger = host.Services.GetService<ILogger<Program>>();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    // get the required parameters for the method
                    var _ctx = services.GetRequiredService<VegaDbContext>();

                    // add the migrations
                    _ctx.Database.Migrate();

                    // now seed the default user
                    SeedData.SeedDefaultData(_ctx);
                    _logger.LogInformation("Data enterd into db...");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unable to insert data into db...", null);
                }
            };

        }
        public static IWebHost CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
