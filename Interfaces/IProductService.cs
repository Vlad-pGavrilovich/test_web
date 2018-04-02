using Data.Access.Models;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IProductService : IGenericService<Product>
    {
        IEnumerable<Product> GetProductList(PagingFilteringOrderingOptions<Product> options);
    }
}
