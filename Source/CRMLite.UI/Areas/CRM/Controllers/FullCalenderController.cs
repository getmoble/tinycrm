using System.Web.Mvc;
using PropznetCommon.Features.CRM.ViewModel;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class FullCalenderController : BaseUIController
    {
        public ActionResult Index(string entityType, long id)
        {
            return RedirectIfNotLoggedIn(() =>
            {
                var fullCalenderVm = new FullCalenderViewModel
                {
                    EntityType = entityType,
                    Id = id
                };
                return View(fullCalenderVm);
            });
        }
    }
}