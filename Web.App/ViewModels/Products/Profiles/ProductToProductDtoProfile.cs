using AutoMapper;
using Data.Access.Models;
using System.Text;

namespace Web.App.ViewModels.Products.Profiles
{
    public class ProductToProductDtoProfile : Profile
    {
        public ProductToProductDtoProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(x => x.Category.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(x => x.Country.Name))
                .ForMember(dest => dest.PriceDetails, opt => opt.MapFrom(x => BuildPriceDetail(x.PriceDetail, x.Discount)))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(x => BuidDiscount(x.Discount)));
        }

        private static string BuidDiscount(DiscountGroup discount)
        {
            StringBuilder sb = new StringBuilder()
                .Append($"{discount.Discount}%");
            if (discount.FinishDate.HasValue)
            {
                sb.Append(" until ")
                    .Append(discount.FinishDate.Value.ToShortDateString());
            }
            return sb.ToString();
        }

        private static string BuildPriceDetail(PriceDetail priceDetail, DiscountGroup dg)
        {
            StringBuilder sb = new StringBuilder();
            if (dg == null)
            {
                sb.Append(priceDetail.Price);
            }
            else
            {
                sb.Append($"{(priceDetail.Price * (1 - dg.Discount / 100)).ToString("0.00")}$ instead of {priceDetail.Price}");
            }
            sb.Append("$ per ")
                .Append(priceDetail.ProductPriceType == ProductPriceType.ForOne ? "1 item" : "100g");
            return sb.ToString();
        }
    }
}