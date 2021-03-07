using AutoMapper.Configuration;
using EventBusRabbitMQ;
using ForestApp_CityApi.RabbitMQ;
using ForestApp_CityApi_Business.Abstract;
using ForestApp_CityApi_Business.Concrate;
using ForestApp_CityApi_DataAccess;
using ForestApp_CityApi_DataAccess.Abstract;
using ForestApp_CityApi_DataAccess.Concrate;
using ForestApp_CityApi_Dto;
using ForestApp_CityApi_Entity;
using ForestAppBase.Abstract;
using ForestAppBase.Concrate;
using ForestAppBase.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using System;

namespace ForestApp_CityApi.Extension
{
    public static class ForestAppContext
    {

        public static IServiceCollection UseForestAppCityContext(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {

            services.AddScoped(typeof(IBaseRepository<CityApiDbContext, City>), typeof(BaseRepository<CityApiDbContext, City>));
            services.AddScoped(typeof(IBaseRepository<CityApiDbContext, District>), typeof(BaseRepository<CityApiDbContext, District>));
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<BaseResponse<object>>();
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddScoped<IDistrictService, DistrictManager>();

            services.AddDbContext<CityApiDbContext>(opt => opt.UseSqlServer(configuration["SqlString"]));
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
            });

            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };
                return new RabbitMQConnection(factory);
            });

            services.AddSingleton<EventBusRabbitMQConsumer>();

            return services;
        }
    }
}
