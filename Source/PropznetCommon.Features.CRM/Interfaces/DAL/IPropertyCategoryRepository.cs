using System.Collections.Generic;
using PropznetCommon.Features.CRM.Entities;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IPropertyCategoryRepository
    {
        IList<PropertyCategory> GetAllPropertyCategories();
    }
}
