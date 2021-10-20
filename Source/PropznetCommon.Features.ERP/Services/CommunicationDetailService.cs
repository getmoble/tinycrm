using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.CommunicationDetail;

namespace PropznetCommon.Features.ERP.Services
{
    public class CommunicationDetailService : ICommunicationDetailService
    {
        readonly ICommunicationDetailRepository _communicationDetailrepository;
        readonly IUnitOfWork _iUnitOfWork;

        public CommunicationDetailService(ICommunicationDetailRepository communicationDetailrepository, IUnitOfWork iUnitOfWork)
        {
            _communicationDetailrepository = communicationDetailrepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public ERPCommunicationDetail GetCommunicationDetail(long id)
        {
            return _communicationDetailrepository.GetCommunicationDetail(id);
        }
        public ERPCommunicationDetail CreateCommunicationDetail(CommunicationDetailModel communicationDetailModel)
        {
            var communicationDetail = new ERPCommunicationDetail
            {
                Address = communicationDetailModel.Address,
                Area = communicationDetailModel.Area,
                Latitude = communicationDetailModel.Latitude,
                Longitude = communicationDetailModel.Longitude,
                Zip = communicationDetailModel.Zip,
                City=communicationDetailModel.City,
                State=communicationDetailModel.State,
                CountryId=communicationDetailModel.CountryId
            };
            var communicationDetailresult = _communicationDetailrepository.Create(communicationDetail);
            _iUnitOfWork.Commit();
            return communicationDetailresult;
        }
        public bool UpdateCommunicationDetail(CommunicationDetailModel communicationDetailModel)
        {
            var communicationDetail = _communicationDetailrepository.GetBy(i => i.Id == communicationDetailModel.Id);
            if (communicationDetail != null)
            {
                communicationDetail.Address = communicationDetailModel.Address;
                communicationDetail.Area = communicationDetailModel.Area;
                communicationDetail.Zip = communicationDetailModel.Zip;
                communicationDetail.Latitude = communicationDetailModel.Latitude;
                communicationDetail.Longitude = communicationDetailModel.Longitude;
                communicationDetail.CountryId = communicationDetailModel.CountryId;
                communicationDetail.State =communicationDetailModel.State;
                communicationDetail.City = communicationDetailModel.City;
                _communicationDetailrepository.Update(communicationDetail);

                _iUnitOfWork.Commit();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}