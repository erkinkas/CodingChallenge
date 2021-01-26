using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.AspNetCore.Http;

using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests
{
    public class HealthcheckTests: HttpBaseTests
    {
        [Fact]
        public async Task Health_OnInvoke_ReturnsHealthy()
        {
            var response = await Client.GetAsync("/health");
            var responseString = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            responseString.Should().Be("Healthy");
        }
    }
}