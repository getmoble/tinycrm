using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class ToDoMapRepository : IToDoMapRepository
    {
        readonly DataContext _dataContext;
        public ToDoMapRepository(DataContext context)
        {
            _dataContext = context;
        }
        public ToDoMap Create(ToDoMap toDoMap)
        {
            var createdToDoMap = _dataContext.ToDoMaps.Add(toDoMap);
            return createdToDoMap;
        }

        public IList<ToDoMap> GetToDosByUserId(long userId)
        {
            return _dataContext.ToDoMaps
                .Include("ToDos")
                .Where(i => i.CreatedBy == userId).ToList();
        }
        public IList<ToDoMap> GetAllToDoMapsByEntityTypeAndUserId(EntityType entityType, long userId)
        {
            return _dataContext.ToDoMaps.Include(p => p.ToDo)
                               .Where(i => i.CreatedBy == userId && i.EntityType == entityType && !i.DeletedOn.HasValue)
                               .ToList();
        }
        public bool Delete(long id)
        {
            var toDoMap = _dataContext.ToDoMaps.FirstOrDefault(i => i.Id == id);
            if (toDoMap != null)
            {
                toDoMap.DeletedOn = DateTimeOffset.UtcNow;
                return true;
            }

            return false;
        }
    }
}
