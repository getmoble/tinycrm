using System.Web.Mvc;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class HomeController : BaseUIController
    {
        public ActionResult Index()
        {
            return RedirectIfNotLoggedIn(View);
        }
    }
}