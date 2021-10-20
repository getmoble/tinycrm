using System.Collections.Generic;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Model.Portfolio
{
   public class PortfolioModel
    {
       public long Id { get; set; }
        public string PortfolioName { get; set; }
        public IList<long> OwnerId { get; set; }
        public ERPPropertyCategory UsageType { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }

        public PortfolioModel(string portfolioName, IList<long> ownerId,string usageType,string description,long createdBy)
        {
            PortfolioName = portfolioName;
            OwnerId = ownerId;
            if (usageType == "0")
                UsageType = ERPPropertyCategory.Residential;
            if (usageType == "1")
                UsageType = ERPPropertyCategory.Commercial;
            Description = description;
            CreatedBy = createdBy;
        }
        public PortfolioModel(long id,string portfolioName, IList<long> ownerId, string usageType, string description, long createdBy)
        {
            Id = id;
            PortfolioName = portfolioName;
            OwnerId = ownerId;
            if (usageType == "0")
                UsageType = ERPPropertyCategory.Residential;
            if (usageType == "1")
                UsageType = ERPPropertyCategory.Commercial;
            Description = description;
            CreatedBy = createdBy;
        }
    }
}