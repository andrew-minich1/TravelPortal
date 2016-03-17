using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TravelPortal.Foundations.Bootsraping
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly IContainer _container;

        public WebApiApplication()
        {
            //_container = new CompositionRoot().Register();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
            //_container.Resolve<ILogService>().LogInfo("Hello");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            //_container.Resolve<ILogService>().LogInfo(exception.ToString());

            //Server.Transfer();
        }
    }
}
