using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class ReportConfiguration : IEntityTypeConfiguration<Report>
	{
		public void Configure(EntityTypeBuilder<Report> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			builder.Property(h => h.isDeleted).HasDefaultValue(false);
			builder.HasData(new Report()
			{

				Id = 1,
				HotelId = 1,
				UserId = "1",
				Complaint="bad food",
				ReviewDate=DateTime.Now,
				
			});
		}
	}

}
