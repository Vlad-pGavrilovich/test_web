
using System;
using System.Linq.Expressions;

namespace Interfaces
{
    public class PagingFilteringOrderingOptions<T>
    {
        public Expression<Func<T, bool>>[] FilterByPredicates { get; set; }

        public string OrderByField { get; set; }

        public bool IsOrderByDesc { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int ObjectsCount { get; set; }
    }
}
