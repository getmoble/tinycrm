using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class PropertyCategoryRepository : IPropertyCategoryRepository
    {
        readonly DataContext _dataContext;
        public PropertyCategoryRepository(DataContext context)
        {
            _dataContext = context;
        }
        public IList<PropertyCategory> GetAllPropertyCategories()
        {
            return _dataContext.PropertyCategories.ToList();
        }
    }
}
