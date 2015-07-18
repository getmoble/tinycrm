using LOG.PropznetCRM.Data.Entities;
using LOG.PropznetCRM.Data.Model.Property;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IPropertyService
    {
        Property CreateProperty(PropertyModel propertyModel);
        Property UpdateProperty(PropertyModel propertyModel);
        bool DeleteProperty(long id);
    }
}
