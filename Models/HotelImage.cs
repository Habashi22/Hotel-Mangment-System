using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class HotelImage //Totally new
	{
		public int Id { set; get; }
		public string Image { set; get; }
		[ForeignKey("hotel")]
		public int HotelId { set; get; }
		public Hotel hotel { set; get; }
		public bool isDeleted { set; get; } = false;
	}
}
