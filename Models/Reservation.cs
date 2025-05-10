using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Reservation
	{
		public int Id { get; set; }

		//[ForeignKey("Reserved")]
		//public int ReservationRoomId { set; get; }
		public List<ReservationRoom> Reserved { set; get; } //list instead of just one room

		[ForeignKey("mealPlan")]
		public int mealPlanId { get; set; }
		public MealPlan mealPlan { get; set; }


		[ForeignKey("amenity")]
		public int AmenityId { set; get; }
		public Amenity amenity { get; set; }
		public DateTime CheckInDate { get; set; }
		public DateTime CheckOutDate { get; set; }

		//[ForeignKey("UsedPromoCode")]
		//public int? UsedPromoCodeId { set; get; }
		public List<UsedPromoCodes> UsedPromoCodes { set; get; } //list that user can use more than one promo code

		//[ForeignKey("Invoice")]
		//public int InvoiceId { set; get; } //1 to 1 is only mapped by one side
		public Invoice Invoice { set; get; }
		
		//public int FamilyMembers { set; get; }
		[NotMapped]
		public double TotalAmount => ((((this.mealPlan.Price + this.Reserved.Select(r=>r.Room).Sum(r=>r.PricePerNight)) * (CheckOutDate.Day - CheckInDate.Day)) + this.amenity.Price)) ; // for all rooms
		[NotMapped]
		public bool usedfcodes => UsedPromoCodes is not null;
		[NotMapped]
		public double AfterDiscount => TotalAmount
			* (100 - (usedfcodes ? UsedPromoCodes.Select(u => u.PromoCode).Where(p => p.IsActive).Sum(p => p.Discount) : 0)) / 100;



		[EnumDataType(typeof(ReservationStatus))]
		public ReservationStatus reservationStatus { get; set; } = ReservationStatus.Pending;
		public DateTime? CancellationDate { set; get; } = null;

		public bool isRefunded = false;
	}
	public enum ReservationStatus
	{
		Confirmed, Pending, Canceled
	}
}
