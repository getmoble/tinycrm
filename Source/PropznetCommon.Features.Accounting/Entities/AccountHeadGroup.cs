using System.Collections.Generic;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class AccountHeadGroup
    {
        public string Group { get; set; }
        public IList<AccountHeadStatus> AccountHeadStatus { get; set; }
        public AccountHeadGroup()
        {
            AccountHeadStatus = new List<AccountHeadStatus>();
        }
    }
}