using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;
using System.Collections.Generic;
using System.Linq;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class JournalEntryRepository : GenericRepository<Journal>, IJournalEntryRepository
    {
        readonly IAccountingDataContext _dataContext;
        public JournalEntryRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<Journal> GetAllAccounts(long customerId)
        {
            return _dataContext.Journal.Include("FromAccount").Include("ToAccount").Where(r => r.DeletedOn == null).OrderByDescending(r => r.CreatedOn).ToList();

        }
        public Journal GetAccountById(long contraId)
        {
            return _dataContext.Journal.Include("FromAccount").Include("ToAccount").FirstOrDefault(r => r.Id == contraId && r.DeletedOn == null);
        }
    }
}
