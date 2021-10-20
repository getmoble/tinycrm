using System.Collections.Generic;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.Property;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface IPropertyRepository : IGenericRepository<ERPProperty>
    {
        IList<ERPProperty> GetAllProperties();
        IList<ERPProperty> GetAllPropertiesById(IList<long> propertyId);
        ERPProperty GetAllPropertiesById(long propertyId);
        bool DeleteProperty(long id);
        SearchResult<ERPProperty> SearchProperty(PropertySearchFilter searchargument, int pagesize, int count);
    }
}