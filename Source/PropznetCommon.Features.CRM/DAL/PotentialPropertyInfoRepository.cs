using Common.Data;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.DAL
{
    public class PotentialPropertyInfoRepository : GenericRepository<PotentialPropertyInfo>, IPotentialPropertyInfoRepository
    {
        readonly ICRMDataContext _dataContext;
        public PotentialPropertyInfoRepository(ICRMDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public bool DeletePotentialPropertyInfo(long id)
        {
            var potentialPropertyInfo = _dataContext.PotentialPropertyInfos.FirstOrDefault(i => i.Id == id);
            if (potentialPropertyInfo != null)
            {
                potentialPropertyInfo.DeletedOn = DateTime.UtcNow;
            }
            return true;
        }
    }
}