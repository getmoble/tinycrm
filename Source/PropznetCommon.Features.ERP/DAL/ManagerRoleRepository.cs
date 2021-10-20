using System.Collections.Generic;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class ManagerRoleRepository : GenericRepository<ManagerRole>, IManagerRoleRepository
    {
        readonly IERPDataContext _dataContext;
        public ManagerRoleRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public IList<ManagerRole> GetAllManagerRoles()
        {
            return _dataContext.ManagerRoles
                .Where(i => !i.DeletedOn.HasValue).ToList();
        }
    }
}
