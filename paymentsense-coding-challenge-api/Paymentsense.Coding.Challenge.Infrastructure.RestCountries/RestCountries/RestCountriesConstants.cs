using System;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.RestCountries
{
    internal static class RestCountriesConstants
    {
        private static readonly Uri BaseUri = new Uri("https://restcountries.eu");

        public static readonly Uri AllUri = new Uri(BaseUri, "rest/v2/all");
        public static Uri CodeUri(string code) => new Uri(BaseUri, $"rest/v2/alpha/{code}");
    }
}