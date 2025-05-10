using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class HotelImageConfiguration : IEntityTypeConfiguration<HotelImage>
	{
		public void Configure(EntityTypeBuilder<HotelImage> builder)
		{
			builder.Property(h => h.isDeleted).HasDefaultValue(false);
			builder.HasData(new HotelImage
			{
				HotelId = 1,
				Image = "393793e4-337e-4d43-8e2e-54093aa8bc34.png",
				Id = 1
			});
		}
	}

}
