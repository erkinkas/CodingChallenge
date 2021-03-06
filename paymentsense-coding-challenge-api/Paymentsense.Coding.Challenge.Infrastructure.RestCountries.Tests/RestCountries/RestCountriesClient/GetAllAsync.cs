using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Exceptions;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests.RestCountries.RestCountriesClient
{
    public class GetAllAsync: RestCountriesClientBaseTests
    {
        [Theory]
        [InlineData("United Kingdom of Great Britain and Northern Ireland")]
        [InlineData("United States of America")]
        public async Task Returns_Country(string expectedCountryName)
        {
            // Arrange
            var countries = GetTestData("all.json");

            var httpContent = new StringContent(JsonConvert.SerializeObject(countries), Encoding.UTF8, "application/json");
            FakeHttpClient(HttpStatusCode.OK, httpContent);

            GetMock<IOptions<RestCountriesUrlSettings>>()
                .Setup(x => x.Value)
                .Returns(() => new RestCountriesUrlSettings
                {
                    All = "http://link_to_all_countries.com"
                });

            // Act
            var response = await ClassUnderTest.GetAllAsync();

            var resultValue = response.ToList();

            // Assert
            var singleCountry = resultValue.Single(x => string.Equals(x.Name, expectedCountryName, StringComparison.InvariantCultureIgnoreCase));
            singleCountry.Should().NotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.Unauthorized)]
        [InlineData(HttpStatusCode.Forbidden)]
        public void Throws_Exception(HttpStatusCode httpStatusCode)
        {
            // Arrange
            const string url = "http://link_to_all_countries.com";

            FakeHttpClient(httpStatusCode, null);

            GetMock<IOptions<RestCountriesUrlSettings>>()
                .Setup(x => x.Value)
                .Returns(() => new RestCountriesUrlSettings
                {
                    All = url
                });

            // Act
            Func<Task> getAllAction = async () => await ClassUnderTest.GetAllAsync();

            // Assert
            getAllAction
                .Should()
                .Throw<RestCallFailedException>()
                .WithMessage(new RestCallFailedException(new Uri(url), httpStatusCode).Message);
        }
    }
}