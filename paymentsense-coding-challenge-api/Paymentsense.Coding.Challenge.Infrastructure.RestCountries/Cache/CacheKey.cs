namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Cache
{
    public class CacheKey
    {
        private readonly string _key;

        private CacheKey(string key)
        {
            _key = $"RestCountriesCache_{key}";
        }

        public override string ToString()
        {
            return _key;
        }

        public static readonly CacheKey All = new CacheKey("all");
        public static CacheKey SearchByCode(string code) => new CacheKey($"searchByCode_{code}");
    }
}