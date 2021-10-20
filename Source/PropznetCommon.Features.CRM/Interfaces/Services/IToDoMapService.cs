using System.Collections.Generic;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Model.ToDoMap;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IToDoMapService
    {
        CRMToDoMap CreateToDoMap(ToDoMapModel toDOMapModel);
        IList<CRMToDoMap> GetToDosByUserId(long userId, IList<int> permissionCodes);
        IList<CRMToDoMap> GetAllToDoMapsByEntityTypeAndUserId(CRMEntityType entityType, long userId);
        bool DeleteTodoMap(long id);
    }
}
