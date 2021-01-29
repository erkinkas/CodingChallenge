using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Moq;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache;

using Tests.Core;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests.Repositories.CountryRepository
{
    public class CallsCached: BaseAutoMock<Infrastructure.RestCountries.Repositories.CountryRepository>
    {
        private readonly CancellationToken _cancellationToken = CancellationToken.None;

        [Fact]
        public async Task GetAllAsync()
        {
            // Act
            await ClassUnderTest.GetAllAsync(_cancellationToken);

            // Assert
            GetMock<ICacheService>()
                .Verify(
                    x => x.GetCachedAsync<IEnumerable<Country>>(
                        CacheKey.All,
                        It.IsAny<Func<Task<IEnumerable<Country>>>>()
                    )
                    , Times.Once
                );
        }

        [Fact]
        public async Task SearchByCodeAsync()
        {
            // Arrange
            const string code = "country code";

            // Act
            await ClassUnderTest.SearchByCodeAsync(code, _cancellationToken);

            // Assert
            GetMock<ICacheService>()
                .Verify(
                    x => x.GetCachedAsync<Country>(
                        It.Is<CacheKey>(ck => ck.ToString() == CacheKey.SearchByCode(code).ToString()),
                        It.IsAny<Func<Task<Country>>>()
                    )
                    , Times.Once
                );
        }
    }
}