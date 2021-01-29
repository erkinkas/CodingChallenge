using System;
using System.Collections.Generic;
using System.Threading;
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
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

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
            await ClassUnderTest.GetAllAsync(_cancellationToken);

            // Assert
            GetMock<ICountryClient>()
                .Verify(x => x.GetAllAsync(_cancellationToken)
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
            await ClassUnderTest.SearchByCodeAsync(code, _cancellationToken);

            // Assert
            GetMock<ICountryClient>()
                .Verify(x => x.SearchByCodeAsync(code, _cancellationToken)
                    , Times.Once
                );
        }

        private static async Task<T> MockedGetCachedAsync<T>(CacheKey cacheKey, Func<Task<T>> func)
        {
            return await func();
        }
    }
}