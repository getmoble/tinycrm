using System;
using System.Data.Entity;
using System.Linq;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.Data;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using System.Collections.Generic;
using PropznetCommon.Features.CRM.Model;
using PropznetCommon.Features.CRM.Model.Potential;

namespace PropznetCommon.Features.CRM.DAL
{
    public class PropertyPotentialRepository : IPropertyPotentialRepository
    {
        readonly ICRMDataContext _dataContext;
        public PropertyPotentialRepository(ICRMDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public PropertyPotential CreatePropertyPotential(PropertyPotential propertyPotential)
        {
            var createPropertyPotential = _dataContext.PropertyPotentials.Add(propertyPotential);
            return createPropertyPotential;
        }
        public IList<PropertyPotential> GetAllPropertyPotentialsByUserId(long userId)
        {
            return _dataContext.PropertyPotentials
                .Where(p => (p.CreatedByUserId == userId || p.Potential.AssignedToUserId == userId) && !p.DeletedOn.HasValue)
                .Include(a => a.Potential.Account)
                .Include(c => c.Potential.Contact)
                .Include(c => c.Potential.Person)
                .Include(c => c.Potential.AssignedToUser)
                .Include(c => c.Potential.Account)
                .Include(c => c.Potential.Account.Person)
                .Include(c => c.Potential.Account.AssignedToUser)
                .Include(l => l.Potential.LeadSource)
                .Include(l => l.Potential.Person)
                .Include(l => l.PotentialPropertyInfo)
                .Include(p => p.PotentialPropertyInfo.PropertyCategory)
                .Include(s => s.Potential.SalesStage)
                .Include(s => s.PotentialPropertyInfo.Country).ToList();
        }
        public IList<PropertyPotential> GetAllPropertyPotentials()
        {
            return _dataContext.PropertyPotentials
                .Where(p => !p.DeletedOn.HasValue)
                .Include(a => a.Potential.Account)
                .Include(c => c.Potential.Contact)
                .Include(c => c.Potential.Person)
                .Include(c => c.Potential.AssignedToUser)
                .Include(c => c.Potential.Account)
                .Include(c => c.Potential.Account.Person)
                .Include(c => c.Potential.Account.AssignedToUser)
                .Include(l => l.Potential.LeadSource)
                .Include(l => l.PotentialPropertyInfo)
                .Include(p => p.PotentialPropertyInfo.PropertyCategory)
                .Include(s => s.Potential.SalesStage)
                .Include(s => s.PotentialPropertyInfo.Country).ToList();
        }
        public PropertyPotential GetPropertyPotentialByPropertyPotentialInfoId(long potentialInfoId)
        {
            return _dataContext.PropertyPotentials
                .Include(i => i.Potential)
                .Include(u => u.PotentialPropertyInfo)
                .SingleOrDefault(p => p.PotentialPropertyInfoId == potentialInfoId);
        }
        public PropertyPotential GetPropertyPotentialByPotentialId(long potentialId)
        {
            return _dataContext.PropertyPotentials
                .Include(a => a.Potential.Account)
                .Include(c => c.Potential.Contact)
                .Include(c => c.Potential.Contact.Person)
                .Include(c => c.Potential.Person)
                .Include(c => c.Potential.AssignedToUser)
                .Include(c => c.Potential.Account)
                .Include(c => c.Potential.Account.Person)
                .Include(c => c.Potential.Account.AssignedToUser)
                .Include(l => l.Potential.LeadSource)
                .Include(l => l.PotentialPropertyInfo)
                .Include(p => p.PotentialPropertyInfo.PropertyCategory)
                .Include(s => s.Potential.SalesStage)
                .Include(s => s.PotentialPropertyInfo.Country)
                    .SingleOrDefault(p => p.PotentialId == potentialId);
        }
        public SearchResult<PropertyPotential> SearchPotential(PropertyPotentialSearchFilter filters, int pageSize, int page)
        {
            var result = new SearchResult<PropertyPotential>();
            IQueryable<PropertyPotential> query = _dataContext.PropertyPotentials
                .OrderByDescending(x => x.CreatedOn)
                .Include(p => p.Potential.AssignedToUser)
                .Include(p => p.Potential.Account)
                .Include(p => p.Potential.Contact)
                .Include(p => p.Potential.LeadSource)
                //.Include(p => p.Property)
                //.Include(p => p.Property.City)
                //.Include(p => p.Property.City.State)
                //.Include(p => p.Property.City.State.Country)
                //.Include(p => p.Property.PropertyCategory)
                .Include(p => p.Potential.SalesStage);

            if (filters.LeadSourceId.HasValue)
                query = query.Where(p => p.Potential.LeadSourceId == (filters.LeadSourceId));

            //if (filters.PropertyTypeId.HasValue)
            //    query = query.Where(p => p.Property.PropertyType == filters.PropertyTypeId);

            if (filters.SalesStageId.HasValue)
                query = query.Where(p => p.Potential.SalesStageId == (filters.SalesStageId));

            if (filters.AgentId.HasValue)
                query = query.Where(p => p.Potential.AssignedToUserId == (filters.AgentId));

            if (!String.IsNullOrEmpty(filters.Account))
                query = query.Where(p => p.Potential.Account.Person.FirstName.Contains(filters.Account));

            if (!String.IsNullOrEmpty(filters.Comments))
                query = query.Where(p => p.Potential.Description.Contains(filters.Comments));

            if (filters.ExpectedAmount > 0)
                query = query.Where(p => p.Potential.ExpectedAmount == (filters.ExpectedAmount));

            if (!String.IsNullOrEmpty(filters.LeadSource))
                query = query.Where(p => p.Potential.LeadSourceName.Contains(filters.LeadSource));

            if (!String.IsNullOrEmpty(filters.Name))
                query = query.Where(p => p.Potential.Person.FirstName.Contains(filters.Name));

            if (!String.IsNullOrEmpty(filters.SalesStage))
                query = query.Where(p => p.Potential.SalesStage.Equals(filters.SalesStage));
            if (filters.UserId.HasValue)
                query = query.Where(p => p.CreatedByUserId == filters.UserId);

            if (page == 0 || pageSize == 0)
                result.Items = query.OrderBy(p => p.Potential.Person.FirstName).ToList();
            else
                result.Items = query.OrderBy(p => p.Potential.Person.FirstName)
               .Skip(pageSize * page)
               .Take(page).ToList();

            result.Items = query.ToList();
            result.PagingInfo = new PagingInfo(pageSize, 1, query.Count());
            return result;

        }
        public bool DeletePropertyPotential(long potentialId)
        {
            var propertyPotential = _dataContext.PropertyPotentials.SingleOrDefault(i => i.PotentialId == potentialId);
            if (propertyPotential != null)
            {
                propertyPotential.DeletedOn = DateTime.UtcNow;
                return true;
            }
            return false;
        }
    }
}