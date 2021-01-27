using Microsoft.Extensions.DependencyInjection;

using Paymentsense.Coding.Challenge.Repository;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries
{
    public static class Startup
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddSingleton<ICountryRepository, RestCountriesClient>();
            services.AddHttpClient();
        }
    }
}