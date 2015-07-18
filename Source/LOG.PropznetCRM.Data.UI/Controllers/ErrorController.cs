using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Controllers
{
    public class ErrorController : Controller
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