using Microsoft.Extensions.Caching.Distributed;
using Report.API.Domain.EventHandlers;
using System;
using System.Threading.Tasks;
using static Report.API.Domain.Dto.Enums;

namespace Report.API.Cache.RedisCache
{
    public interface ICacheProvider
    {
        Task<T> GetFromCache<T>(DistirubedCacheKey key) where T : class;

        Task SetCache<T>(DistirubedCacheKey key, T value, DistributedCacheEntryOptions options) where T : class;

        Task ClearCache(DistirubedCacheKey key);

        event EventHandler<CacheUpdatedEventargs> OnCacheUpdated;
    }
}