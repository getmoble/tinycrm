using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Data;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Model.Property;

namespace PropznetCommon.Features.ERP.DAL
{
    public class PropertyRepository : GenericRepository<ERPProperty>, IPropertyRepository
    {
        readonly IERPDataContext _dataContext;
        public PropertyRepository(IERPDataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public IList<ERPProperty> GetAllProperties()
        {
            return _dataContext.ERPProperties
                .Where(j => !j.DeletedOn.HasValue)
                .OrderByDescending(x => x.CreatedOn)
                .Include(u => u.CommunicationDetails)
                .Include(u => u.CommunicationDetails.Country)
                .Include(i => i.RentMarketingInformation)
                .Include(i => i.SaleMarketingInformation)
                .Include(k => k.Portfolio)
                .Include(m => m.SaleInfo)
                .Include(n => n.User)
                .ToList();
        }
        public IList<ERPProperty> GetAllPropertiesById(IList<long> propertyId)
        {
            return _dataContext.ERPProperties
                .Where(j => !j.DeletedOn.HasValue && propertyId.Contains(j.Id))
                .OrderByDescending(x => x.CreatedOn)
                .Include(u => u.CommunicationDetails)
                .Include(p => p.CommunicationDetails.Country)
                .Include(i => i.RentMarketingInformation)
                .Include(i => i.SaleMarketingInformation)
                .Include(k => k.Portfolio)
                .Include(m => m.SaleInfo)
                .Include(n => n.User)
                .ToList();
        }
        public ERPProperty GetAllPropertiesById(long propertyId)
        {
            return _dataContext.ERPProperties
                .Include(u => u.CommunicationDetails)
                .Include(p => p.CommunicationDetails.Country)
                .Include(i => i.RentMarketingInformation)
                .Include(i => i.SaleMarketingInformation)
                .Include(k => k.Portfolio)
                .Include(m => m.SaleInfo)
                .Include(n => n.User)
                .FirstOrDefault(i => i.Id == propertyId);
        }
        public bool DeleteProperty(long id)
        {
            var property = _dataContext.ERPProperties
                .FirstOrDefault(i => i.Id == id);
            property.DeletedOn = DateTime.UtcNow;
            return true;
        }
        public SearchResult<ERPProperty> SearchProperty(PropertySearchFilter searchargument, int pagesize, int count)
        {
            throw new NotImplementedException();
        }
    }
}