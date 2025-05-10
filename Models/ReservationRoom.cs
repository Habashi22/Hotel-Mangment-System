using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class ReservationRoom
	{
		[Key]
		public int id { set; get; }
		[ForeignKey("Reservation")]
		public int ReservationId { set; get; }
		public virtual Reservation Reservation { set; get; }
		[ForeignKey("Room")]
		public int RoomId { set; get; }
		public virtual Room Room { set; get; }
		[ForeignKey("User")]
		public string UserId  { set; get; }
		public virtual AppUser User { set; get; }
		[DefaultValue(false)]
		public bool IsDeleted { set; get; } = false;
	}
}
