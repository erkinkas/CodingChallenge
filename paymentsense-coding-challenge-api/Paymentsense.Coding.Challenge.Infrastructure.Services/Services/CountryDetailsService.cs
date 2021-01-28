using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Repository;
using Paymentsense.Coding.Challenge.Services;

namespace Paymentsense.Coding.Challenge.Infrastructure.Services.Services
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