using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IManagerRoleService
    {
        IList<ManagerRole> GetAllManagerRoles();
    }
}
