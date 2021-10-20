using System;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Entities.Enums;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Services;

namespace PropznetCommon.Features.Accounting.Services
{
    public class TransactionService : ITransactionService
    {
        readonly ITransactionLineItemRepository _transactionLineItemRepository;
        readonly ITransactionRepository _transactionRepository;
        readonly IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionLineItemRepository transactionLineItemRepository,
                                  ITransactionRepository transactionRepository,
                                  IUnitOfWork unitOfWork)
        {
            _transactionLineItemRepository = transactionLineItemRepository;
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public void Delete(long transactionId)
        {
            _transactionLineItemRepository.DeleteTransaction(transactionId, 1);
            _transactionRepository.Delete(transactionId, 1);
            _unitOfWork.Commit();
        }

        public Transaction Create(DateTimeOffset dateOfTransaction, string title, string description, EntryType entryType)
        {
            var newTransaction = new Transaction
            {
                DateOfTransaction = dateOfTransaction,
                Description = description,
                Title = title,
                EntryType = entryType,
                IsSystem = false,
                CancelFlag = CancelFlag.No
            };
            _transactionRepository.Create(newTransaction);
            _unitOfWork.Commit();
            return newTransaction;
        }

        public void Update(long transactionId)
        {
            var oldTransaction = _transactionRepository.GetBy(i => i.Id == transactionId);
            // oldTransaction.ModifiedByUserId = agentId;
            //oldTransaction.ModifiedOn = DateTimeOffset.Now;
            oldTransaction.CancelFlag = CancelFlag.Yes;
            _transactionRepository.Update(oldTransaction);
            _unitOfWork.Commit();
        }

        public void UpdateLineItem(long transactionId)
        {
            var oldLineItems = _transactionLineItemRepository.CanceLineItems(transactionId);
            foreach (var transactionLineItem in oldLineItems)
            {
                transactionLineItem.CancelFlag = CancelFlag.Yes;
                // transactionLineItem.ModifiedOn = DateTimeOffset.Now;
                // transactionLineItem.ModifiedByUserId = agentId;
                _transactionLineItemRepository.Update(transactionLineItem);
                _unitOfWork.Commit();
            }
        }
        public void LineItemCreate(long transactionId, long debitAccount, long creditAccount, double amount, CancelFlag flag)
        {
            var newLineItem = new TransactionLineItem
            {
                TransactionId = transactionId,
                TransactionType = TransactionType.Debit,
                AccountId = debitAccount,
                Debit = amount,
                Credit = 0,
                CancelFlag = flag
            };
            
            _transactionLineItemRepository.Create(newLineItem);
            
            var newLineCreditItem = new TransactionLineItem
            {
                TransactionId = transactionId,
                TransactionType = TransactionType.Credit,
                AccountId = creditAccount,
                Credit = amount,
                Debit = 0,
                CancelFlag = flag
            };
            
            _transactionLineItemRepository.Create(newLineCreditItem);
            
            _unitOfWork.Commit();
        }
    }
}
