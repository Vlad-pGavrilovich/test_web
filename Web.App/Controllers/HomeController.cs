using AutoMapper;
using Data.Access.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.App.ViewModels.Product;

namespace Web.App.Controllers
{
    public class HomeController : Controller
    {
        private static readonly int PageSize = 10;

        private IProductService productService;
        private IMapper mapper;

        public HomeController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            ProductComplexViewModel productComplexView = new ProductComplexViewModel();
            productComplexView.ProductPagingViewModel.PagesCount = (int)Math.Ceiling((double)productService.Count() / PageSize);
            IEnumerable<Product> products = productService.PageAndOrderItems(
                productComplexView.ProductPagingViewModel.CurrentPage,
                PageSize,
                x => x.Name);
            IEnumerable<ProductViewModel> productViewModels = 
                mapper.Map<IEnumerable<ProductViewModel>>(products);
            return View(new ProductListCombinedViewModel(productComplexView, productViewModels));
        }
    }
}
