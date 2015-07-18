namespace LOG.PropznetCRM.Data.Model.Lead
{
    public class LeadModel : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string LeadSourceName { get; set; }
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
    }
}