using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Paymentsense.Coding.Challenge.Api.Models.Country;
using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Services;

using Tests.Core;

using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers.CountryController
{
    public class WhenDetails: BaseAutoMock<Api.Controllers.CountryController>
    {
        [Fact]
        public async Task Returns_OkResult()
        {
            // Arrange
            const string code = "Country code";

            var country = new Country();

            GetMock<ICountryDetailsService>()
                .Setup(x => x.Get(
                    code,
                    It.IsAny<CancellationToken>()
                ))
                .Returns(Task.FromResult(country));

            // Act
            var result = await ClassUnderTest.Details(code, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<VmCountryDetails>(okResult.Value);

            returnValue.Flag.Should().Be(country.Flag);
            returnValue.Name.Should().Be(country.Name);
            returnValue.Population.Should().Be(country.Population);
            returnValue.Alpha3Code.Should().Be(country.Alpha3Code);
            returnValue.CapitalCity.Should().Be(country.Capital);
            returnValue.Languages.Should().Equal(country.Languages);
            returnValue.Currencies.Should().Equal(country.Currencies);
            returnValue.Timezones.Should().Equal(country.Timezones);
            returnValue.BorderingCountries.Should().Equal(country.Borders);
        }
    }
}