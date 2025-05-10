using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class MealPlanConfiguration : IEntityTypeConfiguration<MealPlan>
	{

		public void Configure(EntityTypeBuilder<MealPlan> builder)
		{
			builder.HasData(new List<MealPlan>()
			{
				new MealPlan{plan = mealPlan.Lunch,
				Id = 1 },
				new MealPlan{plan = mealPlan.BreakfastAndDinner,
				Id = 2 },
				new MealPlan{plan = mealPlan.AllInclusive,
				Id = 3 },

			}
			);
		}
	}

}
