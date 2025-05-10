using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class DraftReservationConfiguration : IEntityTypeConfiguration<DraftReservation>
	{
		public void Configure(EntityTypeBuilder<DraftReservation> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			
			builder.HasData(new DraftReservation()
			{
				//AmenityId = 1,
				//amenity=Amenity.,
				Id = 1,
				//mealPlanId = 1,
				CheckInDate = DateTime.Now,
				CheckOutDate = DateTime.Now.AddDays(5),
				UserId="1",
				
			});
		}
	}

}
