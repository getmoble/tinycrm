using System.Collections.Generic;
using Common.Data.Interfaces;
using PropznetCommon.Features.Accounting.Entities;
using PropznetCommon.Features.Accounting.Interfaces.DAL;
using PropznetCommon.Features.Accounting.Interfaces.Services;

namespace PropznetCommon.Features.Accounting.Services
{
    public class OpeningBalanceService : IOpeningBalanceService
    {
        readonly IAccountHeadRepository _accountHeadRepository;
        readonly IOpeningBalanceRepository _openingBalanceRepository;
        readonly ITransactionService _transactionService;
        readonly IUnitOfWork _unitOfWork;

        public OpeningBalanceService(IAccountHeadRepository accountHeadRepository, 
                                     IOpeningBalanceRepository openingBalanceRepository,
                                     ITransactionService transactionService,
                                     IUnitOfWork unitOfWork)
        {

            _accountHeadRepository = accountHeadRepository;
            _openingBalanceRepository = openingBalanceRepository;
            _transactionService = transactionService;
            _unitOfWork = unitOfWork;
        }

        public OpeningBalance CreateAccount(string description, double amount, long transactionId)
        {
            var newOpeningEntry = new OpeningBalance
            {
                Description = description,
                Amount = amount,
                TransactionId = transactionId
            };
            newOpeningEntry = _openingBalanceRepository.Create(newOpeningEntry);
            _unitOfWork.Commit();
            return newOpeningEntry;


        }

        public OpeningBalance UpdateAccount(string description, double amount, long? id, long transactionId)
        {
            var openingBalance = _openingBalanceRepository.GetBy(i => i.Id == id);
            openingBalance.Description = description;
            openingBalance.Amount = amount;
            openingBalance.TransactionId = transactionId;
          //  openingBalance.ModifiedByUserId = agentId;
          //  openingBalance.ModifiedOn = DateTimeOffset.Now;
            _openingBalanceRepository.Update(openingBalance);

            _unitOfWork.Commit();
            return openingBalance;
        }


        public IList<OpeningBalance> GetAllAccounts()
        {
            return _openingBalanceRepository.GetAllAccounts(1);
        }

        public IList<AccountHead> AssetAndLiabilityAccount()
        {
            return _accountHeadRepository.AssetAndLiabilityAccount(1);
        }

        public OpeningBalance Get(long? id)
        {
            return _openingBalanceRepository.GetAccountById(id);
        }
        public bool Delete(long id)
        {
            var oBalance = _openingBalanceRepository.GetBy(i => i.Id == id && i.DeletedOn == null);
          //  _openingBalanceRepository.MarkEntityAsDeleted(oBalance, agentId);
            _transactionService.Delete(oBalance.TransactionId);
            _unitOfWork.Commit();
            return true;
        }
    }
}
