using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Charge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Services
{
    public class ChargeService : IChargeService
    {
        readonly IChargeRepository _chargeRepository;
        readonly IUnitOfWork _unitOfWork;
        public ChargeService(IChargeRepository chargeRepository,
            IUnitOfWork unitOfWork)
        {
            _chargeRepository = chargeRepository;
            _unitOfWork = unitOfWork;
        }
        public Charge CreateCharge(ChargeModel chargeModel)
        {
            var charge = new Charge
            {
                Name=chargeModel.ChargeName,
                Type = chargeModel.ChargeType,
                CreatedOn=DateTime.UtcNow
            };
           var createdCharge= _chargeRepository.Create(charge);
           _unitOfWork.Commit();
           return createdCharge;
        }
        public IList<Charge> GetAllCharge()
        {
           return _chargeRepository.GetAllCharges();
        }
        public Charge GetChargeById(long chargeId)
        {
            return _chargeRepository.GetChargeById(chargeId);
        }
        public bool DeleteCharge(long id)
        {
            var result= _chargeRepository.DeleteCharge(id);
            _unitOfWork.Commit();
            return result;
        }
    }
}