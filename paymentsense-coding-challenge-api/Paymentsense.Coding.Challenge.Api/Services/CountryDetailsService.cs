using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Api.Repositories;
using Paymentsense.Coding.Challenge.Domain;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryDetailsService: ICountryDetailsService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryDetailsService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Country> Get(string countryCode, CancellationToken cancellationToken)
        {
            return await _countryRepository.SearchByCodeAsync(countryCode, cancellationToken);
        }
    }
}