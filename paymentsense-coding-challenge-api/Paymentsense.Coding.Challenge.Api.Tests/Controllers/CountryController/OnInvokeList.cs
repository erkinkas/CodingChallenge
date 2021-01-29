using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using Newtonsoft.Json;

using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Models.Country;
using Paymentsense.Coding.Challenge.Api.Repositories;
using Paymentsense.Coding.Challenge.Domain;

using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers.CountryController
{
    public class OnInvokeList: HttpBaseTests
    {
        private Mock<ICountryRepository> _countryRepositoryMock;

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            _countryRepositoryMock = new Mock<ICountryRepository>();

            services.AddSingleton(_countryRepositoryMock.Object);
            base.ConfigureTestServices(services);
        }

        [Fact]
        public async Task Returns_DefaultPagedList()
        {
            // Arrange
            var countries = GetMockedCountries();

            _countryRepositoryMock
                .Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult<IEnumerable<Country>>(countries));

            // Act
            var response = await Client.GetAsync("/country");

            // Assert
            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<VmPage<VmCountryList>>(responseString);

            responseObject.PageSize.Should().Be(50);
            responseObject.PageIndex.Should().Be(1);
            responseObject.TotalCount.Should().Be(countries.Count);
            responseObject.TotalPageCount.Should().Be(1);

            var resultItems = responseObject.Items.ToList();
            resultItems.Count.Should().Be(countries.Count);

            for (var index = 0; index < countries.Count; index++)
            {
                resultItems[index].Flag.Should().Be(countries[index].Flag);
                resultItems[index].Name.Should().Be(countries[index].Name);
                resultItems[index].Alpha3Code.Should().Be(countries[index].Alpha3Code);
                resultItems[index].Region.Should().Be(countries[index].Region);
            }
        }

        [Fact]
        public async Task Returns_PagedList()
        {
            // Arrange
            const int pageIndex = 2;
            const int pageSize = 2;
            var countries = GetMockedCountries();

            _countryRepositoryMock
                .Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult<IEnumerable<Country>>(countries));

            // Act
            var response = await Client.GetAsync($"/country?pageIndex={pageIndex}&pageLimit={pageSize}");

            // Assert
            response.StatusCode.Should().Be(StatusCodes.Status200OK);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<VmPage<VmCountryList>>(responseString);

            responseObject.PageSize.Should().Be(pageSize);
            responseObject.PageIndex.Should().Be(pageIndex);
            responseObject.TotalCount.Should().Be(countries.Count);
            responseObject.TotalPageCount.Should().Be(3);

            var resultItems = responseObject.Items.ToList();
            resultItems.Count.Should().Be(pageSize);

            resultItems[0].Flag.Should().Be(countries[2].Flag);
            resultItems[0].Name.Should().Be(countries[2].Name);
            resultItems[0].Alpha3Code.Should().Be(countries[2].Alpha3Code);
            resultItems[0].Region.Should().Be(countries[2].Region);

            resultItems[1].Flag.Should().Be(countries[3].Flag);
            resultItems[1].Name.Should().Be(countries[3].Name);
            resultItems[1].Alpha3Code.Should().Be(countries[3].Alpha3Code);
            resultItems[1].Region.Should().Be(countries[3].Region);
        }

        private static IList<Country> GetMockedCountries()
        {
            return new List<Country>
            {
                new Country
                {
                    Flag = "https://image_server/country1.svg",
                    Name = "country1",
                    Alpha3Code = "countryCode1"
                },
                new Country
                {
                    Flag = "https://image_server/country2.svg",
                    Name = "country2",
                    Alpha3Code = "countryCode2"
                },
                new Country
                {
                    Flag = "https://image_server/country3.svg",
                    Name = "country3",
                    Alpha3Code = "countryCode3"
                },
                new Country
                {
                    Flag = "https://image_server/country4.svg",
                    Name = "country4",
                    Alpha3Code = "countryCode4"
                },
                new Country
                {
                    Flag = "https://image_server/country5.svg",
                    Name = "country5",
                    Alpha3Code = "countryCode5"
                }
            };
        }
    }
}