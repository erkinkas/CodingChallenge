using System;
using System.Net;
using System.Threading.Tasks;

using FluentAssertions;

using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Exceptions;

using Tests.Core;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests.Cache.CacheService
{
    public class WhenRestCallFailedExceptionThrown: BaseAutoMock<Infrastructure.RestCountries.Cache.CacheService>
    {
        [Fact]
        public async Task Returns_Default_Given_Int()
        {
            // Arrange
            var exception = new RestCallFailedException(new Uri("http://testhost"), HttpStatusCode.NotFound);

            // Act
            var result = await ClassUnderTest.GetCachedAsync<int>(CacheKey.All, () => throw exception);

            // Assert
            result.Should().Be(default(int));
        }

        [Fact]
        public async Task Returns_Default_Given_String()
        {
            // Arrange
            var exception = new RestCallFailedException(new Uri("http://testhost"), HttpStatusCode.NotFound);

            // Act
            var result = await ClassUnderTest.GetCachedAsync<string>(CacheKey.All, () => throw exception);

            // Assert
            result.Should().Be(default(string));
        }

        [Fact]
        public async Task Returns_Default_Given_Object()
        {
            // Arrange
            var exception = new RestCallFailedException(new Uri("http://testhost"), HttpStatusCode.NotFound);

            // Act
            var result = await ClassUnderTest.GetCachedAsync<object>(CacheKey.All, () => throw exception);

            // Assert
            result.Should().Be(default(object));
        }
    }
}