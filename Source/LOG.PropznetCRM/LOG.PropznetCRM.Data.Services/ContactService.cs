using Common.Data.Interfaces;
using Common.Data.Models;
using LOG.PropznetCRM.Data.Core;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;
using LOG.PropznetCRM.Data.ElasticSearch;
using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Entities.Enum;
using LOG.PropznetCRM.Data.Model.Contact;
using System;
using System.Collections.Generic;

namespace LOG.PropznetCRM.Data.Services
{
    public class ContactService : IContactService
    {
        readonly IContactRepository _contactRepository;
        readonly IUnitOfWork _iUnitOfWork;
        readonly ElasticSearchService _elasticSearchService;
        readonly IAgentService _agentService;
        public ContactService(IContactRepository contactRepository, IUnitOfWork iUnitOfWork, IElasticSearchSettings elasticsearchsettings, IAgentService agentService)
        {
            _contactRepository = contactRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _iUnitOfWork = iUnitOfWork;
            _agentService = agentService;
        }
        public Contact CreateContact(ContactModel contactmodel)
        {
            if (contactmodel != null)
            {
                var contactCount = _contactRepository.GetContactCountByUser(contactmodel.CreatedBy);
                var contact = new Contact
                {
                    AccountId = contactmodel.AccountId,
                    AgentId = contactmodel.AgentId,
                    CommunicationDetailId = contactmodel.CommunicationDetailId,
                    FirstName = contactmodel.FirstName,
                    LastName = contactmodel.LastName,
                    Comments = contactmodel.Comments,
                    Title = contactmodel.Title,
                    RefId = "C" + (++contactCount),
                    CreatedBy = contactmodel.CreatedBy,
                    CreatedOn = DateTimeOffset.UtcNow
                };
                var contactResult = _contactRepository.Create(contact);
                _elasticSearchService.IndexContact(contactmodel);
                _iUnitOfWork.Commit();
                return contactResult;
            }

            return null;
        }

        public bool UpdateContact(ContactModel contactmodel)
        {
            var contact = _contactRepository.Get(contactmodel.Id);
            if (contact != null)
            {
                contact.AccountId = contactmodel.AccountId;
                contact.AgentId = contactmodel.AgentId;
                contact.CommunicationDetailId = contactmodel.CommunicationDetailId;
                contact.FirstName = contactmodel.FirstName;
                contact.LastName = contactmodel.LastName;
                contact.Comments = contactmodel.Comments;
                contact.Title = contactmodel.Title;
                _contactRepository.Update(contact);
                _elasticSearchService.UpdateContact(contactmodel);
                _iUnitOfWork.Commit();
                return true;
            }

            return false;
        }

        public Contact GetContact(long id)
        {
            return _contactRepository.GetContact(id);
        }

        public IList<Contact> GetAllContactsByUserId(long userId, IList<int> permissionCodes)
        {
            if (PermissionChecker.CheckPermission(permissionCodes, PermissionCodes.ViewContact))
            {
                var agent = _agentService.GetAgentByUserId(userId);
                return _contactRepository.GetAllContactsByUserId(userId, agent.Id);
            }
            
            throw new UnauthorizedAccessException();
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
            {
                contact.DeletedOn = DateTime.Now;
            }

            var contactModel = new ContactModel
            {
                Account = contact.Account.Name,
                AccountId = contact.AccountId,
                Address = contact.CommunicationDetail.Address,
                AgentId = contact.AgentId,
                Comments = contact.Comments,
                CommunicationDetailId = contact.CommunicationDetail.Id,
                CreatedBy = contact.CreatedBy,
                Email = contact.CommunicationDetail.Email,
                Enitytype = EntityType.Contact,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.CommunicationDetail.Phone,
                Title = contact.Title
            };

            _contactRepository.Delete(id);
            _elasticSearchService.DeleteContact(contactModel);
            _iUnitOfWork.Commit();
            return true;
        }
    }
}