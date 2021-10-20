using System.ComponentModel.DataAnnotations;

namespace PropznetCommon.Features.CRM.ViewModel.Agent
{
    public class AgentProfileViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid phone number")]
        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }
        public long CommunicationDetailID { get; set; }
        [Required(ErrorMessage = "Please Enter Your DED License Number")]
        public string DEDlicenseNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your RERA Registration Number")]
        public string RERAregistrationNumber { get; set; }
        public bool IsListingMember { get; set; }
        public string Image { get; set; }
        public string Website { get; set; }
    }
}
