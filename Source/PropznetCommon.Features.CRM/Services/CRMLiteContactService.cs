using System;
using System.Collections.Generic;
using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.DAL;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.CRM.ElasticSearch;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Entities.Enum;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Contact;

namespace PropznetCommon.Features.CRM.Services
{
    public class CRMLiteContactService : ICRMLiteContactService
    {
        readonly IContactRepository _contactRepository;
        readonly IUnitOfWork _iUnitOfWork;
        readonly ElasticSearchService _elasticSearchService;
        readonly IPersonRepository _personRepository;
        public CRMLiteContactService(IContactRepository contactRepository, IUnitOfWork iUnitOfWork,
            IElasticSearchSettings elasticsearchsettings, IPersonRepository personRepository)
        {
            _contactRepository = contactRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _iUnitOfWork = iUnitOfWork;
            _personRepository = personRepository;
        }
        public Contact CreateContact(ContactModel contactmodel)
        {
            if (contactmodel != null)
            {
                var person = new Person
                {
                    FirstName = contactmodel.FirstName,
                    LastName = contactmodel.LastName,
                    Title = contactmodel.Title,
                    CreatedByUserId = contactmodel.CreatedBy,
                    City = contactmodel.City,
                    Region = contactmodel.Region,
                    Zip = contactmodel.Zip,
                    Company = contactmodel.Comapny,
                    Address = contactmodel.Address,
                    Email = contactmodel.Email,
                    PhoneNo = contactmodel.Phone,
                    State = contactmodel.State,
                };
                if (contactmodel.CountryId > 0)
                    person.CountryId = contactmodel.CountryId;
                var newPerson=_personRepository.Create(person);
                _iUnitOfWork.Commit();
                ContactType type = ContactType.Individual;
                if(contactmodel.IsCompany!=null)
                 type = (ContactType)Enum.Parse(typeof(ContactType), contactmodel.IsCompany);
                contactmodel.ContactType = type;
                var contactCount = _contactRepository.GetContactCountByUser(contactmodel.CreatedBy);
                var contact = new Contact
                {
                    //AccountId = contactmodel.AccountId,
                    //AgentId = contactmodel.AgentId,
                    Description = contactmodel.Comments,
               
                    RefId = "C" + (++contactCount),
                    CreatedOn = DateTime.UtcNow,
                    //Bank = contactmodel.Bank,
                    //BankAccountNumber = contactmodel.BankAccountNumber,
                    //BankIFSC = contactmodel.BankIFSC,
                    //Branch = contactmodel.Branch,
                    //CashPaymentMode = contactmodel.CashPaymentMode,
                    //ChequePaymentMode = contactmodel.ChequePaymentMode,
               
                    //Description = contactmodel.Description,
                    //EmailAlerts = contactmodel.EmailAlerts,
                    //EmailStatements = contactmodel.EmailStatements,
                    OfficePhone = contactmodel.OfficePhone,
                    //OnlinePaymentMode = contactmodel.OnlinePaymentMode,
                    //Ownership = contactmodel.Ownership,
                    SecondaryEmail = contactmodel.SecondaryEmail,
                    //TaxEligible = contactmodel.TaxEligible,
                    //TaxId = contactmodel.TaxId,
                    //TaxPayerName = contactmodel.TaxPayerName,
                    ContactType = type,
                    PersonId=newPerson.Id,
                    CreatedByUserId=contactmodel.CreatedBy
                };
                var contactResult = _contactRepository.Create(contact);
                //_elasticSearchService.IndexContact(contactmodel);
                _iUnitOfWork.Commit();
                return contactResult;
            }

            return null;
        }
        public bool UpdateContact(ContactModel contactmodel)
        {
            var contact = _contactRepository.Get(contactmodel.Id);

            ContactType type = (ContactType)Enum.Parse(typeof(ContactType), contactmodel.IsCompany);
            contactmodel.ContactType = type;
            if (contact != null)
            {
                //contact.AccountId = contactmodel.AccountId;
                //contact.AgentId = contactmodel.AgentId;
                contact.ContactType = contactmodel.ContactType;
                contact.Description = contactmodel.Comments;
                //contact.Bank = contactmodel.Bank;
                //contact.BankAccountNumber = contactmodel.BankAccountNumber;
                //contact.BankIFSC = contactmodel.BankIFSC;
                //contact.Branch = contactmodel.Branch;
                //contact.CashPaymentMode = contactmodel.CashPaymentMode;
                //contact.ChequePaymentMode = contactmodel.ChequePaymentMode;
                //contact.Description = contactmodel.Description;
                //contact.EmailAlerts = contactmodel.EmailAlerts;
                //contact.EmailStatements = contactmodel.EmailStatements;
                contact.OfficePhone = contactmodel.OfficePhone;
                //contact.OnlinePaymentMode = contactmodel.OnlinePaymentMode;
                //contact.Ownership = contactmodel.Ownership;
                contact.SecondaryEmail = contactmodel.SecondaryEmail;
                //contact.TaxEligible = contactmodel.TaxEligible;
                //contact.TaxId = contactmodel.TaxId;
                //contact.TaxPayerName = contactmodel.TaxPayerName;
                _contactRepository.Update(contact);
                //_elasticSearchService.UpdateContact(contactmodel);
                _iUnitOfWork.Commit();
               var person = _personRepository.Get(contact.PersonId);
            if (person != null)
            {
                person.FirstName = contactmodel.FirstName;
                person.LastName = contactmodel.LastName;
                person.Title = contactmodel.Title;
                person.CreatedByUserId = contactmodel.CreatedBy;
                person.City = contactmodel.City;
                person.Region = contactmodel.Region;
                person.Zip = contactmodel.Zip;
                if (contactmodel.CountryId > 0)
                    person.CountryId = contactmodel.CountryId;
                person.Company = contactmodel.Comapny;
                person.Address = contactmodel.Address;
                person.CountryId = contactmodel.CountryId;
                person.Email = contactmodel.Email;
                person.PhoneNo = contactmodel.Phone;
                person.State = contactmodel.State; 
            };
                _personRepository.Update(person);
                _iUnitOfWork.Commit();
                return true;
            }

            return false;
        }
        public Contact GetContact(long id)
        {
            return _contactRepository.GetContact(id);
        }
        public IList<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }
        public SearchResult<Contact> Search(ContactSearchFilter searchargument, int pagesize, int count)
        {
            return _contactRepository.SearchContacts(searchargument, pagesize, count);
        }
        public bool DeleteContact(long id)
        {
            var contact = _contactRepository.GetContact(id);
            var result = _contactRepository.DeleteContact(id);
            _iUnitOfWork.Commit();
            try
            {
                var contactModel = new ContactModel
                {
                    //Account = contact.Account.Name,
                    //AccountId = contact.AccountId,
                    Address = contact.Person.Address,
                    // AgentId = contact.AgentId,
                    Comments = contact.Description,
                    CommunicationDetailId = contact.Person.Id,
                    CreatedBy = contact.CreatedByUserId,
                    Email = contact.Person.Email,
                    Enitytype = CRMEntityType.Contact,
                    FirstName = contact.Person.FirstName,
                    LastName = contact.Person.LastName,
                    Phone = contact.Person.PhoneNo,
                    Title = contact.Person.Title
                };

                _elasticSearchService.DeleteContact(contactModel);
            }
            catch (Exception ex)
            { }
            return result;
        }
        public IList<Contact> GetAllContactsByUserId(long userId, IList<int> permissionCodes)
        {
            //var agent = _agentService.GetAgentInfoByUserId(userId);
            return _contactRepository.GetAllContactsByUserId(userId);
        }
    }
}