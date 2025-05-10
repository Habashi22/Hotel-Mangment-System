
using ReservationRoom = MVCBookingFinal_YARAB_.Models.ReservationRoom;

namespace MVCBookingFinal_YARAB_.IRepositories
{
    public interface IReservationRoom
    {
        public List<ReservationRoom> GetAll();
        public ReservationRoom GetById(int id);
        public void Create(ReservationRoomVM vm);
        //public void Update(ReservationRoomVM vm);
        public void Delete(int id);


	}
}
