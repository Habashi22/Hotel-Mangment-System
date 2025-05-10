
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Review
	{
		public int Id { set; get; }
		[ForeignKey("Hotel")]
		public int HotelId { set; get; }
		public Hotel Hotel { set; get; }	

		[ForeignKey("User")]
		public string UserId { set; get; }
		public AppUser User { set; get; }
		[Range(1, 5)]
		public int Rating { set; get; }
		public string? Description { set; get; }
		public DateTime ReviewDate { set; get; }

		public bool isDeleted { set; get; } = false; //addition 
	}
}
