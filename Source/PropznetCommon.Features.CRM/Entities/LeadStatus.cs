using System.ComponentModel.DataAnnotations;

namespace PropznetCommon.Features.CRM.Entities
{
    public class LeadStatus
    {
        [Key]
        public long Id { get; set; }
        public string Name{get;set;}
    }
}
