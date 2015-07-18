using LOG.PropznetCRM.Data.Entities.Enum;
using LOG.PropznetCRM.Data.Model.Account;
using LOG.PropznetCRM.Data.Model.Agent;
using LOG.PropznetCRM.Data.Model.Contact;
using LOG.PropznetCRM.Data.Model.Lead;
using LOG.PropznetCRM.Data.Model.Potential;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LOG.PropznetCRM.Data.ElasticSearch
{
    public class SearchResult
    {
        public IList<AccountModel> AccountSearchResult { get; set; }
        public IList<ContactModel> ContactSearchResult { get; set; }
        public IList<LeadModel> LeadSearchResult { get; set; }
        public IList<PotentialModel> PotentialSearchResult { get; set; }
        public IList<AgentModel> AgentSearchResult { get; set; }
        public SearchResult()
        {
            AccountSearchResult = new List<AccountModel>();
            ContactSearchResult= new List<ContactModel>();
            LeadSearchResult= new List<LeadModel>();
            PotentialSearchResult = new List<PotentialModel>();
            AgentSearchResult = new List<AgentModel>();
        }
    }
    public class ElasticSearchService
    {
        readonly ElasticClient _elasticClient; 
        public ElasticSearchService(string url, string defaultindex)
        {
            var node = new Uri(url);
            var settings = new ConnectionSettings(node, defaultindex);
            _elasticClient = new ElasticClient(settings);
        }
        //Account
        #region Account
        public void IndexAccount(AccountModel accountModel)
        {
            _elasticClient.Index(accountModel);
        }
        public void DeleteAccount(AccountModel accountModel)
        {
            _elasticClient.Delete(accountModel);
        }
        public void UpdateAccount(AccountModel accountModel)
        {
            _elasticClient.Update<AccountModel, object>(u => u.Id(accountModel.Id)
                                .Doc(new
                                {
                                    Id = accountModel.Id,
                                    Name = accountModel.AccountName,
                                    Address = accountModel.Address,
                                    Email = accountModel.Email,
                                    Phone = accountModel.Phone,
                                    Website = accountModel.Website,
                                    Industry = accountModel.Industry,
                                    Comments = accountModel.Comment,
                                    Enitytype = EntityType.Account
                                }).DocAsUpsert());
        }
        #endregion

        #region Contact
        public void IndexContact(ContactModel contactModel)
        {
            _elasticClient.Index(contactModel);
        }
        public void DeleteContact(ContactModel contactModel)
        {
            _elasticClient.Delete(contactModel);
        }
        public void UpdateContact(ContactModel contactModel)
        {
            _elasticClient.Update<ContactModel, object>(u => u.Id(contactModel.Id)
                                .Doc(new
                                {
                                    Id = contactModel.Id,
                                    FirstName = contactModel.FirstName,
                                    LastName = contactModel.LastName,
                                    Title = contactModel.Title,
                                    Address = contactModel.Address,
                                    Account = contactModel.Account,
                                    Email = contactModel.Email,
                                    Phone = contactModel.Phone,
                                    Enitytype = EntityType.Contact
                                }).DocAsUpsert());
        }
        #endregion

        #region Lead
        public void IndexLead(LeadModel leadModel)
        {
            _elasticClient.Index(leadModel);
        }
        public void DeleteLead(LeadModel leadModel)
        {
            _elasticClient.Delete(leadModel);
        }
        public void UpdateLead(LeadModel leadModel)
        {
            _elasticClient.Update<LeadModel, object>(u => u
                                .Id(leadModel.Id)
                                .Doc(new
                                {
                                    Id = leadModel.Id,
                                    FirstName = leadModel.FirstName,
                                    LastName = leadModel.LastName,
                                    Company = leadModel.Company,
                                    Phone = leadModel.Phone,
                                    Website = leadModel.Website,
                                    Email = leadModel.Email,
                                    LeadSourceName = leadModel.LeadSourceName,
                                    LeadStatus = leadModel.LeadStatus.ToString(),
                                    Comments = leadModel.Comment,
                                    Enitytype = EntityType.Lead
                                }).DocAsUpsert());

        }
        #endregion

        #region Potential
        public void IndexPotential(PotentialModel potentialModel)
        {
            _elasticClient.Index(potentialModel);
        }
        public void DeletePotential(PotentialModel potentialModel)
        {
            _elasticClient.Delete(potentialModel);
        }
        public void UpdatePotential(PotentialModel potentialModel)
        {
            _elasticClient.Update<PotentialModel, object>(u => u
                                .Id(potentialModel.Id)
                                .Doc(new
                                {
                                    Name = potentialModel.PotentialName,
                                    Account = potentialModel.Account,
                                    SalesStage = potentialModel.SalesStage,
                                   // PropertyType = potentialModel.,
                                    ExpectedAmount = potentialModel.PotentialAmount,
                                    ExpectedCloseDate = potentialModel.ExpectedCloseDate,
                                    LeadSource = potentialModel.LeadSource,
                                    Comments = potentialModel.Comments,
                                    Id = potentialModel.Id,
                                        Enitytype = EntityType.Potential }).DocAsUpsert());
                                                           

        }
        #endregion

        #region Agent
        public void IndexAgent(AgentModel agentModel)
        {
            _elasticClient.Index(agentModel);
        }
        public void DeleteAgent(AgentModel agentModel)
        {
            _elasticClient.Delete(agentModel);
        }

        public void UpdateAgent(AgentModel agentModel)
        {
            _elasticClient.Update<AgentModel, object>(u => u
                                .Id(agentModel.Id)
                                .Doc(new
                                {
                                 Id =agentModel.Id,
                                 FirstName =agentModel.FirstName,
                                 LastName =agentModel.LastName,
                                 Email =agentModel.Email,
                                 Phone =agentModel.Phone,
                                 Address =agentModel.Address,
                                 CommunicationDetailID =agentModel.CommunicationDetailID,
                                 DEDLicenseNumber =agentModel.DEDLicenseNumber,
                                 RERARegistrationNumber =agentModel.RERARegistrationNumber,
                                 IsListingMember =agentModel.IsListingMember,
                                 Image =agentModel.Image,
                                 UserId =agentModel.UserId,
                                 CreatedBy =agentModel.CreatedBy
                                }).DocAsUpsert());
        }

        #endregion
        public SearchResult GetElasticSearch(string queryValue)
        {
            var accountSearchResult = _elasticClient.Search<AccountModel>(body => body
                      .Query(query =>
                      query.QueryString(qs => qs.Query(queryValue)))).Documents.ToList();

            var contactSearchResult = _elasticClient.Search<ContactModel>(body =>
                      body.Query(query =>
                      query.QueryString(qs => qs.Query(queryValue)))).Documents.ToList();

            var leadSearchResult = _elasticClient.Search<LeadModel>(body =>
                        body.Query(query =>
                        query.QueryString(qs => qs.Query(queryValue)))).Documents.ToList();

            var potentialSearchResult = _elasticClient.Search<PotentialModel>(body =>
                        body.Query(query =>
                        query.QueryString(qs => qs.Query(queryValue)))).Documents.ToList();

            var agentSearchResult = _elasticClient.Search<AgentModel>(body =>
                        body.Query(query =>
                        query.QueryString(qs => qs.Query(queryValue)))).Documents.ToList();

            var searchResult = new SearchResult();
            if (accountSearchResult != null)
                searchResult.AccountSearchResult=accountSearchResult;
            if (contactSearchResult != null)
                searchResult.ContactSearchResult=contactSearchResult;
            if (leadSearchResult != null)
                searchResult.LeadSearchResult=leadSearchResult;
            if (potentialSearchResult != null)
                searchResult.PotentialSearchResult=potentialSearchResult;
            if (agentSearchResult != null)
                searchResult.AgentSearchResult = agentSearchResult;

            return searchResult;
        }
    }
}