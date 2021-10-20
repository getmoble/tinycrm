using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.SaleInfo;
using System;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertySaleInfoService : IPropertySaleInfoService
    {
        readonly IPropertySaleInfoRepository _saleInfoRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertySaleInfoService(IPropertySaleInfoRepository saleInfoRepository,
            IUnitOfWork iUnitOfWork)
        {
            _saleInfoRepository = saleInfoRepository;
        _iUnitOfWork=iUnitOfWork;
        }
        public PropertySaleInfo CreatePropertySaleInfo(PropertySaleInfoModel saleInfoModel)
        {
            var saleInfo = new PropertySaleInfo
            {
                EntityId = saleInfoModel.Id,
                EntityType = saleInfoModel.EntityType,
                CreatedBy = saleInfoModel.CreatedBy,
                ExpectedPrice = saleInfoModel.ExpectedPrice,
                SalesTerms= saleInfoModel.SalesTerms,
                PropertyMeasurementUnit = saleInfoModel.PropertyMeasurementUnit,
                CreatedOn = DateTime.UtcNow
            };
            var createdSaleInfo = _saleInfoRepository.Create(saleInfo);
            return createdSaleInfo;
        }
        public PropertySaleInfo UpdatePropertySaleInfo(PropertySaleInfoModel saleInfoModel)
        {
            var saleInfo = _saleInfoRepository.GetSaleInfo(saleInfoModel.Id);
            saleInfo.EntityId = saleInfoModel.EntityId;
            saleInfo.EntityType = saleInfoModel.EntityType;
            saleInfo.CreatedBy = saleInfoModel.CreatedBy;
            saleInfo.ExpectedPrice = saleInfoModel.ExpectedPrice;
            saleInfo.SalesTerms = saleInfoModel.SalesTerms;
            saleInfo.PropertyMeasurementUnit = saleInfoModel.PropertyMeasurementUnit;
            _saleInfoRepository.Update(saleInfo);
            return saleInfo;
        }
        public bool DeleteSaleInfo(long id)
        {
            var result = _saleInfoRepository.DeleteSaleInfo(id);
            return result;
        }
        public PropertySaleInfo GetSaleInfo(long id)
        {
            return _saleInfoRepository.GetSaleInfo(id);
        }
    }
}