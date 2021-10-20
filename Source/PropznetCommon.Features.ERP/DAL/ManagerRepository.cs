using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {
        readonly IERPDataContext _dataContext;
        public ManagerRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public IList<Manager> GetAllManagers()
        {
            var managers = _dataContext.Managers
                .Where(i => !i.DeletedOn.HasValue)
                .Include(u => u.Person)
                .Include(h => h.Person.Country)
                .Include(k => k.ManagerRole)
                .OrderByDescending(x => x.CreatedOn)
                .ToList();

            return managers;
        }
        public IList<Manager> GetAllManagersById(IList<long> managerId)
        {
            return _dataContext.Managers
                .Where(i => managerId.Contains(i.Id))
                .OrderByDescending(x => x.CreatedOn)
                .Include(u => u.Person)
                .Include(h => h.Person.Country)
                .Include(k => k.ManagerRole)
                .ToList();
        }
        public Manager GetManager(long managerId)
        {
            return _dataContext.Managers
                .Include(u => u.Person)
                .Include(k => k.ManagerRole)
                .Include(h => h.Person.Country)
                .FirstOrDefault(i => i.Id == managerId);
        }
        public bool DeleteManager(long managerId)
        {
            var owner = _dataContext.Managers
                .FirstOrDefault(i => i.Id == managerId);
            owner.DeletedOn = DateTime.UtcNow;
            return true;
        }
    }
}