using System;
using System.Linq;
using System.Web.Mvc;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.ToDo;
using PropznetCommon.Features.CRM.Model.ToDoMap;
using PropznetCommon.Features.CRM.ViewModel;

namespace CRMLite.UI.Areas.Api.Controllers
{
    public class FullCalenderApiController : BaseApiController
    {
        readonly IToDoService _toDoService;
        readonly IToDoMapService _toDoMapService;
        static CRMEntityType _entityType;
        public FullCalenderApiController(IToDoService toDoService, IToDoMapService toDoMapService)
        {
            _toDoService = toDoService;
            _toDoMapService = toDoMapService;
        }
        public ActionResult DeleteEvent(long id)
        {
            _toDoMapService.DeleteTodoMap(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateEvent(long id, string title, string newEventDate, string newEventTime, string newEventDuration, long EventForId)
        {
            var toDoModel = new ToDoModel
            {
                Id = id,
                DueDate = Convert.ToDateTime(newEventDate),
                Time = Convert.ToDateTime(newEventTime),
                Title = title,
                EventForId = EventForId
            };
            _toDoService.UpdateToDo(toDoModel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public CRMEntityType Index(string entityType)
        {
            if (entityType == "Lead")
                _entityType = CRMEntityType.Lead;
            else if (entityType == "Account")
                _entityType = CRMEntityType.Account;
            else if (entityType == "User")
                _entityType = CRMEntityType.Agent;
            else if (entityType == "Contact")
                _entityType = CRMEntityType.Contact;
            else if (entityType == "Potential")
                _entityType = CRMEntityType.Potential;
            return _entityType;
        }
        public bool SaveEvent(string Title, string NewEventDate, string NewEventTime, string NewEventDuration, long EventForId, string EntityType)
        {
            var toDoModel = new ToDoModel
            {
                DueDate = Convert.ToDateTime(NewEventDate),
                Time = Convert.ToDateTime(NewEventTime),
                Title = Title,
                EventForId = EventForId,
                CreatedBy = WebUser.Id
            };
            var createToDo = _toDoService.CreateToDo(toDoModel);
            var toDoMaps = new ToDoMapModel
            {
                ToDoId = createToDo.Id,
                EntityType = Index(EntityType),
                CreatedBy = WebUser.Id
            };
            _toDoMapService.CreateToDoMap(toDoMaps);
            return true;
        }


        [HttpGet]
        public ActionResult GetEvents(string entityType)
        {
            var result = _toDoMapService.GetAllToDoMapsByEntityTypeAndUserId(Index(entityType), WebUser.Id)
                                          .Select(t =>
                                            new ToDoViewModel
                                            {
                                                Id = t.Id,
                                                Title = t.ToDo.Title,
                                                StartTime = t.ToDo.DueDate,
                                                EndTime = t.ToDo.DueDate,
                                                Time = t.ToDo.Time.ToShortTimeString()
                                            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllEvents()
        {
            return ExecuteIfValid(() =>
            {
                if (!WebUser.IsInRole("Admin"))
                {
                    var allTodos = _toDoMapService.GetToDosByUserId(WebUser.Id, WebUser.PermissionCodes);
                    return Json(allTodos, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var allTodos = _toDoService.GetAllToDos();
                    return Json(allTodos, JsonRequestBehavior.AllowGet);
                }
            },
            () =>
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            },
            error => {
                return Json(false, JsonRequestBehavior.AllowGet);
            });
        }
    }
}