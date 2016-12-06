using System.Web.Mvc;
using System.Web.Routing;

namespace App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Noticia",
                url: "Noticia",
                defaults: new { controller = "News", action = "CreateNews", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Beneficio",
                url: "Beneficio",
                defaults: new { controller = "Benefit", action = "CreateBenefit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Politica",
                url: "Politica",
                defaults: new { controller = "Policy", action = "CreatePolicy", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Evento",
                url: "Evento",
                defaults: new { controller = "Event", action = "CreateEvent", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Dashboard",
                url: "Dashboard",
                defaults: new { controller = "Dashboard", action = "Dashboard", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminDash",
                url: "Admin",
                defaults: new { controller = "AdminDashboard", action = "AdminDashboard", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
