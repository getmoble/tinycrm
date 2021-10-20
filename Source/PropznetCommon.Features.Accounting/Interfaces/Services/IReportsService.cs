using System;
using System.Collections.Generic;
using PropznetCommon.Features.Accounting.Entities;

namespace PropznetCommon.Features.Accounting.Interfaces.Services
{
    public interface IReportsService
    {
        List<AccountHead> GetAllAccountHead();
        List<AccountHeadStatus> GetAllGeneralLedgers(long accountId, DateTimeOffset fromDate, DateTimeOffset toDate);
        List<AccountHeadStatus> GetTrialBalance(DateTimeOffset FromDate, DateTimeOffset ToDate);
        List<AccountHeadStatus> GetIncome(DateTimeOffset FromDate, DateTimeOffset ToDate);
        List<AccountHeadStatus> GetExpense(DateTimeOffset FromDate, DateTimeOffset ToDate);
        List<TransactionLineItem> GetGeneralLedgerDetails(long accountId);
        List<AccountHeadStatus> GetIncomeAndExpense(DateTimeOffset FromDate, DateTimeOffset ToDate);
        List<BalanceSheet> BalanceSheet(DateTimeOffset asOnDate);
    }
}