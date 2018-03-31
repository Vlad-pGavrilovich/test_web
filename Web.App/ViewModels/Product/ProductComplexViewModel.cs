using Web.App.ViewModels.Common;

namespace Web.App.ViewModels.Product
{
    public class ProductComplexViewModel
    {
        public ProductComplexViewModel()
        {
            ProductPagingViewModel = new PagingViewModel
            {
                CurrentPage = 0
            };
            ProductFilterViewModel = new ProductFilterViewModel();
            ProductOrderByViewModel = new OrderByViewModel
            {
                Column = "Name"
            };
        }

        public ProductFilterViewModel ProductFilterViewModel { get; private set; }

        public PagingViewModel ProductPagingViewModel { get; private set; }

        public OrderByViewModel ProductOrderByViewModel { get; private set; }
    }
}