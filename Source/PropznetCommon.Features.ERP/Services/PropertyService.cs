using System;
using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.CommunicationDetail;
using PropznetCommon.Features.ERP.Model.Property;
using PropznetCommon.Features.ERP.Model.RentInfo;
using PropznetCommon.Features.ERP.Model.SaleInfo;

namespace PropznetCommon.Features.ERP.Services
{
    public class PropertyService : IPropertyService
    {
        readonly ICommunicationDetailService _communicationDetailService;
        readonly ICommunicationDetailRepository _communicationDetailRepository;
        readonly IPropertyRepository _propertyRepository;
        readonly IPropertyRentInfoService _rentInfoService;
        readonly IPropertyRentInfoMapService _propertyRentInfoMapService;
        readonly IPropertyRentInfoRepository _rentInfoRepository;
        readonly IPropertySaleInfoService _propertySaleInfoService;
        readonly IPropertySaleInfoRepository _propertySaleInfoRepository;
        readonly IUnitOfWork _iUnitOfWork;
        public PropertyService(ICommunicationDetailService communicationDetailService,
            ICommunicationDetailRepository communicationDetailRepository,
            IPropertyRentInfoRepository rentInfoRepository,
            IPropertyRentInfoMapService propertyRentInfoMapService,
            IPropertySaleInfoRepository propertySaleInfoRepository,
            IPropertyRentInfoService rentInfoService,
            IPropertySaleInfoService propertySaleInfoService,
            IUnitOfWork iUnitOfWork,
            IPropertyRepository propertyRepository)
        {
            _communicationDetailService = communicationDetailService;
            _propertyRepository = propertyRepository;
            _rentInfoService = rentInfoService;
            _propertyRentInfoMapService = propertyRentInfoMapService;
            _propertySaleInfoService = propertySaleInfoService;
            _communicationDetailRepository = communicationDetailRepository;
            _rentInfoRepository = rentInfoRepository;
            _propertySaleInfoRepository = propertySaleInfoRepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public ERPProperty CreateProperty(PropertyModel propertyModel)
        {
            long rentInfoId = 0;
            long saleInfoId = 0;
            var communicationDetailModel = new CommunicationDetailModel
            {
                Address = propertyModel.Address,
                Area = propertyModel.Area,
                CountryId = propertyModel.CountryId,
                Latitude = propertyModel.Latitude,
                Longitude = propertyModel.Longitude,
                State = propertyModel.State,
                City=propertyModel.City,
                Zip = propertyModel.Zip
            };
            var createdCommuncationDetail = _communicationDetailService.CreateCommunicationDetail(communicationDetailModel);
            _iUnitOfWork.Commit();

            if (propertyModel.IsSale)
            {
                var saleInfoModel = new PropertySaleInfoModel
                {
                    CreatedBy = propertyModel.CreatedBy,
                    ExpectedPrice = propertyModel.ExpectedPrice,
                    PropertyMeasurementUnit = propertyModel.SalePriceMeasurementUnit,
                    SalesTerms = propertyModel.SalesTemrs,
                    GLAccount=propertyModel.GLAccount,
                    HasSaleCommission=propertyModel.HasSaleCommission,
                    SaleCommissionAmount=propertyModel.SaleCommissionAmount,
                    SalesCommissionType=propertyModel.SalesCommissionType                    
                };
                var saleInfo = _propertySaleInfoService.CreatePropertySaleInfo(saleInfoModel);
                _iUnitOfWork.Commit();
                saleInfoId = saleInfo.Id;
            }
            var property = new ERPProperty
            {
                BuildUpArea = propertyModel.BuildUpArea,
                MeasurementUnitForBuiltupArea = propertyModel.SalePriceMeasurementUnit,
                CommunicationDetailId = createdCommuncationDetail.Id,
                ContractEndDate = propertyModel.ContractEndDate,
                ContractStartDate = propertyModel.ContractStartDate,
                CreatedBy = propertyModel.CreatedBy,
                Description = propertyModel.Description,
                Floor = propertyModel.Floor,
                FloorNumber=propertyModel.FloorNumber,
                ListedBy = propertyModel.ListedBy,
                IsMultipleUnit = propertyModel.MultipleUnit,
                PortfolioId = propertyModel.PortfolioId,
                IsForRent = propertyModel.IsRent,
                IsForSale = propertyModel.IsSale,
                Name = propertyModel.PropertyName,
                PropertyType = propertyModel.PropertyType,
                Vaccancy = propertyModel.Vaccancy,
                TotalArea = propertyModel.TotalArea,
                MeasurementUnitForTotalArea = propertyModel.TotalAreaMeasurementUnit,
                UsageType = propertyModel.UsageType,
                Parking=propertyModel.IsParking,
                NoOfParkingAvailable = propertyModel.NoOfParkingAvailable,
                Furnished = propertyModel.FurnishType,
                HasLeasingTax=propertyModel.IsLeasingTax,
                HasManagementCommission=propertyModel.IsManagementCommission,
                HasRentalCommission=propertyModel.IsRentalCommission,
                RentAvailablity=propertyModel.RentAvailable,
                HasSalesCommission=propertyModel.HasSaleCommission
            };

            //if (propertyModel.IsRent)
            //    property.RentInfoId = rentInfoId;

            if (propertyModel.IsSale)
                property.SaleInfoId = saleInfoId;

            int propertyType=(int)propertyModel.PropertyType;

            if (propertyType==0)
            {
                property.NoOfBed = propertyModel.Bed;
                property.NoOfBath = propertyModel.Bath;
            }
                

            var createdProperty = _propertyRepository.Create(property);
            _iUnitOfWork.Commit();
            IList<long> rentInfoIds = new List<long>();
            if (propertyModel.IsRent)
            {
                if (propertyModel.RentInfoModels != null)
                {
                    foreach (RentInfoModel rentInfoModel in propertyModel.RentInfoModels)
                    {
                        var newRentInfoModel = new RentInfoModel
                        {
                            CreatedBy = rentInfoModel.CreatedBy,
                            Amount = rentInfoModel.Amount,
                            ChargeId = rentInfoModel.ChargeId,
                            Month = rentInfoModel.Month,
                            Supress = rentInfoModel.Supress
                        };
                        var createdRentInfo = _rentInfoService.CreateRentInfo(newRentInfoModel);
                        _iUnitOfWork.Commit();
                        rentInfoIds.Add(createdRentInfo.Id);
                    }
                }
            }
            if(rentInfoIds!=null)
            {
                var propertyRentInfoMapModel=new PropertyRentInfoMapModel{
                    PropertyId=createdProperty.Id,
                    RentInfoIds=rentInfoIds
                };
                _propertyRentInfoMapService.CreatePropertyRentInfoMap(propertyRentInfoMapModel);
                _iUnitOfWork.Commit();
            }
            
            return createdProperty;
        }
        public IList<ERPProperty> GetAllProperties()
        {
            return _propertyRepository.GetAllProperties();
        }
        public IList<ERPProperty> GetAllPropertiesById(IList<long> id)
        {
            return _propertyRepository.GetAllPropertiesById(id);
        }
        public ERPProperty GetPropertyById(long id)
        {
            return _propertyRepository.GetAllPropertiesById(id);
        }
        public bool UpdateProperty(PropertyModel propertyModel)
        {
            //long rentInfoId = 0;
            long saleInfoId = 0;
            var communicationDetail = _communicationDetailService.GetCommunicationDetail(propertyModel.CommunicationDetailId);
            communicationDetail.Address = propertyModel.Address;
            communicationDetail.Area = propertyModel.Area;
            communicationDetail.CountryId = propertyModel.CountryId;
            communicationDetail.State = propertyModel.State;
            communicationDetail.City = propertyModel.City;
            communicationDetail.Latitude = propertyModel.Latitude;
            communicationDetail.Longitude = propertyModel.Longitude;
            communicationDetail.Zip = propertyModel.Zip;
            _communicationDetailRepository.Update(communicationDetail);
            _iUnitOfWork.Commit();           

            if (propertyModel.IsSale)
            {
                var saleInfo = _propertySaleInfoService.GetSaleInfo(propertyModel.SaleId);
                saleInfo.ExpectedPrice = propertyModel.ExpectedPrice;
                saleInfo.PropertyMeasurementUnit = propertyModel.SalePriceMeasurementUnit;                
                saleInfo.HasSaleCommission=propertyModel.HasSaleCommission;
                saleInfo.GLAccount=propertyModel.GLAccount;
                saleInfo.SalesCommissionType=propertyModel.SalesCommissionType;
                saleInfo.SaleCommissionAmount = propertyModel.SaleCommissionAmount;
                saleInfo.UpdatedOn = DateTime.UtcNow;
                _propertySaleInfoRepository.Update(saleInfo);
                _iUnitOfWork.Commit();
                saleInfoId = saleInfo.Id;
            }

            var property = _propertyRepository.GetAllPropertiesById(propertyModel.Id);
            property.BuildUpArea = propertyModel.BuildUpArea;
            property.MeasurementUnitForBuiltupArea = propertyModel.BuildUpAreaMeasurementUnit;
            property.CommunicationDetailId = communicationDetail.Id;
            property.ContractEndDate = propertyModel.ContractEndDate;
            property.ContractStartDate = propertyModel.ContractStartDate;
            property.UpdatedBy = propertyModel.CreatedBy;
            property.Description = propertyModel.Description;
            property.Floor = propertyModel.Floor;
            property.FloorNumber = propertyModel.FloorNumber;
            property.ListedBy = propertyModel.ListedBy;
            property.IsMultipleUnit = propertyModel.MultipleUnit;
            property.PortfolioId = propertyModel.PortfolioId;
            property.IsForRent = propertyModel.IsRent;
            property.IsForSale = propertyModel.IsSale;
            property.Name = propertyModel.PropertyName;
            property.PropertyType = propertyModel.PropertyType;
            property.Vaccancy = propertyModel.Vaccancy;
            property.TotalArea = propertyModel.TotalArea;
            property.MeasurementUnitForTotalArea = propertyModel.TotalAreaMeasurementUnit;
            property.UsageType = propertyModel.UsageType;
            property.Parking=propertyModel.IsParking;
            property.Furnished = propertyModel.FurnishType;
            property.NoOfParkingAvailable = propertyModel.NoOfParkingAvailable;
            property.HasLeasingTax = property.HasLeasingTax;
            property.HasManagementCommission = propertyModel.IsManagementCommission;
            property.HasRentalCommission = propertyModel.IsRentalCommission;
            property.HasSalesCommission = propertyModel.HasSaleCommission;

            //if (propertyModel.IsRent)
            //    property.RentInfoId = rentInfoId;
            if (propertyModel.IsSale)
                property.SaleInfoId = saleInfoId;

            int propertyType = (int)propertyModel.PropertyType;

            if (propertyType == 0)
            {
                property.NoOfBed = propertyModel.Bed;
                property.NoOfBath = propertyModel.Bath;
            }
            _propertyRepository.Update(property);
            _iUnitOfWork.Commit();

            IList<long> rentInfoIds = new List<long>();
            if (propertyModel.IsRent)
            {
                if (propertyModel.RentInfoModels != null)
                {
                    _rentInfoService.DeleteAllRentInfoByPropertyId(propertyModel.Id);
                    foreach (RentInfoModel rentInfoModel in propertyModel.RentInfoModels)
                    {
                        var newRentInfoModel = new RentInfoModel
                        {
                            CreatedBy = rentInfoModel.CreatedBy,
                            Amount = rentInfoModel.Amount,
                            ChargeId = rentInfoModel.ChargeId,
                            Month = rentInfoModel.Month,
                            Supress = rentInfoModel.Supress
                        };
                        var updatedRentInfo = _rentInfoService.CreateRentInfo(newRentInfoModel);
                        _iUnitOfWork.Commit();
                        rentInfoIds.Add(updatedRentInfo.Id);
                    }
                }
            }
            if (rentInfoIds != null)
            {
                var propertyRentInfoMapModel = new PropertyRentInfoMapModel
                {
                    PropertyId = property.Id,
                    RentInfoIds = rentInfoIds
                };
                _propertyRentInfoMapService.UpdatePropertyRentInfoMap(propertyRentInfoMapModel);
                _iUnitOfWork.Commit();
            }

            return true;
        }
        public bool UpdateSalesCommissionDetails(SalesCommissionModel salesCommissionModel)
        {
            var property = _propertyRepository.GetAllPropertiesById(salesCommissionModel.PropertyId);
            if (salesCommissionModel.SalesCommission != null)
                property.SalesCommission = salesCommissionModel.SalesCommission.Value;
            property.CommissionType = salesCommissionModel.CommissionType;
            _propertyRepository.Update(property);
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdateRentMarketingInformation(long marketingInfoId, long propertyId)
        {
            var property = _propertyRepository.GetAllPropertiesById(propertyId);
            property.RentMarketingInformationId = marketingInfoId;
            _propertyRepository.Update(property);
            _iUnitOfWork.Commit();
            return true;
        }
        public bool UpdateSaleMarketingInformation(long marketingInfoId, long propertyId)
        {
            var property = _propertyRepository.GetAllPropertiesById(propertyId);
            property.SaleMarketingInformationId = marketingInfoId;
            _propertyRepository.Update(property);
            _iUnitOfWork.Commit();
            return true;
        }
        public bool DeleteProperty(long id)
        {
            var result = _propertyRepository.DeleteProperty(id);
            _iUnitOfWork.Commit();
            return result;
        }
    }
}