using System;
using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class ERPToDo : ERPEntityBase
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Time { get; set; }
        public bool IsRecurring { get; set; }
        public long EventForId { get; set; }
        public ToDoStatus ToDoStatus { get; set; }
    }
}
