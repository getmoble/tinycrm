using System.ComponentModel.DataAnnotations;

namespace PropznetCommon.Features.ERP.ViewModel
{
    public class RecoverPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "Not a valid email")]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }
    }
}
