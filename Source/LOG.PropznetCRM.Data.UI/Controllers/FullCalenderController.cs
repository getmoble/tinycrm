using LOG.PropznetCRM.Data.Infrastructure;
using LOG.PropznetCRM.Data.ViewModel;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Controllers
{
    public class FullCalenderController : CRMBaseController
    {
        public ActionResult Index(string entityType, long id)
        {
            var fullCalenderVm = new FullCalenderViewModel
            {
                EntityType = entityType,
                Id = id
            };
            return View(fullCalenderVm);
        }
    }
}