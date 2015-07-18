using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;

namespace LOG.PropznetCRM.Data.Services
{
    public class PropertyCategoryService:IPropertyCategoryService
    {
        readonly IPropertyCategoryRepository _propertyCategoryRepository;

        public PropertyCategoryService(IPropertyCategoryRepository propertyCategoryRepository)
        {
            _propertyCategoryRepository = propertyCategoryRepository;
        }
        public IList<PropertyCategory> GetAllPropertyCategories()
        {
            return _propertyCategoryRepository.GetAllPropertyCategories();
        }
    }
}
