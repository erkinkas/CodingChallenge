using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using Newtonsoft.Json;

using Paymentsense.Coding.Challenge.Api.Models.Country;
using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Repositories;

using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers.CountryController
{
    public class OnInvokeDetails: HttpBaseTests
    {
        private Mock<ICountryRepository> _countryRepositoryMock;

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            _countryRepositoryMock = new Mock<ICountryRepository>();

            services.AddSingleton(_countryRepositoryMock.Object);
            base.ConfigureTestServices(services);
        }

        [Fact]
        public async Task Returns_NotFound_Given_NotExistentCode()
        {
            // Arrange
            const string code = "NonExistent Code";

            _countryRepositoryMock
                .Setup(x => x.SearchByCodeAsync(code))
                .Returns(Task.FromResult<Country>(null));

            // Act
            var response = await Client.GetAsync($"/country/{code}");

            // Assert
            response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task Returns_Ok_Given_ExistingCode()
        {
            // Arrange
            const string code = "Existing Code";
            var country = new Country();

            _countryRepositoryMock
                .Setup(x => x.SearchByCodeAsync(code))
                .Returns(Task.FromResult<Country>(country));

            // Act
            var response = await Client.GetAsync($"/country/{code}");

            // Assert
            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<VmCountryDetails>(responseString);

            responseObject.Flag.Should().Be(country.Flag);
            responseObject.Region.Should().Be(country.Region);
            responseObject.Name.Should().Be(country.Name);
            responseObject.Population.Should().Be(country.Population);
            responseObject.Alpha3Code.Should().Be(country.Alpha3Code);
            responseObject.CapitalCity.Should().Be(country.Capital);
            responseObject.Languages.Should().Equal(country.Languages);
            responseObject.Currencies.Should().Equal(country.Currencies);
            responseObject.Timezones.Should().Equal(country.Timezones);
            responseObject.BorderingCountries.Should().Equal(country.Borders);
        }
    }
}