using System.Collections.Generic;

namespace Web.App.ViewModels.Product
{
    public class ProductListCombinedViewModel
    {
        public ProductListCombinedViewModel(
            ProductComplexViewModel productComplexViewModel, 
            IEnumerable<ProductViewModel> productList)
        {
            PagingProductFilterModel = productComplexViewModel;
            ProductList = productList;
        }

        public ProductComplexViewModel PagingProductFilterModel { get; private set; }

        public IEnumerable<ProductViewModel> ProductList { get; private set; }
    }
}