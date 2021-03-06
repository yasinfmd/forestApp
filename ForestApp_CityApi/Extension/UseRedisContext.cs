using ForestApp_CityApi_Business.Abstract;
using ForestApp_CityApi_Business.Concrate;
using ForestApp_CityApi_Business.Consts;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForestApp_CityApi.Extension
{
    public static class RedisContext
    {
        public static IServiceCollection UseRedisContext(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration["RedisString"];
                opt.InstanceName = RedisConsts.InstanceName;
            });
            services.AddSingleton<ForestApp_CityApi_Redis.RedisConnection>();
            services.AddScoped<IRedisCacheService, RedisCacheManager>();
            services.AddScoped<DistributedCacheEntryOptions>();
            return services;
        }
    }
}
