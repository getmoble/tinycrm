using System.Collections.Generic;
using LOG.PropznetCRM.Data.Model.Home;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IReportService
    {
        IList<PieChartModel> GetLeadStatusByUserId(long userId);
        IList<BarChartModel> GetSalesByUserId(long userId);
        IList<PieChartModel> GetAllLeadStatus();
        IList<BarChartModel> GetAllSales();
    }
}
