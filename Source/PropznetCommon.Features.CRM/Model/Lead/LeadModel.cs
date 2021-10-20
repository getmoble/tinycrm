using System;
namespace PropznetCommon.Features.CRM.Model.Lead
{
    public class LeadModel : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string LeadSourceName { get; set; }
        public long? LeadSourceUserId { get; set; }//id of user if lead source is user/staff.
        public string Other { get; set; }//value comes when choose lead source as other.
        public string Comment { get; set; }
        public long SelectedLeadStatus { get; set; }
        public string LeadStatus { get; set; }
        public long SelectedLeadSource { get; set; }
        public long SelectedAssignedTo { get; set; }
        public string LeadSource { get; set; }
        public long Assignedto { get; set; }
        public string RefId { get; set; }
        public long CommunicationDetailID { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? RecievedOn { get; set; }        
        public long PersonId { get; set; }
    }
}