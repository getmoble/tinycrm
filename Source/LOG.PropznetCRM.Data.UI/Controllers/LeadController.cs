using LOG.PropznetCRM.Data.Infrastructure;
using System.Web.Mvc;
using LOG.PropznetCRM.Data.ViewModel.Lead;

namespace LOG.PropznetCRM.Data.UI.Controllers
{
    public class LeadController : CRMBaseController
    {

        public ActionResult Index()
        {
            return RedirectIfNotLoggedIn(View);
        }
        public ActionResult Edit(long id)
        {
            var leadVM = new LeadViewModel
            {
                Id = id
            };

            return View(leadVM);
        }
        public ActionResult ConvertLead()
        {
            return View();
        }
    }
}