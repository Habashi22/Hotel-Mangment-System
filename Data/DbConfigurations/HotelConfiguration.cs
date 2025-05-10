using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
	{

		public void Configure(EntityTypeBuilder<Hotel> builder)
		{
			builder.Property(h => h.isDeleted).HasDefaultValue(false);
			builder.HasData(new Hotel()
			{
				Address = "125 GIZA",
				CityId = 1,
				id = 1,
				AmenetiesId = 1,
				Description = "big hotel",
				Email = "placahotel@gmail.com",
				starRating = 4,
				PhoneNumber = "01143874387",
				Longitude = "0",
				Latitude="0",
				Name = "PlazaHotel"
			});


		}
	}

}
