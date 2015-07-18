namespace LOG.PropznetCRM.Data.ViewModel.Potential
{
    public class PotentialViewModel
    {
        public long Id { get; set; }
        public string RefId { get; set; }
        public string Name { get; set; }
        public double ExpectedAmount { get; set; }
        public string ExpectedCloseDate { get; set; }
        public string LeadSourceName { get; set; }
        public string AccountName { get; set; }
        public string SalesStageName { get; set; }
        public string AgentName { get; set; }
        public decimal PropertyBudgetFrom { get; set; }
        public decimal PropertyBudgetTo { get; set; }
        public int PropertyFloor { get; set; }
        public float PropertyArea { get; set; }
        public string PropertyCategory { get; set; }
        public string PropertyType { get; set; }
        public long AgentId { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string AccountNo { get; set; }
        public string Industry { get; set; }
        public string ContactTitle { get; set; }
        public string ShowingDate{ get; set; }
    }
}
