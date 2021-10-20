using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.DAL;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Services
{
    public class UnitRentalCommissionService : IUnitRentalCommissionService
    {
        readonly IUnitRentalCommissionRepository _unitRentalCommissionRepository;
        readonly IUnitRentalCommissionMapRepository _unitRentalCommissionMapRepository;
        readonly IUnitOfWork _unitOfWork;
        public UnitRentalCommissionService(IUnitRentalCommissionRepository unitRentalCommissionRepository,
            IUnitRentalCommissionMapRepository unitRentalCommissionMapRepository,
            IUnitOfWork unitOfWork)
        {
            _unitRentalCommissionRepository = unitRentalCommissionRepository;
            _unitRentalCommissionMapRepository = unitRentalCommissionMapRepository;
            _unitOfWork = unitOfWork;
        }
        public IList<UnitRentalCommission> GetAllUnitRentalCommissions()
        {
            return _unitRentalCommissionRepository.GetAllUnitRentalCommissions();
        }
        public IList<UnitRentalCommission> GetAllUnitRentalCommissionById(IList<long> unitRentalCommissionsId)
        {
            return _unitRentalCommissionRepository.GetAllUnitRentalCommissionsById(unitRentalCommissionsId);
        }
        public UnitRentalCommission CreateUnitRentalCommission(UnitRentalCommissionModel unitRentalCommissionModel)
        {
            var unitRentalCommission = new UnitRentalCommission
            {
                Amount = unitRentalCommissionModel.Amount,
                ChargeId = unitRentalCommissionModel.ChargeId,
                GLAccount = unitRentalCommissionModel.GLAccount,
                Month = unitRentalCommissionModel.Month,
                Type = unitRentalCommissionModel.Type,
                CreatedOn = DateTime.UtcNow
            };
            var createdUnitRentalCommission = _unitRentalCommissionRepository.Create(unitRentalCommission);
            _unitOfWork.Commit();
            return createdUnitRentalCommission;
        }
        public UnitRentalCommission UpdateUnitRentalCommission(UnitRentalCommissionModel unitRentalCommissionModel)
        {
            var unitRentalCommission = _unitRentalCommissionRepository.Get(unitRentalCommissionModel.Id);
            unitRentalCommission.Amount = unitRentalCommissionModel.Amount;
            unitRentalCommission.ChargeId = unitRentalCommissionModel.ChargeId;
            unitRentalCommission.GLAccount = unitRentalCommissionModel.GLAccount;
            unitRentalCommission.Month = unitRentalCommissionModel.Month;
            unitRentalCommission.Type = unitRentalCommissionModel.Type;
            unitRentalCommission.UpdatedOn = DateTime.UtcNow;
            _unitRentalCommissionRepository.Update(unitRentalCommission);
            return unitRentalCommission;
        }
        public bool DeleteUnitRentalCommission(long id)
        {
            var result = _unitRentalCommissionRepository.DeleteUnitRentalCommission(id);
            _unitOfWork.Commit();
            return result;
        }
        public bool DeleteAllUnitRentalCommissionByUnitId(long unitId)
        {
            IList<long> unitRentalCommissionIds = _unitRentalCommissionMapRepository.GetAllUnitRentalCommissionIdByUnitId(unitId);
            foreach (long unitRentalCommissionId in unitRentalCommissionIds)
            {
                DeleteUnitRentalCommission(unitRentalCommissionId);
            }
            return true;
        }
    }
}
