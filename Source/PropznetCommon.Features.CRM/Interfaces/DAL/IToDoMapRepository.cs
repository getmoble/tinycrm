using System.Collections.Generic;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IToDoMapRepository
    {
        CRMToDoMap Create(CRMToDoMap toDoMap);
        IList<CRMToDoMap> GetToDosByUserId(long userId);
        IList<CRMToDoMap> GetAllToDoMapsByEntityTypeAndUserId(CRMEntityType entityType, long userId);
        bool Delete(long id);
    }
}
