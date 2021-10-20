namespace PropznetCommon.Features.Accounting.Entities
{
    public class BalanceSheet
    {
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountCategory { get; set; }
        public double Credit { get; set; }
        public double Debit { get; set; }
        public double Balance { get; set; }
    }
}
