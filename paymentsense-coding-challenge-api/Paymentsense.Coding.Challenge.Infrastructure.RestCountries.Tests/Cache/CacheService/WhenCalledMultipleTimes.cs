using System.Collections.Generic;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.Extensions.Caching.Memory;

using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests.Cache.CacheService
{
    public class WhenCalledMultipleTimes
    {
        private readonly Infrastructure.RestCountries.Cache.CacheService ClassUnderTest;

        public WhenCalledMultipleTimes()
        {
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            ClassUnderTest = new Infrastructure.RestCountries.Cache.CacheService(memoryCache);
        }

        [Fact]
        public async Task Caches_Given_Int()
        {
            await RunTest(2);
        }

        [Fact]
        public async Task Caches_Given_String()
        {
            await RunTest("some value");
        }

        [Fact]
        public async Task Caches_Given_Object()
        {
            await RunTest(new DummyClass
            {
                Int = 123,
                String = "test value",
                IntList = new List<int> { 1, 2, 3 },
                StringList = new List<string> { "a", "b", "c" }
            });
        }

        private async Task RunTest<T>(T value)
        {
            // Arrange
            var calledTimes = 0;

            Task<T> _func()
            {
                calledTimes++;
                return Task.FromResult(value);
            }

            // Act
            var result1 = await ClassUnderTest.GetCachedAsync(CacheKey.All, _func);
            var result2 = await ClassUnderTest.GetCachedAsync(CacheKey.All, _func);

            // Assert
            calledTimes.Should().Be(1);
            result1.Should().Be(value);
            result2.Should().Be(value);
        }

        private class DummyClass
        {
            public int Int { get; set; }
            public string String { get; set; }
            public IList<string> StringList { get; set; }
            public IList<int> IntList { get; set; }
        }
    }
}