using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Hotel
	{
		[Key]
		public int id { set; get; }
		[MinLength(3)]
		public string Name { set; get; }
		[MinLength(10)]
		public string? Description { set; get; }
		public List<HotelImage> Images { set; get; }//lots of images

		[ForeignKey("city")]
		public int CityId { set; get; }
		public virtual City city { set; get; }
		[Range(1,7)]
		public int starRating { set; get; }
		[Required]
		public string Address { set; get; }
		[EmailAddress]
		public string Email { set; get; }
		[Phone]
		public string PhoneNumber { set; get; }
		public string Longitude { set; get; }
		public string Latitude { set; get; }
		
		public virtual List<Room> Rooms { set; get; }
		public virtual List<Review> Reviewed { set; get; }
		public virtual List<Report> Reported { set; get; }
		public virtual List<Favorite> Favorites { set; get; }
		//public virtual List<PromoCode> PromoCodes { set; get; } //promocodes are associated to website
		[ForeignKey("Ameneties")] 
		public int AmenetiesId { set; get; } //one to one so should have an id
		public virtual Amenity Ameneties { set; get; } 

		//public virtual List<MealPlan> MealPlans { set; get; } //meal plan is fixed for all hotels
		[DefaultValue(false)]
		public bool isDeleted { set; get; } = false;



	}
}
