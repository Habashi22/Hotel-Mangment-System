using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class UsedPromoCodes
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("PromoCode")]
		public int PromoCodeId { get; set; }
		public PromoCode PromoCode { get; set; }

		[ForeignKey("User")]
		public string UserId { set; get; }
		public AppUser User { set; get; }

		[ForeignKey("Reservation")]
		public int ReservationId { set; get; }
		public Reservation Reservation { set; get; }
	}
}
