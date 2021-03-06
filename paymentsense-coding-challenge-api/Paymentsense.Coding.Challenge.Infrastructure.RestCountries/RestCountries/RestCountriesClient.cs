﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using Paymentsense.Coding.Challenge.Domain;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Exceptions;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.RestCountries
{
    public class RestCountriesClient: ICountryClient
    {
        private const string HttpClientName = "RestCountries";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<RestCountriesUrlSettings> _urlSettings;

        public RestCountriesClient(IHttpClientFactory httpClientFactory, IOptions<RestCountriesUrlSettings> urlSettings)
        {
            _httpClientFactory = httpClientFactory;
            _urlSettings = urlSettings;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var uri = new Uri(_urlSettings.Value.All);
            return await GetAsync<IEnumerable<Country>>(uri);
        }

        public async Task<Country> SearchByCodeAsync(string code)
        {
            var baseUri = new Uri(_urlSettings.Value.Code);
            var codeUri = new Uri(baseUri, code);
            return await GetAsync<Country>(codeUri);
        }

        private async Task<T> GetAsync<T>(Uri uri)
        {
            var httpClient = _httpClientFactory.CreateClient(HttpClientName);

            var response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var deserializedObject = JsonConvert.DeserializeObject<T>(responseContent);

                return deserializedObject;
            }

            throw new RestCallFailedException(uri, response.StatusCode);
        }
    }
}