import { CountryCurrency, CountryLanguage } from '.';

export interface CountryDetailsModel {
  alpha3Code: string;
  name: string;
  flag: string;

  population: number;
  capitalCity: string;
  timezones: Array<string>;
  currencies: Array<CountryCurrency>;
  languages: Array<CountryLanguage>;
  borderingCountries: Array<string>;
}
