using Microsoft.Extensions.DependencyInjection;

using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Repositories;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.RestCountries;
using Paymentsense.Coding.Challenge.Repository;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries
{
    public static class Startup
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddSingleton<ICountryRepository, CountryRepository>();
            services.AddSingleton<ICountryClient, RestCountriesClient>();
            services.AddSingleton<ICacheService, CacheService>();
            services.AddHttpClient();
            services.AddMemoryCache();
        }
    }
}