using LOG.PropznetCRM.Data.Infrastructure;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Controllers
{
    public class ContactController : CRMBaseController
    {
        public ActionResult Index()
        {
            return RedirectIfNotLoggedIn(View);
        }
	}
}