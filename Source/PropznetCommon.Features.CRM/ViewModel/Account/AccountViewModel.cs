using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.ViewModel.Account
{
    public class AccountViewModel
    {
         [DisplayName("Account Name")]
        public string Name { get; set; }
        [DisplayName("Industry")]
        public string Industry { get; set; }
        public string Website { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        public string Comments { get; set; }
        public long UserId { get; set; }
    }
}
