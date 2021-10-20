using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PropznetCommon.Features.CRM.DAL.Data;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;

namespace PropznetCommon.Features.CRM.DAL
{
    public class ToDoMapRepository : IToDoMapRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public ToDoMapRepository(ICRMLiteDataContext context)
        {
            _dataContext = context;
        }
        public CRMToDoMap Create(CRMToDoMap toDoMap)
        {
            var createdToDoMap = _dataContext.CRMToDoMaps.Add(toDoMap);
            return createdToDoMap;
        }
        public IList<CRMToDoMap> GetToDosByUserId(long userId)
        {
            return _dataContext.CRMToDoMaps
                .Include("ToDos")
                .Where(i => i.CreatedByUserId == userId).ToList();
        }
        public IList<CRMToDoMap> GetAllToDoMapsByEntityTypeAndUserId(CRMEntityType entityType, long userId)
        {
            return _dataContext.CRMToDoMaps
                .Where(i => i.CreatedByUserId == userId && i.EntityType == entityType && !i.DeletedOn.HasValue)
                .Include(p => p.ToDo)                               
                               .ToList();
        }
        public bool Delete(long id)
        {
            var toDoMap = _dataContext.CRMToDoMaps.FirstOrDefault(i => i.Id == id);
            if (toDoMap != null)
            {
                //toDoMap.DeletedOn = DateTime.UtcNow;
                _dataContext.CRMToDoMaps.Remove(toDoMap);
                return true;
            }
            return false;
        }
    }
}