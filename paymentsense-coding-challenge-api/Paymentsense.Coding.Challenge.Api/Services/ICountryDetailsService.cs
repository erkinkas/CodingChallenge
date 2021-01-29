using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public interface ICountryDetailsService
    {
        Task<Country> Get(string countryCode);
    }
}