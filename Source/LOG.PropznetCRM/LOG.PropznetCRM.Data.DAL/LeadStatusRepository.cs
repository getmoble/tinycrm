using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.DAL.Data;
using LOG.PropznetCRM.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.DAL
{
    public class LeadStatusRepository :  ILeadStatusRepository
    {
        readonly DataContext _dataContext;
        public LeadStatusRepository(DataContext context)
        {
            _dataContext = context;
        }

        public IList<LeadStatus> GetAllLeadStatuses()
        {
           return _dataContext.LeadStatusMaster.ToList();
        }
    }
}
