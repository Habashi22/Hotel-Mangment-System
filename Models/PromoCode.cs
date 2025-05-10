using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class PromoCode
	{
		public int Id { set; get; }

		public string Code { set; get; }
		public bool IsActive { get; set; } = true;

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime ExpiryDate { set; get; } //addition
		[Range(0, 100)]
		public double Discount { get; set; }
		[ForeignKey("AddingUser")]
		public string AddingUserID { get; set; }
		public AppUser AddingUser { set; get; }


		public List<UsedPromoCodes> UsedTimes { set; get; } //ternary relation
	}
}
