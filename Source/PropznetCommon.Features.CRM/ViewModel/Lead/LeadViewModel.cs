using System;
using System.ComponentModel;
namespace PropznetCommon.Features.CRM.ViewModel.Lead
{
    public class LeadViewModel
    {
        public long Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Company { get; set; }
        public string Comments { get; set; }
        public long LeadStatus { get; set; }
         [DisplayName("Lead Source")]
        public long LeadSource { get; set; }
        public long AssignedTo { get; set; }
        public string RefId { get; set; }
        public long CommunicationDetailID { get; set; }
        public long? LeadSourceUserId { get; set; }//id of user if lead source is user/staff.
        public string Other { get; set; }//value comes when choose lead source as other.
        public DateTime? RecievedOn { get; set; }
        public long UserId { get; set; }

    }
}
