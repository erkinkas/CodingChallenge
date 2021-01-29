using System.Configuration;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries
{
    public class RestCountriesUrlSettings: ConfigurationSection
    {
        public string All { get; set; }
        public string Code { get; set; }
    }
}