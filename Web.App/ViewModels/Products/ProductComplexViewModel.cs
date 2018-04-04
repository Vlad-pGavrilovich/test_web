using Web.App.ViewModels.Common;

namespace Web.App.ViewModels.Products
{
    public class ProductComplexViewModel
    {
        public ProductFilterViewModel ProductFilterViewModel { get; private set; }

        public PagingViewModel PagingViewModel { get; private set; }

        public OrderByViewModel OrderByViewModel { get; private set; }
    }
}