using System.ComponentModel;

namespace PropznetCommon.Features.ERP.Entities.Enum
{
   public enum RentalTerm
    {
       [Description("Month")]       
       Month,
       [Description("Week")]
       Week,
       [Description("Night")]
       Night,
       [Description("Sqft per Month")]
       SqftperMonth,
       [Description("Sqft per Year")]
       SqftperYear,
       [Description("Sqm per Month")]
       SqmperMonth,
       [Description("Sqm per Year")]
       SqmperYear
    }
}