using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Model.Home;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.Services
{
    public class ReportService : IReportService
    {
        readonly ILeadRepository _leadRepository;
        readonly IPotentialRepository _potentialRepository;

        public ReportService(ILeadRepository leadRepository,
                             IPotentialRepository potentialRepository)
        {
            _leadRepository = leadRepository;
            _potentialRepository = potentialRepository;
        }
        public IList<PieChartModel> GetLeadStatusByUserId(long userId)
        {
            return _leadRepository.GetLeadStatusByUserId(userId);
        }
        public IList<BarChartModel> GetSalesByUserId(long userId)
        {
            return _potentialRepository.GetSalesByUserId(userId).ToList();
        }
        public IList<PieChartModel> GetAllLeadStatus()
        {
            return _leadRepository.GetAllLeadStatus();
        }

        public IList<BarChartModel> GetAllSales()
        {
            return _potentialRepository.GetAllSales();
        }
    }
}
