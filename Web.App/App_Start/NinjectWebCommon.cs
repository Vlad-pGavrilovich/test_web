[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App.App_Start
{
    using AutoMapper;
    using Data.Access;
    using Interfaces;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Activation;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using ServiceLayer.Products;
    using System;
    using System.Web;
    using ViewModels.Products.Profiles;

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
                config.AddProfile(new ProductToProductDtoProfile());
                config.AddProfile(new PagingFilteringOrderingOptionsProfile());
            });
            Mapper.AssertConfigurationIsValid();
            return Mapper.Instance;
        }
    }
}
