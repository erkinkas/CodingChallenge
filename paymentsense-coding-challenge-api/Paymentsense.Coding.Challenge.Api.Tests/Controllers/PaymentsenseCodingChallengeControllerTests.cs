using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Services;

using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class PaymentsenseCodingChallengeControllerTests
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        [Fact]
        public async Task Get_OnInvoke_ReturnsExpectedMessage()
        {
            // Arrange
            var countryListService = new Mock<ICountryListService>();

            var controller = new CountryController(null, null, null);

            // Act
            var result = await controller.List(new ApiParams(), _cancellationTokenSource.Token);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnValue = Assert.IsType<IEnumerable<Country>>(okResult.Value);
            var idea = returnValue.FirstOrDefault();
            Assert.Equal("One", idea.Name);
        }
    }
}