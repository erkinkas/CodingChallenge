using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;

namespace Paymentsense.Coding.Challenge.Api.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken);
        Task<Country> SearchByCodeAsync(string code, CancellationToken cancellationToken);
    }
}