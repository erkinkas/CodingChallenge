using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.RestCountries;
using Paymentsense.Coding.Challenge.Repository;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Repositories
{
    public class CountryRepository: ICountryRepository
    {
        private readonly ICountryClient _countryClient;
        private readonly ICacheService _cacheService;

        public CountryRepository(ICountryClient countryClient, ICacheService cacheService)
        {
            _countryClient = countryClient;
            _cacheService = cacheService;
        }

        public async Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _cacheService.GetCachedAsync(
                CacheKey.All,
                () => _countryClient.GetAllAsync(cancellationToken)
            );
        }

        public async Task<Country> SearchByCodeAsync(string code, CancellationToken cancellationToken)
        {
            return await _cacheService.GetCachedAsync(
                CacheKey.SearchByCode(code),
                () => _countryClient.SearchByCodeAsync(code, cancellationToken)
            );
        }
    }
}