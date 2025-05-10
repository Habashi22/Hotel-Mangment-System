namespace MVCBookingFinal_YARAB_.Models
{
	public class DraftReservationRoom
	{
		public int id { set; get; }
		public int DraftReservationId { set; get; }
		public DraftReservation DraftReservation { set ;get;}
		
		public int ReservedId { set; get; }
		public Room Reserved { set; get; }
	}
}
