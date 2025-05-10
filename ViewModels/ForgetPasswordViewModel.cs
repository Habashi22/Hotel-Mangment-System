using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        public string Email { get; set; }

        
    }
}
