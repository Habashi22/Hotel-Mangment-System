using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class RoomConfiguration : IEntityTypeConfiguration<Room>
	{
		public void Configure(EntityTypeBuilder<Room> builder)
		{
		builder.Property(h => h.Status).HasDefaultValue(RoomStatus.Available);
			builder.HasData(new List<Room>()
			{
				new Room{
				Id = 1 ,
				HotelId=1,
				//Capacity=5,
				Floor=2,
				PricePerNight=5000,
				roomType=RoomType.Single,
				//Status=RoomStatus.Available
				},
			});
		}
	}

}
