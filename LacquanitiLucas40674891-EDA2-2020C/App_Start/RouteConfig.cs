using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LacquanitiLucas40674891_EDA2_2020C
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Bienvenido", action = "Index" }
            );

            routes.MapRoute(
                name: "Jugador",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Jugadores", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
