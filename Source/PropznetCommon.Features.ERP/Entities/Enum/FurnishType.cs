using System.ComponentModel;

namespace PropznetCommon.Features.ERP.Entities.Enum
{
    public enum FurnishType
    {
        [Description("Fully Furnished")]
        FullyFurnished,
        [Description("Partially Furnished")]
        PartiallyFurnished,
        [Description("Not Furnished")]
        NotFurnished
    }
}