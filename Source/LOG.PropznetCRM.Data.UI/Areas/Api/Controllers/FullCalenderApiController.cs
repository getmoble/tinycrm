using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities.Enum;
using LOG.PropznetCRM.Data.Infrastructure;
using LOG.PropznetCRM.Data.Model.ToDo;
using LOG.PropznetCRM.Data.Model.ToDoMap;
using LOG.PropznetCRM.Data.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LOG.PropznetCRM.Data.UI.Areas.Api.Controllers
{
    public class FullCalenderApiController : CRMBaseController
    {
        readonly IToDoService _toDoService;
        readonly IToDoMapService _toDoMapService;
        static EntityType _entityType;
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

        public EntityType Index(string entityType)
        {
            if (entityType == "Lead")
                _entityType = EntityType.Lead;
            else if (entityType == "Account")
                _entityType = EntityType.Account;
            else if (entityType == "Agent")
                _entityType = EntityType.Agent;
            else if (entityType == "Contact")
                _entityType = EntityType.Contact;
            else if (entityType == "Potential")
                _entityType = EntityType.Potential;
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
                                                StartTime = t.ToDo.DueDate.DateTime,
                                                EndTime = t.ToDo.DueDate.DateTime,
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
                return View();
            },
            error => View());
        }
    }
}