using System;
using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Services;

namespace PropznetCommon.Features.Accounting.Services
{
    public class ContraService : IContraService
    {
        readonly IContraRepository _contraRepository;
        readonly IAccountHeadRepository _accountHeadRepository;
        readonly ITransactionRepository _transactionRepository;
        readonly ITransactionLineItemRepository _transactionLineItemRepository;
        readonly ITransactionService _transactionService;
        readonly IUnitOfWork _unitOfWork;
        public ContraService(IContraRepository contraRepository,
                             IAccountHeadRepository accountHeadRepository,
                             ITransactionRepository transactionRepository,
                             ITransactionLineItemRepository transactionLineItemRepository,
                              ITransactionService transactionService,
                                IUnitOfWork unitOfWork)
        {
            _accountHeadRepository = accountHeadRepository;
            _contraRepository = contraRepository;
            _transactionRepository = transactionRepository;
            _transactionLineItemRepository = transactionLineItemRepository;
            _transactionService = transactionService;
            _unitOfWork = unitOfWork;
        }

        public Contra CreateAccount(DateTimeOffset dateOfTransaction, string reference, string description, long fromAccountId, long toAccountId, double amount, EntryType entryType)
        {
            var newTransaction = new Transaction
            {
                DateOfTransaction = dateOfTransaction,
                Reference = reference,
                Description = description,
                Title = "Cash Bank Transfer",
                EntryType = entryType,
                IsSystem = false,
                CancelFlag = CancelFlag.No
            };
            _transactionRepository.Create(newTransaction);
            _unitOfWork.Commit();
            var newContraEntry = new Contra
            {
                DateOfTransaction = dateOfTransaction,
                Referennce = reference,
                Description = description,
                FromAccountId = fromAccountId,
                ToAccountId = toAccountId,
                Amount = amount,
                TransactionId = newTransaction.Id
            };
            newContraEntry = _contraRepository.Create(newContraEntry);


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
            newContraEntry = _contraRepository.GetAccountById(newContraEntry.Id);
            return newContraEntry;
        }


        public Contra UpdateAccount(DateTimeOffset dateOfTransaction, string reference, string description, long fromAccountId, long toAccountId, double amount, EntryType entryType, long id)
        {
            var contra = _contraRepository.GetBy(i => i.Id == id);
            Contra contra1 = contra;
            var oldTransaction = _transactionRepository.GetBy(i => i.Id == contra1.TransactionId);
            //oldTransaction.ModifiedByUserId = agentId;
            //oldTransaction.ModifiedOn = DateTimeOffset.Now;
            oldTransaction.CancelFlag = CancelFlag.Yes;
            _transactionRepository.Update(oldTransaction);
            var oldLineItems = _transactionLineItemRepository.CanceLineItems(contra.TransactionId);
            foreach (var transactionLineItem in oldLineItems)
            {
                transactionLineItem.CancelFlag = CancelFlag.Yes;
                //transactionLineItem.ModifiedOn = DateTimeOffset.Now;
                //transactionLineItem.ModifiedByUserId = agentId;
                _transactionLineItemRepository.Update(transactionLineItem);
            }
            var newTransaction = new Transaction
            {
                DateOfTransaction = dateOfTransaction,
                Reference = reference,
                Description = description,
                Title = "Cash Bank Transfer",
                EntryType = entryType,
                IsSystem = false,
                CancelFlag = CancelFlag.No
            };
            _transactionRepository.Create(newTransaction);
            _unitOfWork.Commit();
            contra.DateOfTransaction = dateOfTransaction;
            contra.Referennce = reference;
            contra.Description = description;
            contra.FromAccountId = fromAccountId;
            contra.ToAccountId = toAccountId;
            contra.Amount = amount;
            contra.TransactionId = newTransaction.Id;
            //contra.ModifiedByUserId = agentId;
            //contra.ModifiedOn = DateTimeOffset.Now;
            _contraRepository.Update(contra);
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

            contra = _contraRepository.GetAccountById(id);
            return contra;
        }


        public IList<Contra> GetAllAccounts()
        {
            return _contraRepository.GetAllAccounts(1);
        }

        public IList<AccountHead> GetAllPayingAccountList()
        {
            return _accountHeadRepository.GetAllPayingAccounts(1);
        }

        public Contra Get(long id)
        {
            return _contraRepository.GetAccountById(id);
        }

        public bool Delete(long id)
        {
            var transfer = _contraRepository.GetBy(i => i.Id == id && i.DeletedOn == null);
            //_contraRepository.MarkEntityAsDeleted(transfer, agentId);
            _transactionService.Delete(transfer.TransactionId);
            _unitOfWork.Commit();
            return true;
        }
    }
}
