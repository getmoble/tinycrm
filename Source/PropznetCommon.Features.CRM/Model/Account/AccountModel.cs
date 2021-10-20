namespace PropznetCommon.Features.CRM.Model.Account
{
   public class AccountModel : ModelBase
    {
        public string AccountName { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public long SelectedAssignedto {get;set;}
        public long PersonId { get; set; }
        public long CreatedByUserId { get; set; }
    }
}
