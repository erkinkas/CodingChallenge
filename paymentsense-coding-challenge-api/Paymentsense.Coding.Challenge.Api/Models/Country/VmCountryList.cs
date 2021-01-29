using System.Collections.Generic;
using System.Linq;

using Paymentsense.Coding.Challenge.Api.Services.Pagination;

namespace Paymentsense.Coding.Challenge.Api.Models.Country
{
    public class VmCountryList
    {
        public string Alpha3Code { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Region { get; set; }

        private static VmCountryList Build(Domain.Country entity)
        {
            return new VmCountryList
            {
                Name = entity.Name,
                Flag = entity.Flag,
                Alpha3Code = entity.Alpha3Code,
                Region = entity.Region
            };
        }

        public static List<VmCountryList> Build(PageResults<Domain.Country> entities)
        {
            return entities?.Items?.Where(x => x != null).Select(Build).ToList();
        }
    }
}