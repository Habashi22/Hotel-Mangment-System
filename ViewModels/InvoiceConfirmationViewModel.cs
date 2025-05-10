using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.ViewModels
{
	public class InvoiceConfirmationViewModel
	{
		public int ReservationId { set; get; }
		public Reservation Reservation { set; get; }
		public double TotalAmount => this.Reservation.TotalAmount; //use include
		[NotMapped]
		public double discount => this.Reservation.usedfcodes?
			(this.Reservation.UsedPromoCodes.Where(p => this.Reservation.Reserved.First().User.Id == p.UserId).Select(p => p.PromoCode).Sum(p => p.Discount)):0;

		[Range(0, 100)]
		public double Tax { get; set; }
		[NotMapped]
		public double FinalAmount => TotalAmount - (TotalAmount * discount / 100) + (TotalAmount * Tax / 100);

	}
}
