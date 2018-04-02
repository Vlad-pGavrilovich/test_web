using System;
using System.Collections.Generic;
using Data.Access;
using Data.Access.Models;
using Interfaces;
using System.Linq.Expressions;

namespace ServiceLayer.Products
{
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(ProductsContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductList(
            PagingFilteringOrderingOptions<Product> options)
        {
            int productsCount = Count(options.FilterByPredicates);
            if(productsCount != options.ObjectsCount)
            {
                options.CurrentPage = 0;
                options.ObjectsCount = productsCount;
            }
            return PageSearchAndOrderItems(
                options.CurrentPage,
                options.PageSize,
                GetOrderByPredicate(options.OrderByField),
                !options.IsOrderByDesc,
                options.FilterByPredicates);
        }

        private Expression<Func<Product, object>> GetOrderByPredicate(string column)
        {
            ProductOrderByOptions option;
            if (Enum.TryParse(column, out option))
            {
                switch(option)
                {
                    case ProductOrderByOptions.ByCategory:
                        return x => x.Category.Name;
                    case ProductOrderByOptions.ByCountry:
                        return x => x.Country.Name;
                    case ProductOrderByOptions.ByName:
                        return x => x.Name;
                    case ProductOrderByOptions.ByPrice:
                        return x => x.DiscountGroupId.HasValue ?
                        x.PriceDetail.Price * (1 - x.Discount.Discount) / 100 :
                        x.PriceDetail.Price;
                }
            }
            throw new Exception();
        }
    }
}
