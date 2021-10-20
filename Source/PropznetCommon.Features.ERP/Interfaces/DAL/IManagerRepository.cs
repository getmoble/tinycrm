using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IManagerRepository : IGenericRepository<Manager>
    {
        IList<Manager> GetAllManagers();
        IList<Manager> GetAllManagersById(IList<long> managerId);
        Manager GetManager(long managerId);
        bool DeleteManager(long portfolioId);
    }
}