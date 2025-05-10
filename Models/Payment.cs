using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Payment
	{
		[Key]
		public int Id { get; set; }

		//[ForeignKey("invoice")]
		//public int InvoiceId { get; set; } //1 to many is only mapped by one side
		public Invoice invoice { get; set; }



		[ForeignKey("payment")]
		public int PaymentMethodId { get; set; }
		public PaymentMethod payment { get; set; }
		public string status { get; set; }
		public DateTime PaymentDate { get; set; }
		public string TransactionId { get; set; }
	}
}
