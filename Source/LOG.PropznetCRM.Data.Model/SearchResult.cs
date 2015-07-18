using System.Collections.Generic;

namespace LOG.PropznetCRM.Data.Model
{
    public class SearchResult<T>
    {
        public IList<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}