using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*
            //The old way of creating routes
            //Custom route. The more specific, the higher up
            routes.MapRoute(
                name: "MoviesByReleaseDate",
                url: "movies/released/{year}/{month}",
                defaults:  new { controller = "Movies", action = "ByReleaseDate"},
                new { year = @"\d{4}", month = @"\d{2}"}
                //new { year = @"2015|2016", month = @"\d{2}"}
                );
             */

            //The new way of creating routes. Moves them into the Controller
            routes.MapMvcAttributeRoutes();

            

            //Default Route (should be most general, and last)
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
