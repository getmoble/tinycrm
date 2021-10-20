using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;
using System.Collections.Generic;
using System.Linq;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class AccountHeadRepository : GenericRepository<AccountHead>, IAccountHeadRepository
    {
        readonly IAccountingDataContext _dataContext;
        public AccountHeadRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public IList<AccountHead> GetAllAccounts(long customerId)
        {
            return _dataContext.AccountHeads.Include("AccountCategory").Include("OpeningBalance").Where(r => r.DeletedOn == null).OrderByDescending(r => r.CreatedOn).ToList();
        }
        //include apartment accounts
        public IList<AccountHead> GetAllAccountHeads(long customerId)
        {
            return _dataContext.AccountHeads.Include("AccountCategory").Include("OpeningBalance").Where(r => r.DeletedOn == null).OrderByDescending(r => r.CreatedOn).ToList();
        }
        public AccountHead GetAccountById(long accountHeadId)
        {
            return _dataContext.AccountHeads.Include("AccountCategory").Include("OpeningBalance").FirstOrDefault(r => r.Id == accountHeadId && r.DeletedOn == null);
        }

        public IList<AccountHead> GetAllExpenseHead(long customerId)
        {
            return _dataContext.AccountHeads
                              .Include("AccountCategory")
                              .Where(r => r.DeletedOn == null && (r.AccountCategory.ParentId == 1 || r.AccountCategory.ParentId == 4) && r.IsTransaction == false).ToList();
        }
        public IList<AccountHead> GetAllIncomeHead(long customerId)
        {
            return _dataContext.AccountHeads
                              .Include("AccountCategory")
                              .Where(r => r.DeletedOn == null && (r.AccountCategory.ParentId == 2 || r.AccountCategory.ParentId == 3) && r.IsTransaction == false).ToList();
        }
        public IList<AccountHead> GetAllPayingAccounts(long customerId)
        {
            return _dataContext.AccountHeads
                              .Where(r => r.DeletedOn == null && (r.IsTransaction == true)).ToList();
        }
        public IList<AccountHead> NonTransactionAccounts(long customerId)
        {
            return _dataContext.AccountHeads
                              .Where(r => r.DeletedOn == null && (r.IsTransaction == false)).ToList();
        }
        public IList<AccountHead> AssetAndLiabilityAccount(long customerId)
        {
            return _dataContext.AccountHeads.Include("AccountCategory")
                              .Where(r => r.DeletedOn == null && ((r.AccountCategory.AccountType == AccountTypes.Asset) || (r.AccountCategory.AccountType == AccountTypes.Liability)) && r.Id != 2).ToList();
        }
        public IList<AccountHead> GetAllRecieveAccounts(long customerId)
        {
            return _dataContext.AccountHeads
                              .Where(r => r.DeletedOn == null && (r.IsTransaction == true) && r.Id != 1).ToList();
        }
    }
}
