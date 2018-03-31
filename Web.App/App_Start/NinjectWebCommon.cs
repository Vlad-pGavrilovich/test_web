[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App.App_Start
{
    using System;
    using System.Text;
    using System.Web;
    using AutoMapper;
    using Data.Access;
    using Data.Access.Models;
    using Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Activation;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using ServiceLayer;
    using Web.App.ViewModels.Product;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
            kernel.Bind<ProductsContext>().ToSelf().InSingletonScope();
            kernel.Bind<IProductService>().To<ProductService>();
        }

        private static IMapper AutoMapper(IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));
                config.CreateMap<Product, ProductViewModel>()
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(x => x.Category.Name))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(x => x.Country.Name))
                    .ForMember(dest => dest.PriceDetails, opt => opt.MapFrom(x => BuildPriceDetail(x.PriceDetail, x.Discount)))
                    .ForMember(dest => dest.Discount, opt => opt.MapFrom(x => BuidDiscount(x.Discount)));
            });
            Mapper.AssertConfigurationIsValid();
            return Mapper.Instance;
        }

        private static object BuidDiscount(DiscountGroup discount)
        {
            StringBuilder sb = new StringBuilder()
                .Append($"{discount.Discount}%");
            if (discount.FinishDate.HasValue)
            {
                sb.Append(" until ")
                    .Append(discount.FinishDate.ToString());
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
                sb.Append($"{(priceDetail.Price * (1 - dg.Discount / 100)).ToString("0.00")} instead of {priceDetail.Price}");
            }
            sb.Append("$ per ")
                .Append(priceDetail.ProductPriceType == ProductPriceType.ForOne ? "1 item" : "100g");
            return sb.ToString();
        }
    }
}
