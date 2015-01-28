using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pharmacy.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "OrderDetails",
                "order/details/{id}",
                new { controller = "Order", action = "Details" }
            );
            routes.MapRoute(
                "OrderDetailsCreate",
                "orderdetails/create/{orderId}",
                new { controller = "OrderDetails", action = "Create" }
            );
            routes.MapRoute(
                "OrderDetailsEdit",
                "orderdetails/edit/{orderId}/{medcineId}",
                new { controller = "OrderDetails", action = "Edit" }
            );
            routes.MapRoute(
                "OrderDetailsDelete",
                "orderdetails/delete/{orderId}/{medcineId}",
                new { controller = "OrderDetails", action = "Delete" }
            );
            routes.MapRoute(
                "Pharmacies",
                "pharmacies",
                new { controller = "Pharmacy", action = "Index" }
            );
            routes.MapRoute(
                "Medcines",
                "medcines",
                new { controller = "Medcine", action = "Index" }
            );
            routes.MapRoute(
                "Orders",
                "orders",
                new { controller = "Order", action = "Index" }
            );
            routes.MapRoute(
                "Storage",
                "storage",
                new { controller = "Storage", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
