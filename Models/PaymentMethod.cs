using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.Models
{
	public enum PaymentType
	{
		Stripe, Card
	}
	public abstract class PaymentMethod
	{
		public int Id { get; set; }


		[EnumDataType(typeof(PaymentType))]
		public PaymentType PaymentType { get;  set; }
	}

	public class CardPaymentMethod : PaymentMethod
	{
		[CreditCard]
		public string CardNumber { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
		public DateOnly ExpiryDate { get; set; }
		public string CVV { get; set; }

		public CardPaymentMethod()
		{
			PaymentType = PaymentType.Card;
		}
	}

	public class StripePaymentMethod : PaymentMethod
	{
		public string AccountNumber { get; set; }

		public StripePaymentMethod()
		{
			PaymentType = PaymentType.Stripe;
		}
	}
}
