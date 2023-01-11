using Microsoft.Extensions.Caching.Distributed;
using Report.API.Domain.EventHandlers;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using static Report.API.Domain.Dto.Enums;

namespace Report.API.Cache.RedisCache
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IDistributedCache _cache;

        public event EventHandler<CacheUpdatedEventargs> OnCacheUpdated;

        public CacheProvider(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetFromCache<T>(DistirubedCacheKey key) where T : class
        {
            var cachedUsers = await _cache.GetStringAsync(key.ToString());
            return cachedUsers == null ? null : JsonSerializer.Deserialize<T>(cachedUsers,
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        public async Task SetCache<T>(DistirubedCacheKey key, T value, DistributedCacheEntryOptions options) where T : class
        {
            var serilazedValue = JsonSerializer.Serialize(value,
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await _cache.SetStringAsync(key.ToString(), serilazedValue, options);

            if (OnCacheUpdated != null)
            {
                OnCacheUpdated(this, new CacheUpdatedEventargs { UpdatedKey = key, Value = serilazedValue });
            }
        }

        public async Task ClearCache(DistirubedCacheKey key)
        {
            await _cache.RemoveAsync(key.ToString());
        }
    }
}