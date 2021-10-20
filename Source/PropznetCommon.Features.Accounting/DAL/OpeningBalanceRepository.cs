using System.Collections.Generic;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class OpeningBalanceRepository : GenericRepository<OpeningBalance>, IOpeningBalanceRepository
    {
        readonly IAccountingDataContext _dataContext;
        public OpeningBalanceRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<OpeningBalance> GetAllAccounts(long customerId)
        {
            return _dataContext.OpeningBalances.Include("Account").Where(r => r.DeletedOn == null).OrderByDescending(r => r.CreatedOn).ToList();

        }
        public OpeningBalance GetAccountById(long? id)
        {
            return _dataContext.OpeningBalances.Include("Account").FirstOrDefault(r => r.Id == id && r.DeletedOn == null);
        }
    }
}
