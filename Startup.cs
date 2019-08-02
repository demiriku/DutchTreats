using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DutchTreat
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Support for real mail service
            services.AddDbContext<DutchContext>(cfg =>
                {
                    cfg.UseSqlServer(config.GetConnectionString("DutchConnectionString"));
                });

            // Support for Automapping
            services.AddAutoMapper(typeof(Startup));

            // Support add transient seeder.
            services.AddTransient<DutchSeeder>();

            // Support for real mail service
            services.AddTransient<IMailService, NullMailService>();

            // Add the repository so that i can be used by the controllers.
            services.AddScoped<IDutchRepository, DutchRepository>();


            // Support for real mail service
            services.AddMvc()
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseNodeModules(env);

            //Add MVC middleware with 
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                             "{controller}/{action}/{id?}",
                    new { controller = "App", Action = "Index" });
            });

        }
    }
}
