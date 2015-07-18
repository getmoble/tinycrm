using Common.Data.Interfaces;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.CommunicationDetail;

namespace LOG.PropznetCRM.Data.Services
{
    public class CommunicationDetailService:ICommunicationDetailService
    {
        readonly ICommunicationDetailRepository _communicationDetailrepository;
        readonly IUnitOfWork _iUnitOfWork;
        public CommunicationDetailService(ICommunicationDetailRepository communicationDetailrepository, IUnitOfWork iUnitOfWork)
        {
            _communicationDetailrepository = communicationDetailrepository;
            _iUnitOfWork = iUnitOfWork;
        }
        public long CreateCommunicationDetail(CommunicationDetailModel communicationDetailModel)
        {
            var communicationDetail = new CommunicationDetail
            {
                Address = communicationDetailModel.Address,
                Email = communicationDetailModel.Email,
                Phone = communicationDetailModel.Phone,
                Website=communicationDetailModel.Website
            };
            _communicationDetailrepository.Create(communicationDetail);
            _iUnitOfWork.Commit();
            return communicationDetail.Id;
        }
        public long UpdateCommunicationDetail(CommunicationDetailModel communicationDetailModel)
        {
            var communicationDetail = _communicationDetailrepository.GetBy(i => i.Id == communicationDetailModel.Id);
            if(communicationDetail!=null)
            {
                communicationDetail.Address = communicationDetailModel.Address;
                communicationDetail.Email = communicationDetailModel.Email;
                communicationDetail.Phone = communicationDetailModel.Phone;
                if (communicationDetailModel.Website!=null)
                communicationDetail.Website = communicationDetailModel.Website;
                _communicationDetailrepository.Update(communicationDetail);
                _iUnitOfWork.Commit();
                return communicationDetail.Id;
            }
            
            return 0;
        }
    }
}
