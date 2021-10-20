using System.ComponentModel.DataAnnotations;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class UserProfileViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }
        public string PrimaryEmail { get; set; }
        [Phone(ErrorMessage = "Please Enter valid phone number")]
        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }
        public string Image { get; set; }
    }
}
