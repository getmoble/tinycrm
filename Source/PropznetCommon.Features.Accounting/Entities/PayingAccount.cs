using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class PayingAccount : AccountingEntityBase
    {
        public PayingAccountType Type { get; set; }

        public string Name { get; set; }
        public string BankBranch { get; set; }
        public string AccountNo { get; set; }
        public string BankIFSCCode { get; set; }
        public string Description { get; set; }
    }
}
