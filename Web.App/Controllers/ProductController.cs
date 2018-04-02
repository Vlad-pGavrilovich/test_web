using AutoMapper;
using Data.Access.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App.ViewModels.Common;
using Web.App.ViewModels.Products;

namespace Web.App.Controllers
{
    public class ProductController : Controller
    {

        private IProductService productService;
        private IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        // GET: Product
        [HttpGet]
        public ActionResult GetProducts(ProductComplexViewModel complexViewModel)
        {
            PagingFilteringOrderingOptions<Product> options =
                mapper.Map<PagingFilteringOrderingOptions<Product>>(complexViewModel);
            IEnumerable<Product> products = productService.GetProductList(options);
            IEnumerable<ProductViewModel> productDtos =
                mapper.Map<IEnumerable<ProductViewModel>>(products);
            PagingViewModel paging = mapper.Map<PagingViewModel>(complexViewModel);
            return PartialView("~/Views/Product/_ProductListPartial", new ProductsDtoListWithPaging(paging, productDtos));
        }
    }
}