using Common.Data;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;

namespace LOG.PropznetCRM.Data.DAL
{
    public class CommunicationDetailRepository : GenericRepository<CommunicationDetail>, ICommunicationDetailRepository
    {
        DataContext _dataContext;
        public CommunicationDetailRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
