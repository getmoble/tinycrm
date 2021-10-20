using System.Collections.Generic;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Manager;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface IManagerService
    {
        IList<Manager> GetAllManagers();
        IList<Manager> GetAllManagersById(IList<long> managerId);
        Manager GetManagerById(long ManagerId);
        Manager CreateManager(ManagerModel ManagerModel);
        Manager UpdateManager(ManagerModel ManagerModel);
        bool DeleteManager(long ManagerId);
        SearchResult<Manager> SearchManagers(ManagerSearchFilter searchargument, int pagesize, int count, long userId);
    }
}