using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
	{
		public void Configure(EntityTypeBuilder<PromoCode> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			builder.Property(h => h.IsActive).HasDefaultValue(true);
			builder.HasData(new PromoCode()
			{

				Id = 1,
				AddingUserID="1",
				Code="ANMMM",
				ExpiryDate=DateTime.Now.AddDays(5),
				Discount=20,
				

			});
		}
	}

}
