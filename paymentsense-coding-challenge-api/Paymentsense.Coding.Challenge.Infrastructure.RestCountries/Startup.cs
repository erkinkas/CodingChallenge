using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Paymentsense.Coding.Challenge.Api.Repositories;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Repositories;
using Paymentsense.Coding.Challenge.Infrastructure.RestCountries.RestCountries;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICountryRepository, CountryRepository>();
            services.AddSingleton<ICountryClient, RestCountriesClient>();
            services.AddSingleton<ICacheService, CacheService>();

            services.AddHttpClient();
            services.AddMemoryCache();

            services.Configure<RestCountriesUrlSettings>(Configuration);
            services.AddOptions();
        }
    }
}