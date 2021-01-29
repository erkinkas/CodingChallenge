using FluentAssertions;

using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.RestCountries;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests.RestCountries
{
    public class RestCountriesConstantsTests
    {
        [Fact]
        public void AllUri()
        {
            RestCountriesConstants.AllUri.AbsoluteUri.Should().Be("https://restcountries.eu/rest/v2/all");
        }

        [Theory]
        [InlineData(null, "https://restcountries.eu/rest/v2/alpha/")]
        [InlineData("", "https://restcountries.eu/rest/v2/alpha/")]
        [InlineData(" ", "https://restcountries.eu/rest/v2/alpha/")]
        [InlineData("  ", "https://restcountries.eu/rest/v2/alpha/")]
        [InlineData("a", "https://restcountries.eu/rest/v2/alpha/a")]
        [InlineData(" a", "https://restcountries.eu/rest/v2/alpha/%20a")]
        [InlineData("a ", "https://restcountries.eu/rest/v2/alpha/a")]
        [InlineData(" a ", "https://restcountries.eu/rest/v2/alpha/%20a")]
        [InlineData("b", "https://restcountries.eu/rest/v2/alpha/b")]
        public void CodeUri(string code, string expectedUri)
        {
            RestCountriesConstants.CodeUri(code).AbsoluteUri.Should().Be(expectedUri);
        }
    }
}