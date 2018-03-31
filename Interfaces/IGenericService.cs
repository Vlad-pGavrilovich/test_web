using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Interfaces
{
    public interface IGenericService<T>
    {
        IEnumerable<T> SearchItems(params Expression<Func<T, bool>>[] filteringPredicates);

        IEnumerable<T> SearchAndOrderItems<TKey>(
            Expression<Func<T, TKey>> orderByPredicate, 
            bool ascending = true, 
            params Expression<Func<T, bool>>[] filteringPredicates);

        IEnumerable<T> PageSearchAndOrderItems<TKey>(
            int pageNum,
            int pageSize,
            Expression<Func<T, TKey>> orderByPredicate,
            bool ascending = true,
            params Expression<Func<T, bool>>[] filteringPredicates);

        IEnumerable<T> PageAndOrderItems<TKey>(
            int pageNum,
            int pageSize,
            Expression<Func<T, TKey>> orderByPredicate,
            bool ascending = true);

        int Count(params Expression<Func<T, bool>>[] filteringPredicates);
    }
}
