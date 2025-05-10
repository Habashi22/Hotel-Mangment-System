using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class RoomImage
	{
		public int Id { set; get; }
		public string Image { set; get; }
		[ForeignKey("room")]
		public int roomId { set; get; }
		public Room room { set; get; }

		public bool isDeleted { set; get; } = false;
	}
}
