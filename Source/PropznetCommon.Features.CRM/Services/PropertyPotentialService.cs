using System;
using Common.Auth.SingleTenant.Entities;
using Common.Auth.SingleTenant.Interfaces.DAL;
using Common.Data.Interfaces;
using PropznetCommon.Features.CRM.ElasticSearch;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.Potential;
using System.Collections.Generic;
using PropznetCommon.Features.CRM.Model;

namespace PropznetCommon.Features.CRM.Services
{
    public class PropertyPotentialService : IPropertyPotentialService
    {
        readonly IPropertyPotentialRepository _propertyPotentialRepository;
        readonly IPotentialPropertyInfoRepository _potentialPropertyInfoRepository;
        readonly IPotentialRepository _potentialRepository;
        readonly ElasticSearchService _elasticSearchService;
        readonly IPersonRepository _personRepository;
        readonly IAgentInfoService _agentInfoService;
        readonly IUnitOfWork _unitOfWork;
        public PropertyPotentialService(IPropertyPotentialRepository propertyPotentialRepository,
            IPotentialRepository potentialRepository,
            IPotentialPropertyInfoRepository potentialPropertyInfoRepository,
            IElasticSearchSettings elasticsearchsettings,
            IUnitOfWork unitOfWork, IPersonRepository personRepository,
            IAgentInfoService agentInfoService)
        {
            _propertyPotentialRepository = propertyPotentialRepository;
            _potentialRepository = potentialRepository;
            _potentialPropertyInfoRepository = potentialPropertyInfoRepository;
            _elasticSearchService = new ElasticSearchService(elasticsearchsettings.ElasticSearchUrl(), elasticsearchsettings.GetDefaultIndex());
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _agentInfoService = agentInfoService;
        }
        public PropertyPotential CreatePropertyPotential(PropertyPotentialMapModel propertyPotentialMapModel)
        {
            if (propertyPotentialMapModel != null)
            {
                var person = new Person
                {
                    FirstName = propertyPotentialMapModel.PotentialName
                };
                var newPerson = _personRepository.Create(person);
                _unitOfWork.Commit();
                var potentialCount = _potentialRepository.GetPotentialCountByUser(propertyPotentialMapModel.CreatedBy);
                var potential = new Potential
                {
                    AccountId = propertyPotentialMapModel.AccountId,
                    AssignedToUserId = propertyPotentialMapModel.selectedAgent,
                    Description = propertyPotentialMapModel.Comments,
                    ContactId = propertyPotentialMapModel.SelectedContact,
                    CreatedByUserId = propertyPotentialMapModel.CreatedBy,
                    CreatedOn = DateTime.UtcNow,
                    ExpectedAmount = propertyPotentialMapModel.PotentialAmount,
                    ExpectedCloseDate = propertyPotentialMapModel.ExpectedCloseDate,
                    LeadSourceId = propertyPotentialMapModel.SelectedLeadSource,
                    LeadSourceName = propertyPotentialMapModel.LeadSource,
                    SalesStageId = propertyPotentialMapModel.SelectedSalesStage,
                    RefId = "P" + (++potentialCount),
                    PersonId = newPerson.Id
                };
                var potentialResult = _potentialRepository.Create(potential);
                _unitOfWork.Commit();

                var potentialPropertyInfo = new PotentialPropertyInfo
                {
                    CreatedOn = DateTime.UtcNow,
                    ExpectedMoveInDate = propertyPotentialMapModel.ExpectedMoveInDate,
                    Area = propertyPotentialMapModel.Area,
                    Baths = propertyPotentialMapModel.Baths,
                    Beds = propertyPotentialMapModel.Beds,
                    BudgetFrom = propertyPotentialMapModel.BudgetFrom,
                    BudgetTo = propertyPotentialMapModel.BudgetTo,
                    City = propertyPotentialMapModel.City,
                    CountryId = propertyPotentialMapModel.CountryId,
                    Floor = propertyPotentialMapModel.Floor,
                    PropertyCategoryId = propertyPotentialMapModel.selectedPropertyCategory,
                    PropertyType = propertyPotentialMapModel.selectedProperty,
                    Region = propertyPotentialMapModel.Region,
                    State = propertyPotentialMapModel.State
                };
                var createdPotentialPropertyInfo = _potentialPropertyInfoRepository.Create(potentialPropertyInfo);
                _unitOfWork.Commit();

                var propertyPotential = new PropertyPotential
                {
                    PotentialId = potentialResult.Id,
                    PotentialPropertyInfoId = createdPotentialPropertyInfo.Id,
                    CreatedOn=DateTime.UtcNow
                };
                var propertyCreate = _propertyPotentialRepository.CreatePropertyPotential(propertyPotential);
                // _elasticSearchService.IndexPotential(contactPropertyMapModel);
                _unitOfWork.Commit();
                return propertyCreate;
            }
            return null;
        }
        public PropertyPotential GetPropertyPotentialByPropertyId(long potentialPropertyInfoId)
        {
            var potentialContact = _propertyPotentialRepository.GetPropertyPotentialByPropertyPotentialInfoId(potentialPropertyInfoId);
            return potentialContact;
        }
        public PropertyPotential GetPropertyPotentialByPotentialId(long potentialId)
        {
            var potentialContact = _propertyPotentialRepository.GetPropertyPotentialByPotentialId(potentialId);
            return potentialContact;
        }
        public bool UpdatePropertyPotential(PropertyPotentialMapModel propertyPotentialMapModel)
        {
            var potential = _potentialRepository.Get(propertyPotentialMapModel.PotentialId);
            var propertyPotential = _propertyPotentialRepository.GetPropertyPotentialByPotentialId(potential.Id);
            if (propertyPotential != null)
            {
                var potentialPropertyInfo = _potentialPropertyInfoRepository.Get(propertyPotential.PotentialPropertyInfoId);
                if (potentialPropertyInfo != null)
                {
                    potential.AccountId = propertyPotentialMapModel.AccountId;
                    potential.AssignedToUserId = propertyPotentialMapModel.selectedAgent;
                    potential.Description = propertyPotentialMapModel.Comments;
                    potential.ContactId = propertyPotentialMapModel.SelectedContact;
                    potential.CreatedOn = DateTime.UtcNow;
                    potential.ExpectedAmount = propertyPotentialMapModel.PotentialAmount;
                    potential.ExpectedCloseDate = propertyPotentialMapModel.ExpectedCloseDate;
                    potential.LeadSourceId = propertyPotentialMapModel.SelectedLeadSource;
                    potential.LeadSourceName = propertyPotentialMapModel.LeadSource;
                    potential.SalesStageId = propertyPotentialMapModel.SelectedSalesStage;
                    _potentialRepository.Update(potential);
                    _unitOfWork.Commit();
                    var person = _personRepository.GetBy(i => i.Id == potential.PersonId);
                    if (person != null)
                    {
                        person.FirstName = propertyPotentialMapModel.PotentialName;
                    };
                    _personRepository.Update(person);
                    _unitOfWork.Commit();
                    potentialPropertyInfo.ExpectedMoveInDate = propertyPotentialMapModel.ExpectedMoveInDate;
                    potentialPropertyInfo.Area = propertyPotentialMapModel.Area;
                    potentialPropertyInfo.Baths = propertyPotentialMapModel.Baths;
                    potentialPropertyInfo.Beds = propertyPotentialMapModel.Beds;
                    potentialPropertyInfo.BudgetFrom = propertyPotentialMapModel.BudgetFrom;
                    potentialPropertyInfo.BudgetTo = propertyPotentialMapModel.BudgetTo;
                    potentialPropertyInfo.City = propertyPotentialMapModel.City;
                    potentialPropertyInfo.CountryId = propertyPotentialMapModel.CountryId;
                    potentialPropertyInfo.Floor = propertyPotentialMapModel.Floor;
                    potentialPropertyInfo.PropertyCategoryId = propertyPotentialMapModel.selectedPropertyCategory;
                    potentialPropertyInfo.PropertyType = propertyPotentialMapModel.selectedProperty;
                    potentialPropertyInfo.Region = propertyPotentialMapModel.Region;
                    potentialPropertyInfo.State = propertyPotentialMapModel.State;
                    _potentialPropertyInfoRepository.Update(potentialPropertyInfo);
                    _unitOfWork.Commit();
                    return true;
                }
            }
            return false;
        }
        public bool DeletePropertyPotential(long potentialId)
        {
            var result = _propertyPotentialRepository.DeletePropertyPotential(potentialId);
            _unitOfWork.Commit();
            return result;
        }
        public bool DeletePropertyPotentialBypotentialId(long potentialId)
        {
            var propertyPotential = _propertyPotentialRepository.GetPropertyPotentialByPotentialId(potentialId);
            var result= _propertyPotentialRepository.DeletePropertyPotential(propertyPotential.Id);
            _unitOfWork.Commit();
            return result;
        }
        public IList<PropertyPotential> GetAllPropertyPotentialsByUserId(long userId)
        {
            return _propertyPotentialRepository.GetAllPropertyPotentialsByUserId(userId);
        }
        public IList<PropertyPotential> GetAllPropertyPotentials()
        {
            return _propertyPotentialRepository.GetAllPropertyPotentials();
        }
        public SearchResult<PropertyPotential> SearchPotential(PropertyPotentialSearchFilter filters, int pageSize, int page)
        {
            return _propertyPotentialRepository.SearchPotential(filters, pageSize, page);
        }
    }
}