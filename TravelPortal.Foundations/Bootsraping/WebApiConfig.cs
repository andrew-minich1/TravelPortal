using System.Web.Http;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using TravelPortal.Foundations.Infrastructure;

namespace TravelPortal.Foundations.Bootsraping
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new BrowserJsonFormatter());

            var container = (IUnityContainer) ServiceLocator.Current.GetInstance(typeof (IUnityContainer));
            //UnityConfiguration.Apply(container);
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
