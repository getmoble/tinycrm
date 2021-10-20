using System;
using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.DAL
{
    public interface ITransactionLineItemRepository : IGenericRepository<TransactionLineItem>
    {
        double GetAdvance(long advanceId);
        IList<AccountHeadStatus> GetAllGeneralLedgers(long customerId, long accountId, DateTimeOffset fromDate, DateTimeOffset ToDate);
        IList<AccountHeadStatus> TrialBalance(DateTimeOffset FromDate, DateTimeOffset ToDate, long customerId);
        IList<AccountHeadStatus> GetIncome(DateTimeOffset FromDate, DateTimeOffset ToDate, long customerId);
        IList<AccountHeadStatus> GetExpense(DateTimeOffset FromDate, DateTimeOffset ToDate, long customerId);
        IList<AccountHeadStatus> IncomeAndExpense(DateTimeOffset FromDate, DateTimeOffset ToDate, long customerId);
        IList<BalanceSheet> BalanceSheet(DateTimeOffset asOnDate, long customerId);
        IList<TransactionLineItem> GeneralLedgerDetails(long accountId);
        IList<TransactionLineItem> CanceLineItems(long transactionId);
        IList<TransactionLineItem> GetLineItems(long transactionId);
        void DeleteTransaction(long transactionId, long userId);
    }
}