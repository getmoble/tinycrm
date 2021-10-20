using System;
using System.Linq;
using Common.Data;
using Common.Data.Models;
using PropznetCommon.Features.CRM.DAL.Data;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Model.ToDo;

namespace PropznetCommon.Features.CRM.DAL
{
    public class ToDoRepository: GenericRepository<CRMToDo>, IToDoRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public ToDoRepository(ICRMLiteDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public SearchResult<CRMToDo> SearchToDo(ToDoSearchFilter searchargument, int pagesize, int count)
        {
            var result = new SearchResult<CRMToDo>();
            IQueryable<CRMToDo> query = _dataContext.CRMToDos;
            if (!String.IsNullOrEmpty(searchargument.Title))
                query = query.Where(p => p.Title.Contains(searchargument.Title));

            if (searchargument.DueDate!=null)
                query = query.Where(p => p.DueDate.Equals(searchargument.DueDate));

            result.Items = query.OrderBy(p => p.DueDate)
                                .Skip(pagesize * count)
                                .Take(count).ToList();

            
            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pagesize, 1, query.Count());
            return result;
        }
        public bool DeleteTodo(long id)
        {
            var toDo = _dataContext.CRMToDos
                                        .FirstOrDefault(i => i.Id == id);
            if (toDo != null)
            {
                _dataContext.CRMToDos.Remove(toDo);
                //contact.DeletedOn = DateTime.UtcNow;
                return true;
            }
            return false;
        }
    }
}