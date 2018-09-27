using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Videosphere
{
    public class RouteConfig //zasady dobierania controllerow (routing rules).
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //KOLEJNOSC MA ZNACZENIE!

            routes.MapMvcAttributeRoutes(); //lepiej bo np. zmieniajac nazwe akcji still works.
            //tutaj wystarczy tyle, reszte ogarniam w kontrolerze.

            /*
            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate" },
                new { year = @"\d{4}", month = @"\d{2}"} //at sign bo \ to escape i musialbym dac \\. ladniej z @ ;)
                            // np. 2018|2019 tylko te dwa do wyboru.
                );
            */

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", //url pattern. pierwsza czesc to nazwa kontrollera. action klasa. i id ;)
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
