using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Stripe;

namespace MVCBookingFinal_YARAB_.Models
{
	public class DraftReservation
	{
		public int Id { get; set; }

		//[ForeignKey("Reserved")]
		//public int? ReservationRoomId { set; get; }
		public List<DraftReservationRoom>? Reserved { set; get; } //list instead of just one room

		//[ForeignKey("mealPlan")]
		//public int? mealPlanId { get; set; }
		public mealPlan? mealPlan { get; set; }


		//[ForeignKey("amenity")]
		//public int? AmenityId { set; get; }
		public AmenityEnum? amenity { get; set; }
		public DateTime? CheckInDate { get; set; }
		public DateTime? CheckOutDate { get; set; }

		[ForeignKey("UsedPromoCode")]
		public int? UsedPromoCodeId { set; get; } //used promocodes
		public PromoCode? UsedPromoCode { set; get; }

		[ForeignKey("User")]
		public string UserId { set; get; }
		public AppUser User { set; get; }
		//[NotMapped]
		//public double TotalAmount => ((this.mealPlan.Price + this.Reserved.Room.PricePerNight) * (CheckOutDate.Day - CheckInDate.Day)) + this.amenity.Price;



		//[EnumDataType(typeof(ReservationStatus))]
		//public ReservationStatus reservationStatus { get; set; }
		//public DateTime? CancellationDate { set; get; } = null;
		//
		//public bool isRefunded = false;
	}
}
