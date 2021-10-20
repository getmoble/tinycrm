using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.ToDo;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IToDoRepository : IGenericRepository<CRMToDo>
    {
        SearchResult<CRMToDo> SearchToDo(ToDoSearchFilter filters, int pagesize, int page);
    }
}