using System;
using System.Collections.Generic;
using System.Linq;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Services;

namespace PropznetCommon.Features.Accounting.Services
{
    public class AccountHeadService : IAccountHeadService
    {
        readonly IAccountHeadRepository _accountRepository;
        readonly IAccountCategoryRepository _accountCategoryRepository;
        readonly ITransactionService _transactionService;
        readonly IOpeningBalanceService _openingBalanceService;
        readonly IUnitOfWork _unitOfWork;

        public AccountHeadService(IAccountHeadRepository accountHeadRepository,
                                  ITransactionService transactionService,
            IOpeningBalanceService openingBalanceService,
            IAccountCategoryRepository accountCategoryRepository,
            IUnitOfWork unitOfWork)
        {
            _accountRepository = accountHeadRepository;
            _transactionService = transactionService;
            _openingBalanceService = openingBalanceService;
            _accountCategoryRepository = accountCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public AccountHead CreateAccount(string name, long accountCategoryId, string description, double openingBalance, bool isTransaction)
        {
            var transaction = _transactionService.Create(DateTimeOffset.Now, "Opening Balance", description, EntryType.OpeningBalance);
            var openingBalanceEntry = _openingBalanceService.CreateAccount(description, openingBalance, transaction.Id);
            var newAccount = new AccountHead
                                  {
                                      Name = name,
                                      AccountCategoryId = accountCategoryId,
                                      Description = description,
                                      IsTransaction = isTransaction,
                                      OpeningBalanceId = openingBalanceEntry.Id
                                  };
            _accountRepository.Create(newAccount);
            _unitOfWork.Commit();
            var getAccount = _accountCategoryRepository.GetBy(i => i.Id == accountCategoryId);
            if (getAccount.AccountType == AccountTypes.Income || getAccount.AccountType == AccountTypes.Liability)
            {
                _transactionService.LineItemCreate(transaction.Id, newAccount.Id, 2, openingBalance, CancelFlag.No);
            }
            else
            {
                _transactionService.LineItemCreate(transaction.Id, 2, newAccount.Id, openingBalance, CancelFlag.No);
            }
            
            _unitOfWork.Commit();
            return newAccount;
        }

        public IList<AccountHead> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts(1);
        }
        public AccountHead Get(long id)
        {
            return _accountRepository.GetBy(p => p.Id == id);
        }
        public AccountHead GetAllAccountId(long accountHeadId)
        {
            return _accountRepository.GetAccountById(accountHeadId);
        }
        public List<AccountHead> GetAllReceivingAccountList()
        {
            return _accountRepository.GetAllRecieveAccounts(1).ToList();
        }
        public AccountHead UpdateAccountHead(string name, long accountCategoryId, string description, double openingBalance, bool isTransaction, long customerId, long id)
        {
            var accountHead = _accountRepository.GetAccountById(id);
            accountHead.Name = name;
            accountHead.AccountCategoryId = accountCategoryId;
            accountHead.Description = description;
            accountHead.IsTransaction = isTransaction;


            if (accountHead.OpeningBalance != null && accountHead.OpeningBalance.Amount != openingBalance)
            {
                var openingEntry = _openingBalanceService.Get(accountHead.OpeningBalanceId);
                _transactionService.Update(openingEntry.TransactionId);
                var transaction = _transactionService.Create(DateTimeOffset.Now, "Opening Balance", description, EntryType.OpeningBalance);
                _unitOfWork.Commit();
                var getAccount = _accountCategoryRepository.GetBy(i => i.Id == accountCategoryId);
                if (getAccount.AccountType == AccountTypes.Income || getAccount.AccountType == AccountTypes.Liability)
                {
                    _transactionService.LineItemCreate(transaction.Id, 2, accountHead.Id, openingBalance, CancelFlag.No);
                }
                else
                {
                    _transactionService.LineItemCreate(transaction.Id, accountHead.Id, 2, openingBalance, CancelFlag.No);
                }
                var openingBalanceUpdate = _openingBalanceService.UpdateAccount(description, openingBalance, accountHead.OpeningBalanceId, transaction.Id);
            }
            if (openingBalance > 0 && accountHead.OpeningBalance == null && accountHead.Id == 1)
            {
                var transaction = _transactionService.Create(DateTimeOffset.Now, "Opening Balance", description, EntryType.OpeningBalance);
                var openingBalanceEntry = _openingBalanceService.CreateAccount(description, openingBalance, transaction.Id);

                accountHead.OpeningBalanceId = openingBalanceEntry.Id;

                _transactionService.LineItemCreate(transaction.Id, accountHead.Id, 2, openingBalance, CancelFlag.No);

            }
            _accountRepository.Update(accountHead);
            _unitOfWork.Commit();
            accountHead = _accountRepository.GetAccountById(id);
            return accountHead;
        }
        public bool Delete(long id)
        {
            var account = _accountRepository.GetBy(i => i.Id == id && i.DeletedOn == null);
            var lineItem = _openingBalanceService.Get(account.OpeningBalanceId);
            if (lineItem.Amount > 0 || id == 1)
            {
                return false;
            }
            //_accountRepository.MarkEntityAsDeleted(account, agentId);
            _transactionService.Delete(lineItem.TransactionId);
            _unitOfWork.Commit();
            return true;
        }

    }
}
