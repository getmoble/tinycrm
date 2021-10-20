using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.CRM.ViewModel.User
{
    public class UserProfileViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Name")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid phone number")]
        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        [DisplayName("Address")]
        public string Address { get; set; }
        public long CommunicationDetailID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
    }
}