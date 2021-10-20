using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.DAL;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Data.Interfaces;
using PropznetCommon.Features.CRM.ElasticSearch;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model;
using PropznetCommon.Features.CRM.Model.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Services
{
    public class PaymentContactService : IPaymentContactService
    {
        readonly IPaymentContactRepository _paymentContactRepository;
        readonly IContactPaymentInfoRepository _contactPaymentInfoRepository;
        readonly IContactRepository _contactRepository;
        readonly ElasticSearchService _elasticSearchService;
        readonly IUnitOfWork _unitOfWork;
        readonly IPersonService _personService;
        readonly IPersonRepository _personRepository;
        public PaymentContactService(IPaymentContactRepository propertyContactRepository,
            IContactRepository contactRepository,
            IContactPaymentInfoRepository contactPropertyInfoRepository,
            IElasticSearchSettings elasticsearchsettings,
            IPersonService personService,
            IPersonRepository personRepository,
            IUnitOfWork unitOfWork)
        {
            _paymentContactRepository = propertyContactRepository;
            _contactRepository = contactRepository;
            _contactPaymentInfoRepository = contactPropertyInfoRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _personService = personService;
        }
        public bool CreatePropertyContact(PaymentContactMapModel contactPropertyMapModel)
        {
            if (contactPropertyMapModel != null)
            {
                var contactCount = _contactRepository.GetContactCountByUser(contactPropertyMapModel.CreatedBy);
                var person = new Person
                {
                    FirstName = contactPropertyMapModel.FirstName,
                    LastName = contactPropertyMapModel.LastName,
                    Title = contactPropertyMapModel.Title,
                    State=contactPropertyMapModel.State,
                    CountryId=contactPropertyMapModel.CountryId,
                    City = contactPropertyMapModel.City,
                    Address=contactPropertyMapModel.Address,
                    Zip = contactPropertyMapModel.Zip,
                    Company = contactPropertyMapModel.Comapny,
                    Email = contactPropertyMapModel.Email,
                    PhoneNo = contactPropertyMapModel.Phone
                };
                var createdPerson = _personRepository.Create(person);
                _unitOfWork.Commit();
                var contact = new Contact
                {
                    PersonId = createdPerson.Id,
                    Description = contactPropertyMapModel.Comments,
                    RefId = "C" + (++contactCount),
                    CreatedByUserId = contactPropertyMapModel.CreatedBy,
                    CreatedOn = DateTime.UtcNow,
                    OfficePhone = contactPropertyMapModel.OfficePhone,
                    SecondaryEmail = contactPropertyMapModel.SecondaryEmail,
                    ContactType = contactPropertyMapModel.ContactType
                };
                var contactResult = _contactRepository.Create(contact);
                _unitOfWork.Commit();
                var contactPropertyInfo = new ContactPaymentInfo
                {
                    Bank = contactPropertyMapModel.Bank,
                    BankAccountNumber = contactPropertyMapModel.BankAccountNumber,
                    IFSC = contactPropertyMapModel.BankIFSC,
                    Branch = contactPropertyMapModel.Branch,
                    CashPaymentMode = contactPropertyMapModel.CashPaymentMode,
                    ChequePaymentMode = contactPropertyMapModel.ChequePaymentMode,
                    Description = contactPropertyMapModel.Description,
                    EmailAlerts = contactPropertyMapModel.EmailAlerts,
                    EmailStatements = contactPropertyMapModel.EmailStatements,
                    OnlinePaymentMode = contactPropertyMapModel.OnlinePaymentMode,
                    Ownership = contactPropertyMapModel.Ownership,
                    TaxEligible = contactPropertyMapModel.TaxEligible,
                    TaxId = contactPropertyMapModel.TaxId,
                    TaxPayerName = contactPropertyMapModel.TaxPayerName
                };
                var createdContactPropertyInfo = _contactPaymentInfoRepository.Create(contactPropertyInfo);
                _unitOfWork.Commit();
                var propertyContact = new PaymentContact
                {
                    ContactId = contactResult.Id,
                    ContactPaymentInfoId = createdContactPropertyInfo.Id
                };
                _paymentContactRepository.CreatePropertyContact(propertyContact);
                _elasticSearchService.IndexContact(contactPropertyMapModel);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }
        public PaymentContact GetPropertyContactByPropertyId(long contactPropertyInfoId)
        {
            var propertyContact = _paymentContactRepository.GetPropertyContactByPropertyId(contactPropertyInfoId);
            return propertyContact;
        }
        public PaymentContact GetPropertyContactByContactId(long contactId)
        {
            var propertyContact = _paymentContactRepository.GetPropertyContactByContactId(contactId);
            return propertyContact;
        }
        public bool UpdatePropertyContact(PaymentContactMapModel contactPropertyMapModel)
        {
            var contact = _contactRepository.Get(contactPropertyMapModel.ContactId);
            var propertyContact = _paymentContactRepository.GetPropertyContactByContactId(contact.Id);
            if (propertyContact != null)
            {
                var contactPropertyInfo = _contactPaymentInfoRepository.Get(propertyContact.ContactPaymentInfoId);

                var person = _personService.GetPersonById(contact.PersonId);

                person.FirstName = contactPropertyMapModel.FirstName;
                person.LastName = contactPropertyMapModel.LastName;
                person.Title = contactPropertyMapModel.Title;
                person.City = contactPropertyMapModel.City;
                person.Zip = contactPropertyMapModel.Zip;
                person.Company = contactPropertyMapModel.Comapny;
                person.Email = contactPropertyMapModel.Email;
                person.PhoneNo = contactPropertyMapModel.Phone;
                person.Address = contactPropertyMapModel.Address;
                person.State=contactPropertyMapModel.State;
                person.CountryId = contactPropertyMapModel.CountryId;
                _personRepository.Update(person);
                _unitOfWork.Commit();

                if (contact != null)
                {
                    contact.ContactType = contactPropertyMapModel.ContactType;
                    contact.Description = contactPropertyMapModel.Comments;
                    contact.OfficePhone = contactPropertyMapModel.OfficePhone;
                    contact.SecondaryEmail = contactPropertyMapModel.SecondaryEmail;
                    _contactRepository.Update(contact);

                    //contactPropertyInfo.AccountId = contactPropertyMapModel.AccountId;
                    //contactPropertyInfo.AgentId = contactPropertyMapModel.AgentId;
                    contactPropertyInfo.Bank = contactPropertyMapModel.Bank;
                    contactPropertyInfo.BankAccountNumber = contactPropertyMapModel.BankAccountNumber;
                    contactPropertyInfo.IFSC = contactPropertyMapModel.BankIFSC;
                    contactPropertyInfo.Branch = contactPropertyMapModel.Branch;
                    contactPropertyInfo.CashPaymentMode = contactPropertyMapModel.CashPaymentMode;
                    contactPropertyInfo.ChequePaymentMode = contactPropertyMapModel.ChequePaymentMode;
                    contactPropertyInfo.Description = contactPropertyMapModel.Description;
                    contactPropertyInfo.EmailAlerts = contactPropertyMapModel.EmailAlerts;
                    contactPropertyInfo.EmailStatements = contactPropertyMapModel.EmailStatements;
                    contactPropertyInfo.OnlinePaymentMode = contactPropertyMapModel.OnlinePaymentMode;
                    contactPropertyInfo.Ownership = contactPropertyMapModel.Ownership;
                    contactPropertyInfo.TaxEligible = contactPropertyMapModel.TaxEligible;
                    contactPropertyInfo.TaxId = contactPropertyMapModel.TaxId;
                    contactPropertyInfo.TaxPayerName = contactPropertyMapModel.TaxPayerName;
                    _contactPaymentInfoRepository.Update(contactPropertyInfo);

                    _elasticSearchService.UpdateContact(contactPropertyMapModel);
                    _unitOfWork.Commit();
                    return true;
                }
            }

            return false;
        }
        public bool DeletePropertyContact(long contactId)
        {
            var result = _paymentContactRepository.DeletePropertyContact(contactId);
            _unitOfWork.Commit();
            return result;
        }
        public IList<PaymentContact> GetAllPaymentContactsByUserId(long userId)
        {
            return _paymentContactRepository.GetAllPaymentContactsByUserId(userId);
        }
        public IList<PaymentContact> GetAllPaymentContacts()
        {
            return _paymentContactRepository.GetAllPaymentContacts();
        }
        public SearchResult<PaymentContact> SearchContact(PaymentContactSearchFilter filters, int pageSize, int page)
        {
            return _paymentContactRepository.SearchContact(filters, pageSize, page);
        }
    }
}