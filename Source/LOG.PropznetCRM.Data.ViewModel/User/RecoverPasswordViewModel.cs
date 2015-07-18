using System.ComponentModel.DataAnnotations;

namespace LOG.PropznetCRM.Data.ViewModel.User
{
    public class RecoverPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Not a valid email")]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
    }
}
