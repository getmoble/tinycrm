using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;

namespace PropznetCommon.Features.ERP.Services
{
    public class UnitTypeService : IUnitTypeService
    {
        readonly IUnitTypeRepository _unitTypeRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public UnitTypeService(
            IUnitTypeRepository unitTypeRepository,
            IUnitOfWork iUnitOfWork)
        {
            _unitTypeRepository = unitTypeRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public UnitType CreateUnitType(string name)
        {
            var unityType = new UnitType
            {
                Name = name
            };
            _unitTypeRepository.Create(unityType);
            _iUnitOfWork.Commit();
            return unityType;
        }
        public IList<UnitType> GetAllUnitType()
        {
            return _unitTypeRepository.GetAll();
        }
    }
}
