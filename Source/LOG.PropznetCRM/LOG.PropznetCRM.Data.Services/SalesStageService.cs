using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.Services
{
    public class SalesStageService : ISalesStageService
    {
        readonly ISalesStageRepository _salesStageRepository;

        public SalesStageService(ISalesStageRepository salesStageRepository)
        {
            _salesStageRepository = salesStageRepository;
        }
        public IList<SalesStage> GetAllSalesStages()
        {
            return _salesStageRepository.GetAllSalesStages().ToList();
        }
    }
}