[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MvcAzureLoggingDemo.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MvcAzureLoggingDemo.App_Start.NinjectWebCommon), "Stop")]

namespace MvcAzureLoggingDemo.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Extensions.UXRiskLogger.Autologger;
    using Ninject.Extensions.UXRiskLogger.Log4Net;
    using Ninject.Web.Common;
    using System;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new AutomaticLoggingInjectionModule(), new Log4NetModule());
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
    }
}