using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Infrastructure;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Controllers
{
    public class SettingsController : CRMBaseController
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