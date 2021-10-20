using System;
using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Services;

namespace PropznetCommon.Features.Accounting.Services
{
    public class JournalService : IJournalService
    {
        readonly IAccountHeadRepository _accountHeadRepository;
        readonly IJournalEntryRepository _journalEntryRepository;
        readonly ITransactionRepository _transactionRepository;
        readonly ITransactionLineItemRepository _transactionLineItemRepository;
        readonly ITransactionService _transactionService;
        readonly IUnitOfWork _unitOfWork;

        public JournalService(IAccountHeadRepository accountHeadRepository, 
                              IJournalEntryRepository journalEntryRepository,
                              ITransactionRepository transactionRepository,
                              ITransactionLineItemRepository transactionLineItemRepository,
                              ITransactionService transactionService,
                              IUnitOfWork unitOfWork)
        {

            _accountHeadRepository = accountHeadRepository;
            _journalEntryRepository = journalEntryRepository;
            _transactionRepository = transactionRepository;
            _transactionLineItemRepository = transactionLineItemRepository;
            _transactionService = transactionService;
            _unitOfWork = unitOfWork;
        }

        public Journal CreateAccount(DateTimeOffset dateOfTransaction, string reference, string description, long fromAccountId, long toAccountId, double amount, EntryType entryType)
        {
            var newTransaction = new Transaction
            {
                DateOfTransaction = dateOfTransaction,
                Reference = reference,
                Description = description,
                Title = "Journal Entry",
                EntryType = entryType,
                IsSystem = false,
                CancelFlag = CancelFlag.No
            };
            _transactionRepository.Create(newTransaction);
            _unitOfWork.Commit();
            var newJournalEntry = new Journal
            {
                DateOfTransaction = dateOfTransaction,
                Referennce = reference,
                Description = description,
                FromAccountId = fromAccountId,
                ToAccountId = toAccountId,
                Amount = amount,
                TransactionId = newTransaction.Id
            };
            newJournalEntry = _journalEntryRepository.Create(newJournalEntry);


            var newLineItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Debit,
                AccountId = toAccountId,
                Debit = amount,
                Credit = 0,
                CancelFlag = CancelFlag.No
            };
            _transactionLineItemRepository.Create(newLineItem);
            var newLineCreditItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Credit,
                AccountId = fromAccountId,
                Credit = amount,
                Debit = 0,
                CancelFlag = CancelFlag.No
            };
            _transactionLineItemRepository.Create(newLineCreditItem);
            _unitOfWork.Commit();
            newJournalEntry = _journalEntryRepository.GetAccountById(newJournalEntry.Id);
            return newJournalEntry;
        }


        public Journal UpdateAccount(DateTimeOffset dateOfTransaction, string reference, string description, long fromAccountId, long toAccountId, double amount, EntryType entryType, long id)
        {
            var journal = _journalEntryRepository.GetBy(i => i.Id == id);
            Journal journal1 = journal;
            var oldTransaction = _transactionRepository.GetBy(i => i.Id == journal1.TransactionId);
            //oldTransaction.ModifiedByUserId = agentId;
            //oldTransaction.ModifiedOn = DateTimeOffset.Now;
            //oldTransaction.CancelFlag = CancelFlag.Yes;
            _transactionRepository.Update(oldTransaction);
            var oldLineItems = _transactionLineItemRepository.CanceLineItems(journal.TransactionId);
            foreach (var transactionLineItem in oldLineItems)
            {
                transactionLineItem.CancelFlag = CancelFlag.Yes;
                //transactionLineItem.ModifiedOn = DateTimeOffset.Now;
               // transactionLineItem.ModifiedByUserId = agentId;
                _transactionLineItemRepository.Update(transactionLineItem);
            }

            var newTransaction = new Transaction
            {
                DateOfTransaction = dateOfTransaction,
                Reference = reference,
                Description = description,
                Title = "Journal",
                EntryType = entryType,
                IsSystem = false,
                CancelFlag = CancelFlag.No
            };
            _transactionRepository.Create(newTransaction);
            _unitOfWork.Commit();
            journal.DateOfTransaction = dateOfTransaction;
            journal.Referennce = reference;
            journal.Description = description;
            journal.FromAccountId = fromAccountId;
            journal.ToAccountId = toAccountId;
            journal.Amount = amount;
            journal.TransactionId = newTransaction.Id;
           // journal.ModifiedByUserId = agentId;
           // journal.ModifiedOn = DateTimeOffset.Now;
            _journalEntryRepository.Update(journal);
            var newLineItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Debit,
                AccountId = toAccountId,
                Debit = amount,
                Credit = 0,
                CancelFlag = CancelFlag.No,
            };
            _transactionLineItemRepository.Create(newLineItem);
            var newLineCreditItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Credit,
                AccountId = fromAccountId,
                Credit = amount,
                Debit = 0,
                CancelFlag = CancelFlag.No
            };
            _transactionLineItemRepository.Create(newLineCreditItem);
            _unitOfWork.Commit();

            journal = _journalEntryRepository.GetAccountById(id);
            return journal;
        }


        public IList<Journal> GetAllAccounts()
        {
            return _journalEntryRepository.GetAllAccounts(1);
        }

        public IList<AccountHead> NonTransactionAccount()
        {
            return _accountHeadRepository.NonTransactionAccounts(1);
        }


        public Journal Get(long id)
        {
            return _journalEntryRepository.GetAccountById(id);
        }
        public bool Delete(long id)
        {
            var journal = _journalEntryRepository.GetBy(i => i.Id == id && i.DeletedOn == null);
          //  _journalEntryRepository.MarkEntityAsDeleted(journal, agentId);
            _transactionService.Delete(journal.TransactionId);
            _unitOfWork.Commit();
            return true;
        }
    }
}
