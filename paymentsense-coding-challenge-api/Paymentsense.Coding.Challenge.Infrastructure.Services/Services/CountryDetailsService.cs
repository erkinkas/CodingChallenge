using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Services;

namespace Paymentsense.Coding.Challenge.Infrastructure.Services.Services
{
    public class CountryDetailsService: ICountryDetailsService
    {
        public Task<Country> Get(string countryCode, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}