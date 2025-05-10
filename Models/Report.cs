using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Report
	{
		public int Id { set; get; }
		[ForeignKey("Hotel")]
		public int HotelId { set; get; }
		public Hotel Hotel { set; get; }

		[ForeignKey("User")]
		public string UserId { set; get; }
		public AppUser User { set; get; }

		public string? Complaint { set; get; }
		public DateTime ReviewDate { set; get; }
		public bool isDeleted { set; get; } = false; //addition 
	}
}
