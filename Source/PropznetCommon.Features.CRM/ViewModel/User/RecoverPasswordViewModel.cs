using System.ComponentModel.DataAnnotations;

namespace PropznetCommon.Features.CRM.ViewModel.User
{
    public class RecoverPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Not a valid email")]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
    }
}
