using ForestApp_CityApi.Extension;
using ForestApp_CityApi.Filter;
using ForestApp_CityApi_DataAccess;
using ForestAppBase.Abstract;
using ForestAppBase.Concrate;
using ForestAppBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using ForestApp_CityApi_Entity;
using ForestApp_CityApi_DataAccess.Abstract;
using ForestApp_CityApi_DataAccess.Concrate;
using ForestApp_CityApi_Business.Abstract;
using ForestApp_CityApi_Business.Concrate;
using ForestApp_CityApi_Dto;

namespace ForestApp_CityApi
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
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).UseCityApiFluentValidation();

            services.UseForestAppCityContext();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicApp API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseFileServer();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

     
    }
}
