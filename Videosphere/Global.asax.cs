using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Videosphere
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() //odpala sie na start aplikacji.
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes); //routes dla apki od startu.
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

//plik z ASP.NET (od dawna). zaczepia o rozne eventy w lifecycle aplication.