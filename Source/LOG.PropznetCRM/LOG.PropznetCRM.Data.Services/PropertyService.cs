using Common.Data.Interfaces;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Property;
using System;

namespace LOG.PropznetCRM.Data.Services
{
    public class PropertyService:IPropertyService
    {
        readonly IPropertyRepository _propertyRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyService(IPropertyRepository propertyRepository, IUnitOfWork iUnitOfWork)
        {
            _propertyRepository = propertyRepository;
            _iUnitOfWork=iUnitOfWork;
        }
        public Property CreateProperty(PropertyModel propertyModel)
        {
            var property = new Property
            {
                Area = propertyModel.Area,
                BudgetFrom = propertyModel.BudgetFrom,
                BudgetTo = propertyModel.BudgetTo,
                Floor = propertyModel.Floor,
                LocationId = propertyModel.LocationId,
                PropertyCategoryId = propertyModel.PropertyCategoryId,
                PropertyType = propertyModel.PropertyType,
                StateId = propertyModel.StateId
            };
            _propertyRepository.Create(property);
            _iUnitOfWork.Commit();
            return property;
        }
        public Property UpdateProperty(PropertyModel propertyModel)
        {
            var property = _propertyRepository.GetBy(i => i.Id==propertyModel.Id);
                property.Area = propertyModel.Area;
                property.BudgetFrom = propertyModel.BudgetFrom;
                property.BudgetTo = propertyModel.BudgetTo;
                property.Floor = propertyModel.Floor;
                property.LocationId = property.LocationId;
                property.PropertyCategoryId = propertyModel.PropertyCategoryId;
                property.PropertyType = propertyModel.PropertyType;
                property.StateId = propertyModel.StateId;
                _propertyRepository.Update(property);
                _iUnitOfWork.Commit();
                return property;
        }
        public bool DeleteProperty(long id)
        {
            var property = _propertyRepository.GetBy(i => i.Id == id);
            property.DeletedOn = DateTime.Now;
            _propertyRepository.Update(property);
            _iUnitOfWork.Commit();
            return true;
        }
    }    
}
