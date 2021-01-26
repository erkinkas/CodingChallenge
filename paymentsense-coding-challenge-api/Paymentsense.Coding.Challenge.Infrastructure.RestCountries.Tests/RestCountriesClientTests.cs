using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests
{
    public class RestCountriesClientTests: IDisposable
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        [Theory]
        [InlineData("United Kingdom of Great Britain and Northern Ireland")]
        [InlineData("United States of America")]
        public async Task GetAllCountries_Returns_Country(string expectedCountryName)
        {
            // Act
            var response = await new RestCountriesClient().GetAllAsync(_cancellationTokenSource.Token);

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