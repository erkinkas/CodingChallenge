using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.Extensions.Options;

using Moq;
using Moq.Protected;

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

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(countries), Encoding.UTF8, "application/json")
                });

            var fakeHttpClient = new HttpClient(mockHttpMessageHandler.Object);

            GetMock<IHttpClientFactory>()
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(fakeHttpClient);

            GetMock<IOptions<RestCountriesUrlSettings>>()
                .Setup(x => x.Value)
                .Returns(() => new RestCountriesUrlSettings
                {
                    All = "https://restcountries.eu/rest/v2/all"
                });

            // Act
            var response = await ClassUnderTest.GetAllAsync(CancellationToken.None);

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
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = httpStatusCode
                });

            var fakeHttpClient = new HttpClient(mockHttpMessageHandler.Object);

            GetMock<IHttpClientFactory>()
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(fakeHttpClient);

            GetMock<IOptions<RestCountriesUrlSettings>>()
                .Setup(x => x.Value)
                .Returns(() => new RestCountriesUrlSettings
                {
                    All = "https://restcountries.eu/rest/v2/all"
                });

            // Act
            Func<Task> getAllAction = async () =>
                await ClassUnderTest.GetAllAsync(CancellationToken.None);

            // Assert
            getAllAction
                .Should()
                .Throw<RestCallFailedException>()
                .WithMessage(new RestCallFailedException(new Uri("https://restcountries.eu/rest/v2/all"), httpStatusCode).Message);
        }
    }
}