using System.Collections.Generic;
using System.Linq;

using Paymentsense.Coding.Challenge.Services.Pagination;

namespace Paymentsense.Coding.Challenge.Api.Models.Country
{
    public class VmCountryList
    {
        public string Alpha3Code { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }

        private static VmCountryList Build(Domain.Country entity)
        {
            if (entity == null)
                return null;

            return new VmCountryList
            {
                Name = entity.Name,
                Flag = entity.Flag,
                Alpha3Code = entity.Alpha3Code
            };
        }

        public static List<VmCountryList> Build(PageResults<Domain.Country> entities)
        {
            return entities?.Items?.Where(x => x != null).Select(Build).ToList();
        }
    }
}