using System.Collections.Generic;

namespace Paymentsense.Coding.Challenge.Services.Pagination
{
    public class QueryParams
    {
        public List<Sort> Sorts { get; set; } = new List<Sort>();
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}