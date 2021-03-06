using ForestApp_CityApi_Business.Abstract;
using ForestApp_CityApi_Business.Consts;
using ForestApp_CityApi_Redis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForestApp_CityApi_Business.Concrate
{
    public class RedisCacheManager : IRedisCacheService
    {
        private DistributedCacheEntryOptions _options;
        private IDistributedCache _distributedCache;

        private RedisConnection _redisConnection;
        public RedisCacheManager(IDistributedCache cache, DistributedCacheEntryOptions options,RedisConnection redisConnection)
        {
            _redisConnection = redisConnection;
            _options = options;
            _distributedCache = cache;
        }

   

        public async Task<bool> Contains(string recordId)
        {
            return await _redisConnection.KeyExist(RedisConsts.InstanceName + recordId);
        }

        public T Get<T>(string recordId)
        {
            var json = _distributedCache.GetString(recordId);
            if(json is null)
            {
                return default(T);
            }
            else
            {
                return JsonSerializer.Deserialize<T>(json);
            }
        }

        public async Task Remove(string recordId)
        {
            await _distributedCache.RemoveAsync(recordId);
        }

        public void SetAsync<T>(string recordId, T data)
        {
            try
            {
                _options.SetSlidingExpiration(TimeSpan.FromMinutes(60));
                var json = JsonSerializer.Serialize(data);
                _distributedCache.SetStringAsync(recordId, json, _options);
            }
            catch (Exception)
            {

                throw;
            }
 
        }

        public async Task<bool> Clear()
        {
           await _redisConnection.FlushDatabase();
            return true;
        }
    }
}
