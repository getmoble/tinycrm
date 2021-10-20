using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.DAL;
using Common.Data;
using PropznetCommon.Features.CRM.DAL.Data;
using PropznetCommon.Features.CRM.Interfaces.Data;

namespace PropznetCommon.Features.CRM.DAL
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        readonly ICRMLiteDataContext _context;
        public RoleRepository(ICRMLiteDataContext context)
            : base(context)
        {
            _context = context;
        }

        public Common.Auth.SingleTenant.Models.RolesWithPermissionViewModel GetRoleWithPermissionByRoleId(long id)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IList<Common.Auth.SingleTenant.Models.RolesWithPermissionViewModel> GetRolesWithPermission()
        {
            throw new System.NotImplementedException();
        }
    }
}