using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.CRM.DAL.Data;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;

namespace PropznetCommon.Features.CRM.DAL
{
    public class PropertyCategoryRepository : IPropertyCategoryRepository
    {
        readonly ICRMDataContext _dataContext;
        public PropertyCategoryRepository(ICRMDataContext context)
        {
            _dataContext = context;
        }
        public IList<PropertyCategory> GetAllPropertyCategories()
        {
            return _dataContext.PropertyCategories.ToList();
        }
    }
}
