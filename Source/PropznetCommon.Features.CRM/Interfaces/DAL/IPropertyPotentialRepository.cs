using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Model;
using PropznetCommon.Features.CRM.Model.Potential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Interfaces.DAL
{
    public interface IPropertyPotentialRepository
    {
        PropertyPotential CreatePropertyPotential(PropertyPotential propertyPotential);
        PropertyPotential GetPropertyPotentialByPropertyPotentialInfoId(long potentialInfoId);
        PropertyPotential GetPropertyPotentialByPotentialId(long potentialId);
        bool DeletePropertyPotential(long potentialId);
        IList<PropertyPotential> GetAllPropertyPotentialsByUserId(long userId);
        IList<PropertyPotential> GetAllPropertyPotentials();
        SearchResult<PropertyPotential> SearchPotential(PropertyPotentialSearchFilter filters, int pageSize, int page);
    }
}