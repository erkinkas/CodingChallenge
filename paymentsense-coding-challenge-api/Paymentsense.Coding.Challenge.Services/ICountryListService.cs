using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Services.Pagination;

namespace Paymentsense.Coding.Challenge.Services
{
    public interface ICountryListService
    {
        Task<QueryResults<Country>> Get(QueryParams queryParams, CancellationToken cancellationToken);
    }
}