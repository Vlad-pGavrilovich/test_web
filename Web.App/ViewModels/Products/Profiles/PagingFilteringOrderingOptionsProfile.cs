using AutoMapper;
using Data.Access.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.App.ViewModels.Common;

namespace Web.App.ViewModels.Products.Profiles
{
    public class PagingFilteringOrderingOptionsProfile : Profile
    {
        public PagingFilteringOrderingOptionsProfile()
        {
            CreateMap<ProductComplexViewModel, PagingFilteringOrderingOptions<Product>>()
                .ForMember(dest => dest.FilterByPredicates, opt => opt.MapFrom(x => GetFilterPredicates(x.ProductFilterViewModel)))
                .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(
                       x => x.PagingViewModel.IsModelChanged ? 0 : x.PagingViewModel.CurrentPage))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(x => 10))
                .ForMember(dest => dest.OrderByField, opt => opt.MapFrom(x => x.OrderByViewModel.Column))
                .ForMember(dest => dest.IsOrderByDesc, opt => opt.MapFrom(x => x.OrderByViewModel.IsDesc))
                .ForMember(dest => dest.ObjectsCount, opt => opt.MapFrom(x => x.PagingViewModel.ObjectsCount));
            CreateMap<PagingFilteringOrderingOptions<Product>, PagingViewModel>()
                .ForMember(dest => dest.CurrentPage, opt => opt.MapFrom(x => x.CurrentPage))
                .ForMember(dest => dest.ObjectsCount, opt => opt.MapFrom(x => x.ObjectsCount))
                .ForMember(dest => dest.PagesCount, opt => opt.MapFrom(x => (int)Math.Ceiling((double)x.ObjectsCount / x.PageSize)));
        }

        private static Func<Product, bool>[] GetFilterPredicates(
                ProductFilterViewModel productFilterViewModel)
        {
            List<Func<Product, bool>> filters = new List<Func<Product, bool>>();
            if (productFilterViewModel.CategoryId.HasValue)
            {
                filters.Add(x => x.CategoryId == productFilterViewModel.CategoryId.Value);
            }
            if (productFilterViewModel.CountryId.HasValue)
            {
                filters.Add(x => x.CountryId == productFilterViewModel.CountryId.Value);
            }
            if (productFilterViewModel.PriceFrom.HasValue)
            {
                filters.Add(x => x.PriceDetail.Price >= productFilterViewModel.PriceFrom.Value);
            }
            if (productFilterViewModel.PriceTo.HasValue)
            {
                filters.Add(x => x.PriceDetail.Price < productFilterViewModel.PriceTo.Value);
            }
            if (!String.IsNullOrEmpty(productFilterViewModel.SearchName))
            {
                filters.Add(x => x.Name.Contains(productFilterViewModel.SearchName));
            }
            return filters.ToArray();
        }
    }
}