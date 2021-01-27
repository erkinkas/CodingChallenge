using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Moq;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests
{
    // TODO: remove this test
    public class RestCountriesClientTests: IDisposable
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        [Theory]
        [InlineData("United Kingdom of Great Britain and Northern Ireland")]
        [InlineData("United States of America")]
        public async Task GetAllCountries_Returns_Country(string expectedCountryName)
        {
            // Arrange
            var fakeHttpClient = new HttpClient();

            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(fakeHttpClient);

            // Act
            var response = await new RestCountries.RestCountriesClient(httpClientFactory.Object).GetAllAsync(_cancellationTokenSource.Token);

            var countries = response.ToList();

            // Assert
            var country = countries.Single(x => string.Equals(x.Name, expectedCountryName, StringComparison.InvariantCultureIgnoreCase));
            Assert.NotNull(country);
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}