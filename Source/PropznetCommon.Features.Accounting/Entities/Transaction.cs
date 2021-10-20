using System;
using PropznetCommon.Features.Accounting.Entities.Enums;

namespace PropznetCommon.Features.Accounting.Entities
{
    public class Transaction : AccountingEntityBase
    {
        public DateTimeOffset DateOfTransaction { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public EntryType EntryType { get; set; }
        public bool IsSystem { get; set; }
        public CancelFlag CancelFlag { get; set; }

    }
}
