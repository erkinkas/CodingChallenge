using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Api.Services.Pagination;
using Paymentsense.Coding.Challenge.Domain;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public interface ICountryListService
    {
        Task<PageResults<Country>> Get(PageParams pageParams);
    }
}