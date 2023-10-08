namespace SimpleStore.Api.Models
{
    public class QueryParameters
    {
        private int _pageSize = 10;
        public int StartIndex { get; set; }
        public int PageNumber { get; set; }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value <= 0 ? 10 : value;
        }
    }
}
