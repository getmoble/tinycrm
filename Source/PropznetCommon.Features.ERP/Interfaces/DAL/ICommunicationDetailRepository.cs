using Common.Data.Interfaces;
using PropznetCommon.Features.ERP.Entities;

namespace PropznetCommon.Features.ERP.Interfaces.DAL
{
    public interface ICommunicationDetailRepository : IGenericRepository<ERPCommunicationDetail>
    {
        ERPCommunicationDetail GetCommunicationDetail(long id);
    }
}
