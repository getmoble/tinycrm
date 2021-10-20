using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.DAL;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertyRentalCommissionService : IPropertyRentalCommissionService
    {
        readonly IPropertyRentalCommissionRepository _propertyRentalCommissionRepository;
        readonly IPropertyRentalCommissionMapRepository _propertyRentalCommissionMapRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyRentalCommissionService(IPropertyRentalCommissionRepository propertyRentalCommissionRepository,
            IPropertyRentalCommissionMapRepository propertyRentalCommissionMapRepository,
            IUnitOfWork iUnitOfWork)
        {
            _propertyRentalCommissionRepository = propertyRentalCommissionRepository;
            _propertyRentalCommissionMapRepository = propertyRentalCommissionMapRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public IList<PropertyRentalCommission> GetAllPropertyRentalCommissions()
        {
            return _propertyRentalCommissionRepository.GetAllPropertyRentalCommissions();
        }
        public IList<PropertyRentalCommission> GetAllPropertyRentalCommissionById(IList<long> propertyRentalCommissionsId)
        {
            return _propertyRentalCommissionRepository.GetAllPropertyRentalCommissionsById(propertyRentalCommissionsId);
        }
        public PropertyRentalCommission CreatePropertyRentalCommission(PropertyRentalCommissionModel propertyRentalCommissionModel)
        {
            var propertyRentalCommission = new PropertyRentalCommission
            {
               Amount=propertyRentalCommissionModel.Amount,
               ChargeId=propertyRentalCommissionModel.ChargeId,
               GLAccount=propertyRentalCommissionModel.GLAccount,
               Month=propertyRentalCommissionModel.Month,
               Type=propertyRentalCommissionModel.Type,
               CreatedOn=DateTime.UtcNow
            };
            var createdPropertyRentalCommission = _propertyRentalCommissionRepository.Create(propertyRentalCommission);
            _iUnitOfWork.Commit();
            return createdPropertyRentalCommission;
        }
        public PropertyRentalCommission UpdatePropertyRentalCommission(PropertyRentalCommissionModel propertyRentalCommissionModel)
        {
            var propertyRentalCommission = _propertyRentalCommissionRepository.Get(propertyRentalCommissionModel.Id);
            propertyRentalCommission.Amount = propertyRentalCommissionModel.Amount;
            propertyRentalCommission.ChargeId = propertyRentalCommissionModel.ChargeId;
            propertyRentalCommission.GLAccount = propertyRentalCommissionModel.GLAccount;
            propertyRentalCommission.Month = propertyRentalCommissionModel.Month;
            propertyRentalCommission.Type = propertyRentalCommissionModel.Type;
            propertyRentalCommission.UpdatedOn = DateTime.UtcNow;
            _propertyRentalCommissionRepository.Update(propertyRentalCommission);
            return propertyRentalCommission;
        }
        public bool DeletePropertyRentalCommission(long id)
        {
            var result = _propertyRentalCommissionRepository.DeletePropertyRentalCommission(id);
            _iUnitOfWork.Commit();
            return result;
        }
        public bool DeleteAllPropertyRentalCommissionByPropertyId(long propertyId)
        {
            IList<long> propertyRentalCommissionIds = _propertyRentalCommissionMapRepository.GetAllPropertyRentalCommissionIdByPropertyId(propertyId);
            foreach (long propertyRentalCommissionId in propertyRentalCommissionIds)
            {
                DeletePropertyRentalCommission(propertyRentalCommissionId);
            }
            return true;
        }
    }
}