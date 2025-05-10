using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.ViewModels
{
	public class LoginViewModel
	{
		public string UsernameOrEmail { set; get; }
		[DataType(DataType.Password)]
		public string Password { set; get; }
		public bool RememberMe { set; get; }
	}
}
