using System.Collections.Generic;
using PropznetCommon.Features.CRM.Entities;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface ISalesStageService
    {
        IList<SalesStage> GetAllSalesStages();
    }
}
