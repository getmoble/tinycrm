using System;

namespace LOG.PropznetCRM.Data.Model.Lead
{
    public class ConvertLeadModel
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        public string PotentialName { get; set; }
        public double PotentialAmount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long AgentId { get; set; }
        public long CommunicationDetailId { get; set; }
        public long SelectedSalesStage { get; set; }
        public long SelectedLeadSource { get; set; }
        public DateTimeOffset ExpectedDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public long selectedAssignedTo { get; set; }
        public bool IsChecked { get; set; }
    }
}
