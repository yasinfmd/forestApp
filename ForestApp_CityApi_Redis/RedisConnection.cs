using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace ForestApp_CityApi_Redis
{
    public class RedisConnection
    {
        private IDatabase _database;
        private int _currentDb = 0;
        private static ConnectionMultiplexer _connectionMultiplexer;
        public RedisConnection()
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6375,AllowAdmin=true");
            _database = _connectionMultiplexer.GetDatabase(_currentDb);
        }
        public IDatabase Database => _database;

        public async Task<bool> KeyExist(string key)
        {
            return await _database.KeyExistsAsync(key);
        }
        public async Task FlushDatabase()
        {
            try
            {
                var endpoints = _connectionMultiplexer.GetEndPoints(true);
                foreach (var endpoint in endpoints)
                {
                    var server = _connectionMultiplexer.GetServer(endpoint);
                    server.FlushAllDatabases();
                }
                await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
