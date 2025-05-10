
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Helpers;
using MVCBookingFinal_YARAB_.Models;

namespace MVCBookingFinal_YARAB_.Repositories
{
	public class RoomService(ApplicationDbContext _context, IWebHostEnvironment env) : IRoomService
	{
		public List<Room> GetAll()
		{
			return _context.Rooms.Include(h => h.Hotel).Include(r => r.Reserved).ThenInclude(R => R.User).Include(h => h.Images).ToList();
		}

		public List<Room> GetByHotelId(int id, RoomType type = 0, int capacity = -1, int minprice = -1, int maxprice = -1, RoomStatus stat = RoomStatus.Available)
		{
			return _context.Rooms.Where(u => u.roomType == type || type == RoomType.Single)
				.Where(r => r.Status == stat || stat == RoomStatus.Available)
				.Where(r => (r.PricePerNight >= minprice && r.PricePerNight <= maxprice)
				|| (r.PricePerNight >= minprice && maxprice == -1)
				|| (r.PricePerNight <= maxprice && minprice == -1)
				|| (maxprice == -1 && minprice == -1))
				.Where(r => r.Capacity == capacity || capacity == -1)
				.Include(h => h.Hotel)
				.Include(r => r.Reserved)
				.ThenInclude(R => R.User)
				.Include(h => h.Images)
				.Where(r => r.HotelId == id)
				.ToList();

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
				.ThenInclude(r=>r.User)
				.Include(r => r.Reserved)
				.ThenInclude(R => R.User)
				.Include(r=>r.Reserved)
				.ThenInclude(r=>r.Reservation).ThenInclude(r=>r.mealPlan)
				.Include(r => r.Reserved)
				.ThenInclude(r => r.Reservation).ThenInclude(r => r.amenity)
				.Include(r => r.Reserved)
				.ThenInclude(r => r.Reservation).ThenInclude(r => r.UsedPromoCodes).ThenInclude(PC=>PC.PromoCode)
				.Include(r => r.Reserved)
				.ThenInclude(r => r.Reservation).ThenInclude(r => r.mealPlan)
				.Include(h => h.Images)
				.Include(h => h.Hotel).ThenInclude(h => h.Images)
				.Include(h => h.Hotel).ThenInclude(h => h.Favorites).ThenInclude(f => f.User)
				.Include(h => h.Hotel).ThenInclude(H => H.Ameneties)
				.Where(r => r.HotelId == id).Where(room =>
				// old =>11~14
				// if new => 13-15  first any gives an error because checkin >11  but not >14
				// if new => 8-12  first any gives an error because checkin <11  but not <14
					!(room.Reserved.Where(r=>r.Reservation.reservationStatus!=ReservationStatus.Canceled).Any(r => r.Reservation.CheckInDate >= vm.CheckInDate && r.Reservation.CheckInDate <= vm.CheckOutDate)
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

			for (int i = start; i <= rooms.Count - roomsnum; i++)
			{
				foreach (var combo in GetCombinations(rooms, roomsnum - 1, i + 1, counter))
				{
					if (counter.Value >= 300) yield break;

					yield return new List<Room> { rooms[i] }.Concat(combo).ToList();
				}
			}
		}

		public Room GetById(int id)
		{
			return _context.Rooms.Include(h => h.Hotel).Include(r => r.Reserved).ThenInclude(R => R.User).Include(h => h.Images).FirstOrDefault(r => r.Id == id);
		}
		public void Create(RoomViewModel vm)
		{
			Room room = new()
			{

				//Capacity=vm.Capacity,
				Floor = vm.Floor,
				HotelId = vm.HotelId,
				PricePerNight = vm.PricePerNight,
				roomType = vm.roomType,
				//Status = RoomStatus.Available,


			};
			_context.Rooms.Add(room);
			_context.SaveChanges();
			room.Images = vm.Images.Select(i => new RoomImage() { Image = i.Save(env), roomId = room.Id }).ToList();
			_context.RoomsImages.AddRange(room.Images);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			//GetById(id).Status = RoomStatus.Maintenance;
			_context.SaveChanges();
		}


		public void Update(RoomViewModel vm)
		{
			Room room = GetById((int)vm.Id);

			//room.Capacity = vm.Capacity;
			room.Floor = vm.Floor;
			room.HotelId = vm.HotelId;
			room.PricePerNight = vm.PricePerNight;
			room.roomType = vm.roomType;
			//room.Status = vm.status ?? RoomStatus.Available;
			if (vm.Images?.Count() != 0 && vm.Images is not null)
			{
				room.Images = vm.Images.Select(i => new RoomImage() { Image = i.Save(env), roomId = room.Id }).ToList();
				var deletedimages = _context.RoomsImages.Where(h => h.roomId == room.Id).ToList();
				_context.RoomsImages.RemoveRange(deletedimages);
				_context.RoomsImages.AddRange(room.Images);

			}


			_context.Rooms.Update(room);
			_context.SaveChanges();
		}
	}
}
