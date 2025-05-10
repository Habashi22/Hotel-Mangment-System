using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
	{
		public void Configure(EntityTypeBuilder<Favorite> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);

			builder.HasData(new Favorite()
			{
		
				Id = 1,
				HotelId=1,
				UserId = "1",
				

			});
		}
	}

}
