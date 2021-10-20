using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Home;
using PropznetCommon.Features.CRM.Model.Potential;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IPotentialRepository : IGenericRepository<Potential>
    {
        SearchResult<Potential> SearchPotential(PotentialSearchFilter filters, int pagesize, int count);
        Potential GetPotential(long id);
        int GetPotentialCountByUser(long userId);
        IList<BarChartModel> GetSalesByUserId(long userId);
        IList<Potential> GetAllPotentials(long userId, long agentId);
        IList<BarChartModel> GetAllSales();
        IList<Potential> GetAllPotentials();
        bool DeletePotential(long id);
    }
}