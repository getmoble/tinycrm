using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Agent;
using PropznetCommon.Features.CRM.Model.CommunicationDetail;
using PropznetCommon.Features.CRM.ViewModel.Agent;
using CRMLite.Infrastructure;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class AgentApiController : BaseApiController
    {
        readonly IAgentService _agentService;
        readonly ICommunicationDetailService _communicationDetailService;
        public AgentApiController(IAgentService agentService, ICommunicationDetailService communicationDetailService)
        {
            _agentService = agentService;
            _communicationDetailService = communicationDetailService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAgent(long id)
        {
            var agent = _agentService.GetAgent(id);
            agent.Image = ImageUrlResolver.ResolveUrl(agent.Image);
            return Json(agent, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult List()
        {
            return ExecuteIfValid(() =>
            {
                if (!WebUser.IsInRole("Admin"))
                {
                    var agentlist = _agentService.GetAllAgentsByUserId(WebUser.Id, WebUser.PermissionCodes);
                    var output = JsonConvert.SerializeObject(agentlist);
                    return Json(output, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var agentlist = _agentService.GetAllAgents();
                    var output = JsonConvert.SerializeObject(agentlist);
                    return Json(output, JsonRequestBehavior.AllowGet);
                }
            },
             () =>
             {
                 return Json(false, JsonRequestBehavior.AllowGet);
             },
             error => { return Json(false, JsonRequestBehavior.AllowGet); 
             });
        }
        public ActionResult EditAgent(long id)
        {
            var agent = _agentService.GetAgent(id);
            agent.Image = ImageUrlResolver.ResolveUrl(agent.Image);
            return Json(agent, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadImageFiles()
        {
            var r = new List<UploadFileContentViewModel>();

            foreach (string file in Request.Files)
            {
                var hpf = Request.Files[file];
                if (hpf != null && hpf.ContentLength == 0)
                    continue;

                var savedFileName = Path.Combine(Server.MapPath("~/Upload/Avatar"), Path.GetFileName(hpf.FileName));
                hpf.SaveAs(savedFileName); // Save the file

                r.Add(new UploadFileContentViewModel
                {
                    Name = hpf.FileName,
                    Length = hpf.ContentLength,
                    Type = hpf.ContentType,
                    Path = savedFileName
                });
            }
            // Returns json
            var vm = new UploadFileContentViewModel { Name = r[0].Name, Length = r[0].Length, Type = r[0].Type, Path = r[0].Path };
            return Json(vm);
        }
        public ActionResult Create(AgentModel agentModel)
        {
            var communicationDetailModel = new CommunicationDetailModel
            {
                Email = agentModel.Email,
                Phone = agentModel.Phone,
                Address = agentModel.Address
            };
            if (agentModel.Image != null)
            {
                agentModel.Image = agentModel.Image.Split('\\').Last();
            }
            var communicationDetailId = _communicationDetailService.CreateCommunicationDetail(communicationDetailModel);
            agentModel.CommunicationDetailID = communicationDetailId;
            agentModel.CreatedBy = WebUser.Id;
            _agentService.CreateAgent(agentModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(AgentSearchFilter agentSearchFilter)
        {
            agentSearchFilter.UserId = WebUser.Id;
            var searchResult = _agentService.SearchAgent(agentSearchFilter, 0, 0);
            return Json(searchResult.Items, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDelete(long id)
        {
            var deletestatus = _agentService.DeleteAgent(id);
            return Json(deletestatus);
        }
        public ActionResult Update(AgentModel agentModel)
        {
            var communicationDetailModel = new CommunicationDetailModel
            {
                Id = agentModel.CommunicationDetailID,
                Address = agentModel.Address,
                Email = agentModel.Email,
                Phone = agentModel.Phone
            };

            if (!String.IsNullOrEmpty(agentModel.Image))
            {
                if (agentModel.Image.Contains("C:\\fakepath\\"))
                    agentModel.Image = agentModel.Image.Split('\\').Last();
                if (agentModel.Image.Contains("/Upload/Avatar/"))
                    agentModel.Image = agentModel.Image.Split('/').Last();
            }

            var communicationDetailId = _communicationDetailService.UpdateCommunicationDetail(communicationDetailModel);
            agentModel.CommunicationDetailID = communicationDetailId;
            var agentupdate = _agentService.UpdateAgent(agentModel);
            return Json(agentupdate, JsonRequestBehavior.AllowGet);
        }
    }
}