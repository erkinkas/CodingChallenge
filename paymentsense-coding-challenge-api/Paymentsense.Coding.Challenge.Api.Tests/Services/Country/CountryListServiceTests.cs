using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using Paymentsense.Coding.Challenge.Api.Services;
using Paymentsense.Coding.Challenge.Api.Services.Pagination;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Repositories;

using Tests.Core;

using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services.Country
{
    public class CountryListServiceTests: BaseAutoMock<CountryListService>
    {
        [Fact]
        public async Task Returns_PagedResult()
        {
            // Arrange
            const int pageSize = 2;
            const int pageIndex = 2;
            const int totalItems = 10;

            var pageParams = new PageParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };

            var repoCountries = Enumerable.Range(1, totalItems)
                .Select(x => new Domain.Country())
                .ToList();

            GetMock<ICountryRepository>()
                .Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult<IEnumerable<Domain.Country>>(repoCountries));

            // Act
            var result = await ClassUnderTest.Get(pageParams);

            // Assert
            result.Should().NotBeNull();

            result.Total.Should().Be(totalItems);
            result.PageSize.Should().Be(pageSize);
            result.PageIndex.Should().Be(pageIndex);
            result.Items.Count.Should().Be(pageSize);
        }

        [Fact]
        public async Task Returns_LastPage()
        {
            // Arrange
            const int pageSize = 2;
            const int pageIndex = 9;

            const int totalItems = 11;
            const int lastPageIndex = 6;

            var pageParams = new PageParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };

            var repoCountries = Enumerable.Range(1, totalItems)
                .Select(x => new Domain.Country())
                .ToList();

            GetMock<ICountryRepository>()
                .Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult<IEnumerable<Domain.Country>>(repoCountries));

            // Act
            var result = await ClassUnderTest.Get(pageParams);

            // Assert
            result.Should().NotBeNull();

            result.Total.Should().Be(totalItems);
            result.PageSize.Should().Be(pageSize);
            result.PageIndex.Should().Be(lastPageIndex);
            result.Items.Count.Should().Be(1);
        }

        [Fact]
        public async Task Returns_FirstPage()
        {
            // Arrange
            const int pageSize = 2;
            const int pageIndex = 9;

            const int totalItems = 1;
            const int firstPageIndex = 1;

            var pageParams = new PageParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };

            var repoCountries = Enumerable.Range(1, totalItems)
                .Select(x => new Domain.Country())
                .ToList();

            GetMock<ICountryRepository>()
                .Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult<IEnumerable<Domain.Country>>(repoCountries));

            // Act
            var result = await ClassUnderTest.Get(pageParams);

            // Assert
            result.Should().NotBeNull();

            result.Total.Should().Be(totalItems);
            result.PageSize.Should().Be(pageSize);
            result.PageIndex.Should().Be(firstPageIndex);
            result.Items.Count.Should().Be(totalItems);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public async Task Returns_FirstPage_Given_0PageIndex(int pageIndex)
        {
            // Arrange
            const int pageSize = 2;

            const int totalItems = 1;
            const int firstPageIndex = 1;

            var pageParams = new PageParams
            {
                PageSize = pageSize,
                PageIndex = pageIndex
            };

            var repoCountries = Enumerable.Range(1, totalItems)
                .Select(x => new Domain.Country())
                .ToList();

            GetMock<ICountryRepository>()
                .Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult<IEnumerable<Domain.Country>>(repoCountries));

            // Act
            var result = await ClassUnderTest.Get(pageParams);

            // Assert
            result.Should().NotBeNull();

            result.Total.Should().Be(totalItems);
            result.PageSize.Should().Be(pageSize);
            result.PageIndex.Should().Be(firstPageIndex);
            result.Items.Count.Should().Be(totalItems);
        }
    }
}