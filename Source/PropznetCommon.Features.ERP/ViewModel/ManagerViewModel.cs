using PropznetCommon.Features.ERP.Entities;
using Common.Utilities;
namespace PropznetCommon.Features.ERP.ViewModel
{
    public class ManagerViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public long RoleId { get; set; }
        public string Address { get; set; }
        public long PersonId { get; set; }
        public long CountryId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public long Zip { get; set; }
        public long CreatedBy { get; set; }
        public long UserId { get; set; }
        public ManagerViewModel()
        {

        }
        public ManagerViewModel(Manager vm)
        {
            Id = vm.Id;
            FirstName = vm.Person.FirstName;
            LastName = vm.Person.LastName;
            Email = vm.Person.Email;
            Mobile = vm.Mobile;
            Phone = vm.Person.PhoneNo;
            RoleId = vm.RoleId;
            Address = vm.Coalesce(p=>p.Person,a=>a.Address,"");
            CountryId = vm.Coalesce(p => p.Person.Country, a => a.Id, 0);
            City = vm.Coalesce(p => p.Person, a => a.City, "");
            State = vm.Coalesce(p => p.Person, a => a.State, "");
            Zip = vm.Coalesce(p => p.Person, a => a.Zip.Value, 0);
        }
    }
}