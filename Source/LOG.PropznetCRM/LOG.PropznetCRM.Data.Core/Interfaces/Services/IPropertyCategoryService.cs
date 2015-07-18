﻿using System.Collections.Generic;
using LOG.PropznetCRM.Data.Entities;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IPropertyCategoryService
    {
        IList<PropertyCategory> GetAllPropertyCategories();
    }
}
