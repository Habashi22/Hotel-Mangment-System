using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.ViewModels
{
    public class ReservationRoomVM
    {
        public int Id { get; set; }

        [Display(Name = "Reservation Id")]
        public int ReservationId { get; set; }



        [Display(Name = "Room Number")]
        public int RoomId { get; set; }



        [Display(Name = "User Id")]
        public string UserId { get; set; }



        //[Display(Name = "User Name")]
        //public string UserName { get; set; }

    }
}
