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
    public class GeneralExpenseService : IGeneralExpenseService
    {
        readonly IGeneralExpenseRepository _generalExpenseRepository;
        readonly IAccountHeadRepository _accountHeadRepository;
        readonly ITransactionRepository _transactionRepository;
        readonly ITransactionLineItemRepository _transactionLineItemRepository;
        readonly ITransactionService _transactionService;
        private readonly IUnitOfWork _unitOfWork;

        public GeneralExpenseService(IGeneralExpenseRepository generalExpenseRepository,
                                     IAccountHeadRepository accountHeadRepository,
                                     ITransactionRepository transactionRepository,
                                     ITransactionLineItemRepository transactionLineItemRepository,
                                     ITransactionService transactionService,
                                     IUnitOfWork unitOfWork)
        {
            _generalExpenseRepository = generalExpenseRepository;
            _accountHeadRepository = accountHeadRepository;
            _transactionRepository = transactionRepository;
            _transactionLineItemRepository = transactionLineItemRepository;
            _transactionService = transactionService;
            _unitOfWork = unitOfWork;
        }

        public GeneralExpense CreateAccount(DateTimeOffset dateOfPay, string party, string reference, string description, long expenseHeadId, long payingAccountId, double amount, string chequeOrDDNo, DateTimeOffset? chequeOrDDDate, EntryType entryType)
        {
            var newTransaction = new Transaction
            {
                DateOfTransaction = dateOfPay,
                Reference = reference,
                Description = description,
                Title = "General Expense",
                EntryType = entryType,
                IsSystem = false,
                CancelFlag = CancelFlag.No
            };
            _transactionRepository.Create(newTransaction);
            _unitOfWork.Commit();
            var newExpenseEntry = new GeneralExpense
            {
                DateOfPay = dateOfPay,
                Party = party,
                Referenace = reference,
                Description = description,
                ExpenseAccountId = expenseHeadId,
                PayingAccountId = payingAccountId,
                Amount = amount,
                ChequeOrDDNo = chequeOrDDNo,
                ChequeOrDDDate = chequeOrDDDate,
                TransactionId = newTransaction.Id
            };
            newExpenseEntry = _generalExpenseRepository.Create(newExpenseEntry);
            var newLineItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Debit,
                AccountId = expenseHeadId,
                Debit = amount,
                Credit = 0,
                CancelFlag = CancelFlag.No
            };
            var newLineCreditItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Credit,
                AccountId = payingAccountId,
                Credit = amount,
                Debit = 0,
                CancelFlag = CancelFlag.No
            };
            _transactionLineItemRepository.Create(newLineItem);
            _transactionLineItemRepository.Create(newLineCreditItem);
            _unitOfWork.Commit();
            var generalExpense = _generalExpenseRepository.GetAccountById(newExpenseEntry.Id);
            return generalExpense;
        }


        public GeneralExpense UpdateAccount(DateTimeOffset dateOfPay, string party, string reference, string description, long expenseHeadId, long payingAccountId, double amount, string chequeDdNo, DateTimeOffset? chequeDdDate, EntryType entryType, long id)
        {
            var generalExpense = _generalExpenseRepository.GetBy(i => i.Id == id);
            GeneralExpense expense = generalExpense;
            var oldTransaction = _transactionRepository.GetBy(i => i.Id == expense.TransactionId);
            //oldTransaction.ModifiedByUserId = agentId;
            //oldTransaction.ModifiedOn = DateTimeOffset.Now;
            oldTransaction.CancelFlag = CancelFlag.Yes;
            _transactionRepository.Update(oldTransaction);
            var oldLineItems = _transactionLineItemRepository.CanceLineItems(generalExpense.TransactionId);
            foreach (var transactionLineItem in oldLineItems)
            {
                transactionLineItem.CancelFlag = CancelFlag.Yes;
                //transactionLineItem.ModifiedOn = DateTimeOffset.Now;
                //transactionLineItem.ModifiedByUserId = agentId;
                _transactionLineItemRepository.Update(transactionLineItem);
            }
            var newTransaction = new Transaction
            {
                DateOfTransaction = dateOfPay,
                Reference = reference,
                Description = description,
                Title = "General Expense",
                EntryType = entryType,
                IsSystem = false,
                CancelFlag = CancelFlag.No
            };
            _transactionRepository.Create(newTransaction);
            _unitOfWork.Commit();

            generalExpense.DateOfPay = dateOfPay;
            generalExpense.Party = party;
            generalExpense.Referenace = reference;
            generalExpense.Description = description;
            generalExpense.ExpenseAccountId = expenseHeadId;
            generalExpense.PayingAccountId = payingAccountId;
            generalExpense.Amount = amount;
            generalExpense.ChequeOrDDNo = chequeDdNo;
            generalExpense.ChequeOrDDDate = chequeDdDate;
            generalExpense.TransactionId = newTransaction.Id;
            //generalExpense.ModifiedByUserId = agentId;
            //generalExpense.ModifiedOn = DateTimeOffset.Now;
            _generalExpenseRepository.Update(generalExpense);
            _unitOfWork.Commit();

            var newLineItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Debit,
                AccountId = expenseHeadId,
                Debit = amount,
                Credit = 0,
                CancelFlag = CancelFlag.No
            };
            var newLineCreditItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Credit,
                AccountId = payingAccountId,
                Credit = amount,
                Debit = 0,
                CancelFlag = CancelFlag.No
            };
            _transactionLineItemRepository.Create(newLineItem);
            _transactionLineItemRepository.Create(newLineCreditItem);
            _unitOfWork.Commit();


            generalExpense = _generalExpenseRepository.GetAccountById(id);
            return generalExpense;
        }


        public IList<GeneralExpense> GetAllAccounts()
        {
            return _generalExpenseRepository.GetAllAccounts(1);
        }
        public List<AccountHead> GetAllExpenseHead()
        {
            return _accountHeadRepository.GetAllExpenseHead(1).ToList();
        }
        public List<AccountHead> GetAllPayingAccountList()
        {
            return _accountHeadRepository.GetAllPayingAccounts(1).ToList();
        }
        public GeneralExpense Get(long id)
        {
            return _generalExpenseRepository.GetAccountById(id);
        }

        public bool Delete(long id)
        {
            var generalExpense = _generalExpenseRepository.GetBy(i => i.Id == id && i.DeletedOn == null);
            //_generalExpenseRepository.MarkEntityAsDeleted(generalExpense, agentId);
            _transactionService.Delete(generalExpense.TransactionId);
            _unitOfWork.Commit();
            return true;
        }
    }
}
