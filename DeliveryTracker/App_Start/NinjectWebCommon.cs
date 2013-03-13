[assembly: WebActivator.PreApplicationStartMethod(typeof(DeliveryTracker.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(DeliveryTracker.App_Start.NinjectWebCommon), "Stop")]

namespace DeliveryTracker.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using DapperQueryExecutor;
    using DeliveryTracker.Repositories;
    using DeliveryTracker.Managers;

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
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new NinjectKernelActivator(kernel));

            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            //QueryExecutors
            kernel.Bind<IDapperQueryExecutor>().To<SqlDapperQueryExecutor>().InSingletonScope();

            //Managers
            kernel.Bind<IAuthenticationManager>().To<AuthenticationManager>();

            //Repositories
            kernel.Bind<IAuthenticationsRepository>().To<DapperAuthenticationsRepository>();
            kernel.Bind<IUsersRepository>().To<DapperUsersRepository>();
            kernel.Bind<ITrucksRepository>().To<MemoryTrucksRepository>();
            kernel.Bind<IPasswordHasher>().To<PasswordHasher>();
        }        
    }
}
