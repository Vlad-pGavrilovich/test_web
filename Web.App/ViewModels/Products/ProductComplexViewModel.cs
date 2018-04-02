using Web.App.ViewModels.Common;

namespace Web.App.ViewModels.Products
{
    public class ProductComplexViewModel
    {
        public ProductComplexViewModel()
        {
            PagingViewModel = new PagingViewModel
            {
                CurrentPage = 0
            };
            ProductFilterViewModel = new ProductFilterViewModel();
            OrderByViewModel = new OrderByViewModel
            {
                Column = "ByName"
            };
        }

        public ProductFilterViewModel ProductFilterViewModel { get; private set; }

        public PagingViewModel PagingViewModel { get; private set; }

        public OrderByViewModel OrderByViewModel { get; private set; }
    }
}