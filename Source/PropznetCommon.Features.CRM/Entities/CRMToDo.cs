using System;

namespace PropznetCommon.Features.CRM.Entities
{
    public class CRMToDo :CRMEntityBase
    {        
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Time { get; set; }
        public bool? IsRecurring { get; set; }
        public long EventForId { get; set; }
    }
}