using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ludo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Home",
                "{action}",
                new { controller = "Home"}
                );
            routes.MapRoute(
                "Game",
                "game/{id}",
                new { controller = "Game", action = "Game"},
                new { id = @"\d+" }

            );
            routes.MapRoute(
                "GameDefault",
                "game/{action}",
                new { controller = "Game", action = "New" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
