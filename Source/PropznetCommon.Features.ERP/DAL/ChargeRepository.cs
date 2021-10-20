using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.DAL
{
    public class ChargeRepository : GenericRepository<Charge>, IChargeRepository
    {
        readonly IERPDataContext _dataContext;
        public ChargeRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public IList<Charge> GetAllCharges()
        {
            return _dataContext.Charges
                 .Where(i => !i.DeletedOn.HasValue)
                 .OrderByDescending(x => x.CreatedOn)
                 .Distinct().ToList();
        }
        public bool DeleteCharge(long chargeId)
        {
            var charge = _dataContext.Charges
                .FirstOrDefault(i => i.Id == chargeId);
            charge.DeletedOn = DateTime.UtcNow;
            return true;
        }
        public Charge GetChargeById(long chargeId)
        {
            return _dataContext.Charges
                 .OrderByDescending(x => x.CreatedOn)
                .FirstOrDefault(i=>i.Id==chargeId);
        }
    }
}