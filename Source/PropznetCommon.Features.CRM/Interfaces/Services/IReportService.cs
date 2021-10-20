using System.Collections.Generic;
using PropznetCommon.Features.CRM.Model.Home;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IReportService
    {
        IList<PieChartModel> GetLeadStatusByUserId(long userId);
        IList<BarChartModel> GetSalesByUserId(long userId);
        IList<PieChartModel> GetAllLeadStatus();
        IList<BarChartModel> GetAllSales();
    }
}
