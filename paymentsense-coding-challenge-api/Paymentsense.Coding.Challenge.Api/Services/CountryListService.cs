using System.Linq;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Api.Services.Pagination;
using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Repositories;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryListService: ICountryListService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryListService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<PageResults<Country>> Get(PageParams pageParams)
        {
            var pageSize = pageParams.PageSize;
            var pageIndex = pageParams.PageIndex;

            var enumerable = await _countryRepository.GetAllAsync();
            var countries = enumerable.ToList();

            var totalCount = countries.Count;
            pageIndex = GetPageIndex(pageIndex: pageIndex, pageSize: pageSize, totalCount: totalCount);

            var items = countries
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PageResults<Country>
            {
                Items = items,
                Total = totalCount,
                PageSize = pageSize,
                PageIndex = pageIndex
            };
        }

        private static int GetPageIndex(int pageIndex, int pageSize, int totalCount)
        {
            if (totalCount <= pageSize
                || pageIndex <= 0)
                return 1;

            if (pageSize * pageIndex > totalCount)
                return totalCount / pageSize + ((totalCount % pageSize) > 0 ? 1 : 0);

            return pageIndex;
        }
    }
}