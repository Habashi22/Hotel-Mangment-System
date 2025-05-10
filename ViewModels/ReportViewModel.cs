using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.ViewModels
{
    public class ReportViewModel
    {
       
        public int? Id { set; get; }
        public int HotelId { set; get; }

        public string? UserId { set; get; }
        public string? Complaint { set; get; }
        //public DateTime ReviewDate { set; get; }

        
      

    }
}
