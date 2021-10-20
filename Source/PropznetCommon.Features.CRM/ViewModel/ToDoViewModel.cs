using System;

namespace PropznetCommon.Features.CRM.ViewModel
{
    public class ToDoViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Time { get; set; }
    }
}
