using System;

namespace LOG.PropznetCRM.Data.Entities
{
    public class ToDo :CRMEntityBase
    {        
        public string Title { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTime Time { get; set; }
        public bool IsRecurring { get; set; }
        public long EventForId { get; set; }
    }
}
