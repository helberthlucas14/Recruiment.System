using Newtonsoft.Json;
using Recruitment.System.Application.Interfaces;
using StackExchange.Redis;

namespace Recruitment.System.Infra.Data.Redis
{
    public class RedisCache : ICache
    {
        private readonly IDatabase _database;

        public RedisCache(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            if (value.IsNullOrEmpty) return default;

            return JsonConvert.DeserializeObject<T>(value!);
        }

        public async Task SetAsync<T>(
            string key,
            T value,
            TimeSpan timeSpan)
        {
            var json = JsonConvert.SerializeObject(value);
            await _database.StringSetAsync(key, json, timeSpan);
        }

        public async Task RemoveAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }
    }

}
