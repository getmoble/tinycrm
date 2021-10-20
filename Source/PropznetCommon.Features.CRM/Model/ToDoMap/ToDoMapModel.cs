using PropznetCommon.Features.CRM.Entities.Enum;

namespace PropznetCommon.Features.CRM.Model.ToDoMap
{
    public class ToDoMapModel
    {
        public long Id { get; set; }
        public long EntityId { get; set; }
        public CRMEntityType EntityType { get; set; }
        public long ToDoId { get; set; }     
        public long CreatedBy { get; set; }
    }
}