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
    public class PropertyRentalCommissionRepository : GenericRepository<PropertyRentalCommission>, IPropertyRentalCommissionRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyRentalCommissionRepository(IERPDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public IList<PropertyRentalCommission> GetAllPropertyRentalCommissions()
        {
            return _dataContext.PropertyRentalCommissions
                .Include(i => i.Charge)
                .OrderByDescending(x => x.CreatedOn).ToList();
        }

        public IList<PropertyRentalCommission> GetAllPropertyRentalCommissionsById(IList<long> propertyRentalCommissionsId)
        {
            return _dataContext.PropertyRentalCommissions
                        .OrderByDescending(x => x.CreatedOn)
                        .Where(i => propertyRentalCommissionsId.Contains(i.Id)).ToList();
        }

        public PropertyRentalCommission GetPropertyRentalCommission(long id)
        {
            return _dataContext.PropertyRentalCommissions
                               .SingleOrDefault(i => i.Id == id);
        }

        public bool DeletePropertyRentalCommission(long id)
        {
            var propertyRentalCommission = _dataContext.PropertyRentalCommissions.FirstOrDefault(i => i.Id == id);
            if (propertyRentalCommission != null)
            {
                propertyRentalCommission.DeletedOn = DateTime.UtcNow;
            }
            return true;
        }
    }
}
