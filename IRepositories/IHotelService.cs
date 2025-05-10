namespace MVCBookingFinal_YARAB_.IRepositories
{
	public interface IHotelService
	{
		public List<Hotel> GetAll();

		public IEnumerable<Hotel> GetAllFilteredPaginated(SearchViewModel vm, int PerPage = 5, int pagenum = 0, string city = null, string country = null);

		public Hotel GetById(int id);
		public void Create(HotelViewModel vm);
		public void Update(HotelViewModel vm);
		public void Delete(int id);
		public void Favor(int hotelid, string userid);
		public void RemoveFromFavorites(int hotelid, string userid);


	}
}
