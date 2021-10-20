using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Data;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Data;

namespace PropznetCommon.Features.Accounting.DAL
{
    public class TransactionLineItemRepository : GenericRepository<TransactionLineItem>, ITransactionLineItemRepository
    {
        readonly IAccountingDataContext _dataContext;
        public TransactionLineItemRepository(IAccountingDataContext context)
            : base(context)
        {
            _dataContext = context;
        }

        public double GetAdvance(long advanceId)
        {
            return _dataContext.TransactionLineItems.Where(u => u.AccountId == advanceId).Sum(income => (double?)income.Debit) ?? 0;
        }
        public IList<AccountHeadStatus> GetAllGeneralLedgers(long customerId, long accountId, DateTimeOffset fromDate, DateTimeOffset ToDate)
        {
            var toDate = DateTimeOffset.Parse(ToDate.DateTime.AddDays(1).ToShortDateString());
            if (accountId == 0)
            {
                var accountheads =
                    (from lineitem in
                         _dataContext.TransactionLineItems.Include("Account")
                            .Include("Account.AccountCategory")
                            .Where(
                                r => r.DeletedOn == null && r.CancelFlag == CancelFlag.No && (r.Transaction.DateOfTransaction >= fromDate && r.Transaction.DateOfTransaction <= toDate))
                     group lineitem by new { lineitem.AccountId, lineitem.Account, lineitem.Account.AccountCategory }
                         into g
                         select
                             new AccountHeadStatus
                             {
                                 AccountId = g.Key.AccountId,
                                 AccountName = g.Key.Account.Name,
                                 AccountCategory = g.Key.Account.AccountCategory.AccountType.ToString(),
                                 Credit = g.Sum(s => s.Credit),
                                 Debit = g.Sum(d => d.Debit)
                             }).ToList();
                return accountheads;
            }
            else
            {
                var accountheads =
                     (from lineitem in
                          _dataContext.TransactionLineItems.Include("Account")
                              .Include("Account.AccountCategory")
                              .Where(
                                  r => r.DeletedOn == null && r.CancelFlag == CancelFlag.No && r.AccountId == accountId && (r.Transaction.DateOfTransaction >= fromDate && r.Transaction.DateOfTransaction <= toDate))
                      group lineitem by new { lineitem.AccountId, lineitem.Account, lineitem.Account.AccountCategory }
                          into g
                          select
                              new AccountHeadStatus
                              {
                                  AccountId = g.Key.AccountId,
                                  AccountName = g.Key.Account.Name,
                                  AccountCategory = g.Key.Account.AccountCategory.AccountType.ToString(),
                                  Credit = g.Sum(s => s.Credit),
                                  Debit = g.Sum(d => d.Debit)
                              }).ToList();
                return accountheads;
            }
        }
        public IList<AccountHeadStatus> TrialBalance(DateTimeOffset FromDate, DateTimeOffset ToDate, long customerId)
        {
            var toDate = DateTimeOffset.Parse(ToDate.DateTime.AddDays(1).ToShortDateString());
            var accountheads = (from lineitem in _dataContext.TransactionLineItems.Include("Account").Include("Account.AccountCategory").Include("Transaction")
                                .Where(r => r.DeletedOn == null && r.CancelFlag == CancelFlag.No && (r.Transaction.DateOfTransaction >= FromDate && r.Transaction.DateOfTransaction <= toDate))
                                group lineitem by new { lineitem.AccountId, lineitem.Account, lineitem.Account.AccountCategory } into g
                                select new AccountHeadStatus { AccountId = g.Key.AccountId, AccountName = g.Key.Account.Name, AccountCategory = g.Key.Account.AccountCategory.AccountType.ToString(), Credit = g.Sum(s => s.Credit), Debit = g.Sum(d => d.Debit) }).ToList();
            return accountheads;
        }
        public IList<AccountHeadStatus> GetIncome(DateTimeOffset FromDate, DateTimeOffset ToDate, long customerId)
        {
            var toDate = DateTimeOffset.Parse(ToDate.DateTime.AddDays(1).ToShortDateString());
            var accountheads = (from lineitem in _dataContext.TransactionLineItems.Include("Account").Include("Account.AccountCategory").Include("Transaction").Where(r => r.DeletedOn == null && r.CancelFlag == CancelFlag.No && r.Account.AccountCategory.AccountType == AccountTypes.Income && (r.Transaction.DateOfTransaction >= FromDate && r.Transaction.DateOfTransaction <= toDate))
                                group lineitem by new { lineitem.AccountId, lineitem.Account, lineitem.Account.AccountCategory } into g
                                select new AccountHeadStatus { AccountId = g.Key.AccountId, AccountName = g.Key.Account.Name, AccountCategory = g.Key.Account.AccountCategory.AccountType.ToString(), Credit = g.Sum(s => s.Credit), Debit = g.Sum(d => d.Debit) }).ToList();
            return accountheads;
        }

        public IList<AccountHeadStatus> GetExpense(DateTimeOffset FromDate, DateTimeOffset ToDate, long customerId)
        {
            var toDate = DateTimeOffset.Parse(ToDate.DateTime.AddDays(1).ToShortDateString());
            var accountheads = (from lineitem in _dataContext.TransactionLineItems.Include("Account").Include("Account.AccountCategory").Include("Transaction").Where(r => r.DeletedOn == null && r.CancelFlag == CancelFlag.No && r.Account.AccountCategory.AccountType == AccountTypes.Expense && (r.Transaction.DateOfTransaction >= FromDate && r.Transaction.DateOfTransaction <= toDate))
                                group lineitem by new { lineitem.AccountId, lineitem.Account, lineitem.Account.AccountCategory } into g
                                select new AccountHeadStatus { AccountId = g.Key.AccountId, AccountName = g.Key.Account.Name, AccountCategory = g.Key.Account.AccountCategory.AccountType.ToString(), Credit = g.Sum(s => s.Credit), Debit = g.Sum(d => d.Debit) }).ToList();
            return accountheads;
        }
        public IList<AccountHeadStatus> IncomeAndExpense(DateTimeOffset FromDate, DateTimeOffset ToDate, long customerId)
        {
            var toDate = DateTimeOffset.Parse(ToDate.DateTime.AddDays(1).ToShortDateString());
            var accountheads = (from lineitem in _dataContext.TransactionLineItems.Include("Account").Include("Account.AccountCategory").Include("Transaction").Where(r => r.DeletedOn == null && r.CancelFlag == CancelFlag.No && (r.Account.AccountCategory.AccountType == AccountTypes.Income || r.Account.AccountCategory.AccountType == AccountTypes.Expense) && (r.Transaction.DateOfTransaction >= FromDate && r.Transaction.DateOfTransaction <= toDate))
                                group lineitem by new { lineitem.AccountId, lineitem.Account, lineitem.Account.AccountCategory } into g
                                select new AccountHeadStatus { AccountId = g.Key.AccountId, AccountName = g.Key.Account.Name, AccountCategory = g.Key.Account.AccountCategory.AccountType.ToString(), Credit = g.Sum(s => s.Credit), Debit = g.Sum(d => d.Debit) }).ToList();
            return accountheads;
        }
        public IList<BalanceSheet> BalanceSheet(DateTimeOffset asOnDate, long customerId)
        {
            var toDate = DateTimeOffset.Parse(asOnDate.DateTime.AddDays(1).ToShortDateString());
            var accountheads = (from lineitem in _dataContext.TransactionLineItems.Include("Account").Include("Account.AccountCategory").Include("Transaction").Where(r => r.DeletedOn == null && r.CancelFlag == CancelFlag.No && (r.Account.AccountCategory.AccountType == AccountTypes.Asset || r.Account.AccountCategory.AccountType == AccountTypes.Liability) && (r.Transaction.DateOfTransaction <= toDate))
                                group lineitem by new { lineitem.AccountId, lineitem.Account, lineitem.Account.AccountCategory } into g
                                select new BalanceSheet { AccountId = g.Key.AccountId, AccountName = g.Key.Account.Name, AccountCategory = g.Key.Account.AccountCategory.AccountType.ToString(), Credit = g.Sum(s => s.Credit), Debit = g.Sum(d => d.Debit), Balance = (g.Sum(d => d.Debit) - g.Sum(s => s.Credit)) }).ToList();
            return accountheads;
        }
        public IList<TransactionLineItem> GeneralLedgerDetails(long accountId)
        {
            return _dataContext.TransactionLineItems.Include("Account").Include("Transaction").Where(i => i.AccountId == accountId && i.DeletedOn == null && i.CancelFlag == CancelFlag.No).ToList();
        }
        public IList<TransactionLineItem> CanceLineItems(long transactionId)
        {
            return _dataContext.TransactionLineItems.Where(i => i.TransactionId == transactionId && i.DeletedOn == null).ToList();
        }
        public IList<TransactionLineItem> GetLineItems(long transactionId)
        {
            return _dataContext.TransactionLineItems.Where(i => i.TransactionId == transactionId && i.DeletedOn == null).ToList();
        }
        public void DeleteTransaction(long transactionId, long userId)
        {
            var lineItems = GetLineItems(transactionId).ToList();
            foreach (var transactionLineItem in lineItems)
            {
                transactionLineItem.CancelFlag = CancelFlag.Yes;
                transactionLineItem.DeletedOn = DateTime.Now;
                transactionLineItem.DeletedByUserId = userId;
                _dataContext.Entry(transactionLineItem).State = EntityState.Modified;
            }
        }
    }
}
