using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class AccountCategoryRepository : GenericRepository<AccountCategory>, IAccountCategoryRepository
    {
        readonly IAccountingDataContext _dataContext;
        public AccountCategoryRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }
    }
}
