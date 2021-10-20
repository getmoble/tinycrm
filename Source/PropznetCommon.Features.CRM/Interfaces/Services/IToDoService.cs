using System.Collections.Generic;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.ToDo;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IToDoService
    {
        CRMToDo CreateToDo(ToDoModel toDoModel);
        bool UpdateToDo(ToDoModel toDoModel);
        CRMToDo GetToDo(long id);
        IList<CRMToDo> GetAllToDos();
        SearchResult<CRMToDo> Search(ToDoSearchFilter filters, int pageSize, int page);
        bool DeleteToDo(long id);
    }
}