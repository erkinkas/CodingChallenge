using System.Threading.Tasks;

using FluentAssertions;

using Paymentsense.Coding.Challenge.Api.Services;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Repositories;

using Tests.Core;

using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services.Country
{
    public class CountryDetailsServiceTests: BaseAutoMock<CountryDetailsService>
    {
        [Fact]
        public async Task Returns_Country_Given_Found()
        {
            // Arrange
            const string code = "Alpha3Code";
            var country = new Domain.Country();

            GetMock<ICountryRepository>()
                .Setup(x => x.SearchByCodeAsync(code))
                .Returns(Task.FromResult(country));

            // Act
            var result = await ClassUnderTest.Get(code);

            // Assert
            result.Should().NotBeNull();

            result.Should().BeSameAs(country);
        }

        [Fact]
        public async Task Returns_Null_Given_NotFound()
        {
            // Arrange
            const string code = "Alpha3Code_NotFound";

            GetMock<ICountryRepository>()
                .Setup(x => x.SearchByCodeAsync(code))
                .Returns(Task.FromResult(default(Domain.Country)));

            // Act
            var result = await ClassUnderTest.Get(code);

            // Assert
            result.Should().BeNull();
        }
    }
}