using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RocketLanding_AFerreiraPT.Hubs;
using RocketLanding_AFerreiraPT.Factories;
using RocketLanding_AFerreiraPT.Factories.Interfaces;
using RocketLanding_AFerreiraPT.Services.Interfaces;
using RocketLanding_AFerreiraPT.Services;

namespace RocketLanding_AFerreiraPT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ILandService, LandService>();
            services.AddScoped<ISpaceVehicleService, SpaceVehicleService>();

            services.AddScoped<IControlTowerService, ControlTowerService>();


            //factories
            services.AddScoped<ILandModelFactory, LandModelFactory>();
            services.AddScoped<ISpaceVehicleModelFactory, SpaceVehicleModelFactory>();
            


            services.AddControllers();

            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.3",
                    Title = "RocketLanding AFerreiraPT API",
                    Description = ""
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // This middleware serves generated Swagger document as a JSON endpoint
            app.UseSwagger();

            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RocketLanding AFerreiraPT API");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            // To show in the root
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RocketLanding AFerreiraPT API");
                c.RoutePrefix = string.Empty;
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                ///RocketHub/notifications?id=0
                endpoints.MapHub<RocketHub>(pattern: "/RocketHub/notifications");

            });


        }
    }
}
