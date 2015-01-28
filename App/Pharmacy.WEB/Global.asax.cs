using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using FluentValidation.Mvc;
using Pharmacy.CastleWindsor.Installers;

namespace Pharmacy.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //private static IWindsorContainer _container;
        
        protected void Application_Start()
        {
            FluentValidationModelValidatorProvider.Configure();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapperConfig.RegisterMappings();
            var container = new WindsorContainer()
                .Install(new AdminInstaller());
        }
    }
}
