using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PropznetCommon.Features.CRM.Entities.Enum;

namespace PropznetCommon.Features.CRM.Entities
{
    public class CRMToDoMap 
    {
        [Key]
        public long Id { get; set; }
        public long EntityId { get; set; }
        public CRMEntityType EntityType { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public string DeletedByUserId { get; set; }

        public long ToDoId { get; set; }
        [ForeignKey("ToDoId")]
        public virtual CRMToDo ToDo { get; set; }
    }
}
