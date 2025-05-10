
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Models;

namespace MVCBookingFinal_YARAB_.Repositories
{
    public class ReservationRoomService(ApplicationDbContext context, IWebHostEnvironment _env) : IReservationRoom
    {



        List<ReservationRoom> IReservationRoom.GetAll()
        {
            return context.ReservationRooms.Include(r => r.User).Include(r => r.Room).Include(r => r.Reservation).Where(r => !r.IsDeleted).ToList();
        }

        ReservationRoom IReservationRoom.GetById(int id)
        {
            return context.ReservationRooms.Include(r => r.User).Include(r => r.Room).Include(r => r.Reservation).SingleOrDefault(r => r.id == id);

        }

        public void Create(ReservationRoomVM vm)
        {
            ReservationRoom ResRoom = new ReservationRoom()
            {
                id = vm.Id,
                ReservationId = vm.ReservationId,
                UserId = vm.UserId,
                RoomId = vm.RoomId,
                
            };

            context.ReservationRooms.Add(ResRoom);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ResRoom = context.ReservationRooms.SingleOrDefault(r => r.id == id);
            ResRoom.IsDeleted = true;
            context.ReservationRooms.Update(ResRoom);
            context.SaveChanges();
        }

    }
}
