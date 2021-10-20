using PropznetCommon.Features.ERP.DAL.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyChargeMapRepository : IPropertyChargeMapRepository
    {
        readonly ERPDataContext _dataContext;
        public PropertyChargeMapRepository(ERPDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreatePropertyChargeMap(PropertyChargeMap propertyChargeMap)
        {
            _dataContext.PropertyChargeMaps.Add(propertyChargeMap);
            return true;
        }

        public IList<long> GetAllChargeIdByPropertyId(long propertyId)
        {
            return _dataContext.PropertyChargeMaps
               .Where(i => i.PropertyId == propertyId)
               .OrderByDescending(x => x.CreatedOn)
               .Select(i => i.ChargeId).Distinct().ToList();
        }

        public IList<PropertyChargeMap> GetAllPropertyChargeMapByPropertyId(long propertyId)
        {
            return _dataContext.PropertyChargeMaps
                    .Where(i => i.PropertyId == propertyId)
                    .OrderByDescending(x => x.CreatedOn)
                    .Include(u => u.Charge).ToList();
        }

        public long GetPropertyIdByChargeId(long chargeId)
        {
            return _dataContext.PropertyChargeMaps
               .FirstOrDefault(i => i.ChargeId == chargeId).PropertyId;
        }

        public bool DeletePropertyChargeMap(long propertyId)
        {
            var propertyChargeMap = _dataContext.PropertyChargeMaps
                                   .Where(i => i.PropertyId == propertyId).ToList();
            foreach (PropertyChargeMap item in propertyChargeMap)
            {
                _dataContext.PropertyChargeMaps.Remove(item);
            }
            return true;
        }
    }
}