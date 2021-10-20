using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model.Contact;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using Common.Data.Interfaces;

namespace PropznetCommon.Features.CRM.Services
{
    public class ContactPaymentInfoService : IContactPropertyInfoService
    {
        readonly IContactPaymentInfoRepository _contactPropertyInfoRepository;
        readonly IUnitOfWork _unitOfWork;
        public ContactPaymentInfoService(IContactPaymentInfoRepository contactPropertyInfoRepository,
            IUnitOfWork unitOfWork)
        {
            _contactPropertyInfoRepository = contactPropertyInfoRepository;
            _unitOfWork = unitOfWork;
        }
        public ContactPaymentInfo CreateContactPropertyInfo(ContactPaymentInfoModel contactPropertyInfomodel)
        {
            var ContactPropertyInfo = new ContactPaymentInfo
            {
                Bank = contactPropertyInfomodel.Bank,
                BankAccountNumber = contactPropertyInfomodel.BankAccountNumber,
                IFSC = contactPropertyInfomodel.BankIFSC,
                Branch = contactPropertyInfomodel.Branch,
                CashPaymentMode = contactPropertyInfomodel.CashPaymentMode,
                ChequePaymentMode = contactPropertyInfomodel.ChequePaymentMode,
                CreatedOn = DateTime.UtcNow,
                Description = contactPropertyInfomodel.Description,
                EmailAlerts = contactPropertyInfomodel.EmailAlerts,
                EmailStatements = contactPropertyInfomodel.EmailStatements,
                OnlinePaymentMode = contactPropertyInfomodel.OnlinePaymentMode,
                Ownership = contactPropertyInfomodel.Ownership,
                TaxEligible = contactPropertyInfomodel.TaxEligible,
                TaxId = contactPropertyInfomodel.TaxId,
                TaxPayerName = contactPropertyInfomodel.TaxPayerName
            };
            var newContactPropertyInfo = _contactPropertyInfoRepository.Create(ContactPropertyInfo);
            _unitOfWork.Commit();
            return newContactPropertyInfo;
        }
        public bool UpdateContactPropertyInfo(ContactPaymentInfoModel contactPropertyInfomodel)
        {
            var ContactPropertyInfo = _contactPropertyInfoRepository.Get(contactPropertyInfomodel.Id);
            if (!String.IsNullOrEmpty(contactPropertyInfomodel.Bank))
            {
                ContactPropertyInfo.Bank = contactPropertyInfomodel.Bank;
            }
            ContactPropertyInfo.BankAccountNumber = contactPropertyInfomodel.BankAccountNumber;

            if (!String.IsNullOrEmpty(contactPropertyInfomodel.BankIFSC))
            {
                ContactPropertyInfo.IFSC = contactPropertyInfomodel.BankIFSC;
            }
            if (!String.IsNullOrEmpty(contactPropertyInfomodel.Branch))
            {
                ContactPropertyInfo.Branch = contactPropertyInfomodel.Branch;
            }
            ContactPropertyInfo.CashPaymentMode = contactPropertyInfomodel.CashPaymentMode;

            ContactPropertyInfo.ChequePaymentMode = contactPropertyInfomodel.ChequePaymentMode;

            ContactPropertyInfo.CreatedOn = DateTime.UtcNow;
            if (!String.IsNullOrEmpty(contactPropertyInfomodel.Description))
            {
                ContactPropertyInfo.Description = contactPropertyInfomodel.Description;
            }
            ContactPropertyInfo.EmailAlerts = contactPropertyInfomodel.EmailAlerts;
            ContactPropertyInfo.EmailStatements = contactPropertyInfomodel.EmailStatements;
            ContactPropertyInfo.OnlinePaymentMode = contactPropertyInfomodel.OnlinePaymentMode;
            ContactPropertyInfo.Ownership = contactPropertyInfomodel.Ownership;
            ContactPropertyInfo.TaxEligible = contactPropertyInfomodel.TaxEligible;
            ContactPropertyInfo.TaxId = contactPropertyInfomodel.TaxId;
            if (!String.IsNullOrEmpty(contactPropertyInfomodel.TaxPayerName))
                ContactPropertyInfo.TaxPayerName = contactPropertyInfomodel.TaxPayerName;

            _contactPropertyInfoRepository.Update(ContactPropertyInfo);
            _unitOfWork.Commit();
            return true;
        }
        public bool DeleteContactPropertyInfo(long id)
        {
            var result = _contactPropertyInfoRepository.DeleteContactPropertyInfo(id);
            return result;
        }
    }
}
