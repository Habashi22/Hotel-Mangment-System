using MVCBookingFinal_YARAB_.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Amenity
	{

		public int Id { set; get; }
		[MinLength(3)]
		[EnumDataType(typeof(AmenityEnum))]
		public AmenityEnum Amenities { set; get; }
		[NotMapped]
		[DataType(DataType.Currency)]
		public double Price => AmenityFixedPrices.GetTotalPrice(this.Amenities);
		public virtual List<Reservation> Reservation { set; get; }
		public virtual List<Hotel> Hotels { set; get; }
	
	}
	[Flags]
	public enum AmenityEnum
	{
		WiFi = 0,
		Parking = 1,
		SwimmingPool = 2,
		Gym = 4,
		Spa = 8,
		Restaurant = 16,
		Laundry = 32,
		ExtraRoomService = 64
	}

}
