namespace MVCBookingFinal_YARAB_.IRepositories
{
	public interface IReservationService
	{
		public Task savedraft(DraftReservation reservation, string userid,List<Room> rooms);
		public void Delete(string userid);
		public DraftReservation getUserReservation(string userid);
		public PromoCode GETCODE(string text);
		public string GETCODEText(int id);
		public Reservation SaveReservation(ReservationViewModel vm, IEnumerable<Room> rooms, string userid);
		public Reservation getById(int id);
		public  Task<List<Reservation>> MyReservations(string userid);
		public void CancelReservation(int id);

	}
}
