using Common.Auth.SingleTenant.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.ERP.Entities
{
    public class Manager : ERPEntityBase
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        public string Mobile { get; set; }
        //public string Phone { get; set; }
        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        public long RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual ManagerRole ManagerRole { get; set; }
    }
}
