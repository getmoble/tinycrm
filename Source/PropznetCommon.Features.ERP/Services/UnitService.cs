using System;
using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Entities.Enum;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.CommunicationDetail;
using PropznetCommon.Features.ERP.Model.Unit;
using PropznetCommon.Features.ERP.Model.RentInfo;

namespace PropznetCommon.Features.ERP.Services
{
    public class UnitService : IUnitService
    {
        readonly IUnitRepository _unitRepository;
        readonly IUnitSaleInfoService _saleInfoService;
        readonly IUnitRentInfoService _rentInfoService;
        readonly IUnitRentInfoMapService _unitRentInfoMapService;
        readonly IUnitSaleInfoRepository _saleInfoRepository;
        readonly IUnitRentInfoRepository _rentInfoRepository;
        readonly ICommunicationDetailService _communicationDetailService;
        readonly ICommunicationDetailRepository _communicationDetailRepository;
        readonly IUnitOfWork _iUnitOfWork;

        public UnitService(IUnitRepository unitRepository,
            IUnitRentInfoService rentInfoService,
            IUnitSaleInfoService saleInfoService,
            IUnitRentInfoMapService unitRentInfoMapService,
            IUnitSaleInfoRepository saleInfoRepository,
            IUnitRentInfoRepository rentInfoRepository,
            ICommunicationDetailService communicationDetailService,
            ICommunicationDetailRepository communicationDetailRepository,
            IUnitOfWork iUnitOfWork)
        {
            _unitRepository = unitRepository;
            _saleInfoService = saleInfoService;
            _rentInfoService = rentInfoService;
            _saleInfoRepository = saleInfoRepository;
            _rentInfoRepository = rentInfoRepository;
            _unitRentInfoMapService = unitRentInfoMapService;
            _communicationDetailService = communicationDetailService;
            _communicationDetailRepository = communicationDetailRepository;
            _iUnitOfWork = iUnitOfWork;
        }

        public Unit CreateUnit(UnitModel unitModel)
        {
            long rentInfoId = 0;
            long saleInfoId = 0;
            //if (unitModel.IsRent)
            //{
            //    var rentInfo = new UnitRentInfo
            //    {
            //        ChargeId = unitModel.ChargeId,
            //        CreatedBy = unitModel.CreatedBy,
            //        Amount = unitModel.RentAmount,
            //        CreatedOn=DateTime.UtcNow,
            //        Month=unitModel.RentMonth,
            //        Supress=unitModel.Supress
            //    };
            //    var createdRentInfo = _rentInfoRepository.Create(rentInfo);
            //    _iUnitOfWork.Commit();
            //    rentInfoId = createdRentInfo.Id;
            //}

            if (unitModel.IsSale)
            {
                var saleInfo = new UnitSaleInfo
                {
                    ExpectedPrice = unitModel.ExpectedPrice,
                    UnitMeasurementUnit = unitModel.SalePriceMeasurementUnit,
                    SalesTerms = unitModel.SalesTemrs,
                    GLAccount = unitModel.GLAccount,
                    HasSaleCommission = unitModel.HasSaleCommission,
                    SaleCommissionAmount = unitModel.SaleCommissionAmount,
                    SalesCommissionType = unitModel.SalesCommissionType
                };
                var createdSaleInfo = _saleInfoRepository.Create(saleInfo);
                _iUnitOfWork.Commit();
                saleInfoId = createdSaleInfo.Id;
            }

            var communicationDetailModel = new CommunicationDetailModel
            {
                Address = unitModel.Address,
                Area = unitModel.Area,
                CountryId = unitModel.CountryId,
                City=unitModel.City,
                Latitude = unitModel.Latitude,
                Longitude = unitModel.Longitude,
                State = unitModel.State,
                Zip = unitModel.Zip
            };

            var communicationDetail = _communicationDetailService.CreateCommunicationDetail(communicationDetailModel);
            _iUnitOfWork.Commit();
            var unit = new Unit
            {
                BuildUpArea = unitModel.BuildUpArea,
                MeasurementUnitForBuiltUpArea = unitModel.BuildUpAreaMeasurementUnit,
                Category = unitModel.Category,
                CommissionType = unitModel.CommissionType,
                CommunicationDetailId = communicationDetail.Id,
                CreatedBy = unitModel.CreatedBy,
                CreatedOn=DateTime.UtcNow,
                Description = unitModel.Description,
                FloorNo = unitModel.Floor,
                Furnished = unitModel.FurnishType,
                ListedBy = unitModel.ListedBy,
                ParkingAvailable = unitModel.ParkingAvailable,
                PropertyId = unitModel.PropertyId,
                SalesCommission = unitModel.SalesCommission,
                TotalArea = unitModel.TotalArea,
                MeasurementUnitForTotalArea = unitModel.TotalAreaMeasurementUnit,
                TotalFloors = unitModel.TotalFloors,
                UnitFor = unitModel.UnitFor,
                Name = unitModel.UnitName,
                UnitTypeId = unitModel.UnitTypeId,
                Vacccancy = unitModel.Vaccancy,
                ParkingNumber = unitModel.ParkingNumber,
                NoOfBath = unitModel.Bath,
                NoOfBed = unitModel.Bed
            };

            //if (unitModel.IsRent)
            //    unit.RentId = rentInfoId;

            if (unitModel.IsSale)
                unit.SaleId = saleInfoId;

            var createdUnit = _unitRepository.Create(unit);

            _iUnitOfWork.Commit();
            IList<long> rentInfoIds = null;
            if (unitModel.IsRent)
            {
                if (unitModel.RentInfoModels != null)
                {
                    rentInfoIds = new List<long>();
                    foreach (RentInfoModel rentInfoModel in unitModel.RentInfoModels)
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
            if (rentInfoIds != null)
            {
                var unitRentInfoMapModel = new UnitRentInfoMapModel
                {
                    UnitId = createdUnit.Id,
                    RentInfoIds = rentInfoIds
                };
                _unitRentInfoMapService.CreateUnitRentInfoMap(unitRentInfoMapModel);
                _iUnitOfWork.Commit();
            }
            return createdUnit;
        }
        public Unit GetUnitById(long id)
        {
            return _unitRepository.GetUnitById(id);
        }
        public IList<Unit> GetAllUnits()
        {
            return _unitRepository.GetAllUnits();
        }
        public bool UpdateUnit(UnitModel unitModel)
        {
            long rentInfoId = 0;
            long saleInfoId = 0;
            //if (unitModel.UnitFor == ListingType.Rent)
            //{
            //    var rent = _rentInfoService.GetRentInfo(unitModel.RentInfoId);
            //    rent.Amount = unitModel.RentAmount;
            //    rent.ChargeId = unitModel.ChargeId;
            //    rent.Month = unitModel.RentMonth;
            //    rent.Supress = unitModel.Supress;
            //    rent.UpdatedOn = DateTime.UtcNow;
            //    _rentInfoRepository.Update(rent);
            //    _iUnitOfWork.Commit();
            //    rentInfoId = rent.Id;
            //}

            if (unitModel.UnitFor == ListingType.Sale)
            {
                var sale = _saleInfoService.GetUnitSaleInfo(unitModel.SaleInfoId);
                sale.ExpectedPrice = unitModel.ExpectedPrice;
                sale.UnitMeasurementUnit = unitModel.SalePriceMeasurementUnit;
                sale.SalesTerms = unitModel.SalesTemrs;
                sale.UpdatedOn = DateTime.UtcNow;
                _saleInfoRepository.Update(sale);
                _iUnitOfWork.Commit();
                saleInfoId = sale.Id;
            }

            var communicationDetail = _communicationDetailService.GetCommunicationDetail(unitModel.CommunicationDetailId);
            communicationDetail.Address = unitModel.Address;
            communicationDetail.Area = unitModel.Area;
            communicationDetail.Latitude = unitModel.Latitude;
            communicationDetail.Longitude = unitModel.Longitude;
            communicationDetail.Zip = unitModel.Zip;
            communicationDetail.UpdatedOn = DateTime.UtcNow;

            _communicationDetailRepository.Update(communicationDetail);
            _iUnitOfWork.Commit();

            var unit = _unitRepository.GetUnitById(unitModel.Id);
            unit.BuildUpArea = unitModel.BuildUpArea;
            unit.MeasurementUnitForBuiltUpArea = unitModel.BuildUpAreaMeasurementUnit;
            unit.Category = unitModel.Category;
            unit.CommissionType = unitModel.CommissionType;
            unit.CreatedBy = unitModel.CreatedBy;
            unit.Description = unitModel.Description;
            unit.FloorNo = unitModel.Floor;
            unit.Furnished = unitModel.FurnishType;
            unit.ListedBy = unit.ListedBy;
            unit.ParkingAvailable = unitModel.ParkingAvailable;
            unit.NoOfBath = unitModel.Bath;
            unit.NoOfBed = unitModel.Bed;
            unit.PropertyId = unitModel.PropertyId;
            unit.CommunicationDetailId = communicationDetail.Id;
            //if (rentInfoId > 0)
            //    unit.RentId = rentInfoId;
            if (saleInfoId > 0)
                unit.SaleId = saleInfoId;
            unit.SalesCommission = unitModel.SalesCommission;
            unit.TotalArea = unitModel.TotalArea;
            unit.MeasurementUnitForTotalArea = unitModel.TotalAreaMeasurementUnit;
            unit.TotalFloors = unitModel.TotalFloors;
            unit.UnitFor = unitModel.UnitFor;
            unit.Name = unitModel.UnitName;
            unit.UnitTypeId = unitModel.UnitTypeId;
            unit.UpdatedOn = DateTime.UtcNow;
            unit.Vacccancy = unitModel.Vaccancy;
            unit.ParkingNumber = unitModel.ParkingNumber;
            unit.TotalFloors = unitModel.TotalFloors;
            _unitRepository.Update(unit);
            _iUnitOfWork.Commit();
            IList<long> rentInfoIds = null;
            if (unitModel.IsRent)
            {
                if (unitModel.RentInfoModels != null)
                {
                    rentInfoIds = new List<long>();
                    _rentInfoService.DeleteAllRentInfoByUnitId(unitModel.Id);
                    foreach (RentInfoModel rentInfoModel in unitModel.RentInfoModels)
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
                var unitRentInfoMapModel = new UnitRentInfoMapModel
                {
                    UnitId = unit.Id,
                    RentInfoIds = rentInfoIds
                };
                _unitRentInfoMapService.UpdateUnitRentInfoMap(unitRentInfoMapModel);
                _iUnitOfWork.Commit();
            }
            return true;
        }
        public bool UpdateSalesCommissionDetails(SalesCommissionModel salesCommissionModel)
        {
            var unit = _unitRepository.GetUnitById(salesCommissionModel.UnitId);
            if (salesCommissionModel.SalesCommission != null)
                unit.SalesCommission = salesCommissionModel.SalesCommission.Value;
            unit.CommissionType = salesCommissionModel.CommissionType;
            _unitRepository.Update(unit);
            _iUnitOfWork.Commit();
            return true;
        }
        public bool DeleteUnit(long id)
        {
            var result = _unitRepository.DeleteUnit(id);
            _iUnitOfWork.Commit();
            return result;
        }
        public IList<Unit> GetAllUnits(IList<long> id)
        {
            return _unitRepository.GetAllUnits(id);
        }
    }
}