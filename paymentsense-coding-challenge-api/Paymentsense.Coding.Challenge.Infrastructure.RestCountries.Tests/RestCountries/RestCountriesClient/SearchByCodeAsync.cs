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
    public class SearchByCodeAsync: RestCountriesClientBaseTests
    {
        [Theory]
        [InlineData("GBR")]
        [InlineData("USA")]
        public async Task Returns_Country(string code)
        {
            // Arrange
            var country = GetTestData("all.json").First(x => string.Equals(x.Alpha3Code, code, StringComparison.InvariantCultureIgnoreCase));

            var httpContent = new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json");
            FakeHttpClient(HttpStatusCode.OK, httpContent);

            GetMock<IOptions<RestCountriesUrlSettings>>()
                .Setup(x => x.Value)
                .Returns(() => new RestCountriesUrlSettings
                {
                    Code = "http://link_to_country_by_code.com"
                });

            // Act
            var resultValue = await ClassUnderTest.SearchByCodeAsync(code);

            // Assert
            resultValue.Should().BeEquivalentTo(country);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.Unauthorized)]
        [InlineData(HttpStatusCode.Forbidden)]
        public void Throws_Exception(HttpStatusCode httpStatusCode)
        {
            // Arrange
            const string url = "http://link_to_country_by_code.com";
            const string code = "wrong_country_code";

            FakeHttpClient(httpStatusCode, null);

            GetMock<IOptions<RestCountriesUrlSettings>>()
                .Setup(x => x.Value)
                .Returns(() => new RestCountriesUrlSettings
                {
                    Code = url
                });

            // Act
            Func<Task> getAllAction = async () => await ClassUnderTest.SearchByCodeAsync(code);

            // Assert
            getAllAction
                .Should()
                .Throw<RestCallFailedException>()
                .WithMessage(new RestCallFailedException(new Uri($"{url}/{code}"), httpStatusCode).Message);
        }
    }
}