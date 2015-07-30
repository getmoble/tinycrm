using System.Web.Mvc;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class ErrorController : BaseUIController
    {
        public ActionResult NotAuthorized()
        {
            return View();
        }
        public ActionResult NoAccess()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
	}
}