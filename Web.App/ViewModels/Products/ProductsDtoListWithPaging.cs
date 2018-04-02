using System.Collections.Generic;
using Web.App.ViewModels.Common;

namespace Web.App.ViewModels.Products
{
    public class ProductsDtoListWithPaging
    {
        public ProductsDtoListWithPaging(
            PagingViewModel pagingViewModel, 
            IEnumerable<ProductViewModel> productList)
        {
            PagingViewModel = pagingViewModel;
            ProductList = productList;
        }

        public PagingViewModel PagingViewModel { get; private set; }

        public IEnumerable<ProductViewModel> ProductList { get; private set; }
    }
}