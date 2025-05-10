using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.ViewModels
{
    public class PromoCodeViewModel
    {
        public int? Id { set; get; }

        public string Code { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { set; get; }

        [Range(10,40)]
        public int discount { set; get; }

        //[ForeignKey("AddingUser")]
        public string? AddingUserID { get; set; }
        //public AppUser AddingUser { set; get; }
    }
}
