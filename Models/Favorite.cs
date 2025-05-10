using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Favorite
	{
		public int Id { set; get; }
		[ForeignKey("Hotel")]
		public int HotelId { set; get; }
		public Hotel Hotel { set; get; }

		[ForeignKey("User")]
		public string UserId { set; get; }
		public AppUser User { set; get; }

	}
}
