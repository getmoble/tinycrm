using System.Web.Mvc;

namespace CRMLite.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalIdentityInjector());
        }
    }
}