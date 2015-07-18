using Common.Data;
using Common.Data.Entities;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;

namespace LOG.PropznetCRM.Data.DAL
{
    public class StateRepository : GenericRepository<State>, IStateRepository 
    {
        DataContext _dataContext;
        public StateRepository(DataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
