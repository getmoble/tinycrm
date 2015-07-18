namespace LOG.PropznetCRM.Data.Model.Contact
{
    public class ContactModel : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public long AccountId { get; set; }
        public long AgentId { get; set; }
        public string Comments { get; set; }
        public long CommunicationDetailId { get; set; }
        public long CreatedBy { get; set; }

    }
}
