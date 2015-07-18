using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Home;
using LOG.PropznetCRM.Data.Model.Potential;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
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
    }
}