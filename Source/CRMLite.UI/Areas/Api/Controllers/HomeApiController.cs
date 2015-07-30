using System.Web.Mvc;
using PropznetCommon.Features.CRM.Interfaces.Services;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class HomeApiController : BaseApiController
    {
        readonly IReportService _reportService;
        public HomeApiController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public ActionResult GetStatus()
        {
            if (WebUser != null && !WebUser.IsInRole("Admin"))
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