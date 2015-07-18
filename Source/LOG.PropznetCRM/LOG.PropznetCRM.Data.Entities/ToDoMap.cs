using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LOG.PropznetCRM.Data.Entities.Enum;

namespace LOG.PropznetCRM.Data.Entities
{
    public class ToDoMap 
    {
        [Key]
        public long Id { get; set; }
        public long EntityId { get; set; }
        public EntityType EntityType { get; set; }
        public long ToDoId { get; set; }
        [ForeignKey("ToDoId")]
        public virtual ToDo ToDo { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public string DeletedBy { get; set; }
    }
}
