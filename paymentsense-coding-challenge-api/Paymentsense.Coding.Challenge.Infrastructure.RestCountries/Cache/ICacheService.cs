using System;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache
{
    public interface ICacheService
    {
        Task<T> GetCachedAsync<T>(CacheKey cacheKey, Func<Task<T>> func);
    }
}