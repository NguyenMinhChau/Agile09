using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Agile09
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{MetaTitle}-{id}",
                defaults: new { controller = "Home", action = "Category", id = UrlParameter.Optional, },
                namespaces: new[] { "Agile09.Controllers" }
            );
            routes.MapRoute(
               name: "Payment",
               url: "thanh-toan",
               defaults: new { controller = "CartItem", action = "Payment", id = UrlParameter.Optional, },
               namespaces: new[] { "Agile09.Controllers" }
           );
            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "CartItem", action = "Index", id = UrlParameter.Optional, },
               namespaces: new[] { "Agile09.Controllers" }
           );
            routes.MapRoute(
               name: "Success",
               url: "hoan-thanh",
               defaults: new { controller = "CartItem", action = "Success", id = UrlParameter.Optional, },
               namespaces: new[] { "Agile09.Controllers" }
           );
            routes.MapRoute(
               name: "Error",
               url: "loi-thanh-toan",
               defaults: new { controller = "CartItem", action = "Error", id = UrlParameter.Optional, },
               namespaces: new[] { "Agile09.Controllers" }
           );
            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional, },
               namespaces: new[] { "Agile09.Controllers" }
           );
            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "CartItem", action = "AddItem", id = UrlParameter.Optional, },
               namespaces: new[] { "Agile09.Controllers" }
           );
            routes.MapRoute(
                name: "Product Detail",
                url: "chi-tiet/{MetaTitle}-{id}",
                defaults: new { controller = "Home", action = "Detail", id = UrlParameter.Optional, },
                namespaces: new[] { "Agile09.Controllers" }
            );
            routes.MapRoute(
                name: "About",
                url: "gioi-thieu/",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional, },
                namespaces: new[] { "Agile09.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, },
                namespaces: new[] { "Agile09.Controllers" }
            );
        }
    }
}
