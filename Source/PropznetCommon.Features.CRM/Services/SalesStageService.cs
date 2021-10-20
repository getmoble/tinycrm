using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;

namespace PropznetCommon.Features.CRM.Services
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