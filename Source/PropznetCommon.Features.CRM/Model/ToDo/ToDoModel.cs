using System;

namespace PropznetCommon.Features.CRM.Model.ToDo
{
    public class ToDoModel
    {
        public long Id{get;set;}
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Time { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsRecurring { get; set; }
        public long CreatedBy { get; set; }
        public long EventForId { get; set; }

    }
}
