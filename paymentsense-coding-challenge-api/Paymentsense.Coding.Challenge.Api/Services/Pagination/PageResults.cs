using System.Collections.Generic;

namespace Paymentsense.Coding.Challenge.Api.Services.Pagination
{
    public class PageResults<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 0;
        public int Total { get; set; } = 0;
    }
}