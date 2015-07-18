using LOG.PropznetCRM.Data.Infrastructure;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Controllers
{
    public class HomeController : CRMBaseController
    {
        public ActionResult Index()
        {
            return RedirectIfNotLoggedIn(View);
        }
    }
}