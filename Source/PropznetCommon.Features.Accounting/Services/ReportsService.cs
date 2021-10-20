using System;
using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Services;

namespace PropznetCommon.Features.Accounting.Services
{
    public class ReportsService : IReportsService
    {
        readonly ITransactionLineItemRepository _transactionLineItemRepository;
        readonly IAccountHeadRepository _accountHeadRepository;

        public ReportsService(ITransactionLineItemRepository transactionLineItemRepository, 
                              IAccountHeadRepository accountHeadRepository)
        {
            _transactionLineItemRepository = transactionLineItemRepository;
            _accountHeadRepository = accountHeadRepository;
        }

        public List<AccountHead> GetAllAccountHead()
        {
            return _accountHeadRepository.GetAllAccountHeads(1).ToList();
        }
        public List<AccountHeadStatus> GetAllGeneralLedgers(long accountId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            return _transactionLineItemRepository.GetAllGeneralLedgers(1, accountId, fromDate, toDate).ToList();
        }
        public List<AccountHeadStatus> GetTrialBalance(DateTimeOffset FromDate, DateTimeOffset ToDate)
        {
            return _transactionLineItemRepository.TrialBalance(FromDate, ToDate, 1).ToList();
        }
        public List<AccountHeadStatus> GetIncome(DateTimeOffset FromDate, DateTimeOffset ToDate)
        {
            return _transactionLineItemRepository.GetIncome(FromDate, ToDate, 1).ToList();
        }

        public List<AccountHeadStatus> GetExpense(DateTimeOffset FromDate, DateTimeOffset ToDate)
        {
            return _transactionLineItemRepository.GetExpense(FromDate, ToDate, 1).ToList();
        }
        public List<TransactionLineItem> GetGeneralLedgerDetails(long accountId)
        {
            return _transactionLineItemRepository.GeneralLedgerDetails(1).ToList();
        }
        public List<AccountHeadStatus> GetIncomeAndExpense(DateTimeOffset FromDate, DateTimeOffset ToDate)
        {
            return _transactionLineItemRepository.IncomeAndExpense(FromDate, ToDate, 1).ToList();
        }
        public List<BalanceSheet> BalanceSheet(DateTimeOffset asOnDate)
        {
            return _transactionLineItemRepository.BalanceSheet(asOnDate,1).ToList();
        }

    }
}