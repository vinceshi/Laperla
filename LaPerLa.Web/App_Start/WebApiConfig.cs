using LaPerLa.Web.Resolver;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LaPerLa.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var container = new UnityContainer();
            //DependencyRegisterType.Container_Sys(ref container);
            //config.DependencyResolver = new UnityResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
