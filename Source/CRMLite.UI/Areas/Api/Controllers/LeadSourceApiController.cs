using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.LeadSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class LeadSourceApiController : BaseApiController
    {
        ILeadSourceService _leadSourceService;
        public LeadSourceApiController(ILeadSourceService leadSourceService)
        {
            _leadSourceService = leadSourceService;
        }
        //
        // GET: /Api/LeadSourceApi/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllLeadSource()
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
          {
              var getLeadSource = _leadSourceService.GetAllLeadSources();
              return getLeadSource;
          }));
        }

        public JsonResult CreateLeadSource(LeadSourceModel leadSourceModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var createLeadSource = _leadSourceService.CreateLeadSource(leadSourceModel);
                return createLeadSource;
            }));
        }
        public JsonResult UpdateLeadSource(LeadSourceModel leadSourceModel)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var updateLeadSource = _leadSourceService.UpdateLeadSource(leadSourceModel);
                return updateLeadSource;
            }));
        }
        public JsonResult DeleteLeadSource(long id)
        {
            return ThrowIfNotLoggedIn(() => TryExecuteWrapAndReturn(() =>
            {
                var deleteLeadSource = _leadSourceService.DeleteLeadSource(id);
                return deleteLeadSource;
            }));
        }
	}
}