namespace MVCBookingFinal_YARAB_.IRepositories
{
	public interface IRoomService
	{
		public List<Room> GetAll();
		public List<Room> GetByHotelId(int id, RoomType type = 0, int capacity = -1, int minprice = -1, int maxprice = -1, RoomStatus stat = RoomStatus.Available);
		public Room GetById(int id);
		public IEnumerable<List<Room>> GetCombinationsByHotelId(int id, SearchViewModel vm);
		public void Create(RoomViewModel vm);
		public void Update(RoomViewModel vm);
		public void Delete(int id);
	}
}
