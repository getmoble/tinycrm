using System.Collections.Generic;
using System.Linq;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;

namespace PropznetCommon.Features.ERP.Services
{
    public class ManagerRoleService : IManagerRoleService
    {
        readonly IManagerRoleRepository _managerRoleRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public ManagerRoleService(IManagerRoleRepository managerRoleRepository, IUnitOfWork iUnitOfWork)
        {
            _managerRoleRepository = managerRoleRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public IList<ManagerRole> GetAllManagerRoles()
        {
            return _managerRoleRepository.GetAllManagerRoles().ToList();
        }
    }
}
