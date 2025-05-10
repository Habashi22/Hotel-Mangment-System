using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class UsedPromoCodesConfiguration : IEntityTypeConfiguration<UsedPromoCodes>
	{
		public void Configure(EntityTypeBuilder<UsedPromoCodes> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			
			builder.HasData(new UsedPromoCodes()
			{

				Id = 1,
				PromoCodeId=1,
				ReservationId=1,
				UserId="1"
			});
		}
	}

}
