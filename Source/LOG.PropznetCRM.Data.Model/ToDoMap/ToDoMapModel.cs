using LOG.PropznetCRM.Data.Entities.Enum;

namespace LOG.PropznetCRM.Data.Model.ToDoMap
{
    public class ToDoMapModel
    {
        public long Id { get; set; }
        public long EntityId { get; set; }
        public EntityType EntityType { get; set; }
        public long ToDoId { get; set; }     
        public long CreatedBy { get; set; }
    }
}