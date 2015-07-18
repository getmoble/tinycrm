using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG.PropznetCRM.Data.Model
{
   public class ContactModel : ModelBase
    {//
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
