using ForestApp_IdentifiyApi.Localize;
using ForestApp_IdentifiyApi_DataAccess;
using ForestApp_IdentifiyApi_Entity;
using ForestApp_IdentifiyApi_RabbitMq;
using ForestApp_IdentifyApi_Business.Abstract;
using ForestApp_IdentifyApi_Business.Concrate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace ForestApp_IdentifiyApi.Extension
{
    public static class UseIdentifyContext
    {
        public static IServiceCollection UseIdentityApiContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddScoped<IUserService, UserServiceManager>();
            services.AddSingleton<RabbitMqService>();
            services.AddScoped<Publisher>(p => new Publisher(new RabbitMqService()));
            services.AddDbContext<IdentifiyApiDbContext>(opt => opt.UseSqlServer(configuration["SqlIdentityString"]));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ForestApp Identitiy Api",
                    Version = "1.0.0",
                    Description = "ForestApp Identitiy Api",
                    Contact = new OpenApiContact() { Email = "ysndlklc1234@gmail.com", Name = "Yasin Efem Dalkilic", Url = new Uri("https://github.com/yasinfmd/"), }
                });
            });
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredUniqueChars = 1;

                options.SignIn.RequireConfirmedEmail = true;


                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                //options.Lockout.MaxFailedAccessAttempts = 5;
                //options.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<IdentifiyApiDbContext>().AddDefaultTokenProviders().AddErrorDescriber<MultilanguageIdentityErrorDescriber>();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["SecretKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                };
            });

            services.AddScoped<AuthResponse<object>>();
            return services;
        }
    }
}
