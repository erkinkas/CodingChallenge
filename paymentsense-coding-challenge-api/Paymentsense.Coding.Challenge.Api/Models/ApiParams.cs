namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class ApiParams
    {
        private int? _pageIndex { get; set; }
        private int? _pageLimit { get; set; }

        public int PageIndex
        {
            get => _pageIndex ?? 1;
            set => _pageIndex = value;
        }

        public int PageLimit
        {
            get => _pageLimit ?? 50;
            set => _pageLimit = value;
        }
    }
}