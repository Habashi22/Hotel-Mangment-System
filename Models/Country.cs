using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCBookingFinal_YARAB_.Models
{
	public class Country
	{	
		[Key]
		public int Id { set; get; }
		[Required]
		[MinLength(3)]
		public string Name { set; get; }
		public string Image { set; get; }
		[DefaultValue(false)]
		public bool isDeleted { set; get; } = false;
		public virtual List<City> Cities { set; get; }

	}
}
