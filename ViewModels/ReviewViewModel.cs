using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.ViewModels
{
    public class ReviewViewModel
    {
        public int? Id { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
        
        public int HotelId { get; set; }
        //public string HotelName { get; set; }
        public string Description { get; set; }
        //public DateTime ReviewDate { get; set; }
    }
}
