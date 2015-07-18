namespace LOG.PropznetCRM.Data.ViewModel.Agent
{
    public class AgentViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public long CommunicationDetailID { get; set; }
        public string DEDlicenseNumber { get; set; }
        public string RERAregistrationNumber { get; set; }
        public bool IsListingMember { get; set; }
        public string Image { get; set; }
    }
}
