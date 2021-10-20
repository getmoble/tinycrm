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
    public class GeneralReceiptService : IGeneralReceiptService
    {
        readonly IGeneralReceiptRepository _generalReceiptRepository;
        readonly IAccountHeadRepository _accountHeadRepository;
        readonly ITransactionRepository _transactionRepository;
        readonly ITransactionLineItemRepository _transactionLineItemRepository;
        readonly ITransactionService _transactionService;
        readonly IUnitOfWork _unitOfWork;
        public GeneralReceiptService(IGeneralReceiptRepository generalReceiptRepository,
                                     IAccountHeadRepository accountHeadRepository,
                                     ITransactionRepository transactionRepository,
                                     ITransactionLineItemRepository transactionLineItemRepository,
                                     ITransactionService transactionService,
                                     IUnitOfWork unitOfWork)
        {
            _generalReceiptRepository = generalReceiptRepository;
            _accountHeadRepository = accountHeadRepository;
            _transactionRepository = transactionRepository;
            _transactionLineItemRepository = transactionLineItemRepository;
            _transactionService = transactionService;
            _unitOfWork = unitOfWork;
        }

        public GeneralReceipt CreateAccount(DateTimeOffset dateOfReceipt, string party, string reference, string description, long incomeHeadId, long payingAccountId, double amount, string chequeOrDDNo, DateTimeOffset? chequeOrDDDate, EntryType entryType)
        {
            var newTransaction = new Transaction
            {
                DateOfTransaction = dateOfReceipt,
                Reference = reference,
                Description = description,
                Title = "General Receipt",
                EntryType = entryType,
                IsSystem = false,
                CancelFlag = CancelFlag.No
            };
            _transactionRepository.Create(newTransaction);
            _unitOfWork.Commit();
            var newReceiptEntry = new GeneralReceipt
            {
                DateOfPay = dateOfReceipt,
                Party = party,
                Referenace = reference,
                Description = description,
                IncomeAccountId = incomeHeadId,
                RecievingAccountId = payingAccountId,
                Amount = amount,
                ChequeOrDDNo = chequeOrDDNo,
                ChequeOrDDDate = chequeOrDDDate,
                TransactionId = newTransaction.Id
            };
            newReceiptEntry = _generalReceiptRepository.Create(newReceiptEntry);


            var newLineItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Debit,
                AccountId = payingAccountId,
                Debit = amount,
                Credit = 0,
                CancelFlag = CancelFlag.No
            };
            _transactionLineItemRepository.Create(newLineItem);
            var newLineCreditItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Credit,
                AccountId = incomeHeadId,
                Credit = amount,
                Debit = 0,
                CancelFlag = CancelFlag.No
            };
            _transactionLineItemRepository.Create(newLineCreditItem);
            _unitOfWork.Commit();
            var generalReceipt = _generalReceiptRepository.GetAccountById(newReceiptEntry.Id);
            return generalReceipt;
        }


        public GeneralReceipt UpdateAccount(DateTimeOffset dateOfReceipt, string party, string reference, string description, long incomeHeadId, long payingAccountId, double amount, string chequeDdNo, DateTimeOffset? chequeDdDate, EntryType entryType, long id)
        {
            var generalReceipt = _generalReceiptRepository.GetBy(i => i.Id == id);
            GeneralReceipt receipt = generalReceipt;
            var oldTransaction = _transactionRepository.GetBy(i => i.Id == receipt.TransactionId);
            //oldTransaction.ModifiedByUserId = agentId;
            //oldTransaction.ModifiedOn = DateTimeOffset.Now;
            oldTransaction.CancelFlag = CancelFlag.Yes;
            _transactionRepository.Update(oldTransaction);
            var oldLineItems = _transactionLineItemRepository.CanceLineItems(generalReceipt.TransactionId);
            foreach (var transactionLineItem in oldLineItems)
            {
                transactionLineItem.CancelFlag = CancelFlag.Yes;
                //  transactionLineItem.ModifiedOn = DateTimeOffset.Now;
                // transactionLineItem.ModifiedByUserId = agentId;
                _transactionLineItemRepository.Update(transactionLineItem);
            }
            var newTransaction = new Transaction
            {
                DateOfTransaction = dateOfReceipt,
                Reference = reference,
                Description = description,
                Title = "General Receipt",
                EntryType = entryType,
                IsSystem = false,
                CancelFlag = CancelFlag.No
            };
            _transactionRepository.Create(newTransaction);
            _unitOfWork.Commit();
            generalReceipt.DateOfPay = dateOfReceipt;
            generalReceipt.Party = party;
            generalReceipt.Referenace = reference;
            generalReceipt.Description = description;
            generalReceipt.IncomeAccountId = incomeHeadId;
            generalReceipt.RecievingAccountId = payingAccountId;
            generalReceipt.Amount = amount;
            generalReceipt.TransactionId = newTransaction.Id;
            generalReceipt.ChequeOrDDNo = chequeDdNo;
            generalReceipt.ChequeOrDDDate = chequeDdDate;
            //generalReceipt.ModifiedByUserId = agentId;
            //generalReceipt.ModifiedOn = DateTimeOffset.Now;
            _generalReceiptRepository.Update(generalReceipt);
            var newLineItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Debit,
                AccountId = payingAccountId,
                Debit = amount,
                Credit = 0,
                CancelFlag = CancelFlag.No
            };
            _transactionLineItemRepository.Create(newLineItem);
            var newLineCreditItem = new TransactionLineItem
            {
                TransactionId = newTransaction.Id,
                TransactionType = TransactionType.Credit,
                AccountId = incomeHeadId,
                Credit = amount,
                Debit = 0,
                CancelFlag = CancelFlag.No
            };
            _transactionLineItemRepository.Create(newLineCreditItem);
            _unitOfWork.Commit();


            generalReceipt = _generalReceiptRepository.GetAccountById(id);
            return generalReceipt;
        }


        public IList<GeneralReceipt> GetAllAccounts()
        {
            return _generalReceiptRepository.GetAllAccounts(1);
        }
        public List<AccountHead> GetAllIncomeHead()
        {
            return _accountHeadRepository.GetAllIncomeHead(1).ToList();
        }
        public List<AccountHead> GetAllPayingAccountList()
        {
            return _accountHeadRepository.GetAllPayingAccounts(1).ToList();
        }
        public GeneralReceipt Get(long id)
        {
            return _generalReceiptRepository.GetAccountById(id);
        }
        public bool Delete(long id)
        {
            var generalReceipt = _generalReceiptRepository.GetBy(i => i.Id == id && i.DeletedOn == null);
            // _generalReceiptRepository.MarkEntityAsDeleted(generalReceipt, agentId);
            _transactionService.Delete(generalReceipt.TransactionId);
            _unitOfWork.Commit();
            return true;
        }
    }
}
