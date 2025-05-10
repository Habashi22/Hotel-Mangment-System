using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.ViewModels
{
	public class RoomViewModel
	{
		//[Key]
		public int? Id { set; get; }

		public int HotelId { set; get; }

		//public virtual List<ReservationRoom> Reserved { set; get; }

		[EnumDataType(typeof(RoomType))]
		public RoomType roomType { set; get; }
		//[Range(1, 7)]
		//public int Capacity { set; get; }
		[Range(1000, 100000)]
		[DataType(DataType.Currency)]
		public double PricePerNight { set; get; }
		[Range(0, 100)]
		public int Floor { set; get; }
		[EnumDataType(typeof(RoomStatus))]
		public RoomStatus? status  { set; get; }

		[ImageExtension]
		public List<IFormFile>? Images { set; get; }//lots of images

	}
}
