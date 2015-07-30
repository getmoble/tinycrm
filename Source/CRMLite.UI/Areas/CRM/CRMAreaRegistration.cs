using System.Web.Mvc;

namespace CRMLite.UI.Areas.CRM
{
    public class CrmAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CRM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CRM_default",
                "CRM/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "CRMLite.UI.Areas.CRM.Controllers" }
            );
        }
    }
}