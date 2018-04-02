namespace Web.App.ViewModels.Products
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string PriceDetails { get; set; }

        public string Country { get; set; }

        public string Category { get; set; }

        public string Discount { get; set; }
    }
}
