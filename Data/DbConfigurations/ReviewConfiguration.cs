using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class ReviewConfiguration : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			builder.Property(h => h.isDeleted).HasDefaultValue(false);
			builder.HasData(new Review()
			{

				Id = 1,
				HotelId = 1,
				UserId = "1",
				Description="thank you for the hotel",
				Rating=5,
				ReviewDate = DateTime.Now,

			});
		}
	}

}
