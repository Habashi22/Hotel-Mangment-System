
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Helpers;
using MVCBookingFinal_YARAB_.Models;
using System.Xml;

namespace MVCBookingFinal_YARAB_.Repositories
{
	public class ReservationService(ApplicationDbContext context,UserManager<AppUser> usermanager) : IReservationService
	{
		/*
		 * 		public double AfterDiscount => TotalAmount
			* (100 - (usedfcodes ? UsedPromoCodes.Select(u => u.PromoCode).Where(p => p.IsActive).Sum(p => p.Discount) : 0)) / 100;

		 */
		public async Task<List<Reservation>> MyReservations(string userid)
		{
			var mylist= context.Reservations.Where(r => r.Reserved.Any(res => res.UserId == userid))
				.Include(r => r.Reserved).ThenInclude(R => R.Room).ThenInclude(R => R.Hotel)
				.Include(r => r.mealPlan)
				.Include(r => r.amenity)
				.Include(r => r.Reserved).ThenInclude(R => R.Room)
				.Include(r => r.UsedPromoCodes).ThenInclude(U => U.PromoCode)
				.Include(r => r.Reserved).ThenInclude(r => r.User)
				.ToList();
			return mylist;
		}
		public async Task savedraft(DraftReservation reservation,string userid, List<Room> rooms)
		{

	
			DraftReservation newone = new();
			var userdraft = context.DraftReservations.Include(r => r.Reserved).FirstOrDefault(d => d.UserId == userid);
			if (userdraft is null)
			{
				newone.UserId = userid;
				newone.amenity = reservation.amenity ?? 0;
				newone.mealPlan = reservation.mealPlan ?? 0;
				newone.CheckInDate = reservation.CheckInDate ?? null;
				newone.CheckOutDate = reservation.CheckOutDate ?? null;
				newone.UsedPromoCodeId = reservation.UsedPromoCodeId ?? null;
				context.Add(newone);
				context.SaveChanges();
			}
			else
			{
				userdraft.amenity = reservation.amenity ?? 0;
				userdraft.mealPlan = reservation.mealPlan ?? 0;
				userdraft.CheckInDate = reservation.CheckInDate ?? null;
				userdraft.CheckOutDate = reservation.CheckOutDate ?? null;
				userdraft.UsedPromoCodeId = reservation.UsedPromoCodeId ?? null;
				newone = userdraft;
				context.Update(userdraft);
				context.SaveChanges();
			}

			context.DraftReservationRoom.RemoveRange(context.DraftReservationRoom.Where(r => r.DraftReservationId == newone.Id));
			newone.Reserved = new();
			foreach (var room in rooms)
			{
				var draftReservationRoom = new DraftReservationRoom
				{
					DraftReservationId = newone.Id,
					ReservedId = room.Id
				};
				newone.Reserved.Add(draftReservationRoom);
			}
			//context.Update(newone);
			context.SaveChanges();
		}
			
		
		public Reservation SaveReservation(ReservationViewModel vm,IEnumerable<Room> rooms,string userid)
		{
			Reservation reservation = new()
			{
				AmenityId = rooms.FirstOrDefault().Hotel.Ameneties.Id,
				CheckInDate = (DateTime)vm.CheckInDate,
				CheckOutDate = (DateTime)vm.CheckOutDate,
				mealPlanId = ((int)vm.Plan) + 1,
				reservationStatus = ReservationStatus.Pending,
				
			};
			context.Reservations.Add(reservation);
			context.SaveChanges();
			List<ReservationRoom> myrooms = new();
			foreach (var room in rooms) {
				myrooms.Add( new()
				{
					ReservationId = reservation.Id,
					RoomId = room.Id,
					UserId = userid
				});
			}
			context.ReservationRooms.AddRange(myrooms);
			if (!string.IsNullOrEmpty(vm.PromoCode))
			{

				UsedPromoCodes prmo = new()
				{
					PromoCodeId = context.PromoCodes.FirstOrDefault(c => c.Code == vm.PromoCode).Id,
					UserId = userid,
					ReservationId = reservation.Id
				};

				context.UsedPromoCodes.Add(prmo);
			}
				context.SaveChanges();
			context.Entry(reservation).Reference(e => e.mealPlan).Load();
			context.Entry(reservation).Reference(e => e.amenity).Load();
			foreach (var entry in reservation.Reserved)
			{ 
				context.Entry(entry).Reference(e => e.Room).Load();
				context.Entry(entry.Room).Reference(e => e.Hotel).Load();

				context.Entry(entry.Room).Collection(e => e.Images).Load();
				

			}

			return reservation;
		}
		public Reservation getById(int id)
		{
			return context.Reservations
				.Include(r=>r.UsedPromoCodes).ThenInclude(pc=>pc.PromoCode)
				.Include(r=>r.amenity)
				.Include(r=>r.mealPlan)
				.Include(r=>r.Reserved).ThenInclude(r=>r.Room).ThenInclude(r=>r.Hotel)
				.Include(r=>r.Reserved).ThenInclude(r=>r.Room).ThenInclude(r=>r.Images)
				//.Include(r => r.Reserved).ThenInclude(r => r.Reservation)
				.FirstOrDefault(r => r.Id == id);
		}

		public PromoCode GETCODE(string text)
		{
			return context.PromoCodes.FirstOrDefault(r => r.Code == text);
		}
		public string GETCODEText(int id)
		{
			var code = context.PromoCodes.FirstOrDefault(r => r.Id == id);
			return code==null? "": code.Code;
		}

		public void Delete(string userid)
		{
			var draft = context.DraftReservations.FirstOrDefault(d => d.UserId == userid);
			if (draft is not null)
			{
				context.DraftReservationRoom.RemoveRange(context.DraftReservationRoom.Where(r => r.DraftReservationId == draft.Id));
				//if(draft is not null)
				context.Remove(draft);
			}
			context.SaveChanges();
		}
		public DraftReservation getUserReservation(string userid)
		{
			var hhh=context.DraftReservations.Include(r => r.Reserved).ThenInclude(R => R.Reserved).ThenInclude(R => R.Hotel).ThenInclude(H => H.Ameneties).Include(r=>r.UsedPromoCode)
				.Include(r=>r.Reserved).ThenInclude(R=>R.Reserved).ThenInclude(r=>r.Reserved).ThenInclude(r=>r.Reservation).ThenInclude(R=>R.mealPlan)
				.Include(r=>r.Reserved).ThenInclude(R=>R.Reserved).ThenInclude(r=>r.Reserved).ThenInclude(r=>r.Reservation).ThenInclude(R => R.amenity)
				//.Include(r=>r.Reserved).ThenInclude(R=>R.Reserved).ThenInclude(r=>r.Reserved).ThenInclude(r=>r.Reservation).ThenInclude(R => R.)
				//.Include(r=>r.Reserved).ThenInclude(R=>R.Reserved).ThenInclude(r=>r.Reserved).ThenInclude(r=>r.Reservation)
				.FirstOrDefault(d => d.UserId == userid);
			return hhh;
		
		}
		public void CancelReservation(int id)
		{
			var reservation = getById(id);
			reservation.reservationStatus = ReservationStatus.Canceled;
			reservation.CancellationDate = DateTime.Now;
			context.Update(reservation);
			context.SaveChanges();
		}


	}
}
