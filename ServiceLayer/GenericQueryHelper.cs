using System;
using System.Linq;
using System.Linq.Expressions;

namespace ServiceLayer
{
    public static class GenericQueryHelper
    {
        public static IQueryable<T> ApplyPaging<T>(
            this IQueryable<T> query, 
            int pageNumberZeroBased, 
            int pageSize)
        {
            if (pageSize == 0)
            {
                throw new ArgumentOutOfRangeException
                    (nameof(pageSize), "pageSize cannot be zero.");
            }
            return query
                .Skip(pageNumberZeroBased * pageSize)
                .Take(pageSize);
        }

        public static IQueryable<T> ApplyFiltering<T>(
            this IQueryable<T> query,
            params Expression<Func<T,bool>>[] filteringPredicates)
        {
            foreach(Expression<Func<T, bool>> filteringPredicate in filteringPredicates)
            {
                query = query.Where(filteringPredicate);
            }
            return query;
        }

        public static IQueryable<T> ApplyOrdering<T, TKey>(
            this IQueryable<T> query,
            Expression<Func<T, TKey>> orderByPredicate,
            bool ascending)
        {
            if(ascending)
            {
                return query.OrderBy(orderByPredicate);
            }
            return query.OrderByDescending(orderByPredicate);
        }

    }
}
