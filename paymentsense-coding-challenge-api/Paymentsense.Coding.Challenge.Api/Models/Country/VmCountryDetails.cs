using System.Collections.Generic;

using Paymentsense.Coding.Challenge.Domain;

namespace Paymentsense.Coding.Challenge.Api.Models.Country
{
    public class VmCountryDetails
    {
        public string Alpha3Code { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Region { get; set; }

        public int Population { get; set; }
        public string CapitalCity { get; set; }
        public List<string> Timezones { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<Language> Languages { get; set; }
        public List<string> BorderingCountries { get; set; }

        public static VmCountryDetails Build(Domain.Country entity)
        {
            return new VmCountryDetails
            {
                Name = entity.Name,
                Flag = entity.Flag,
                Alpha3Code = entity.Alpha3Code,
                Region = entity.Region,

                Population = entity.Population,
                CapitalCity = entity.Capital,
                Timezones = entity.Timezones,
                Currencies = entity.Currencies,
                Languages = entity.Languages,
                BorderingCountries = entity.Borders
            };
        }
    }
}