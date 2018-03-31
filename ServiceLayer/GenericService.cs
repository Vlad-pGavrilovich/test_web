using Data.Access;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ServiceLayer
{
    public class GenericService<T> : IGenericService<T> where T : class
    {

        private ProductsContext context;

        public GenericService(ProductsContext context)
        {
            this.context = context;
        }

        public int Count(params Expression<Func<T, bool>>[] filteringPredicates)
        {
            IQueryable<T> query = context.Set<T>();
            foreach(Expression<Func<T, bool>> filterPredicate in filteringPredicates)
            {
                query = query.Where(filterPredicate);
            }
            return query.Count();
        }

        public IEnumerable<T> PageAndOrderItems<TKey>(
            int pageNum, 
            int pageSize, 
            Expression<Func<T, TKey>> orderByPredicate, 
            bool ascending = true)
        {
            return context.Set<T>()
                .ApplyOrdering(orderByPredicate, ascending)
                .ApplyPaging(pageNum, pageSize)
                .ToList();
        }

        public IEnumerable<T> PageSearchAndOrderItems<TKey>(
            int pageNum, 
            int pageSize,
            Expression<Func<T, TKey>> orderByPredicate, 
            bool ascending = true, 
            params Expression<Func<T, bool>>[] filteringPredicates)
        {
            return context.Set<T>()
                .ApplyFiltering(filteringPredicates)
                .ApplyOrdering(orderByPredicate, ascending)
                .ApplyPaging(pageNum, pageSize)
                .ToList();
        }

        public IEnumerable<T> SearchAndOrderItems<TKey>(
            Expression<Func<T, TKey>> orderByPredicate, 
            bool ascending = true, 
            params Expression<Func<T, bool>>[] filteringPredicates)
        {
            return context.Set<T>()
                .ApplyFiltering(filteringPredicates)
                .ApplyOrdering(orderByPredicate, ascending)
                .ToList();
        }

        public IEnumerable<T> SearchItems(params Expression<Func<T, bool>>[] filteringPredicates)
        {
            return context.Set<T>()
                .ApplyFiltering(filteringPredicates)
                .ToList();
        }
    }
}
