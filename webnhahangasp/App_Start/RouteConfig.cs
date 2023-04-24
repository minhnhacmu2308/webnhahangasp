using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace webnhahangasp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "Foods Index",
              url: "Home/Foods/{page}",
              defaults: new { controller = "Home", action = "Foods", id = UrlParameter.Optional }
             );
            routes.MapRoute(
              name: "News Index",
              url: "Home/News/{page}",
              defaults: new { controller = "Home", action = "News", id = UrlParameter.Optional }
             );
            routes.MapRoute(
             name: "History booking",
             url: "Booking/HistoryBook/{userId}",
             defaults: new { controller = "Booking", action = "HistoryBook", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
