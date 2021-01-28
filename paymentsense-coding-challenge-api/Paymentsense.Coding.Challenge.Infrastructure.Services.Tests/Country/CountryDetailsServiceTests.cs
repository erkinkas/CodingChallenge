using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using Moq;

using Paymentsense.Coding.Challenge.Infrastructure.Services.Services;
using Paymentsense.Coding.Challenge.Repository;

using Tests.Core;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.Services.Tests.Country
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
                .Setup(x => x.SearchByCodeAsync(code, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(country));

            // Act
            var result = await ClassUnderTest.Get(code, CancellationToken.None);

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
                .Setup(x => x.SearchByCodeAsync(code, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(default(Domain.Country)));

            // Act
            var result = await ClassUnderTest.Get(code, CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }
    }
}