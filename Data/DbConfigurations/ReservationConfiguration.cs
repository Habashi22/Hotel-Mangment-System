using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
	{
		public void Configure(EntityTypeBuilder<Reservation> builder)
		{
			builder.Property(h => h.reservationStatus).HasDefaultValue(ReservationStatus.Pending);
			builder.HasData(new Reservation()
			{
				AmenityId = 1,
				Id = 1,
				mealPlanId = 1,
				CheckInDate = DateTime.Now,
				CheckOutDate = DateTime.Now.AddDays(5),
				
			});
		}
	}

}
