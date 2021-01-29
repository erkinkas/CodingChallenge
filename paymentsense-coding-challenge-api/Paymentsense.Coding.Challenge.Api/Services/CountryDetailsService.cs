using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Repositories;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryDetailsService: ICountryDetailsService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryDetailsService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<Country> Get(string countryCode)
        {
            return await _countryRepository.SearchByCodeAsync(countryCode);
        }
    }
}