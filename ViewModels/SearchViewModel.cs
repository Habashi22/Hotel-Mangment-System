using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.ViewModels
{
	[Serializable]

	public class SearchViewModel
	{
		public string CountryOrCity { set; get; }
		public DateTime CheckInDate { set; get; }
		public DateTime CheckOutDate { set; get; }
		[Range(1,7)]
		public int AdultsNumber { set; get; }
		[Range(1, 7)]
		public int ChildrenNumber { set; get; }
		[Range(1, 25)]
		public int NumberOfRooms { set; get; }
	}
}
