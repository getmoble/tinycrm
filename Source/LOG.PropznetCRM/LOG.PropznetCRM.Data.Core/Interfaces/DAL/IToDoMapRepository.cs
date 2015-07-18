using System.Collections.Generic;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Entities.Enum;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
{
    public interface IToDoMapRepository
    {
        ToDoMap Create(ToDoMap toDoMap);
        IList<ToDoMap> GetToDosByUserId(long userId);
        IList<ToDoMap> GetAllToDoMapsByEntityTypeAndUserId(EntityType entityType, long userId);
        bool Delete(long id);
    }
}
