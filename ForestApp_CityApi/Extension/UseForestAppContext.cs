using AutoMapper.Configuration;
using ForestApp_CityApi_Business.Abstract;
using ForestApp_CityApi_Business.Concrate;
using ForestApp_CityApi_DataAccess;
using ForestApp_CityApi_DataAccess.Abstract;
using ForestApp_CityApi_DataAccess.Concrate;
using ForestApp_CityApi_Dto;
using ForestApp_CityApi_Entity;
using ForestAppBase.Abstract;
using ForestAppBase.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForestApp_CityApi.Extension
{
    public static class ForestAppContext
    {
        public static IServiceCollection UseForestAppCityContext(this IServiceCollection services)
        {

            services.AddScoped(typeof(IBaseRepository<CityApiDbContext, City>), typeof(BaseRepository<CityApiDbContext, City>));
            services.AddScoped(typeof(IBaseRepository<CityApiDbContext, District>), typeof(BaseRepository<CityApiDbContext, District>));
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityManager>();
            services.AddDbContext<CityApiDbContext>(opt => opt.UseSqlServer(@"Server=.;Database=ForestAppDb;Trusted_Connection=True;"));
            services.AddAutoMapper(typeof(AutoMapping));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ForestApp City Api",
                    Version = "1.0.0",
                    Description = "ForestApp City Api",
                    Contact = new OpenApiContact() { Email = "ysndlklc1234@gmail.com", Name = "Yasin Efem Dalkilic", Url = new Uri("https://github.com/yasinfmd/"), }
                });
                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);

            });

            return services;
        }
    }
}
