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
                "Game",
                "game/{id}",
                new { controller = "Game", action = "Game" },
                new { id = @"\d+" }

            );
            routes.MapRoute(
                "Move",
                "game/move",
                new { controller = "Game", action = "Move" }
                //new { playedId = @"\d+", brickId = @"\d+" }
            );

            routes.MapRoute(
                "GameDefault",
                "game/{action}",
                new { controller = "Game" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
