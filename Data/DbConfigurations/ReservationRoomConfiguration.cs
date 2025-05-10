using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class ReservationRoomConfiguration : IEntityTypeConfiguration<ReservationRoom>
	{
		public void Configure(EntityTypeBuilder<ReservationRoom> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			builder.Property(h => h.IsDeleted).HasDefaultValue(false);
			builder.HasData(new ReservationRoom()
			{
				id=1,
				ReservationId=1,
				RoomId=1,
				UserId="1",
			});
		}
	}

}
