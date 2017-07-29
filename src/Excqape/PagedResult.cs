using System.Collections.Generic;

namespace Excqape
{
    public class PagedResult<TItem>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public IReadOnlyCollection<TItem> Items { get; set; }

        public PagedResult()
        {
            Items = new List<TItem>(0);
        }
    }
}
