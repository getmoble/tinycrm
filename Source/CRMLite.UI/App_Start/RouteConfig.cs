using System.Web.Mvc;
using System.Web.Routing;

namespace CRMLite.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "CRMLite.UI.Controllers" }).DataTokens["UseNamespaceFallback"] = true;
        }
    }
}