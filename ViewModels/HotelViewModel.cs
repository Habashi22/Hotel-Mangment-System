
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCBookingFinal_YARAB_.ViewModels
{
	public class HotelViewModel
	{
		public int? id { set; get; }
		[MinLength(3)]
		public string Name { set; get; }
		[MinLength(10)]
		public string? Description { set; get; }
		

		[ForeignKey("city")]
		public int CityId { set; get; }
		public virtual City? city { set; get; }
		[Range(1, 7)]
		public int starRating { set; get; }
		[Required]
		public string Address { set; get; }
		[EmailAddress]
		public string Email { set; get; }
		[Phone]
		public string PhoneNumber { set; get; }

		public string Longitude { set; get; }
		public string Latitude { set; get; }

		//public virtual List<PromoCode> PromoCodes { set; get; } //promocodes are associated to website
		//[ForeignKey("Ameneties")]
		//public int? AmenetiesId { set; get; } //one to one so should have an id
		//public virtual Amenity? Ameneties { set; get; }
		public virtual AmenityEnum Ameneties { set; get; }
		[ImageExtension]

		public List<IFormFile>? Images { set; get; }//lots of images


	}
}
