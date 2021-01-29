using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Models.Country;
using Paymentsense.Coding.Challenge.Api.Services;
using Paymentsense.Coding.Challenge.Api.Services.Pagination;
using Paymentsense.Coding.Challenge.Domain;

using Tests.Core;

using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers.CountryController
{
    public class WhenList: BaseAutoMock<Api.Controllers.CountryController>
    {
        [Fact]
        public async Task Returns_OkResult_With_PageResults()
        {
            // Arrange
            const int pageSize = 15;
            const int pageIndex = 2;
            const int totalItems = 31;
            const int totalPageCount = 3;

            var queryResults = new PageResults<Country>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = totalItems
            };

            GetMock<ICountryListService>()
                .Setup(x => x.Get(
                    It.Is<PageParams>(p => p.PageSize == pageSize && p.PageIndex == pageIndex),
                    It.IsAny<CancellationToken>()
                ))
                .Returns(Task.FromResult(queryResults));

            // Act
            var apiParams = new ApiParams
            {
                PageIndex = pageIndex,
                PageLimit = pageSize
            };
            var result = await ClassUnderTest.List(apiParams, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<VmPage<VmCountryList>>(okResult.Value);

            returnValue.PageSize.Should().Be(pageSize);
            returnValue.PageIndex.Should().Be(pageIndex);
            returnValue.TotalCount.Should().Be(totalItems);
            returnValue.TotalPageCount.Should().Be(totalPageCount);
        }
    }
}