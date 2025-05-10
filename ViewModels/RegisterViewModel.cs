using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.ViewModels
{
	public class RegisterViewModel
	{
		public int id { set; get; }
		public string FirstName { set; get; }
		public string LastName { set; get; }
		public string UserName { set; get; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[myAge]
		public DateTime DateOfBirth { set; get; }

		public string Email { set; get; }

		[Phone]
		[MaxLength(11)]
		[MinLength(11)]
		public string PhoneNumber { set; get; }
		[DataType(DataType.Password)]
		public string? Password { set; get; }
		[Compare("Password")]
		[DataType(DataType.Password)]
		public string? ConfirmPassword { set; get; }

		[ImageExtension]
		[NotMapped]
		public IFormFile? ProfilePicture { set; get; }



		public string? Usernameoremail { set; get; }
		public string? loginPassword { set; get; }
		public bool? rememberme { set; get; } = false;

	}
}
