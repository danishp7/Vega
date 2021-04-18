using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Vega.Data;
using Vega.Repositories;
using Newtonsoft.Json;

namespace Vega
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // add cors cross origin resource sharing
            services.AddCors();

            // add db context
            services.AddDbContext<VegaDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("VegaConnectionString")));

            // add mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // add repositories
            services.AddScoped<IVegaRepository, VegaRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

            // remove self referencing loop

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            // to resolve self refence loop
            // we need to install microsoft.aspnetcore.mvc.newtonsoft
                .AddNewtonsoftJson(a => a.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
