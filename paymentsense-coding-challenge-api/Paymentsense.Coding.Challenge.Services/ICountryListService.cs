using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Services.Pagination;

namespace Paymentsense.Coding.Challenge.Services
{
    public interface ICountryListService
    {
        Task<PageResults<Country>> Get(PageParams pageParams, CancellationToken cancellationToken);
    }
}