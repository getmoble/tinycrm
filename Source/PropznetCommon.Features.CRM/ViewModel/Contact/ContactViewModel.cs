using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.ViewModel.Contact
{
    public class ContactViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        public string Account { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
