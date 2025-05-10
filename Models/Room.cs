using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Room
	{
		[Key]
		public int Id { set; get; }
		[ForeignKey("Hotel")]
		public int HotelId { set; get; }
		public virtual Hotel Hotel { set; get; }
		public virtual List<ReservationRoom> Reserved { set; get; }

		[EnumDataType(typeof(RoomType))]
		public RoomType roomType { set; get; }
		[Range(1, 7)]
		[NotMapped]
		public int Capacity => roomType == RoomType.Single ? 1 :
								roomType == RoomType.Double ? 2 :
								roomType == RoomType.Triple ? 3 :
								roomType == RoomType.Deluxe ? 4 : 5;
								
		[Range(1000,100000)]
		[DataType(DataType.Currency)]
		public double PricePerNight { set; get; }
		[Range(0,100)]
		public int Floor { set; get; }
		[EnumDataType(typeof(RoomStatus))] 

		public RoomStatus Status;

		//[EnumDataType(typeof(RoomStatus))]
		//[NotMapped]

		//public RoomStatus Status2 =>
		//	this.Reserved.OrderBy(r => r.Reservation.CheckOutDate)
		//	.LastOrDefault().Reservation.CheckOutDate <= DateTime.Now ?
		//	RoomStatus.Available :
		//	this.Reserved.OrderBy(r => r.Reservation.CheckInDate)
		//	.LastOrDefault().Reservation.CheckInDate >= DateTime.Now ?
		//	RoomStatus.Available : RoomStatus.Reserved;
		public List<RoomImage> Images { set; get; }

		public List<DraftReservationRoom> DraftReservations { get; set; } = new();


	}
	public enum RoomStatus
	{
		Available,
		Reserved,
		Maintenance
	}
	public enum RoomType
	{
		Single,
		Double,
		Triple,
		Deluxe,
		Suite
	}
}
