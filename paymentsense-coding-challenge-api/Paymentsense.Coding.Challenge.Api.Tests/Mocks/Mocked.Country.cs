using System.Collections.Generic;

using Paymentsense.Coding.Challenge.Domain;

namespace Paymentsense.Coding.Challenge.Api.Tests.Mocks
{
    public static class Mocked
    {
        public static Country Country(string code) => new Country
        {
            Flag = "flag.ico",
            Region = "region",
            Name = "name",
            Population = 15000000,
            Alpha3Code = code,
            Capital = "city",
            Languages = new List<Language>
            {
                new Language
                {
                    Name = "lang_name",
                    Iso639_1 = "lang_Iso639_1",
                    Iso639_2 = "lang_Iso639_2",
                    NativeName = "lang_NativeName"
                }
            },
            Currencies = new List<Currency>
            {
                new Currency
                {
                    Code = "currency_code",
                    Name = "currency_name",
                    Symbol = "currency_symbol"
                }
            },
            Timezones = new List<string> { "+0", "+1" },
            Borders = new List<string> { "border_code1", "border_code2", "border_code3" }
        };
    }
}