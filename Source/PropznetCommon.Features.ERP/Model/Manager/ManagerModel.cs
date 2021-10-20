using PropznetCommon.Features.ERP.ViewModel;

namespace PropznetCommon.Features.ERP.Model.Manager
{
    public class ManagerModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public long RoleId { get; set; }
        public string Address { get; set; }
        public long AddressId { get; set; }
        public long CountryId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public long Zip { get; set; }
        public long PersonId { get; set; }
        public ManagerModel()
        {

        }
        public ManagerModel(ManagerViewModel vm)
        {
            Id = vm.Id;
            FirstName = vm.FirstName;
            LastName = vm.LastName;
            Email = vm.Email;
            Mobile = vm.Mobile;
            Phone = vm.Phone;
            RoleId = vm.RoleId;
            Address = vm.Address;
            CountryId = vm.CountryId;
            City = vm.City;
            State = vm.State;
            Zip = vm.Zip;
            PersonId = vm.PersonId;
        }
    }
}