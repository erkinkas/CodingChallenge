using FluentAssertions;

using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests.Cache
{
    public class CacheKeyTests
    {
        [Fact]
        public void Returns_Key_Given_All()
        {
            CacheKey.All.ToString().Should().Be("RestCountriesCache_all");
        }

        [Theory]
        [InlineData(null, "RestCountriesCache_searchByCode_")]
        [InlineData("", "RestCountriesCache_searchByCode_")]
        [InlineData(" ", "RestCountriesCache_searchByCode_")]
        [InlineData("  ", "RestCountriesCache_searchByCode_")]
        [InlineData("a", "RestCountriesCache_searchByCode_a")]
        [InlineData(" a", "RestCountriesCache_searchByCode_a")]
        [InlineData("a ", "RestCountriesCache_searchByCode_a")]
        [InlineData(" a ", "RestCountriesCache_searchByCode_a")]
        [InlineData("b", "RestCountriesCache_searchByCode_b")]
        public void Returns_Key_Given_Code(string code, string expectedKey)
        {
            CacheKey.SearchByCode(code).ToString().Should().Be(expectedKey);
        }
    }
}