using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Model.CommunicationDetail;

namespace PropznetCommon.Features.ERP.Interfaces.Services
{
    public interface ICommunicationDetailService
    {
        ERPCommunicationDetail GetCommunicationDetail(long id);
        ERPCommunicationDetail CreateCommunicationDetail(CommunicationDetailModel communicationDetailModel);
        bool UpdateCommunicationDetail(CommunicationDetailModel communicationDetailModel);
    }
}