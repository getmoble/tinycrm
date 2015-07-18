namespace LOG.PropznetCRM.Data.ViewModel.Lead
{
    public class LeadViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Company { get; set; }
        public string Comments { get; set; }
        public long LeadStatus { get; set; }
        public long LeadSource { get; set; }
        public long AssignedTo { get; set; }
        public string RefId { get; set; }
        public long CommunicationDetailID { get; set; }

    }
}
