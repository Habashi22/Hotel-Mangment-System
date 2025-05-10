using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MVCBookingFinal_YARAB_.Models
{
	public class AppUser : IdentityUser
	{
	
		public string FirstName { set; get; }
		public string LastName { set; get; }
		public DateTime CreationDate { set; get; }
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime DateOfBirth { set; get; }
		public string? ProfilePicture { set; get; }
		public virtual List<Favorite> FavoriteHotels { set; get; }
		public virtual List<Report> Reports { set; get; }
		public virtual List<Review> Reviews { set; get; }
		public virtual List<UsedPromoCodes> UsedPromoCodes { set; get; } //used promo codes
		public virtual DraftReservation? SavedDraft { set; get; }//saved draft for user
	}
}
