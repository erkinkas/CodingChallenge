using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Repository;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries
{
    public class RestCountriesClient: ICountryRepository
    {
        public async Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken)
        {
            // TODO: refactor by implementing design pattern
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(new Uri("https://restcountries.eu/rest/v2/all"), cancellationToken);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(responseContent);

                return countries;
            }

            // Try catch?
            // throw some exception?
            return null;
        }

        public async Task<Country> SearchByCodeAsync(string code, CancellationToken cancellationToken)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(new Uri($"https://restcountries.eu/rest/v2/alpha/{code}"), cancellationToken);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var country = JsonConvert.DeserializeObject<Country>(responseContent);

                return country;
            }

            // Try catch?
            // throw some exception?
            return null;
        }
    }
}