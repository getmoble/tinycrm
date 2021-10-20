using System.ComponentModel;

namespace PropznetCommon.Features.ERP.Entities.Enum
{
    public enum PaymentMethods
    {
        [Description("Cheque")]
        Cheque,
        [Description("Cash")]
        Cash,
        [Description("Online Payment")]
        OnlinePayment
    }
}
