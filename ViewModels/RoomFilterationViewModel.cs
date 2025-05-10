namespace MVCBookingFinal_YARAB_.ViewModels
{
	public class RoomFilterationViewModel
	{
		public decimal minPrice { set; get; }
		public decimal maxPrice { set; get; }
		//public AmenityEnum amenity { set; get; }
		public sortBy Sorting { set; get; }
	}
	public enum sortBy
	{
		OurTopPicks,
		LowPrice,
		HighPrice

	}
}
