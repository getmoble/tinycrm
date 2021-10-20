using System;
using PropznetCommon.Features.ERP.ViewModel;

namespace PropznetCommon.Features.ERP.Model.Amenity
{
    public class AmenityModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public AmenityModel(AmenityViewModel vm)
        {
            Id = vm.Id;
            Name = vm.Name;
        }
    }
}
