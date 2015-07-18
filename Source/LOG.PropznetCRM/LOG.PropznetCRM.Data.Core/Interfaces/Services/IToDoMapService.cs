using System.Collections.Generic;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Entities.Enum;
using LOG.PropznetCRM.Data.Model.ToDoMap;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IToDoMapService
    {
        ToDoMap CreateToDoMap(ToDoMapModel toDOMapModel);
        IList<ToDoMap> GetToDosByUserId(long userId, IList<int> permissionCodes);
        IList<ToDoMap> GetAllToDoMapsByEntityTypeAndUserId(EntityType entityType, long userId);
        bool DeleteTodoMap(long id);
    }
}
