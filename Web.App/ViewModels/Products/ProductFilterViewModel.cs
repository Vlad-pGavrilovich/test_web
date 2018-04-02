namespace Web.App.ViewModels.Products
{
    public class ProductFilterViewModel
    {
        public long? CategoryId { get; set; }

        public string SearchName { get; set; }

        public float? PriceFrom { get; set; }

        public float? PriceTo { get; set; }

        public long? CountryId { get; set; }
    }
}