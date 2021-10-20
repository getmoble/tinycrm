namespace PropznetCommon.Features.CRM.Model.Lead
{
    public class ConvertLeadDataModel
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        public string PotentialName { get; set; }
        public string PotentialAmount { get; set; }
        public long SelectedAssignedTo { get; set; }
        public long CommunicationDetailId { get; set; }
        public long SelectedSalesStage { get; set; }
    }
}
