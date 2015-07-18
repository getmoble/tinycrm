using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.ToDo;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
{
    public interface IToDoRepository : IGenericRepository<ToDo>
    {
        SearchResult<ToDo> SearchToDo(ToDoSearchFilter filters, int pagesize, int page);
    }
}