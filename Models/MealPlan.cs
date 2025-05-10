using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBookingFinal_YARAB_.Models
{
	public class MealPlan
	{
		public int Id { set; get; }

		public mealPlan plan { set; get; }
		//[Range(100,5000)]
		//public Double Price { set; get; }
		[NotMapped]
		public double Price => 500 + (int)plan * 500;

		//public virtual List<Hotel> Hotels { set; get; } //constant for all hotels
		public virtual List<Reservation> Reservations { set; get; }
	}
	public enum mealPlan
	{
		Lunch,
		BreakfastAndDinner,
		AllInclusive,
	}
}
