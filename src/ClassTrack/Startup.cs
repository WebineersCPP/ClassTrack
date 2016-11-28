using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ClassTrack.Services;
using ClassTrack.ViewModels;
using ClassTrack.Repositories;
using ClassTrack.Models;
using System;

namespace ClassTrack
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            // definining our config.json as our configuration file
            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);

            services.AddDbContext<ClassTrackContext>();
            services.AddTransient<ClassTrackContextSeedData>();  
            
            services.AddScoped<IClassTrackRepository, ClassTrackRepository>();

            services.AddTransient<HTMLToCurriculumSheetService>();

            services.AddIdentity<ClassTrackUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";     // Forward user to url if not authorized                
            })
            .AddEntityFrameworkStores<ClassTrackContext>();

            services.AddMvc(config =>
            {
                if (_env.IsEnvironment("Production"))   // or _env.IsProduction(). This uses default. If you want to set your own prod env, use: ASPNETCORE_ENVIRONMENT=Production
                {
                    config.Filters.Add(new RequireHttpsAttribute());
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ClassTrackContextSeedData seeder, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseIdentity();

            Mapper.Initialize(config =>
            {
                config.CreateMap<CurriculumSheetViewModel, CurriculumSheet>().ReverseMap();
            });

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                );
            });

            try
            {
                seeder.EnsureSeedData().Wait();     // asynchronously seed initial data to context
            }
            catch (Exception e)
            {
            }           
        }
    }
}
