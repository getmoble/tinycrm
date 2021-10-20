using System.Collections.Generic;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;

namespace PropznetCommon.Features.CRM.Services
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
