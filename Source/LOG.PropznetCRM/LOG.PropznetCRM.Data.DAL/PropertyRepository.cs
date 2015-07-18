﻿using Common.Data;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;

namespace LOG.PropznetCRM.Data.DAL
{
    public class PropertyRepository: GenericRepository<Property>, IPropertyRepository
    {
        DataContext _dataContext;
        public PropertyRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
