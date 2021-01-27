using Microsoft.Extensions.DependencyInjection;

using Paymentsense.Coding.Challenge.Infrastructure.Services.Services;
using Paymentsense.Coding.Challenge.Services;

namespace Paymentsense.Coding.Challenge.Infrastructure.Services
{
    public static class Startup
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<ICountryListService, CountryListService>();
            services.AddScoped<ICountryDetailsService, CountryDetailsService>();
        }
    }
}