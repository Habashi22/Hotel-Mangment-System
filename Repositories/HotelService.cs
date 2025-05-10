
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Models;
using System.Diagnostics.Metrics;

namespace MVCBookingFinal_YARAB_.Repositories
{
	public class HotelService(ApplicationDbContext _context, IWebHostEnvironment env) : IHotelService
	{
		public List<Hotel> GetAll()
		{
			return _context.Hotels.Where(h => !h.isDeleted).Include(h => h.city).ThenInclude(c => c.Country).Include(h => h.Favorites).ThenInclude(f => f.User).Include(h => h.Rooms).ThenInclude(r => r.Images).Include(h => h.Reviewed).ThenInclude(r => r.User)
				.Include(h => h.Ameneties).Include(h => h.Images).Include(h => h.Reported).ThenInclude(r => r.User).Where(h => !h.city.isDeleted && !h.city.Country.isDeleted).ToList();
		}

		public IEnumerable<Hotel> GetAllFilteredPaginated(SearchViewModel vm, int PerPage = 5, int pagenum = 0, string city = null, string country = null)
		{
			if (vm.AdultsNumber + vm.ChildrenNumber == 0)
			{
				vm.AdultsNumber++;
			}
			if (vm.NumberOfRooms == 0)
			{
				vm.NumberOfRooms++;
			}
			var peopleCount = vm.AdultsNumber + vm.ChildrenNumber;
			var roomsRequired = vm.NumberOfRooms;




			var query = _context.Hotels.Where(h => !h.isDeleted).Include(h => h.city).ThenInclude(c => c.Country).Include(h => h.Favorites).ThenInclude(f => f.User).Include(h => h.Rooms).ThenInclude(r => r.Images).Include(h => h.Reviewed).ThenInclude(r => r.User)
			.Include(h => h.Ameneties).Include(h => h.Reported)
			.ThenInclude(r => r.User)
			.Include(h => h.Rooms).ThenInclude(r => r.Reserved).ThenInclude(r => r.Reservation).Include(h => h.Images);

			List<Hotel> query2;

			if (city == null && country == null)
			{
				query2 = query.ToList();
			}
			else
			{

				query2 = query.Where(h => h.city.Name == city || h.city.Country.Name == country).ToList();
			}
			//else
			//{
			//	 query2= query.Where(h => h.city.Name.ToLower() == city.ToLower()).ToList();
			//}

			//	var query3 = query2.Where(h => h.Rooms
			//		.Where(r => r.Reserved
			//		.All(r => r.Reservation.CheckOutDate <= vm.CheckInDate || r.Reservation.CheckInDate >= vm.CheckOutDate))

			//		.Sum(r => r.Capacity) >= (vm.AdultsNumber + vm.ChildrenNumber)
			//		&&
			//		h.Rooms
			//.Where(r => r.Reserved
			//	.All(res => res.Reservation.CheckOutDate <= vm.CheckInDate || res.Reservation.CheckInDate >= vm.CheckOutDate))
			//.Count() >= vm.NumberOfRooms
			//		);
			var filteredHotels =
				query2.Where(h =>
				GetCombinationsByHotelId(h.id, vm).Count() != 0);
			//{
			//	// Get available rooms that are NOT reserved within the given date range
			//	var availableRooms = h.Rooms
			//		.Where(r => r.Reserved.All(res =>
			//			res.Reservation.CheckOutDate <= vm.CheckInDate ||
			//			res.Reservation.CheckInDate >= vm.CheckOutDate))
			//		.ToList();

			//	// Get all valid room combinations
			//	//var validCombinations = GetValidRoomCombinations(availableRooms, roomsRequired, peopleCount);
			//	var validCombinations = RoomService.GetCombinations(availableRooms, roomsRequired, peopleCount);

			//	return validCombinations.Any(c=>c.Sum(r=>r.Capacity)== peopleCount);
			//});

			return filteredHotels.ToList().Skip(pagenum * PerPage).Take(PerPage);
		}

		public IEnumerable<List<Room>> GetCombinationsByHotelId(int id, SearchViewModel vm)
		{
			if (vm.AdultsNumber + vm.ChildrenNumber == 0)
			{
				vm.AdultsNumber++;
			}
			var peoplenum = vm.AdultsNumber + vm.ChildrenNumber;
			var roomsnum = vm.NumberOfRooms == default ? 1 : vm.NumberOfRooms;
			var query = _context.Rooms
				.Include(h => h.Hotel)
				.ThenInclude(h => h.Reviewed)
				.ThenInclude(r => r.User)
				.Include(r => r.Reserved)
				.ThenInclude(R => R.User)
				.Include(r => r.Reserved)
				.ThenInclude(r => r.Reservation)
				.Include(r => r.Reserved)
				.ThenInclude(r => r.Reservation).ThenInclude(r => r.mealPlan)
				.Include(r => r.Reserved)
				.ThenInclude(r => r.Reservation).ThenInclude(r => r.amenity)
				.Include(r => r.Reserved)
				.ThenInclude(r => r.Reservation).ThenInclude(r => r.UsedPromoCodes).ThenInclude(PC => PC.PromoCode)
				.Include(h => h.Images)
				.Include(h => h.Hotel).ThenInclude(h => h.Images)
				.Include(h => h.Hotel).ThenInclude(h => h.Favorites).ThenInclude(f => f.User)
				.Include(h => h.Hotel).ThenInclude(H => H.Ameneties)
				.Where(r => r.HotelId == id).Where(room =>
					// old =>11~14
					// if new => 13-15  first any gives an error because checkin >11  but not >14
					// if new => 8-12  first any gives an error because checkin <11  but not <14
					!(room.Reserved.Where(r => r.Reservation.reservationStatus != ReservationStatus.Canceled).Any(r => r.Reservation.CheckInDate >= vm.CheckInDate && r.Reservation.CheckInDate <= vm.CheckOutDate)
				 || room.Reserved.Where(r => r.Reservation.reservationStatus != ReservationStatus.Canceled).Any(r => r.Reservation.CheckInDate <= vm.CheckInDate && r.Reservation.CheckOutDate >= vm.CheckInDate)));
						

			var combinations = GetCombinations(query.ToList(), (int)roomsnum);
			var roomCombinations = combinations.Where(combination =>
			{
				var totalCapacity = combination.Sum(r => r.Capacity);

				return totalCapacity == peoplenum;
			}
			);
			return roomCombinations;

		}
		public static IEnumerable<List<Room>> GetCombinations(List<Room> rooms, int roomsnum, int start = 0, Counter counter = null)
		{
			counter ??= new Counter();
			if (counter.Value >= 300) yield break;
			if (roomsnum == 0)
			{
				yield return new List<Room>();
				counter.Value++;
				yield break;
			}

			for (int i = 0; i <= rooms.Count - roomsnum; i++)
			{
				foreach (var combo in GetCombinations(rooms, roomsnum - 1, i + 1, counter))
				{
					if (counter.Value >= 300) yield break;

					yield return new List<Room> { rooms[i] }.Concat(combo).ToList();
				}
			}
		}


		//private IEnumerable<List<Room>> GetValidRoomCombinations(List<Room> rooms, int roomsRequired, int peopleRequired)
		//{
		//	int count = 0;
		//	var allCombinations = Enumerable.Range(1, rooms.Count)
		//		.SelectMany(n => GetCombinations(rooms, n));

		//	return allCombinations.Where(combo =>
		//		combo.Sum(r => r.Capacity) == peopleRequired && // Exact capacity match
		//		combo.Count == roomsRequired // Exact room count match
		//	);
		//}
		//private IEnumerable<List<Room>> GetCombinations(List<Room> rooms, int roomsnum, int start = 0,Counter counter=null)
		//{
		//	counter ??= new Counter();
		//	if (counter.Value >= 5000)
		//	{
		//		yield break;
		//	}
		//	if (roomsnum == 0)
		//	{
		//		yield return new List<Room>();
		//		counter.Value++;
		//		yield break;
		//	}

		//	for (int i = start; i <= rooms.Count - roomsnum; i++)
		//	{
		//		foreach (var combo in GetCombinations(rooms, roomsnum - 1, i + 1, counter))
		//		{
		//			yield return new List<Room> { rooms[i] }.Concat(combo).ToList();
		//			counter.Value++;
		//		}
		//	}
		//}

		public Hotel GetById(int id)
		{
			return _context.Hotels.Where(h => !h.isDeleted).Include(h => h.city).ThenInclude(c => c.Country).Include(h => h.Favorites).ThenInclude(f => f.User).Include(h => h.Rooms).ThenInclude(r => r.Images).Include(h => h.Reviewed).ThenInclude(r => r.User)
				.Include(h => h.Images).Include(h => h.Ameneties).Include(h => h.Reported).ThenInclude(r => r.User).FirstOrDefault(h => h.id == id);
		}
		public void Favor(int hotelid, string userid)
		{
			var fav = new Favorite() { HotelId = hotelid, UserId = userid };
			if (_context.Favorites.SingleOrDefault(f => f.HotelId == hotelid && f.UserId == userid) is null)
			{
				_context.Favorites.Add(fav);
				_context.SaveChanges();
			}
		}
		public void RemoveFromFavorites(int hotelid, string userid)
		{
			var fav = _context.Favorites.FirstOrDefault(f => f.HotelId == hotelid && f.UserId == userid);
			if (fav is not null)
			{
				_context.Favorites.Remove(fav);
				_context.SaveChanges();
			}
		}
		public void Create(HotelViewModel vm)
		{
			var amen = _context.Amenities.FirstOrDefault(A => A.Amenities == vm.Ameneties);
			if (amen is null)
			{
				amen = new Amenity()
				{
					Amenities = vm.Ameneties,

				};
				_context.Amenities.Add(amen);
				_context.SaveChanges();
			}

			Hotel hotel = new()
			{
				Address = vm.Address,
				AmenetiesId = amen.Id,
				CityId = vm.CityId,
				Email = vm.Email,
				starRating = vm.starRating,
				Name = vm.Name,
				PhoneNumber = vm.PhoneNumber,
				Description = vm.Description,
				Latitude = vm.Latitude,
				Longitude = vm.Longitude

			};
			_context.Hotels.Add(hotel);
			_context.SaveChanges();
			hotel.Images = vm.Images.Select(i => new HotelImage() { Image = i.Save(env), HotelId = hotel.id }).ToList();
			_context.HotelsImages.AddRange(hotel.Images);
			_context.SaveChanges();

		}

		public void Update(HotelViewModel vm)
		{
			var amen = _context.Amenities.FirstOrDefault(A => A.Amenities == vm.Ameneties);
			if (amen is null)
			{
				amen = new Amenity()
				{
					Amenities = vm.Ameneties,

				};
				_context.Amenities.Add(amen);
				_context.SaveChanges();
			}

			Hotel hotel = GetById((int)vm.id);

			hotel.Address = vm.Address;
			hotel.AmenetiesId = amen.Id;
			hotel.CityId = vm.CityId;
			hotel.Email = vm.Email;
			hotel.starRating = vm.starRating;
			hotel.Name = vm.Name;
			hotel.PhoneNumber = vm.PhoneNumber;
			hotel.Description = vm.Description;
			hotel.Latitude = vm.Latitude;
			hotel.Longitude = vm.Longitude;
			if (vm.Images?.Count() != 0 && vm.Images is not null)
			{
				hotel.Images = vm.Images.Select(i => new HotelImage() { Image = i.Save(env), HotelId = hotel.id }).ToList();
				_context.HotelsImages.RemoveRange(_context.HotelsImages.Where(h => h.HotelId == hotel.id).ToList());
				_context.HotelsImages.AddRange(hotel.Images);
				_context.SaveChanges();
			}


			_context.Hotels.Update(hotel);
			_context.SaveChanges();

		}
		public void Delete(int id)
		{
			GetById(id).isDeleted = true;
			_context.SaveChanges();
			//throw new NotImplementedException();
		}


	}
	public class Counter
	{
		public int Value { get; set; } = 0;
	}
}
