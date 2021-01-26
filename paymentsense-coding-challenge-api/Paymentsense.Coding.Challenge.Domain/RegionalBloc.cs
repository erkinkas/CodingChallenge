using System.Collections.Generic;

namespace Paymentsense.Coding.Challenge.Domain
{
    public class RegionalBloc
    {
        public string Acronym { get; set; }
        public string Name { get; set; }
        public List<string> OtherAcronyms { get; set; }
        public List<string> OtherNames { get; set; }
    }
}