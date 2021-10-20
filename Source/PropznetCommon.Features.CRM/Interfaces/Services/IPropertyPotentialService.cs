using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model;
using PropznetCommon.Features.CRM.Model.Potential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.Services
{
    public interface IPropertyPotentialService
    {
        PropertyPotential CreatePropertyPotential(PropertyPotentialMapModel propertyPotentialMapModel);
        PropertyPotential GetPropertyPotentialByPropertyId(long potentialPropertyInfoId);
        PropertyPotential GetPropertyPotentialByPotentialId(long potentialId);
        bool UpdatePropertyPotential(PropertyPotentialMapModel propertyPotentialMapModel);
        bool DeletePropertyPotential(long potentialId);
        bool DeletePropertyPotentialBypotentialId(long potentialId);
        IList<PropertyPotential> GetAllPropertyPotentialsByUserId(long userId);
        IList<PropertyPotential> GetAllPropertyPotentials();
        SearchResult<PropertyPotential> SearchPotential(PropertyPotentialSearchFilter filters, int pageSize, int page);
    }
}