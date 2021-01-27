using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;

using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Exceptions;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache
{
    public class CacheService: ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetCachedAsync<T>(CacheKey cacheKey, Func<Task<T>> func)
        {
            try
            {
                if (_cache.TryGetValue(cacheKey.ToString(), out T cachedValue))
                {
                    return cachedValue;
                }

                var result = await func();

                _cache.Set(cacheKey.ToString(), result);

                return result;
            }
            catch (RestCallFailedException)
            {
                // ignore this failure, do not cache in this case
                return default;
            }
        }
    }
}