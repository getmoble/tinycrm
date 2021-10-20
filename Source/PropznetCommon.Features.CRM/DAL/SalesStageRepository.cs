using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.CRM.DAL.Data;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;

namespace PropznetCommon.Features.CRM.DAL
{
    public class SalesStageRepository : ISalesStageRepository
    {
        readonly ICRMLiteDataContext _dataContext;
        public SalesStageRepository(ICRMLiteDataContext context)
        {
            _dataContext = context;
        }

        public IList<SalesStage> GetAllSalesStages()
        {
           return _dataContext.SalesStageMaster.ToList();
        }
    }
}
