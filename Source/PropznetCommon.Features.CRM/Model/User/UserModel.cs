using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.Model.User
{
    public class UserModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public long PersonId { get; set; }
        public bool IsListingMember { get; set; }
        public string Image { get; set; }
        public long? UserId { get; set; }
        public long CreatedBy { get; set; }
    }
}