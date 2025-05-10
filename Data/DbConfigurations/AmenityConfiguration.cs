using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
	{
		public void Configure(EntityTypeBuilder<Amenity> builder)
		{
			builder.HasData(new Amenity()
			{
				//builder.Property(h => h.).HasDefaultValue(false);
				Amenities = AmenityEnum.SwimmingPool | AmenityEnum.Laundry | AmenityEnum.ExtraRoomService,
				Id = 1,
			});
		}
	}

}
