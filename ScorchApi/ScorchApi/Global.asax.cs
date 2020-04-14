using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Web;
using ScorchApi.App_Start;
using ScorchApi.Modules;

namespace ScorchApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider => _containerProvider;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            _containerProvider = new ContainerProvider(AutofacConfig.ConfigureAutofac());
            AutoMapperModule.Initialize();
        }
    }
}
