using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Infrastructure;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Areas.Api.Controllers
{
    public class HomeApiController : CRMBaseController
    {
        readonly IReportService _reportService;
        public HomeApiController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public ActionResult GetStatus()
        {
            if (!WebUser.IsInRole("Admin"))
            {
                var userId = WebUser.Id;
                var leadStatuses = _reportService.GetLeadStatusByUserId(userId);
                var salesStages = _reportService.GetSalesByUserId(userId);
                var retunData = new { SalesStage = salesStages, LeadStatuses = leadStatuses };
                return Json(retunData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var leadStatuses = _reportService.GetAllLeadStatus();
                var salesStages = _reportService.GetAllSales();
                var retunData = new { SalesStage = salesStages, LeadStatuses = leadStatuses };
                return Json(retunData, JsonRequestBehavior.AllowGet);
            }
        }
    }
}