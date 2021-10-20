using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PropznetCommon.Features.ERP.DAL
{
    public class UnitRentalCommissionRepository : GenericRepository<UnitRentalCommission>, IUnitRentalCommissionRepository
    {
        readonly IERPDataContext _dataContext;
        public UnitRentalCommissionRepository(IERPDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<UnitRentalCommission> GetAllUnitRentalCommissions()
        {
            return _dataContext.UnitRentalCommissions
                .Include(i => i.Charge).ToList();
        }
        public IList<UnitRentalCommission> GetAllUnitRentalCommissionsById(IList<long> unitRentalCommissionsId)
        {
            return _dataContext.UnitRentalCommissions
                        .Where(i => unitRentalCommissionsId.Contains(i.Id)).ToList();
        }
        public UnitRentalCommission GetUnitRentalCommission(long id)
        {
            return _dataContext.UnitRentalCommissions
                               .SingleOrDefault(i => i.Id == id);
        }
        public bool DeleteUnitRentalCommission(long id)
        {
            var unitRentalCommission = _dataContext.UnitRentalCommissions.FirstOrDefault(i => i.Id == id);
            if (unitRentalCommission != null)
            {
                unitRentalCommission.DeletedOn = DateTime.UtcNow;
            }
            return true;
        }
    }
}