using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IManagerRoleRepository : IGenericRepository<ManagerRole>
    {
        IList<ManagerRole> GetAllManagerRoles();
    }
}
