using Common.Data;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.ToDo;
using System;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class ToDoRepository: GenericRepository<ToDo>, IToDoRepository
    {
        readonly DataContext _dataContext;
        public ToDoRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public SearchResult<ToDo> SearchToDo(ToDoSearchFilter searchargument, int pagesize, int count)
        {
            var result = new SearchResult<ToDo>();
            IQueryable<ToDo> query = _dataContext.ToDos;
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
    }
}
