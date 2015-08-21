using System.Web.Mvc;

namespace CRMLite.UI.Controllers
{
    [RoutePrefix("home")]
    [Route("{action=index}")]
    public class HomeController : BaseUIController
    {
        public ActionResult Index()
       {
            return RedirectIfNotLoggedIn(View);
        }
        public ActionResult Rough()
        {
            return View();
        }
	}
}