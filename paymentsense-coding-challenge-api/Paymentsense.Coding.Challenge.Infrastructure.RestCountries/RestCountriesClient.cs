using System;
using System.Collections.Generic;
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
        private const string HttpClientName = "RestCountries";

        private static IHttpClientFactory _httpClientFactory;

        public RestCountriesClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await GetAsync<IEnumerable<Country>>(RestCountriesConstants.AllUri, cancellationToken);
        }

        public async Task<Country> SearchByCodeAsync(string code, CancellationToken cancellationToken)
        {
            return await GetAsync<Country>(RestCountriesConstants.CodeUri(code), cancellationToken);
        }

        private static async Task<T> GetAsync<T>(Uri uri, CancellationToken cancellationToken)
        {
            var httpClient = _httpClientFactory.CreateClient(HttpClientName);

            var response = await httpClient.GetAsync(uri, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var deserializedObject = JsonConvert.DeserializeObject<T>(responseContent);

                return deserializedObject;
            }

            return default;
        }
    }
}