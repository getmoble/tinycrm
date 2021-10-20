using System.ComponentModel;

namespace PropznetCommon.Features.ERP.Entities.Enum
{
    public enum PaymentStatus
    {
        [Description("Paid")]
        Paid,
        [Description("Not Paid")]
        NotPaid
    }
}
