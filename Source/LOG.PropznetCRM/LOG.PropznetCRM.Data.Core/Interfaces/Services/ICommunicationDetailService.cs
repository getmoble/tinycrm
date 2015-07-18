using LOG.PropznetCRM.Data.Model.CommunicationDetail;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface ICommunicationDetailService
    {
        long CreateCommunicationDetail(CommunicationDetailModel communicationDetailModel);
        long UpdateCommunicationDetail(CommunicationDetailModel communicationDetailModel);
    }
}
