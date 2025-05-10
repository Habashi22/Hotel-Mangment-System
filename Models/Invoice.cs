using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Invoice
	{
		public int Id { get; set; }


		[ForeignKey("Reservation")]
		public int ReservationId { get; set; }
		public Reservation Reservation { get; set; }



		[ForeignKey("Payment")]
		public int PaymentId { get; set; }
		public Payment Payment { get; set; }


		//[Range(0,100)]

		//public double discount { get; set; }
		public double TotalAmount => this.Reservation.TotalAmount   ; //use include
		[NotMapped]
		public double discount => this.Reservation.UsedPromoCodes.Where(p => this.Reservation.Reserved.First().User.Id==p.UserId).Select(p=>p.PromoCode).Sum(p => p.Discount);

		[Range(0, 100)]
		public double Tax { get; set; }
		[NotMapped]
		public double FinalAmount => TotalAmount - (TotalAmount*discount/100 ) + (TotalAmount * Tax / 100);

		public bool isDeleted { set; get; } = false;
	}
}

