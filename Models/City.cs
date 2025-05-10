using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class City
	{
		[Key]
		public int Id { set; get; }
		[MinLength(3)]
		public string Name { set; get; }
		public string Image { set; get; }
		[ForeignKey("Country")]
		public int CountryId { set; get; }
		public virtual Country Country { set; get; }
		public virtual List<Hotel> Hotels { set; get; }
		[DefaultValue(false)]
		public bool isDeleted { set; get; } = false;	
	}
}
