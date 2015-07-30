using System.Web.Mvc;
using PropznetCommon.Features.CRM.Interfaces.Services;

namespace CRMLite.UI.Areas.CRM.Controllers
{
    public class SettingsController : BaseUIController
    {
        public readonly IToDoMapService _toDoMapService;
        public SettingsController(IToDoMapService toDoMapService)
        {
            _toDoMapService = toDoMapService;
        }
        public ActionResult Index()
        {
            return RedirectIfNotLoggedIn(View);
        }
    }
}