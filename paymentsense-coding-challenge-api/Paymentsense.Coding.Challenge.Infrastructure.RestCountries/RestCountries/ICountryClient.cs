using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.RestCountries
{
    public interface ICountryClient
    {
        Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken);
        Task<Country> SearchByCodeAsync(string code, CancellationToken cancellationToken);
    }
}