using System.Collections.Generic;

namespace PropznetCommon.Features.CRM.Model
{
    public class SearchResult<T>
    {
        public IList<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}