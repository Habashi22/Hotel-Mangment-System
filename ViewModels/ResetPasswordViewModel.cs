using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }



        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage ="Confirm password doesn't match the new password") ]
        public string ConfirmNewPassword { get; set; }

    }
}
