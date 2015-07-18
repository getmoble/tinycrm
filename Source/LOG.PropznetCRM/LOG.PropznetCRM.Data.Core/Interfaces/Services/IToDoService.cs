using System.Collections.Generic;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.ToDo;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IToDoService
    {
        ToDo CreateToDo(ToDoModel toDoModel);
        bool UpdateToDo(ToDoModel toDoModel);
        ToDo GetToDo(long id);
        IList<ToDo> GetAllToDos();
        SearchResult<ToDo> Search(ToDoSearchFilter filters, int pageSize, int page);
        bool DeleteToDo(long id);
    }
}