using System;
using System.Threading;
using System.Threading.Tasks;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Services;
using Paymentsense.Coding.Challenge.Services.Pagination;

namespace Paymentsense.Coding.Challenge.Infrastructure.Services
{
    public class CountryListService: ICountryListService
    {
        public Task<QueryResults<Country>> Get(QueryParams queryParams, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}