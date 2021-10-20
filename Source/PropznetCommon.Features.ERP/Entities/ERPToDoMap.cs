using System.ComponentModel.DataAnnotations.Schema;

namespace PropznetCommon.Features.ERP.Entities
{
    public class ERPToDoMap : ERPMapBase
    {
        public string AssignedTo { get; set; }
        public long ToDoId { get; set; }
        [ForeignKey("ToDoId")]
        public virtual ERPToDo ToDo { get; set; }
    }
}
