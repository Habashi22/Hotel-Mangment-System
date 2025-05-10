using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.ViewModels
{
	public class ReservationViewModel
	{
		public int? Id { get; set; }

		//[ForeignKey("Reserved")]
		//public int? ReservationRoomId { set; get; }
		//public List<ReservationRoom>? Reserved { set; get; } //list instead of just one room
		public string rooms { set; get; }
		//[ForeignKey("mealPlan")]
		public mealPlan? Plan { set; get; }
		//public int? mealPlanId { get; set; }
		//public MealPlan? mealPlan { get; set; }


		//[ForeignKey("amenity")]
		//public int? AmenityId { set; get; }
		public AmenityEnum? amenity { get; set; }
		[DataType(DataType.Date)]
		public DateTime? CheckInDate { get; set; }
		[DataType(DataType.Date)]
		public DateTime? CheckOutDate { get; set; }

		//[ForeignKey("UsedPromoCode")]
		//public int? UsedPromoCodeId { set; get; } //used promocodes
		//public UsedPromoCodes? UsedPromoCode { set; get; }
		[PromoCodeInDataBase]
		public string? PromoCode { set; get; }

		//[ForeignKey("User")]
		//public string UserId { set; get; }
		//public AppUser User { set; get; }
	}
}
