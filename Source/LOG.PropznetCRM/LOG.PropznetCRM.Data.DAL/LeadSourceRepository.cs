using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class LeadSourceRepository : ILeadSourceRepository
    {
        readonly DataContext _dataContext;
        public LeadSourceRepository(DataContext context)
        {
            _dataContext = context;
        }

        public IList<LeadSource> GetAllLeadSources()
        {
            return _dataContext.LeadSourceMaster.ToList();
        }
    }
}
