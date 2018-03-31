using Data.Access;
using Data.Access.Models;
using Interfaces;

namespace ServiceLayer
{
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(ProductsContext context) : base(context)
        {
        }
    }
}
