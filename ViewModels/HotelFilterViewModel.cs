namespace MVCBookingFinal_YARAB_.ViewModels
{
	public class HotelFilterViewModel
	{
		public AmenityEnum Amenities { set; get; }
		//public AmenityEnum amenity { set; get; }
		public HotelsortBy Sorting { set; get; }
	}
	public enum HotelsortBy
	{
		OurTopPicks,
		StarsRating,
		ReviewsRating

	}
}
