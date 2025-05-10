using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.ViewModels
{
    public class CityViewModel
    {
        public int? Id { set; get; }
        public string Name { set; get; }


        [NotMapped]
        [ImageExtension]
        public IFormFile? Image { set; get; }

        public int CountryId { get; set; }
    }
}
