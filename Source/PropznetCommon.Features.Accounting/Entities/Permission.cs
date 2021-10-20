namespace PropznetCommon.Features.Accounting.Entities
{
    public class Permission : AccountingEntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
    }
}
