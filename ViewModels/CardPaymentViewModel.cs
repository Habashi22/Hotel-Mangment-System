using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.ViewModels
{
    public class CardPaymentViewModel
    {
        public int? Id { get; set; }
        [CreditCard]
        public string CardNumber { get; set; }
        [DataType(DataType.Date)]
        public DateOnly ExpiryDate { get; set; }
        [MaxLength(3)]
        [MinLength(3)]
        public string CVV { get; set; }
    }
}
