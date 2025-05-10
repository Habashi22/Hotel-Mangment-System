using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MVCBookingFinal_YARAB_.Data.DbConfigurations
{
	public class StripePaymentMethodConfiguration : IEntityTypeConfiguration<StripePaymentMethod>
	{
		public void Configure(EntityTypeBuilder<StripePaymentMethod> builder)
		{
			//builder.Property(h => h.).HasDefaultValue(ReservationStatus.Pending);
			builder.HasData(new StripePaymentMethod()
			{
				Id = 2,
				PaymentType = PaymentType.Stripe,
				AccountNumber = "5151515",
			});
		}
	}

}
