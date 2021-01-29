using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Moq;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.RestCountries;

using Tests.Core;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests.Repositories.CountryRepository
{
    public class CallsService: BaseAutoMock<Infrastructure.RestCountries.Repositories.CountryRepository>
    {
        [Fact]
        public async Task GetAllAsync()
        {
            // Arrange
            GetMock<ICacheService>()
                .Setup(x => x.GetCachedAsync(
                    It.IsAny<CacheKey>(),
                    It.IsAny<Func<Task<IEnumerable<Country>>>>()
                ))
                .Callback(
                    async (CacheKey cacheKey, Func<Task<IEnumerable<Country>>> func)
                        => await MockedGetCachedAsync(cacheKey, func)
                );

            // Act
            await ClassUnderTest.GetAllAsync();

            // Assert
            GetMock<ICountryClient>()
                .Verify(x => x.GetAllAsync()
                    , Times.Once
                );
        }

        [Fact]
        public async Task SearchByCodeAsync()
        {
            // Arrange
            const string code = "country code";

            GetMock<ICacheService>()
                .Setup(x => x.GetCachedAsync(
                    It.IsAny<CacheKey>(),
                    It.IsAny<Func<Task<Country>>>()
                ))
                .Callback(
                    async (CacheKey cacheKey, Func<Task<Country>> func)
                        => await MockedGetCachedAsync(cacheKey, func)
                );

            // Act
            await ClassUnderTest.SearchByCodeAsync(code);

            // Assert
            GetMock<ICountryClient>()
                .Verify(x => x.SearchByCodeAsync(code)
                    , Times.Once
                );
        }

        private static async Task<T> MockedGetCachedAsync<T>(CacheKey cacheKey, Func<Task<T>> func)
        {
            return await func();
        }
    }
}