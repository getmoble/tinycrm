using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.SaleInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.ERP.Services
{
    public class UnitSaleInfoService:IUnitSaleInfoService
    {
        readonly IUnitSaleInfoRepository _unitSaleInfoRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public UnitSaleInfoService(IUnitSaleInfoRepository unitSaleInfoRepository,
            IUnitOfWork iUnitOfWork)
        {
            _unitSaleInfoRepository = unitSaleInfoRepository;
        _iUnitOfWork=iUnitOfWork;
        }
        public UnitSaleInfo CreateUnitSaleInfo(UnitSaleInfoModel saleInfoModel)
        {
            var saleInfo = new UnitSaleInfo
            {
                EntityId = saleInfoModel.Id,
                EntityType = saleInfoModel.EntityType,
                CreatedBy = saleInfoModel.CreatedBy,
                ExpectedPrice = saleInfoModel.ExpectedPrice,
                SalesTerms= saleInfoModel.SalesTerms,
                UnitMeasurementUnit = saleInfoModel.UnitMeasurementUnit,
                CreatedOn = DateTime.UtcNow
            };
            var createdSaleInfo = _unitSaleInfoRepository.Create(saleInfo);
            return createdSaleInfo;
        }

        public UnitSaleInfo UpdateUnitSaleInfo(UnitSaleInfoModel saleInfoModel)
        {
            var saleInfo = _unitSaleInfoRepository.GetSaleInfo(saleInfoModel.Id);
            saleInfo.EntityId = saleInfoModel.EntityId;
            saleInfo.EntityType = saleInfoModel.EntityType;
            saleInfo.CreatedBy = saleInfoModel.CreatedBy;
            saleInfo.ExpectedPrice = saleInfoModel.ExpectedPrice;
            saleInfo.SalesTerms = saleInfoModel.SalesTerms;
            saleInfo.UnitMeasurementUnit = saleInfoModel.UnitMeasurementUnit;
            saleInfo.UpdatedOn = DateTime.UtcNow;
            _unitSaleInfoRepository.Update(saleInfo);
            return saleInfo;
        }

        public bool DeleteUnitSaleInfo(long id)
        {
            var result = _unitSaleInfoRepository.DeleteSaleInfo(id);
            return result;
        }

        public UnitSaleInfo GetUnitSaleInfo(long id)
        {
            return _unitSaleInfoRepository.GetSaleInfo(id);
        }
    }
}