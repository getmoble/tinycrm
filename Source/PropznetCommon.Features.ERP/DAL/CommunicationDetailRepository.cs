using System.Data.Entity;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.Data;
using PropznetCommon.Features.ERP.Interfaces.DAL;

namespace PropznetCommon.Features.ERP.DAL
{
    public class CommunicationDetailRepository : GenericRepository<ERPCommunicationDetail>, ICommunicationDetailRepository
    {
        IERPDataContext _dataContext;
        public CommunicationDetailRepository(IERPDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
        public ERPCommunicationDetail GetCommunicationDetail(long id)
        {
            return _dataContext.ERPCommunicationDetails
                .Include(i => i.Country)
                .FirstOrDefault(i => i.Id == id);
        }
    }
}
